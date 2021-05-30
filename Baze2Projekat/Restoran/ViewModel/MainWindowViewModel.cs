﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Restoran.ViewModel
{
	public class MainWindowViewModel : BindableBase
	{
		private GradViewModel gradViewModel = new GradViewModel();
        private ProizvodViewModel proizvodViewModel = new ProizvodViewModel();
        private ZaposleniViewModel zaposleniViewModel = new ZaposleniViewModel();
        private RestoranViewModel restoranViewModel = new RestoranViewModel();
        private StoViewModel stoViewModel = new StoViewModel();

		private BindableBase trenutniViewModel;

		public MyICommand<string> KarticeCommand { get; private set; }

        public BindableBase TrenutniViewModel
        {
            get
            {
                return trenutniViewModel;
            }
            set
            {
                SetProperty(ref trenutniViewModel, value);
            }
        }

        public MainWindowViewModel(){
			trenutniViewModel = gradViewModel;
            KarticeCommand = new MyICommand<string>(Kartice);
        }

        public void Kartice(string naziv)
        {
            switch (naziv)
            {
                case "Grad":
                    if (TrenutniViewModel == gradViewModel)
                    {
                        break;
                    }
                    TrenutniViewModel = gradViewModel;
                    break;
                case "Proizvod":
                    if (TrenutniViewModel == proizvodViewModel)
                    {
                        break;
                    }
                    TrenutniViewModel = proizvodViewModel;
                    break;
                case "Zaposleni":
                    if (TrenutniViewModel == zaposleniViewModel)
                    {
                        break;
                    }
                    TrenutniViewModel = zaposleniViewModel;
                    break;
                case "Restoran":
                    if (TrenutniViewModel == restoranViewModel)
                    {
                        break;
                    }
                    TrenutniViewModel = restoranViewModel;
                    break;
                case "Sto":
                    if (TrenutniViewModel == stoViewModel)
                    {
                        break;
                    }
                    TrenutniViewModel = stoViewModel;
                    break;
            }
        }
    }
}
