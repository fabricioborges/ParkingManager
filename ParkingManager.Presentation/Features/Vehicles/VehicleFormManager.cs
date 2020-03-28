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
        private VehicleAppService AppService;

        public VehicleFormManager(VehicleAppService appService)
        {
            AppService = appService;
        }

        public override void Add()
        {
            VehicleDialog vehicleDialog = new VehicleDialog();

            DialogResult result = vehicleDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                AppService.Add(vehicleDialog.addCommand);
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
