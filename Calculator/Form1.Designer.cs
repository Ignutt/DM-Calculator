
namespace Calculator
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.inputField = new System.Windows.Forms.TextBox();
            this.buttonOr = new System.Windows.Forms.Button();
            this.buttonNot = new System.Windows.Forms.Button();
            this.buttonAnd = new System.Windows.Forms.Button();
            this.table1 = new System.Windows.Forms.TextBox();
            this.buttonXor = new System.Windows.Forms.Button();
            this.buttonSchaffer = new System.Windows.Forms.Button();
            this.buttonEq = new System.Windows.Forms.Button();
            this.buttonPierce = new System.Windows.Forms.Button();
            this.buttonImplic = new System.Windows.Forms.Button();
            this.buttonZ = new System.Windows.Forms.Button();
            this.buttonX = new System.Windows.Forms.Button();
            this.buttonY = new System.Windows.Forms.Button();
            this.buttonC = new System.Windows.Forms.Button();
            this.buttonB = new System.Windows.Forms.Button();
            this.buttonOne = new System.Windows.Forms.Button();
            this.buttonA = new System.Windows.Forms.Button();
            this.buttonZero = new System.Windows.Forms.Button();
            this.buttonX6 = new System.Windows.Forms.Button();
            this.buttonX4 = new System.Windows.Forms.Button();
            this.buttonX5 = new System.Windows.Forms.Button();
            this.buttonX3 = new System.Windows.Forms.Button();
            this.buttonX2 = new System.Windows.Forms.Button();
            this.buttonCloseScope = new System.Windows.Forms.Button();
            this.buttonX1 = new System.Windows.Forms.Button();
            this.buttonOpenScope = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.debug = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inputField
            // 
            this.inputField.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputField.Location = new System.Drawing.Point(87, 83);
            this.inputField.Name = "inputField";
            this.inputField.Size = new System.Drawing.Size(350, 31);
            this.inputField.TabIndex = 0;
            // 
            // buttonOr
            // 
            this.buttonOr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOr.Location = new System.Drawing.Point(50, 141);
            this.buttonOr.Name = "buttonOr";
            this.buttonOr.Size = new System.Drawing.Size(40, 40);
            this.buttonOr.TabIndex = 1;
            this.buttonOr.Text = "∨";
            this.buttonOr.UseVisualStyleBackColor = true;
            this.buttonOr.Click += new System.EventHandler(this.buttonOr_Click);
            // 
            // buttonNot
            // 
            this.buttonNot.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonNot.Location = new System.Drawing.Point(162, 141);
            this.buttonNot.Name = "buttonNot";
            this.buttonNot.Size = new System.Drawing.Size(40, 40);
            this.buttonNot.TabIndex = 2;
            this.buttonNot.Text = "¬";
            this.buttonNot.UseVisualStyleBackColor = true;
            this.buttonNot.Click += new System.EventHandler(this.buttonNot_Click);
            // 
            // buttonAnd
            // 
            this.buttonAnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAnd.Location = new System.Drawing.Point(106, 141);
            this.buttonAnd.Name = "buttonAnd";
            this.buttonAnd.Size = new System.Drawing.Size(40, 40);
            this.buttonAnd.TabIndex = 3;
            this.buttonAnd.Text = "∧";
            this.buttonAnd.UseVisualStyleBackColor = true;
            this.buttonAnd.Click += new System.EventHandler(this.buttonAnd_Click);
            // 
            // table1
            // 
            this.table1.AllowDrop = true;
            this.table1.Location = new System.Drawing.Point(106, 414);
            this.table1.Multiline = true;
            this.table1.Name = "table1";
            this.table1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.table1.Size = new System.Drawing.Size(322, 174);
            this.table1.TabIndex = 10;
            // 
            // buttonXor
            // 
            this.buttonXor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonXor.Location = new System.Drawing.Point(218, 141);
            this.buttonXor.Name = "buttonXor";
            this.buttonXor.Size = new System.Drawing.Size(40, 40);
            this.buttonXor.TabIndex = 12;
            this.buttonXor.Text = "⊕";
            this.buttonXor.UseVisualStyleBackColor = true;
            this.buttonXor.Click += new System.EventHandler(this.buttonXor_Click);
            // 
            // buttonSchaffer
            // 
            this.buttonSchaffer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSchaffer.Location = new System.Drawing.Point(444, 141);
            this.buttonSchaffer.Name = "buttonSchaffer";
            this.buttonSchaffer.Size = new System.Drawing.Size(40, 40);
            this.buttonSchaffer.TabIndex = 16;
            this.buttonSchaffer.Text = "↑";
            this.buttonSchaffer.UseVisualStyleBackColor = true;
            this.buttonSchaffer.Click += new System.EventHandler(this.buttonSchaffer_Click);
            // 
            // buttonEq
            // 
            this.buttonEq.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEq.Location = new System.Drawing.Point(332, 141);
            this.buttonEq.Name = "buttonEq";
            this.buttonEq.Size = new System.Drawing.Size(40, 40);
            this.buttonEq.TabIndex = 15;
            this.buttonEq.Text = "≡";
            this.buttonEq.UseVisualStyleBackColor = true;
            this.buttonEq.Click += new System.EventHandler(this.buttonEq_Click);
            // 
            // buttonPierce
            // 
            this.buttonPierce.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPierce.Location = new System.Drawing.Point(388, 141);
            this.buttonPierce.Name = "buttonPierce";
            this.buttonPierce.Size = new System.Drawing.Size(40, 40);
            this.buttonPierce.TabIndex = 14;
            this.buttonPierce.Text = "↓";
            this.buttonPierce.UseVisualStyleBackColor = true;
            this.buttonPierce.Click += new System.EventHandler(this.buttonPierce_Click);
            // 
            // buttonImplic
            // 
            this.buttonImplic.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonImplic.Location = new System.Drawing.Point(276, 141);
            this.buttonImplic.Name = "buttonImplic";
            this.buttonImplic.Size = new System.Drawing.Size(40, 40);
            this.buttonImplic.TabIndex = 13;
            this.buttonImplic.Text = "→";
            this.buttonImplic.UseVisualStyleBackColor = true;
            this.buttonImplic.Click += new System.EventHandler(this.buttonImplic_Click);
            // 
            // buttonZ
            // 
            this.buttonZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonZ.Location = new System.Drawing.Point(444, 206);
            this.buttonZ.Name = "buttonZ";
            this.buttonZ.Size = new System.Drawing.Size(40, 40);
            this.buttonZ.TabIndex = 24;
            this.buttonZ.Text = "z";
            this.buttonZ.UseVisualStyleBackColor = true;
            this.buttonZ.Click += new System.EventHandler(this.buttonZ_Click);
            // 
            // buttonX
            // 
            this.buttonX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonX.Location = new System.Drawing.Point(332, 206);
            this.buttonX.Name = "buttonX";
            this.buttonX.Size = new System.Drawing.Size(40, 40);
            this.buttonX.TabIndex = 23;
            this.buttonX.Text = "x";
            this.buttonX.UseVisualStyleBackColor = true;
            this.buttonX.Click += new System.EventHandler(this.buttonX_Click);
            // 
            // buttonY
            // 
            this.buttonY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonY.Location = new System.Drawing.Point(388, 206);
            this.buttonY.Name = "buttonY";
            this.buttonY.Size = new System.Drawing.Size(40, 40);
            this.buttonY.TabIndex = 22;
            this.buttonY.Text = "y";
            this.buttonY.UseVisualStyleBackColor = true;
            this.buttonY.Click += new System.EventHandler(this.buttonY_Click);
            // 
            // buttonC
            // 
            this.buttonC.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonC.Location = new System.Drawing.Point(276, 206);
            this.buttonC.Name = "buttonC";
            this.buttonC.Size = new System.Drawing.Size(40, 40);
            this.buttonC.TabIndex = 21;
            this.buttonC.Text = "c";
            this.buttonC.UseVisualStyleBackColor = true;
            this.buttonC.Click += new System.EventHandler(this.buttonC_KeyDown);
            // 
            // buttonB
            // 
            this.buttonB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonB.Location = new System.Drawing.Point(218, 206);
            this.buttonB.Name = "buttonB";
            this.buttonB.Size = new System.Drawing.Size(40, 40);
            this.buttonB.TabIndex = 20;
            this.buttonB.Text = "b";
            this.buttonB.UseVisualStyleBackColor = true;
            this.buttonB.Click += new System.EventHandler(this.buttonB_Click);
            // 
            // buttonOne
            // 
            this.buttonOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOne.Location = new System.Drawing.Point(106, 206);
            this.buttonOne.Name = "buttonOne";
            this.buttonOne.Size = new System.Drawing.Size(40, 40);
            this.buttonOne.TabIndex = 19;
            this.buttonOne.Text = "1";
            this.buttonOne.UseVisualStyleBackColor = true;
            this.buttonOne.Click += new System.EventHandler(this.buttonOne_Click);
            // 
            // buttonA
            // 
            this.buttonA.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonA.Location = new System.Drawing.Point(162, 206);
            this.buttonA.Name = "buttonA";
            this.buttonA.Size = new System.Drawing.Size(40, 40);
            this.buttonA.TabIndex = 18;
            this.buttonA.Text = "a";
            this.buttonA.UseVisualStyleBackColor = true;
            this.buttonA.Click += new System.EventHandler(this.buttonA_Click);
            // 
            // buttonZero
            // 
            this.buttonZero.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonZero.Location = new System.Drawing.Point(50, 206);
            this.buttonZero.Name = "buttonZero";
            this.buttonZero.Size = new System.Drawing.Size(40, 40);
            this.buttonZero.TabIndex = 17;
            this.buttonZero.Text = "0";
            this.buttonZero.UseVisualStyleBackColor = true;
            this.buttonZero.Click += new System.EventHandler(this.buttonZero_Click);
            // 
            // buttonX6
            // 
            this.buttonX6.Cursor = System.Windows.Forms.Cursors.No;
            this.buttonX6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonX6.Location = new System.Drawing.Point(444, 271);
            this.buttonX6.Name = "buttonX6";
            this.buttonX6.Size = new System.Drawing.Size(40, 40);
            this.buttonX6.TabIndex = 32;
            this.buttonX6.Text = "X6";
            this.buttonX6.UseVisualStyleBackColor = true;
            // 
            // buttonX4
            // 
            this.buttonX4.Cursor = System.Windows.Forms.Cursors.No;
            this.buttonX4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonX4.Location = new System.Drawing.Point(332, 271);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(40, 40);
            this.buttonX4.TabIndex = 31;
            this.buttonX4.Text = "X4";
            this.buttonX4.UseVisualStyleBackColor = true;
            // 
            // buttonX5
            // 
            this.buttonX5.Cursor = System.Windows.Forms.Cursors.No;
            this.buttonX5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonX5.Location = new System.Drawing.Point(388, 271);
            this.buttonX5.Name = "buttonX5";
            this.buttonX5.Size = new System.Drawing.Size(40, 40);
            this.buttonX5.TabIndex = 30;
            this.buttonX5.Text = "X5";
            this.buttonX5.UseVisualStyleBackColor = true;
            // 
            // buttonX3
            // 
            this.buttonX3.Cursor = System.Windows.Forms.Cursors.No;
            this.buttonX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonX3.Location = new System.Drawing.Point(276, 271);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(40, 40);
            this.buttonX3.TabIndex = 29;
            this.buttonX3.Text = "X3";
            this.buttonX3.UseVisualStyleBackColor = true;
            // 
            // buttonX2
            // 
            this.buttonX2.Cursor = System.Windows.Forms.Cursors.No;
            this.buttonX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonX2.Location = new System.Drawing.Point(218, 271);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(40, 40);
            this.buttonX2.TabIndex = 28;
            this.buttonX2.Text = "X2";
            this.buttonX2.UseVisualStyleBackColor = true;
            // 
            // buttonCloseScope
            // 
            this.buttonCloseScope.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCloseScope.Location = new System.Drawing.Point(106, 271);
            this.buttonCloseScope.Name = "buttonCloseScope";
            this.buttonCloseScope.Size = new System.Drawing.Size(40, 40);
            this.buttonCloseScope.TabIndex = 27;
            this.buttonCloseScope.Text = ")";
            this.buttonCloseScope.UseVisualStyleBackColor = true;
            this.buttonCloseScope.Click += new System.EventHandler(this.buttonCloseScope_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.Cursor = System.Windows.Forms.Cursors.No;
            this.buttonX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonX1.Location = new System.Drawing.Point(162, 271);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(40, 40);
            this.buttonX1.TabIndex = 26;
            this.buttonX1.Text = "X1";
            this.buttonX1.UseVisualStyleBackColor = true;
            // 
            // buttonOpenScope
            // 
            this.buttonOpenScope.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOpenScope.Location = new System.Drawing.Point(50, 271);
            this.buttonOpenScope.Name = "buttonOpenScope";
            this.buttonOpenScope.Size = new System.Drawing.Size(40, 40);
            this.buttonOpenScope.TabIndex = 25;
            this.buttonOpenScope.Text = "(";
            this.buttonOpenScope.UseVisualStyleBackColor = true;
            this.buttonOpenScope.Click += new System.EventHandler(this.buttonOpenScope_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(218, 342);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 40);
            this.button1.TabIndex = 33;
            this.button1.Text = "Решить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Solve);
            // 
            // debug
            // 
            this.debug.AutoSize = true;
            this.debug.Location = new System.Drawing.Point(12, 9);
            this.debug.Name = "debug";
            this.debug.Size = new System.Drawing.Size(37, 13);
            this.debug.TabIndex = 34;
            this.debug.Text = "debug";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 600);
            this.Controls.Add(this.debug);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonX6);
            this.Controls.Add(this.buttonX4);
            this.Controls.Add(this.buttonX5);
            this.Controls.Add(this.buttonX3);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.buttonCloseScope);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.buttonOpenScope);
            this.Controls.Add(this.buttonZ);
            this.Controls.Add(this.buttonX);
            this.Controls.Add(this.buttonY);
            this.Controls.Add(this.buttonC);
            this.Controls.Add(this.buttonB);
            this.Controls.Add(this.buttonOne);
            this.Controls.Add(this.buttonA);
            this.Controls.Add(this.buttonZero);
            this.Controls.Add(this.buttonSchaffer);
            this.Controls.Add(this.buttonEq);
            this.Controls.Add(this.buttonPierce);
            this.Controls.Add(this.buttonImplic);
            this.Controls.Add(this.buttonXor);
            this.Controls.Add(this.table1);
            this.Controls.Add(this.buttonAnd);
            this.Controls.Add(this.buttonNot);
            this.Controls.Add(this.buttonOr);
            this.Controls.Add(this.inputField);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Калькулятор";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputField;
        private System.Windows.Forms.Button buttonOr;
        private System.Windows.Forms.Button buttonNot;
        private System.Windows.Forms.Button buttonAnd;
        private System.Windows.Forms.TextBox table1;
        private System.Windows.Forms.Button buttonXor;
        private System.Windows.Forms.Button buttonSchaffer;
        private System.Windows.Forms.Button buttonEq;
        private System.Windows.Forms.Button buttonPierce;
        private System.Windows.Forms.Button buttonImplic;
        private System.Windows.Forms.Button buttonZ;
        private System.Windows.Forms.Button buttonX;
        private System.Windows.Forms.Button buttonY;
        private System.Windows.Forms.Button buttonC;
        private System.Windows.Forms.Button buttonB;
        private System.Windows.Forms.Button buttonOne;
        private System.Windows.Forms.Button buttonA;
        private System.Windows.Forms.Button buttonZero;
        private System.Windows.Forms.Button buttonX6;
        private System.Windows.Forms.Button buttonX4;
        private System.Windows.Forms.Button buttonX5;
        private System.Windows.Forms.Button buttonX3;
        private System.Windows.Forms.Button buttonX2;
        private System.Windows.Forms.Button buttonCloseScope;
        private System.Windows.Forms.Button buttonX1;
        private System.Windows.Forms.Button buttonOpenScope;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label debug;
    }
}

