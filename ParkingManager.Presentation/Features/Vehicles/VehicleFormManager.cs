using ParkingManager.Applications.Features.Payments;
using ParkingManager.Applications.Features.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingManager.Presentation.Features.Vehicles
{
    public class VehicleFormManager : FormManager
    {
        private VehicleAppService VehicleAppService;
        private PaymentAppService PaymentAppService;

        public VehicleFormManager(VehicleAppService vehicleAppService, PaymentAppService paymentAppService)
        {
            VehicleAppService = vehicleAppService;
            PaymentAppService = paymentAppService;
        }

        public override void Add()
        {
            VehicleDialog vehicleDialog = new VehicleDialog();

            DialogResult result = vehicleDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var id = VehicleAppService.Add(vehicleDialog.addCommand);

                var command = PaymentAppService.BuildCommand(id);

                PaymentAppService.Add(command);
            }
        }

        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override UserControl GetAll()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
