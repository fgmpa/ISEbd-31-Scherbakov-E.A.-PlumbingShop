using PlumbingShopContracts.BindingModels;
using PlumbingShopContracts.BusinessLogicsContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace PlumbingShopView
{
    public partial class FormMain : Form
    {
        private readonly IOrderLogic orderLogic;
        private readonly IReportLogic reportLogic;
        private readonly IWorkProcess workProcces;
        private readonly IImplementerLogic implementerLogic;

        public FormMain(IOrderLogic _orderLogic, IReportLogic _reportLogic, IWorkProcess _workProcess, IImplementerLogic _implementerLogic)
        {
            InitializeComponent();
            orderLogic = _orderLogic;
            reportLogic = _reportLogic;
            workProcces = _workProcess;
            implementerLogic = _implementerLogic;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = orderLogic.Read(null);
                dataGridViewOrders.DataSource = list;
                dataGridViewOrders.Columns[0].Visible = false;
                dataGridViewOrders.Columns[1].Visible = false;
                dataGridViewOrders.Columns[2].Visible = false;
                dataGridViewOrders.Columns[3].Visible = false;
                dataGridViewOrders.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridViewOrders.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridViewOrders.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void toolStripMenuItemComponent_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormComponents>();
            form.ShowDialog();
        }

        private void toolStripMenuItemSanitaryEngineering_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormSanitaryEngineerings>();
            form.ShowDialog();
            LoadData();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormCreateOrder>();
            form.ShowDialog();
            LoadData();
        }
        
        private void buttonIssue_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrders.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridViewOrders.SelectedRows[0].Cells[0].Value);
                try
                {
                    orderLogic.DeliveryOrder(new ChangeStatusBindingModel { OrderId = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void списокКомпонентовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "docx|*.docx" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                reportLogic.SaveSanitaryEngineeringsToWordFile(new ReportBindingModel
                {
                    FileName = dialog.FileName
                });
                MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }
        private void компонентыПоИзделиямToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormReportSanitaryEngineeringComponents>();
            form.ShowDialog();
        }
        private void списокЗаказовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormReportOrders>();
            form.ShowDialog();
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormClients>();
            form.ShowDialog();
        }
        private void исполнителиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormImplementers>();
            form.ShowDialog();
        }

        private void запускРаботToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workProcces.DoWork(implementerLogic, orderLogic);
            LoadData();
        }
        private void вывестиПисьмаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormMessagesInfo>();
            form.ShowDialog();
        }
    }
}
