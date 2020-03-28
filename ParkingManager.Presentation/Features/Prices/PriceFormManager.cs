using ParkingManager.Application.Features.Prices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingManager.Presentation.Features.Prices
{
    public class PriceFormManager : FormManager
    {
        PriceAppService AppService;

        public PriceFormManager(PriceAppService priceAppService)
        {
            AppService = priceAppService;
        }

        public override void Add()
        {
            PriceDialog priceDialog = new PriceDialog(AppService);

            DialogResult result = priceDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                AppService.Add(priceDialog.addCommand);
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
