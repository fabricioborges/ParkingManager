using ParkingManager.Applications.Features.Payments;
using ParkingManager.Applications.Features.Payments.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingManager.Presentation.Features.Payments
{
    public class PaymentFormManager : FormManager
    {
        PaymentAppService AppService;
        PaymentViewModel PaymentViewModel;

        public PaymentFormManager(PaymentAppService appService, PaymentViewModel paymentViewSelected)
        {
            AppService = appService;
            PaymentViewModel = paymentViewSelected;
        }

        public override void Add()
        {
            PaymentExitDialog paymentExitDialog = new PaymentExitDialog(AppService, PaymentViewModel);

            DialogResult result = paymentExitDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                AppService.Update(paymentExitDialog.updateCommand);
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
