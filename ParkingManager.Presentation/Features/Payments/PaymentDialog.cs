using ParkingManager.Application.Features.Prices;
using ParkingManager.Applications.Features.Payments;
using ParkingManager.Applications.Features.Payments.ViewModels;
using ParkingManager.Applications.Features.Vehicles;
using ParkingManager.Domain.Features.Payments;
using ParkingManager.Presentation.Features.Prices;
using ParkingManager.Presentation.Features.Vehicles;
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
    public partial class PaymentDialog : Form
    {
        FormManager FormManager;
        PriceAppService PriceAppService;
        VehicleAppService VehicleAppService;
        PaymentAppService PaymentAppService;
        PaymentViewModel PaymentViewSelected;

        public PaymentDialog()
        {
            InitializeComponent();
        }

        public PaymentDialog(PriceAppService priceAppService, VehicleAppService vehicleAppService, PaymentAppService paymentAppService)
        {
            InitializeComponent();
            VehicleAppService = vehicleAppService;
            PriceAppService = priceAppService;
            PaymentAppService = paymentAppService;

            List<Payment> paymentList = PaymentAppService.GetAll().ToList();

            PopulateDataGridPayment(paymentList);

            ConfigureDataGridPayment();
        }

        private void ConfigureDataGridPayment()
        {
            dgvPayment.Columns[0].Visible = false;
            dgvPayment.Columns[1].HeaderText = "Placa:";
            dgvPayment.Columns[2].HeaderText = "Entrada:";
            dgvPayment.Columns[3].HeaderText = "Saída:";
            dgvPayment.Columns[4].HeaderText = "Duração:";
            dgvPayment.Columns[5].HeaderText = "Valor Inicial:";
            dgvPayment.Columns[6].HeaderText = "Hora adicional:";
            dgvPayment.Columns[7].HeaderText = "Valor a cobrar:";
        }

        private void PopulateDataGridPayment(List<Payment> paymentList)
        {
            List<PaymentViewModel> paymentViewModels = new List<PaymentViewModel>();

            foreach (var payment in paymentList)
            {
                paymentViewModels.Add(new PaymentViewModel
                {
                    Id = payment.Id,
                    ExitTime = payment.ExitTime,
                    PriceValueAdditional = payment.Price.AdditionalValue,
                    PriceValueInitial = payment.Price.InitialValue,
                    Value = payment.Value,
                    VehicleLicensePlate = payment.Vehicle.LicensePlate,
                    VehicleInput = payment.Vehicle.Input,
                    Duration = payment.Duration
                });
            }

            dgvPayment.DataSource = paymentViewModels;
        }

        private void tsbAddPrice_Click(object sender, EventArgs e)
        {
            FormManager = new PriceFormManager(PriceAppService);
            FormManager.Add();
            List<Payment> paymentList = PaymentAppService.GetAll().ToList();
            PopulateDataGridPayment(paymentList);
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            FormManager = new VehicleFormManager(VehicleAppService, PaymentAppService);
            FormManager.Add();
            List<Payment> paymentList = PaymentAppService.GetAll().ToList();
            PopulateDataGridPayment(paymentList);
        }

        private void dgvPayment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PaymentViewSelected = dgvPayment.CurrentRow.DataBoundItem as PaymentViewModel;
            btnToExit.Enabled = true;
        }

        private void btnToExit_Click(object sender, EventArgs e)
        {
            FormManager = new PaymentFormManager(PaymentAppService, PaymentViewSelected);
            FormManager.Add();
            List<Payment> paymentList = PaymentAppService.GetAll().ToList();
            PopulateDataGridPayment(paymentList);
        }

        private void btnSearchVehicle_Click(object sender, EventArgs e)
        {
            var paymentList = PaymentAppService.GetByLicensePlate(txtSearchVehicle.Text);
            PopulateDataGridPayment(paymentList);

            txtSearchVehicle.Text = "";
        }

        private void txtSearchVehicle_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSearchVehicle.Text))
                btnSearchVehicle.Enabled = true;
            else
                btnSearchVehicle.Enabled = false;
        }
    }
}
