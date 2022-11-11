
namespace PlumbingShopView
{
    partial class FormReportSanitaryEngineeringComponents
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonSavetoExcel = new System.Windows.Forms.Button();
            this.SanitaryEngineering = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Component = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SanitaryEngineering,
            this.Component,
            this.Count});
            this.dataGridView.Location = new System.Drawing.Point(0, 57);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(671, 630);
            this.dataGridView.TabIndex = 0;
            // 
            // buttonSavetoExcel
            // 
            this.buttonSavetoExcel.Location = new System.Drawing.Point(12, 12);
            this.buttonSavetoExcel.Name = "buttonSavetoExcel";
            this.buttonSavetoExcel.Size = new System.Drawing.Size(143, 23);
            this.buttonSavetoExcel.TabIndex = 1;
            this.buttonSavetoExcel.Text = "Сохранить в Excel";
            this.buttonSavetoExcel.UseVisualStyleBackColor = true;
            this.buttonSavetoExcel.Click += new System.EventHandler(this.buttonSaveToExcel_Click);
            // 
            // SanitaryEngineering
            // 
            this.SanitaryEngineering.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SanitaryEngineering.HeaderText = "Сантехника";
            this.SanitaryEngineering.Name = "SanitaryEngineering";
            // 
            // Component
            // 
            this.Component.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Component.HeaderText = "Компонент";
            this.Component.Name = "Component";
            // 
            // Count
            // 
            this.Count.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Count.HeaderText = "Количество";
            this.Count.Name = "Count";
            // 
            // FormReportSanitaryEngineeringComponents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 686);
            this.Controls.Add(this.buttonSavetoExcel);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormReportSanitaryEngineeringComponents";
            this.Text = "FormReportSanitaryEngineeringComponents";
            this.Load += new System.EventHandler(this.FormReportSanitaryEngineeringComponents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonSavetoExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Component;
        private System.Windows.Forms.DataGridViewTextBoxColumn SanitaryEngineering;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
    }
}