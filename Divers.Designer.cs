namespace DiversForm
{
    partial class frmDivers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDivers));
            this.btnReport = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.rtxtOutput = new System.Windows.Forms.RichTextBox();
            this.BtnExit = new System.Windows.Forms.Button();
            this.picWater = new System.Windows.Forms.PictureBox();
            this.picDiver = new System.Windows.Forms.PictureBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picWater)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDiver)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(52, 67);
            this.btnReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(114, 34);
            this.btnReport.TabIndex = 0;
            this.btnReport.Text = "Make Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(63, 3);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(342, 24);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Competitive Diving Report Maker";
            // 
            // btnView
            // 
            this.btnView.Enabled = false;
            this.btnView.Location = new System.Drawing.Point(174, 67);
            this.btnView.Margin = new System.Windows.Forms.Padding(4);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(116, 34);
            this.btnView.TabIndex = 3;
            this.btnView.Text = "View Report";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // rtxtOutput
            // 
            this.rtxtOutput.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtOutput.Location = new System.Drawing.Point(13, 44);
            this.rtxtOutput.Name = "rtxtOutput";
            this.rtxtOutput.ReadOnly = true;
            this.rtxtOutput.Size = new System.Drawing.Size(428, 359);
            this.rtxtOutput.TabIndex = 4;
            this.rtxtOutput.Text = "";
            this.rtxtOutput.Visible = false;
            // 
            // BtnExit
            // 
            this.BtnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnExit.Location = new System.Drawing.Point(298, 67);
            this.BtnExit.Margin = new System.Windows.Forms.Padding(4);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(118, 34);
            this.BtnExit.TabIndex = 6;
            this.BtnExit.Text = "Exit";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // picWater
            // 
            this.picWater.Image = ((System.Drawing.Image)(resources.GetObject("picWater.Image")));
            this.picWater.Location = new System.Drawing.Point(-1, 30);
            this.picWater.Name = "picWater";
            this.picWater.Size = new System.Drawing.Size(487, 435);
            this.picWater.TabIndex = 7;
            this.picWater.TabStop = false;
            // 
            // picDiver
            // 
            this.picDiver.Image = ((System.Drawing.Image)(resources.GetObject("picDiver.Image")));
            this.picDiver.Location = new System.Drawing.Point(421, 3);
            this.picDiver.Name = "picDiver";
            this.picDiver.Size = new System.Drawing.Size(41, 24);
            this.picDiver.TabIndex = 8;
            this.picDiver.TabStop = false;
            // 
            // txtInput
            // 
            this.txtInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInput.Location = new System.Drawing.Point(52, 30);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(176, 26);
            this.txtInput.TabIndex = 9;
            this.txtInput.Text = "Input File Name Here";
            // 
            // txtOutput
            // 
            this.txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutput.Location = new System.Drawing.Point(240, 30);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(176, 26);
            this.txtOutput.TabIndex = 10;
            this.txtOutput.Text = "Output File Name Here";
            // 
            // frmDivers
            // 
            this.AcceptButton = this.btnReport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.CancelButton = this.BtnExit;
            this.ClientSize = new System.Drawing.Size(456, 115);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.picDiver);
            this.Controls.Add(this.rtxtOutput);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.picWater);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDivers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dive Report";
            ((System.ComponentModel.ISupportInitialize)(this.picWater)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDiver)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.RichTextBox rtxtOutput;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.PictureBox picWater;
        private System.Windows.Forms.PictureBox picDiver;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtOutput;

    }
}

