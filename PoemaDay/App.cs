using System;
using System.Diagnostics;
using MvvmCross.ViewModels;
using PoemaDay.viewmodel;

namespace PoemaDay
{
    public partial class App : MvxApplication
    {

        public override void Initialize()
        {
            RegisterAppStart<MainPageVM>();
        }

    }
}
