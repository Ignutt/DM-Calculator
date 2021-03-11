
namespace Calculator
{
    partial class DefaultSolve
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
            this.tableOut = new System.Windows.Forms.FlowLayoutPanel();
            this.tableOutFunc = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // tableOut
            // 
            this.tableOut.AutoScroll = true;
            this.tableOut.BackColor = System.Drawing.SystemColors.Control;
            this.tableOut.Location = new System.Drawing.Point(12, 12);
            this.tableOut.Name = "tableOut";
            this.tableOut.Size = new System.Drawing.Size(460, 571);
            this.tableOut.TabIndex = 36;
            // 
            // tableOutFunc
            // 
            this.tableOutFunc.AutoScroll = true;
            this.tableOutFunc.BackColor = System.Drawing.SystemColors.Control;
            this.tableOutFunc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tableOutFunc.Location = new System.Drawing.Point(478, 12);
            this.tableOutFunc.Name = "tableOutFunc";
            this.tableOutFunc.Size = new System.Drawing.Size(460, 571);
            this.tableOutFunc.TabIndex = 37;
            // 
            // DefaultSolve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 595);
            this.Controls.Add(this.tableOutFunc);
            this.Controls.Add(this.tableOut);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DefaultSolve";
            this.Text = "Стандартное решение";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel tableOut;
        private System.Windows.Forms.FlowLayoutPanel tableOutFunc;
    }
}