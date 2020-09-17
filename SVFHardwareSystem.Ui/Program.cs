﻿using SVFHardwareSystem.Services;
using SVFHardwareSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace SVFHardwareSystem.Ui
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var form = UnityConfig
                .Register().Resolve<frmCustomers>();
            Application.Run(form);
        }
    }
}
