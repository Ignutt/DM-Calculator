
namespace Calculator
{
    partial class Solve_SKNF
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
            this.KTF = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // tableOut
            // 
            this.tableOut.AutoScroll = true;
            this.tableOut.BackColor = System.Drawing.Color.White;
            this.tableOut.Location = new System.Drawing.Point(12, 12);
            this.tableOut.Name = "tableOut";
            this.tableOut.Size = new System.Drawing.Size(472, 571);
            this.tableOut.TabIndex = 38;
            // 
            // KTF
            // 
            this.KTF.AutoScroll = true;
            this.KTF.Location = new System.Drawing.Point(508, 12);
            this.KTF.Name = "KTF";
            this.KTF.Size = new System.Drawing.Size(625, 571);
            this.KTF.TabIndex = 39;
            // 
            // Solve_SKNF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1145, 595);
            this.Controls.Add(this.KTF);
            this.Controls.Add(this.tableOut);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Solve_SKNF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Решение СКНФ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel tableOut;
        private System.Windows.Forms.FlowLayoutPanel KTF;
    }
}