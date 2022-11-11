namespace PlumbingShopView
{
    partial class FormImplementer
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxImplementerFIO = new System.Windows.Forms.TextBox();
            this.labelImplementerFIO = new System.Windows.Forms.Label();
            this.labelWorkTime = new System.Windows.Forms.Label();
            this.labelPauseTime = new System.Windows.Forms.Label();
            this.textBoxWorkTime = new System.Windows.Forms.TextBox();
            this.textBoxPauseTime = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(272, 145);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 33);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(147, 145);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 33);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxImplementerFIO
            // 
            this.textBoxImplementerFIO.Location = new System.Drawing.Point(118, 22);
            this.textBoxImplementerFIO.Name = "textBoxImplementerFIO";
            this.textBoxImplementerFIO.Size = new System.Drawing.Size(254, 23);
            this.textBoxImplementerFIO.TabIndex = 5;
            // 
            // labelImplementerFIO
            // 
            this.labelImplementerFIO.AutoSize = true;
            this.labelImplementerFIO.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelImplementerFIO.Location = new System.Drawing.Point(12, 23);
            this.labelImplementerFIO.Name = "labelImplementerFIO";
            this.labelImplementerFIO.Size = new System.Drawing.Size(40, 17);
            this.labelImplementerFIO.TabIndex = 4;
            this.labelImplementerFIO.Text = "ФИО:";
            // 
            // labelWorkTime
            // 
            this.labelWorkTime.AutoSize = true;
            this.labelWorkTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelWorkTime.Location = new System.Drawing.Point(12, 63);
            this.labelWorkTime.Name = "labelWorkTime";
            this.labelWorkTime.Size = new System.Drawing.Size(98, 17);
            this.labelWorkTime.TabIndex = 8;
            this.labelWorkTime.Text = "Время работы:";
            // 
            // labelPauseTime
            // 
            this.labelPauseTime.AutoSize = true;
            this.labelPauseTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPauseTime.Location = new System.Drawing.Point(12, 102);
            this.labelPauseTime.Name = "labelPauseTime";
            this.labelPauseTime.Size = new System.Drawing.Size(95, 17);
            this.labelPauseTime.TabIndex = 9;
            this.labelPauseTime.Text = "Время отдыха:";
            // 
            // textBoxWorkTime
            // 
            this.textBoxWorkTime.Location = new System.Drawing.Point(118, 62);
            this.textBoxWorkTime.Name = "textBoxWorkTime";
            this.textBoxWorkTime.Size = new System.Drawing.Size(129, 23);
            this.textBoxWorkTime.TabIndex = 10;
            // 
            // textBoxPauseTime
            // 
            this.textBoxPauseTime.Location = new System.Drawing.Point(118, 101);
            this.textBoxPauseTime.Name = "textBoxPauseTime";
            this.textBoxPauseTime.Size = new System.Drawing.Size(129, 23);
            this.textBoxPauseTime.TabIndex = 11;
            // 
            // FormImplementer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 190);
            this.Controls.Add(this.textBoxPauseTime);
            this.Controls.Add(this.textBoxWorkTime);
            this.Controls.Add(this.labelPauseTime);
            this.Controls.Add(this.labelWorkTime);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxImplementerFIO);
            this.Controls.Add(this.labelImplementerFIO);
            this.Name = "FormImplementer";
            this.Text = "Исполнитель";
            this.Load += new System.EventHandler(this.FormImplementer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxImplementerFIO;
        private System.Windows.Forms.Label labelImplementerFIO;
        private System.Windows.Forms.Label labelWorkTime;
        private System.Windows.Forms.Label labelPauseTime;
        private System.Windows.Forms.TextBox textBoxWorkTime;
        private System.Windows.Forms.TextBox textBoxPauseTime;
    }
}
