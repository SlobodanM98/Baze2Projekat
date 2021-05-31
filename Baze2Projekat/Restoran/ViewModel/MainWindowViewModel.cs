using System;
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
        private MusterijaViewModel musterijaViewModel = new MusterijaViewModel();
        private SpremaViewModel spremaViewModel = new SpremaViewModel();
        private RadiViewModel radiViewModel = new RadiViewModel();
        private NudiViewModel nudiViewModel = new NudiViewModel();
        private KupujeViewModel kupujeViewModel = new KupujeViewModel();

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
                case "Musterija":
                    if (TrenutniViewModel == musterijaViewModel)
                    {
                        break;
                    }
                    TrenutniViewModel = musterijaViewModel;
                    break;
                case "Sprema":
                    if (TrenutniViewModel == spremaViewModel)
                    {
                        break;
                    }
                    TrenutniViewModel = spremaViewModel;
                    break;
                case "Radi":
                    if (TrenutniViewModel == radiViewModel)
                    {
                        break;
                    }
                    TrenutniViewModel = radiViewModel;
                    break;
                case "Nudi":
                    if (TrenutniViewModel == nudiViewModel)
                    {
                        break;
                    }
                    TrenutniViewModel = nudiViewModel;
                    break;
                case "Kupuje":
                    if (TrenutniViewModel == kupujeViewModel)
                    {
                        break;
                    }
                    TrenutniViewModel = kupujeViewModel;
                    break;
            }
        }
    }
}
