﻿using ParkingManager.Application.Config;
using ParkingManager.Application.Features.Prices;
using ParkingManager.Applications.Features.Payments;
using ParkingManager.Applications.Features.Vehicles;
using ParkingManager.Infra.ORM.Context;
using ParkingManager.Infra.ORM.Features.Payments;
using ParkingManager.Infra.ORM.Features.Prices;
using ParkingManager.Infra.ORM.Features.Vehicles;
using ParkingManager.Presentation.Features.Payments;
using ParkingManager.Presentation.Features.Prices;
using ParkingManager.Presentation.Features.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingManager.Presentation
{
    static class Program
    {
        private static VehicleRepository VehicleRepository;
        private static VehicleAppService VehicleAppService;
        private static PriceRepository PriceRepository;
        private static PriceAppService PriceAppService;
        private static PaymentRepository PaymentRepository;
        private static PaymentAppService PaymentAppService;
        private static ParkingManagerContext Context;
        
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            AutoMapperConfig.Initialize();
            Context = new ParkingManagerContext();
            VehicleRepository = new VehicleRepository(Context);
            VehicleAppService = new VehicleAppService(VehicleRepository);
            PriceRepository = new PriceRepository(Context);
            PriceAppService = new PriceAppService(PriceRepository);
            PaymentRepository = new PaymentRepository(Context);
            PaymentAppService = new PaymentAppService(PaymentRepository, VehicleRepository, PriceRepository);
            System.Windows.Forms.Application.Run(new PaymentDialog(PriceAppService, VehicleAppService, PaymentAppService));
        }
    }
}
