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
    public partial class FormSanitaryEngineerings : Form
    {
        private readonly ISanitaryEngineeringLogic logic;

        public FormSanitaryEngineerings(ISanitaryEngineeringLogic _logic)
        {
            InitializeComponent();
            logic = _logic;
        }

        private void FormSanitaryEngineerings_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = logic.Read(null);
                if (list != null)
                {
                    dataGridViewSanitaryEngineerings.DataSource = list;
                    dataGridViewSanitaryEngineerings.Columns[0].Visible = false;
                    dataGridViewSanitaryEngineerings.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridViewSanitaryEngineerings.Columns[3].Visible = false;
                }
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

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormSanitaryEngineering>();
            if (form.ShowDialog() == DialogResult.OK) LoadData();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewSanitaryEngineerings.SelectedRows.Count == 1)
            {
                var form = Program.Container.Resolve<FormSanitaryEngineering>();
                form.Id = Convert.ToInt32(dataGridViewSanitaryEngineerings.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK) LoadData();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewSanitaryEngineerings.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridViewSanitaryEngineerings.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        logic.Delete(new SanitaryEngineeringBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
                    }
                    LoadData();
                }
            }
        }
    }
}
