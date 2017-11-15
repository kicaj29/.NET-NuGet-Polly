using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    }
}
