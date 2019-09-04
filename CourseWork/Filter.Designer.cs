namespace CourseWork
{
    partial class Filter
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
            this.label_Visiting_and_Diagnosis = new System.Windows.Forms.Label();
            this.button_Visiting_and_Diagnosis = new System.Windows.Forms.Button();
            this.textBox_D = new System.Windows.Forms.TextBox();
            this.textBox_S = new System.Windows.Forms.TextBox();
            this.textBox_P = new System.Windows.Forms.TextBox();
            this.textBox_G = new System.Windows.Forms.TextBox();
            this.textBox_R = new System.Windows.Forms.TextBox();
            this.textBox_K = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label_Visiting_and_Diagnosis
            // 
            this.label_Visiting_and_Diagnosis.AutoSize = true;
            this.label_Visiting_and_Diagnosis.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Visiting_and_Diagnosis.Location = new System.Drawing.Point(5, 9);
            this.label_Visiting_and_Diagnosis.Name = "label_Visiting_and_Diagnosis";
            this.label_Visiting_and_Diagnosis.Size = new System.Drawing.Size(404, 19);
            this.label_Visiting_and_Diagnosis.TabIndex = 1;
            this.label_Visiting_and_Diagnosis.Text = "Расчет количества посещений и диагнозов по районам";
            // 
            // button_Visiting_and_Diagnosis
            // 
            this.button_Visiting_and_Diagnosis.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_Visiting_and_Diagnosis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Visiting_and_Diagnosis.Location = new System.Drawing.Point(415, 6);
            this.button_Visiting_and_Diagnosis.Name = "button_Visiting_and_Diagnosis";
            this.button_Visiting_and_Diagnosis.Size = new System.Drawing.Size(133, 26);
            this.button_Visiting_and_Diagnosis.TabIndex = 2;
            this.button_Visiting_and_Diagnosis.Text = "Расчитать";
            this.button_Visiting_and_Diagnosis.UseVisualStyleBackColor = false;
            this.button_Visiting_and_Diagnosis.Click += new System.EventHandler(this.button_Visiting_and_Diagnosis_Click);
            // 
            // textBox_D
            // 
            this.textBox_D.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_D.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_D.Location = new System.Drawing.Point(16, 50);
            this.textBox_D.Name = "textBox_D";
            this.textBox_D.Size = new System.Drawing.Size(532, 23);
            this.textBox_D.TabIndex = 3;
            // 
            // textBox_S
            // 
            this.textBox_S.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_S.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_S.Location = new System.Drawing.Point(16, 79);
            this.textBox_S.Name = "textBox_S";
            this.textBox_S.Size = new System.Drawing.Size(532, 23);
            this.textBox_S.TabIndex = 4;
            // 
            // textBox_P
            // 
            this.textBox_P.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_P.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_P.Location = new System.Drawing.Point(16, 108);
            this.textBox_P.Name = "textBox_P";
            this.textBox_P.Size = new System.Drawing.Size(532, 23);
            this.textBox_P.TabIndex = 5;
            // 
            // textBox_G
            // 
            this.textBox_G.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_G.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_G.Location = new System.Drawing.Point(16, 137);
            this.textBox_G.Name = "textBox_G";
            this.textBox_G.Size = new System.Drawing.Size(532, 23);
            this.textBox_G.TabIndex = 6;
            // 
            // textBox_R
            // 
            this.textBox_R.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_R.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_R.Location = new System.Drawing.Point(16, 166);
            this.textBox_R.Name = "textBox_R";
            this.textBox_R.Size = new System.Drawing.Size(532, 23);
            this.textBox_R.TabIndex = 7;
            // 
            // textBox_K
            // 
            this.textBox_K.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_K.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_K.Location = new System.Drawing.Point(16, 195);
            this.textBox_K.Name = "textBox_K";
            this.textBox_K.Size = new System.Drawing.Size(532, 23);
            this.textBox_K.TabIndex = 8;
            // 
            // Filter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(560, 251);
            this.Controls.Add(this.textBox_K);
            this.Controls.Add(this.textBox_R);
            this.Controls.Add(this.textBox_G);
            this.Controls.Add(this.textBox_P);
            this.Controls.Add(this.textBox_S);
            this.Controls.Add(this.textBox_D);
            this.Controls.Add(this.button_Visiting_and_Diagnosis);
            this.Controls.Add(this.label_Visiting_and_Diagnosis);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Filter";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Расчёт данных";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_Visiting_and_Diagnosis;
        private System.Windows.Forms.Button button_Visiting_and_Diagnosis;
        private System.Windows.Forms.TextBox textBox_D;
        private System.Windows.Forms.TextBox textBox_S;
        private System.Windows.Forms.TextBox textBox_P;
        private System.Windows.Forms.TextBox textBox_G;
        private System.Windows.Forms.TextBox textBox_R;
        private System.Windows.Forms.TextBox textBox_K;
    }
}