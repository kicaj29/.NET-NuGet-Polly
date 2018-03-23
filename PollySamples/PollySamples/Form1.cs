using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Polly;

namespace PollySamples
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DivideByZero()
        {
            var x = 0;
            var y = 1 / x;
        }

        private void btnRetryPolicy_Click(object sender, EventArgs e)
        {
            var retryOnce = Policy
                .Handle<DivideByZeroException>()
                .Retry();

            retryOnce.Execute(() =>
            {
                this.DivideByZero();
            });
        }

        private void btnRetryPolicyMultiple_Click(object sender, EventArgs e)
        {
            var retryMultipleTimes = Policy
                .Handle<DivideByZeroException>()
                .Retry(3);

            retryMultipleTimes.Execute(() =>
            {
                this.DivideByZero();
            });
        }

        private void btnFallback_Click(object sender, EventArgs e)
        {
            var retryOnce = Policy
                .Handle<DivideByZeroException>()
                .Fallback((result, context) =>
                {
                    

                }, (result, context) =>
                {
                    //in this way we can throw our exception with the inner exception
                    throw new MyException("aaaa", result);
                });

            try
            {


                retryOnce.Execute(() =>
                {
                    this.DivideByZero();
                });
            }
            catch (MyException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                MessageBox.Show("finally");
            }
        }

        private void btnFallbackPlusWaitAndRetry_Click(object sender, EventArgs e)
        {
            var fallbackPolicy = Policy
                .Handle<MyException>(ex => ex.Message == "temporary-problem")
                .Fallback((result, context) => { }, (result, context) =>
                {
                    throw new DbNotAvailableException(result);
                });

            var genericDBRetrayPolicy = Policy
                .Handle<Exception>()
                .WaitAndRetry(
                    retryCount: 2,
                    sleepDurationProvider: (retryAttempt) => TimeSpan.FromSeconds(5),
                    onRetry: (exception, delay, retrycount, context) =>
                    {
                        Debug.WriteLine("genericDBRetrayPolicy: onRetry");
                    }
                );

            //var policy = Policy.Wrap(genericDBRetrayPolicy, fallbackPolicy);
            var policy = Policy.Wrap(fallbackPolicy, genericDBRetrayPolicy);


            /*fallbackPolicy.Execute(() =>
            {
                throw new MyException("temporary-problem");
            });*/

            /*genericDBRetrayPolicy.Execute(() =>
            {
                throw new MyException("temporary-problem");
            });*/

            policy.Execute(() =>
            {
                throw new MyException("temporary-problem");
            });
        }

        private void btnCircuitBreakerWaitAndRetry_Click(object sender, EventArgs e)
        {
            var policy = Policy
                .Handle<MyException>()
                .WaitAndRetry(
                    retryCount:3,
                    sleepDurationProvider: retryAttempt => TimeSpan.FromMilliseconds(5000),
                    onRetry: (exception, delay, retryCount, context) =>
                    {
                        Debug.WriteLine("onRetry");      
                    });

            var circuitBreaker = Policy
                .Handle<Exception>()
                .CircuitBreaker(
                    exceptionsAllowedBeforeBreaking: 1,
                    durationOfBreak: TimeSpan.FromMinutes(5),
                        onBreak: (exception, delay, context) =>
                        {
                            Debug.WriteLine("onBreak");
                        },
                        onReset: context =>
                        {
                            Debug.WriteLine("onReset");
                        }
                    );

            //var p = Policy.Wrap(policy, circuitBreaker);
            var p = Policy.Wrap(circuitBreaker, policy);

            try
            {
                p.Execute(() =>
                {
                    throw new MyException("problem");
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                // if we try execute something if the CircuitBreaker is open then:
                // Polly.CircuitBreaker.BrokenCircuitException: 'The circuit is now open and is not allowing calls.'
                try
                {
                    p.Execute(() =>
                    {

                    });
                }
                catch (Exception ex1)
                {
                    Debug.WriteLine(ex1.Message);
                }

            }

        }
    }
}
