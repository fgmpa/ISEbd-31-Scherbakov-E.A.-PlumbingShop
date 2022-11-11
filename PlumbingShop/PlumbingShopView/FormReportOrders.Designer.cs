namespace PlumbingShopView
{
    partial class FormReportOrders
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
            this.panelFormOrder = new System.Windows.Forms.Panel();
            this.labelPO = new System.Windows.Forms.Label();
            this.labelC = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.buttonMake = new System.Windows.Forms.Button();
            this.buttonToPdf = new System.Windows.Forms.Button();
            this.panelFormOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFormOrder
            // 
            this.panelFormOrder.Controls.Add(this.labelPO);
            this.panelFormOrder.Controls.Add(this.labelC);
            this.panelFormOrder.Controls.Add(this.dateTimePickerTo);
            this.panelFormOrder.Controls.Add(this.dateTimePickerFrom);
            this.panelFormOrder.Controls.Add(this.buttonMake);
            this.panelFormOrder.Controls.Add(this.buttonToPdf);
            this.panelFormOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFormOrder.Location = new System.Drawing.Point(0, 0);
            this.panelFormOrder.Name = "panelFormOrder";
            this.panelFormOrder.Size = new System.Drawing.Size(941, 80);
            this.panelFormOrder.TabIndex = 0;
            // 
            // labelPO
            // 
            this.labelPO.AutoSize = true;
            this.labelPO.Location = new System.Drawing.Point(188, 33);
            this.labelPO.Name = "labelPO";
            this.labelPO.Size = new System.Drawing.Size(21, 15);
            this.labelPO.TabIndex = 5;
            this.labelPO.Text = "по";
            // 
            // labelC
            // 
            this.labelC.AutoSize = true;
            this.labelC.Location = new System.Drawing.Point(13, 33);
            this.labelC.Name = "labelC";
            this.labelC.Size = new System.Drawing.Size(15, 15);
            this.labelC.TabIndex = 4;
            this.labelC.Text = "С";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(215, 27);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(147, 23);
            this.dateTimePickerTo.TabIndex = 3;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(34, 27);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(148, 23);
            this.dateTimePickerFrom.TabIndex = 2;
            // 
            // buttonMake
            // 
            this.buttonMake.Location = new System.Drawing.Point(436, 24);
            this.buttonMake.Name = "buttonMake";
            this.buttonMake.Size = new System.Drawing.Size(108, 33);
            this.buttonMake.TabIndex = 1;
            this.buttonMake.Text = "Сформировать";
            this.buttonMake.UseVisualStyleBackColor = true;
            this.buttonMake.Click += new System.EventHandler(this.buttonMake_Click);
            // 
            // buttonToPdf
            // 
            this.buttonToPdf.Location = new System.Drawing.Point(786, 24);
            this.buttonToPdf.Name = "buttonToPdf";
            this.buttonToPdf.Size = new System.Drawing.Size(108, 33);
            this.buttonToPdf.TabIndex = 0;
            this.buttonToPdf.Text = "в pdf";
            this.buttonToPdf.UseVisualStyleBackColor = true;
            this.buttonToPdf.Click += new System.EventHandler(this.buttonToPdf_Click);
            // 
            // FormReportOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 516);
            this.Controls.Add(this.panelFormOrder);
            this.Name = "FormReportOrders";
            this.Text = "FormReportOrders";
            this.panelFormOrder.ResumeLayout(false);
            this.panelFormOrder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFormOrder;
        private System.Windows.Forms.Label labelPO;
        private System.Windows.Forms.Label labelC;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Button buttonMake;
        private System.Windows.Forms.Button buttonToPdf;
    }
}