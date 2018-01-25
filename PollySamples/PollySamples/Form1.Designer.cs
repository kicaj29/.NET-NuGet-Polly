namespace PollySamples
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRetryPolicy_once = new System.Windows.Forms.Button();
            this.btnRetryPolicyMultiple = new System.Windows.Forms.Button();
            this.btnFallback = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRetryPolicy_once
            // 
            this.btnRetryPolicy_once.Location = new System.Drawing.Point(27, 24);
            this.btnRetryPolicy_once.Name = "btnRetryPolicy_once";
            this.btnRetryPolicy_once.Size = new System.Drawing.Size(107, 23);
            this.btnRetryPolicy_once.TabIndex = 0;
            this.btnRetryPolicy_once.Text = "RetryPolicy-Once";
            this.btnRetryPolicy_once.UseVisualStyleBackColor = true;
            this.btnRetryPolicy_once.Click += new System.EventHandler(this.btnRetryPolicy_Click);
            // 
            // btnRetryPolicyMultiple
            // 
            this.btnRetryPolicyMultiple.Location = new System.Drawing.Point(168, 24);
            this.btnRetryPolicyMultiple.Name = "btnRetryPolicyMultiple";
            this.btnRetryPolicyMultiple.Size = new System.Drawing.Size(116, 23);
            this.btnRetryPolicyMultiple.TabIndex = 1;
            this.btnRetryPolicyMultiple.Text = "RetryPolicy-Multiple";
            this.btnRetryPolicyMultiple.UseVisualStyleBackColor = true;
            this.btnRetryPolicyMultiple.Click += new System.EventHandler(this.btnRetryPolicyMultiple_Click);
            // 
            // btnFallback
            // 
            this.btnFallback.Location = new System.Drawing.Point(318, 24);
            this.btnFallback.Name = "btnFallback";
            this.btnFallback.Size = new System.Drawing.Size(116, 23);
            this.btnFallback.TabIndex = 2;
            this.btnFallback.Text = "Fallback";
            this.btnFallback.UseVisualStyleBackColor = true;
            this.btnFallback.Click += new System.EventHandler(this.btnFallback_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 262);
            this.Controls.Add(this.btnFallback);
            this.Controls.Add(this.btnRetryPolicyMultiple);
            this.Controls.Add(this.btnRetryPolicy_once);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRetryPolicy_once;
        private System.Windows.Forms.Button btnRetryPolicyMultiple;
        private System.Windows.Forms.Button btnFallback;
    }
}

