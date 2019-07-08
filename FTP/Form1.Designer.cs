namespace FTP
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
            this.m_ProgressBarControl = new System.Windows.Forms.ProgressBar();
            this.m_DownloadButton = new System.Windows.Forms.Button();
            this.m_EstimationLabel = new System.Windows.Forms.Label();
            this.m_BytesLabel = new System.Windows.Forms.Label();
            this.m_FtpUri = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ProgressBarControl
            // 
            this.m_ProgressBarControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ProgressBarControl.Location = new System.Drawing.Point(12, 55);
            this.m_ProgressBarControl.Name = "ProgressBarControl";
            this.m_ProgressBarControl.Size = new System.Drawing.Size(737, 24);
            this.m_ProgressBarControl.TabIndex = 0;
            // 
            // button1
            // 
            this.m_DownloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_DownloadButton.Location = new System.Drawing.Point(639, 85);
            this.m_DownloadButton.Name = "button1";
            this.m_DownloadButton.Size = new System.Drawing.Size(110, 23);
            this.m_DownloadButton.TabIndex = 1;
            this.m_DownloadButton.Text = "Download";
            this.m_DownloadButton.UseVisualStyleBackColor = true;
            this.m_DownloadButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // m_EstimationLabel
            // 
            this.m_EstimationLabel.AutoSize = true;
            this.m_EstimationLabel.Location = new System.Drawing.Point(12, 90);
            this.m_EstimationLabel.Name = "m_EstimationLabel";
            this.m_EstimationLabel.Size = new System.Drawing.Size(35, 13);
            this.m_EstimationLabel.TabIndex = 2;
            this.m_EstimationLabel.Text = "label1";
            // 
            // m_BytesLabel
            // 
            this.m_BytesLabel.AutoSize = true;
            this.m_BytesLabel.Location = new System.Drawing.Point(125, 90);
            this.m_BytesLabel.Name = "m_BytesLabel";
            this.m_BytesLabel.Size = new System.Drawing.Size(35, 13);
            this.m_BytesLabel.TabIndex = 3;
            this.m_BytesLabel.Text = "label1";
            // 
            // m_FtpUri
            // 
            this.m_FtpUri.Location = new System.Drawing.Point(15, 13);
            this.m_FtpUri.Name = "m_FtpUri";
            this.m_FtpUri.Size = new System.Drawing.Size(734, 20);
            this.m_FtpUri.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 120);
            this.Controls.Add(this.m_FtpUri);
            this.Controls.Add(this.m_BytesLabel);
            this.Controls.Add(this.m_EstimationLabel);
            this.Controls.Add(this.m_DownloadButton);
            this.Controls.Add(this.m_ProgressBarControl);
            this.Name = "Form1";
            this.Text = "FTP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ProgressBar m_ProgressBarControl;
        private System.Windows.Forms.Button m_DownloadButton;
        private System.Windows.Forms.Label m_EstimationLabel;
        private System.Windows.Forms.Label m_BytesLabel;
        private System.Windows.Forms.TextBox m_FtpUri;
    }
}

