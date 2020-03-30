using ParkingManager.Applications.Features.Payments;
using ParkingManager.Applications.Features.Payments.Commands;
using ParkingManager.Applications.Features.Payments.ViewModels;
using ParkingManager.Domain.Features.Payments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingManager.Presentation.Features.Payments
{
    public partial class PaymentExitDialog : Form
    {
        PaymentAppService PaymentAppService;
        PaymentViewModel PaymentViewModel;
        Payment Payment;

        public PaymentUpdateCommand updateCommand
        {
            get
            {
                PaymentUpdateCommand command = new PaymentUpdateCommand();
                command.Id = Payment.Id;
                command.PriceId = Payment.PriceId;
                command.VehicleId = Payment.VehicleId;
                command.Duration = Payment.Duration;
                command.ExitTime = dtExit.Value;
                command.Value = Payment.Value;

                return command;
            }
        }

        public PaymentExitDialog()
        {
            InitializeComponent();
        }

        public PaymentExitDialog(PaymentAppService paymentAppService, PaymentViewModel paymentViewModel)
        {
            InitializeComponent();
            PaymentAppService = paymentAppService;
            PaymentViewModel = paymentViewModel;

            txtLicensePlate.Text = PaymentViewModel.VehicleLicensePlate;

            GetPayment(PaymentViewModel.Id);

            dtExit.Format = DateTimePickerFormat.Custom;
            dtExit.CustomFormat = "H:mm:ss, dd/MM/yy";
        }

        public void GetPayment(long id)
        {
            Payment = PaymentAppService.GetById(id);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                updateCommand.Validation();
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
