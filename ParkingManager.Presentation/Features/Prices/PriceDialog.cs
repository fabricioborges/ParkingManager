using ParkingManager.Application.Features.Prices;
using ParkingManager.Application.Features.Prices.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingManager.Presentation.Features.Prices
{
    public partial class PriceDialog : Form
    {
        private readonly PriceAppService AppService;

        public PriceAddCommand addCommand
        {
            get
            {
                PriceAddCommand command = new PriceAddCommand();
                command.InitialValue = float.Parse(txtInitialValue.Text);
                command.AdditionalValue = float.Parse(txtAdditionalValue.Text);
                command.InitialDate = mthInitialDate.SelectionRange.Start.Date;
                command.FinalDate = mthFinalDate.SelectionRange.Start.Date;

                return command;
            }
            set
            {

            }
        }

        public PriceDialog(PriceAppService priceAppService)
        {
            InitializeComponent();
            AppService = priceAppService;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                addCommand.Validation();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(ex.Message);
            }
        }
    }
}
