using PlumbingShopContracts.BindingModels;
using PlumbingShopContracts.BusinessLogicsContracts;
using PlumbingShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlumbingShopView
{
    public partial class FormCreateOrder : Form
    {
        private readonly ISanitaryEngineeringLogic logicP;
        private readonly IOrderLogic logicO;
        private readonly IClientLogic logicC;

        public FormCreateOrder(ISanitaryEngineeringLogic _logicP, IOrderLogic _logicO, IClientLogic _logicC)
        {
            InitializeComponent();
            logicP = _logicP;
            logicO = _logicO;
            logicC = _logicC;
        }

        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            List<SanitaryEngineeringViewModel> list = logicP.Read(null);
            if (list != null)
            {
                comboBoxSanitaryEngineering.DisplayMember = "SanitaryEngineeringName";
                comboBoxSanitaryEngineering.ValueMember = "Id";
                comboBoxSanitaryEngineering.DataSource = list;
                comboBoxSanitaryEngineering.SelectedItem = null;
            }
            List<ClientViewModel> listC = logicC.Read(null);
            if (listC != null)
            {
                comboBoxClient.DisplayMember = "ClientFIO";
                comboBoxClient.ValueMember = "Id";
                comboBoxClient.DataSource = listC;
                comboBoxClient.SelectedItem = null;
            }
        }

        private void CalcSum()
        {
            if (comboBoxSanitaryEngineering.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxSanitaryEngineering.SelectedValue);
                    SanitaryEngineeringViewModel product = logicP.Read(new SanitaryEngineeringBindingModel { Id = id })?[0];
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * product?.Price ?? 0).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void comboBoxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Укажите количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxSanitaryEngineering.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxClient.SelectedValue == null)
            {
                MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                logicO.CreateOrder(new CreateOrderBindingModel
                {
                    SanitaryEngineeringId = Convert.ToInt32(comboBoxSanitaryEngineering.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDecimal(textBoxSum.Text),
                    ClientId = Convert.ToInt32(comboBoxClient.SelectedValue)
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
