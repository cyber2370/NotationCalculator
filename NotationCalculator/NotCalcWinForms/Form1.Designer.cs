namespace NotCalcWinForms
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
            this.num1_TB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.num2_TB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.num2_nud = new System.Windows.Forms.NumericUpDown();
            this.num1_nud = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.not16_lbl = new System.Windows.Forms.Label();
            this.not8_lbl = new System.Windows.Forms.Label();
            this.not10_lbl = new System.Windows.Forms.Label();
            this.not2_lbl = new System.Windows.Forms.Label();
            this.plus_button = new System.Windows.Forms.Button();
            this.substract_button = new System.Windows.Forms.Button();
            this.multiply_button = new System.Windows.Forms.Button();
            this.divide_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.num2_nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num1_nud)).BeginInit();
            this.SuspendLayout();
            // 
            // num1_TB
            // 
            this.num1_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.num1_TB.Location = new System.Drawing.Point(53, 80);
            this.num1_TB.Name = "num1_TB";
            this.num1_TB.Size = new System.Drawing.Size(100, 35);
            this.num1_TB.TabIndex = 0;
            this.num1_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.num1_TB.TextChanged += new System.EventHandler(this.num1_TB_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(49, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(49, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Number 2";
            // 
            // num2_TB
            // 
            this.num2_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.num2_TB.Location = new System.Drawing.Point(53, 178);
            this.num2_TB.Name = "num2_TB";
            this.num2_TB.Size = new System.Drawing.Size(100, 35);
            this.num2_TB.TabIndex = 2;
            this.num2_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.num2_TB.TextChanged += new System.EventHandler(this.num2_TB_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(162, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Notation";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(162, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Notation";
            // 
            // num2_nud
            // 
            this.num2_nud.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.num2_nud.Location = new System.Drawing.Point(166, 179);
            this.num2_nud.Name = "num2_nud";
            this.num2_nud.Size = new System.Drawing.Size(100, 35);
            this.num2_nud.TabIndex = 8;
            this.num2_nud.ValueChanged += new System.EventHandler(this.num2_nud_ValueChanged);
            // 
            // num1_nud
            // 
            this.num1_nud.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.num1_nud.Location = new System.Drawing.Point(166, 81);
            this.num1_nud.Name = "num1_nud";
            this.num1_nud.Size = new System.Drawing.Size(100, 35);
            this.num1_nud.TabIndex = 9;
            this.num1_nud.ValueChanged += new System.EventHandler(this.num1_nud_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(49, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "Notation 2:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(49, 317);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 24);
            this.label6.TabIndex = 11;
            this.label6.Text = "Notation 10:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(49, 284);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 24);
            this.label7.TabIndex = 12;
            this.label7.Text = "Notation 8:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(49, 351);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 24);
            this.label8.TabIndex = 13;
            this.label8.Text = "Notation 16:";
            // 
            // not16_lbl
            // 
            this.not16_lbl.AutoSize = true;
            this.not16_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.not16_lbl.Location = new System.Drawing.Point(162, 351);
            this.not16_lbl.Name = "not16_lbl";
            this.not16_lbl.Size = new System.Drawing.Size(20, 24);
            this.not16_lbl.TabIndex = 17;
            this.not16_lbl.Text = "0";
            // 
            // not8_lbl
            // 
            this.not8_lbl.AutoSize = true;
            this.not8_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.not8_lbl.Location = new System.Drawing.Point(162, 284);
            this.not8_lbl.Name = "not8_lbl";
            this.not8_lbl.Size = new System.Drawing.Size(20, 24);
            this.not8_lbl.TabIndex = 16;
            this.not8_lbl.Text = "0";
            // 
            // not10_lbl
            // 
            this.not10_lbl.AutoSize = true;
            this.not10_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.not10_lbl.Location = new System.Drawing.Point(162, 317);
            this.not10_lbl.Name = "not10_lbl";
            this.not10_lbl.Size = new System.Drawing.Size(20, 24);
            this.not10_lbl.TabIndex = 15;
            this.not10_lbl.Text = "0";
            // 
            // not2_lbl
            // 
            this.not2_lbl.AutoSize = true;
            this.not2_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.not2_lbl.Location = new System.Drawing.Point(162, 249);
            this.not2_lbl.Name = "not2_lbl";
            this.not2_lbl.Size = new System.Drawing.Size(20, 24);
            this.not2_lbl.TabIndex = 14;
            this.not2_lbl.Text = "0";
            // 
            // plus_button
            // 
            this.plus_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plus_button.Location = new System.Drawing.Point(309, 67);
            this.plus_button.Name = "plus_button";
            this.plus_button.Size = new System.Drawing.Size(73, 69);
            this.plus_button.TabIndex = 18;
            this.plus_button.Text = "+";
            this.plus_button.UseVisualStyleBackColor = true;
            this.plus_button.Click += new System.EventHandler(this.plus_button_Click);
            // 
            // substract_button
            // 
            this.substract_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.substract_button.Location = new System.Drawing.Point(402, 67);
            this.substract_button.Name = "substract_button";
            this.substract_button.Size = new System.Drawing.Size(73, 69);
            this.substract_button.TabIndex = 19;
            this.substract_button.Text = "-";
            this.substract_button.UseVisualStyleBackColor = true;
            this.substract_button.Click += new System.EventHandler(this.substract_button_Click);
            // 
            // multiply_button
            // 
            this.multiply_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.multiply_button.Location = new System.Drawing.Point(309, 151);
            this.multiply_button.Name = "multiply_button";
            this.multiply_button.Size = new System.Drawing.Size(73, 69);
            this.multiply_button.TabIndex = 20;
            this.multiply_button.Text = "*";
            this.multiply_button.UseVisualStyleBackColor = true;
            this.multiply_button.Click += new System.EventHandler(this.multiply_button_Click);
            // 
            // divide_button
            // 
            this.divide_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.divide_button.Location = new System.Drawing.Point(402, 151);
            this.divide_button.Name = "divide_button";
            this.divide_button.Size = new System.Drawing.Size(73, 69);
            this.divide_button.TabIndex = 21;
            this.divide_button.Text = "/";
            this.divide_button.UseVisualStyleBackColor = true;
            this.divide_button.Click += new System.EventHandler(this.divide_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 445);
            this.Controls.Add(this.divide_button);
            this.Controls.Add(this.multiply_button);
            this.Controls.Add(this.substract_button);
            this.Controls.Add(this.plus_button);
            this.Controls.Add(this.not16_lbl);
            this.Controls.Add(this.not8_lbl);
            this.Controls.Add(this.not10_lbl);
            this.Controls.Add(this.not2_lbl);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.num1_nud);
            this.Controls.Add(this.num2_nud);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.num2_TB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.num1_TB);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.num2_nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num1_nud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox num1_TB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox num2_TB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown num2_nud;
        private System.Windows.Forms.NumericUpDown num1_nud;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label not16_lbl;
        private System.Windows.Forms.Label not8_lbl;
        private System.Windows.Forms.Label not10_lbl;
        private System.Windows.Forms.Label not2_lbl;
        private System.Windows.Forms.Button plus_button;
        private System.Windows.Forms.Button substract_button;
        private System.Windows.Forms.Button multiply_button;
        private System.Windows.Forms.Button divide_button;
    }
}

