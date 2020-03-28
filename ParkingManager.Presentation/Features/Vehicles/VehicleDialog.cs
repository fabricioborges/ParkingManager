using ParkingManager.Application.Features.Vehicles.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingManager.Presentation.Features.Vehicles
{
    public partial class VehicleDialog : Form
    {

        public VehicleAddCommand addCommand
        {
            get
            {
                VehicleAddCommand command = new VehicleAddCommand();
                command.Input = dtInput.Value;
                command.LicensePlate = txtLicensePlate.Text;

                return command;
            }
            set
            {

            }
        }

        public VehicleDialog()
        {
            InitializeComponent();

            dtInput.Format = DateTimePickerFormat.Custom;
            dtInput.CustomFormat = "H:mm:ss, dd/MM/yy";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                addCommand.Validation();
                DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(ex.Message);
            }
        }

        private void VehicleDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
