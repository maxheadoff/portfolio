﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CashMachine
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Model.CashMachine Machine=null;
        public static CashMachine.Model.Pages CurrentOperation = Model.Pages.Welcome;
    }
}
