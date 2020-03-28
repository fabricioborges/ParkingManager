using ParkingManager.Application.Features.Prices;
using ParkingManager.Applications.Features.Vehicles;
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

namespace ParkingManager.Presentation.Features.Managers
{
    public partial class Manager : Form
    {
        FormManager FormManager;
        VehicleAppService VehicleAppService;
        PriceAppService PriceAppService;

        public Manager()
        {
            InitializeComponent();

        }

        public Manager(PriceAppService priceAppService, VehicleAppService vehicleAppService)
        {
            InitializeComponent();
            VehicleAppService = vehicleAppService;
            PriceAppService = priceAppService;

            var data = vehicleAppService.GetAll().ToList();
           
            dGManager.DataSource = data;
            dGManager.Columns[0].Visible = false;
        }

        private void btnToVehicle_Click(object sender, EventArgs e)
        {
            FormManager = new VehicleFormManager(VehicleAppService);
            FormManager.Add();
            dGManager.DataSource = VehicleAppService.GetAll().ToList();
        }

        private void btnToPrice_Click(object sender, EventArgs e)
        {
            FormManager = new PriceFormManager(PriceAppService);
            FormManager.Add();
        }
    }
}
