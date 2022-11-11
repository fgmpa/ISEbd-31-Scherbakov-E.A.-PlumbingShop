
namespace PlumbingShopView
{
    partial class FormMain
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemLists = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSanitaryEngineering = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemComponent = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокКомпонентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыПоИзделиямToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonTakeInWork = new System.Windows.Forms.Button();
            this.buttonReady = new System.Windows.Forms.Button();
            this.buttonIssue = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemLists,
            this.отчетыToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(986, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItemLists
            // 
            this.toolStripMenuItemLists.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSanitaryEngineering,
            this.toolStripMenuItemComponent,
            this.клиентыToolStripMenuItem});
            this.toolStripMenuItemLists.Name = "toolStripMenuItemLists";
            this.toolStripMenuItemLists.Size = new System.Drawing.Size(94, 20);
            this.toolStripMenuItemLists.Text = "Справочники";
            // 
            // toolStripMenuItemSanitaryEngineering
            // 
            this.toolStripMenuItemSanitaryEngineering.Name = "toolStripMenuItemSanitaryEngineering";
            this.toolStripMenuItemSanitaryEngineering.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemSanitaryEngineering.Text = "Сантехника";
            this.toolStripMenuItemSanitaryEngineering.Click += new System.EventHandler(this.toolStripMenuItemSanitaryEngineering_Click);
            // 
            // toolStripMenuItemComponent
            // 
            this.toolStripMenuItemComponent.Name = "toolStripMenuItemComponent";
            this.toolStripMenuItemComponent.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemComponent.Text = "Компоненты";
            this.toolStripMenuItemComponent.Click += new System.EventHandler(this.toolStripMenuItemComponent_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокКомпонентовToolStripMenuItem,
            this.компонентыПоИзделиямToolStripMenuItem,
            this.списокЗаказовToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // списокКомпонентовToolStripMenuItem
            // 
            this.списокКомпонентовToolStripMenuItem.Name = "списокКомпонентовToolStripMenuItem";
            this.списокКомпонентовToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.списокКомпонентовToolStripMenuItem.Text = "Список компонентов";
            this.списокКомпонентовToolStripMenuItem.Click += new System.EventHandler(this.списокКомпонентовToolStripMenuItem_Click);
            // 
            // компонентыПоИзделиямToolStripMenuItem
            // 
            this.компонентыПоИзделиямToolStripMenuItem.Name = "компонентыПоИзделиямToolStripMenuItem";
            this.компонентыПоИзделиямToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.компонентыПоИзделиямToolStripMenuItem.Text = "Компоненты по изделиям";
            this.компонентыПоИзделиямToolStripMenuItem.Click += new System.EventHandler(this.компонентыПоИзделиямToolStripMenuItem_Click);
            // 
            // списокЗаказовToolStripMenuItem
            // 
            this.списокЗаказовToolStripMenuItem.Name = "списокЗаказовToolStripMenuItem";
            this.списокЗаказовToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.списокЗаказовToolStripMenuItem.Text = "Список заказов";
            this.списокЗаказовToolStripMenuItem.Click += new System.EventHandler(this.списокЗаказовToolStripMenuItem_Click);
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrders.Location = new System.Drawing.Point(0, 40);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.RowTemplate.Height = 25;
            this.dataGridViewOrders.Size = new System.Drawing.Size(789, 472);
            this.dataGridViewOrders.TabIndex = 1;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCreate.Location = new System.Drawing.Point(809, 60);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(165, 35);
            this.buttonCreate.TabIndex = 2;
            this.buttonCreate.Text = "Создать заказ";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonTakeInWork
            // 
            this.buttonTakeInWork.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonTakeInWork.Location = new System.Drawing.Point(809, 117);
            this.buttonTakeInWork.Name = "buttonTakeInWork";
            this.buttonTakeInWork.Size = new System.Drawing.Size(165, 35);
            this.buttonTakeInWork.TabIndex = 3;
            this.buttonTakeInWork.Text = "Отдать на выполнение";
            this.buttonTakeInWork.UseVisualStyleBackColor = true;
            this.buttonTakeInWork.Click += new System.EventHandler(this.buttonTakeInWork_Click);
            // 
            // buttonReady
            // 
            this.buttonReady.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonReady.Location = new System.Drawing.Point(809, 178);
            this.buttonReady.Name = "buttonReady";
            this.buttonReady.Size = new System.Drawing.Size(165, 35);
            this.buttonReady.TabIndex = 4;
            this.buttonReady.Text = "Заказ готов";
            this.buttonReady.UseVisualStyleBackColor = true;
            this.buttonReady.Click += new System.EventHandler(this.buttonReady_Click);
            // 
            // buttonIssue
            // 
            this.buttonIssue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonIssue.Location = new System.Drawing.Point(809, 236);
            this.buttonIssue.Name = "buttonIssue";
            this.buttonIssue.Size = new System.Drawing.Size(165, 35);
            this.buttonIssue.TabIndex = 5;
            this.buttonIssue.Text = "Заказ выдан";
            this.buttonIssue.UseVisualStyleBackColor = true;
            this.buttonIssue.Click += new System.EventHandler(this.buttonIssue_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRefresh.Location = new System.Drawing.Point(809, 302);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(165, 35);
            this.buttonRefresh.TabIndex = 6;
            this.buttonRefresh.Text = "Обновить список";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 514);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonIssue);
            this.Controls.Add(this.buttonReady);
            this.Controls.Add(this.buttonTakeInWork);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.dataGridViewOrders);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "Магазин Сантехники";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLists;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSanitaryEngineering;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemComponent;
        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonTakeInWork;
        private System.Windows.Forms.Button buttonReady;
        private System.Windows.Forms.Button buttonIssue;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокКомпонентовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компонентыПоИзделиямToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокЗаказовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
    }
}