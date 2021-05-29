using System;
using System.Collections.Generic;
using System.Text;

namespace Restoran.ViewModel
{
	public class MainWindowViewModel : BindableBase
	{
		private GradViewModel gradViewModel = new GradViewModel();

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

        public void Kartice(string s)
        {
            switch (s)
            {
                case "NetworkData":
                    if (TrenutniViewModel == gradViewModel)
                    {
                        break;
                    }
                    TrenutniViewModel = gradViewModel;
                    break;
            }
        }
    }
}
