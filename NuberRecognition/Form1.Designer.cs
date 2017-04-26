namespace NuberRecognition
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
            this.buttonTeach = new System.Windows.Forms.Button();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.pictureBoxInputs = new System.Windows.Forms.PictureBox();
            this.richTextBoxAnswers = new System.Windows.Forms.RichTextBox();
            this.richTextBoxWeightMap = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInputs)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonTeach
            // 
            this.buttonTeach.Location = new System.Drawing.Point(13, 13);
            this.buttonTeach.Name = "buttonTeach";
            this.buttonTeach.Size = new System.Drawing.Size(166, 32);
            this.buttonTeach.TabIndex = 0;
            this.buttonTeach.Text = "Обучить сеть";
            this.buttonTeach.UseVisualStyleBackColor = true;
            this.buttonTeach.Click += new System.EventHandler(this.buttonTeach_Click);
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Location = new System.Drawing.Point(13, 52);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.Size = new System.Drawing.Size(166, 358);
            this.richTextBoxLog.TabIndex = 1;
            this.richTextBoxLog.Text = "";
            // 
            // pictureBoxInputs
            // 
            this.pictureBoxInputs.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBoxInputs.Location = new System.Drawing.Point(186, 13);
            this.pictureBoxInputs.Name = "pictureBoxInputs";
            this.pictureBoxInputs.Size = new System.Drawing.Size(241, 401);
            this.pictureBoxInputs.TabIndex = 2;
            this.pictureBoxInputs.TabStop = false;
            this.pictureBoxInputs.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxInputs_Paint);
            this.pictureBoxInputs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxInputs_MouseDown);
            // 
            // richTextBoxAnswers
            // 
            this.richTextBoxAnswers.Location = new System.Drawing.Point(13, 417);
            this.richTextBoxAnswers.Name = "richTextBoxAnswers";
            this.richTextBoxAnswers.Size = new System.Drawing.Size(414, 178);
            this.richTextBoxAnswers.TabIndex = 3;
            this.richTextBoxAnswers.Text = "";
            // 
            // richTextBoxWeightMap
            // 
            this.richTextBoxWeightMap.Location = new System.Drawing.Point(433, 12);
            this.richTextBoxWeightMap.Name = "richTextBoxWeightMap";
            this.richTextBoxWeightMap.Size = new System.Drawing.Size(317, 583);
            this.richTextBoxWeightMap.TabIndex = 4;
            this.richTextBoxWeightMap.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 607);
            this.Controls.Add(this.richTextBoxWeightMap);
            this.Controls.Add(this.richTextBoxAnswers);
            this.Controls.Add(this.pictureBoxInputs);
            this.Controls.Add(this.richTextBoxLog);
            this.Controls.Add(this.buttonTeach);
            this.Name = "Form1";
            this.Text = "Распознавание цифр";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInputs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonTeach;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.PictureBox pictureBoxInputs;
        private System.Windows.Forms.RichTextBox richTextBoxAnswers;
        private System.Windows.Forms.RichTextBox richTextBoxWeightMap;
    }
}

