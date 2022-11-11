using PlumbingShopContracts.BindingModels;
using PlumbingShopContracts.BusinessLogicsContracts;
using PlumbingShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using Unity;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlumbingShopView
{
    public partial class FormSanitaryEngineering : Form
    {
        public int Id { set { id = value; } }
        private readonly ISanitaryEngineeringLogic logic;
        private int? id;
        private Dictionary<int, (string, int)> sanitaryEngineeringComponents;

        public FormSanitaryEngineering(ISanitaryEngineeringLogic _logic)
        {
            InitializeComponent();
            logic = _logic;
        }

        private void FormSanitaryEngineering_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    SanitaryEngineeringViewModel view = logic.Read(new SanitaryEngineeringBindingModel { Id = id.Value })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.SanitaryEngineeringName;
                        textBoxPrice.Text = view.Price.ToString();
                        sanitaryEngineeringComponents = view.SanitaryEngineeringComponents;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else sanitaryEngineeringComponents = new Dictionary<int, (string, int)>();
        }

        private void LoadData()
        {
            try
            {
                if (sanitaryEngineeringComponents != null)
                {
                    dataGridViewComponents.Rows.Clear();
                    foreach (var pastry in sanitaryEngineeringComponents)
                    {
                        dataGridViewComponents.Rows.Add(new object[] { pastry.Key, pastry.Value.Item1, pastry.Value.Item2 });
                    }
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
            var form = Program.Container.Resolve<FormSanitaryEngineeringComponent>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (sanitaryEngineeringComponents.ContainsKey(form.Id))
                {
                    sanitaryEngineeringComponents[form.Id] = (form.ComponentName, form.Count);
                }
                else sanitaryEngineeringComponents.Add(form.Id, (form.ComponentName, form.Count));
                LoadData();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewComponents.SelectedRows.Count == 1)
            {
                var form = Program.Container.Resolve<FormSanitaryEngineeringComponent>();
                int id = Convert.ToInt32(dataGridViewComponents.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = sanitaryEngineeringComponents[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    sanitaryEngineeringComponents[form.Id] = (form.ComponentName, form.Count);
                    LoadData();
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewComponents.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    try
                    {
                        sanitaryEngineeringComponents.Remove(Convert.ToInt32(dataGridViewComponents.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Укажите название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Укажите цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (sanitaryEngineeringComponents == null || sanitaryEngineeringComponents.Count == 0)
            {
                MessageBox.Show("Укажите компоненты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                logic.CreateOrUpdate(new SanitaryEngineeringBindingModel
                {
                    Id = id,
                    SanitaryEngineeringName = textBoxName.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    SanitaryEngineeringComponents = sanitaryEngineeringComponents
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
