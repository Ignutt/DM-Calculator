
namespace Calculator
{
    partial class Solve_SDNF_SKNF
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
            this.DTF = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // tableOut
            // 
            this.tableOut.AutoScroll = true;
            this.tableOut.BackColor = System.Drawing.Color.White;
            this.tableOut.Location = new System.Drawing.Point(12, 12);
            this.tableOut.Name = "tableOut";
            this.tableOut.Size = new System.Drawing.Size(472, 571);
            this.tableOut.TabIndex = 37;
            // 
            // DTF
            // 
            this.DTF.AutoScroll = true;
            this.DTF.Location = new System.Drawing.Point(508, 12);
            this.DTF.Name = "DTF";
            this.DTF.Size = new System.Drawing.Size(625, 571);
            this.DTF.TabIndex = 38;
            // 
            // Solve_SDNF_SKNF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1145, 595);
            this.Controls.Add(this.DTF);
            this.Controls.Add(this.tableOut);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Solve_SDNF_SKNF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Решение СДНФ и СКНФ";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel tableOut;
        private System.Windows.Forms.FlowLayoutPanel DTF;
    }
}