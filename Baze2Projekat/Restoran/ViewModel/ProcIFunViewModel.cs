using RestoranDB;
using RestoranDB.PomocneKlase;
using RestoranDB.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace Restoran.ViewModel
{
	public class ProcIFunViewModel : BindableBase
	{
		public MyICommand ProcKuvarCommand { get; set; }
		public MyICommand ProcRestoranCommand { get; set; }
		public MyICommand FunCenaCommand { get; set; }
		public MyICommand FunBrojCommand { get; set; }
		public ProcIFunService Service { get; set; }
		public MusterijaService ServiceMusterija;
		public RestoranService ServiceRestoran;
		public ObservableCollection<int> sveMusterije { get; set; }
		public ObservableCollection<int> sviRestorani { get; set; }
		public ObservableCollection<KuvarPodaci> sviKuvari { get; set; }
		public ObservableCollection<RestoranPodaci> sviRestoraniMusterije { get; set; }

		#region private
		private string procRedniBrojKuvar;
		private string procRedniBrojRestoran;
		private string funRedniBroj;
		private string funIDRestoran;
		private string funUkupnaCena;
		private string funUkupnoLjudi;
		#endregion

		#region public
		public string ProcRedniBrojKuvar
		{
			get
			{
				return procRedniBrojKuvar;
			}
			set
			{
				if (value != procRedniBrojKuvar)
				{
					procRedniBrojKuvar = value;
					OnPropertyChanged("ProcRedniBrojKuvar");
				}
			}
		}

		public string ProcRedniBrojRestoran
		{
			get
			{
				return procRedniBrojRestoran;
			}
			set
			{
				if (value != procRedniBrojRestoran)
				{
					procRedniBrojRestoran = value;
					OnPropertyChanged("ProcRedniBrojRestoran");
				}
			}
		}

		public string FunRedniBroj
		{
			get
			{
				return funRedniBroj;
			}
			set
			{
				if (value != funRedniBroj)
				{
					funRedniBroj = value;
					OnPropertyChanged("FunRedniBroj");
				}
			}
		}

		public string FunIDRestoran
		{
			get
			{
				return funIDRestoran;
			}
			set
			{
				if (value != funIDRestoran)
				{
					funIDRestoran = value;
					OnPropertyChanged("FunIDRestoran");
				}
			}
		}

		public string FunUkupnaCena
		{
			get
			{
				return funUkupnaCena;
			}
			set
			{
				if (value != funUkupnaCena)
				{
					funUkupnaCena = value;
					OnPropertyChanged("FunUkupnaCena");
				}
			}
		}

		public string FunUkupnoLjudi
		{
			get
			{
				return funUkupnoLjudi;
			}
			set
			{
				if (value != funUkupnoLjudi)
				{
					funUkupnoLjudi = value;
					OnPropertyChanged("FunUkupnoLjudi");
				}
			}
		}
		#endregion

		public ProcIFunViewModel()
		{
			ProcKuvarCommand = new MyICommand(ProcKuvar);
			ProcRestoranCommand = new MyICommand(ProcRestoran);
			FunCenaCommand = new MyICommand(FunCena);
			FunBrojCommand = new MyICommand(FunBroj);

			Service = new ProcIFunService();
			ServiceMusterija = new MusterijaService();
			ServiceRestoran = new RestoranService();

			DobaviSveMusterije();
			DobaviSveRestorane();

			ProcRedniBrojKuvar = "";
			ProcRedniBrojRestoran = "";
			FunRedniBroj = "";
			FunIDRestoran = "";
			FunUkupnaCena = "";
			FunUkupnoLjudi = "";
	}

		private void FunBroj()
		{
			if (funIDRestoran != "")
			{
				FunUkupnoLjudi = Service.FunBrojLjudi(Int32.Parse(funIDRestoran)).ToString();

				FunIDRestoran = "";
			}
			else
			{
				MessageBox.Show("Polje IDRestoran ne sme biti prazno!", "Funkcija broj ljudi za stolovima", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void FunCena()
		{
			if (funRedniBroj != "")
			{
				FunUkupnaCena = Service.FunUkupnaCena(Int32.Parse(funRedniBroj)).ToString();

				FunRedniBroj = "";
			}
			else
			{
				MessageBox.Show("Polje Redni broj ne sme biti prazno!", "Funkcija ukupna cena", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void ProcRestoran()
		{
			if (procRedniBrojRestoran != "")
			{
				sviRestoraniMusterije = new ObservableCollection<RestoranPodaci>();
				List<RestoranPodaci> podaci = Service.ProcRestoran(Int32.Parse(procRedniBrojRestoran));

				foreach (RestoranPodaci restoranPodaci in podaci)
				{
					sviRestoraniMusterije.Add(restoranPodaci);
				}

				OnPropertyChanged("sviRestoraniMusterije");
				ProcRedniBrojRestoran = "";
			}
			else
			{
				MessageBox.Show("Polje Redni broj ne sme biti prazno!", "Procedura restoran", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void ProcKuvar()
		{
			if(procRedniBrojKuvar != "")
			{
				sviKuvari = new ObservableCollection<KuvarPodaci>();
				List<KuvarPodaci> podaci = Service.ProcKuvar(Int32.Parse(procRedniBrojKuvar));

				foreach(KuvarPodaci kuvarPodaci in podaci)
				{
					sviKuvari.Add(kuvarPodaci);
				}

				OnPropertyChanged("sviKuvari");
				ProcRedniBrojKuvar = "";
			}
			else
			{
				MessageBox.Show("Polje Redni broj ne sme biti prazno!", "Procedura kuvara", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void DobaviSveMusterije()
		{
			try
			{
				List<Musterija> listaMusterija = ServiceMusterija.DobaviSve();
				sveMusterije = new ObservableCollection<int>();

				foreach (Musterija musterija in listaMusterija)
				{
					sveMusterije.Add(musterija.RedniBroj);
				}
				OnPropertyChanged("sveMusterije");
			}
			catch
			{
				MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih musterija", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void DobaviSveRestorane()
		{
			try
			{
				List<RestoranDB.Restoran> listaRestorana = ServiceRestoran.DobaviSve();
				sviRestorani = new ObservableCollection<int>();

				foreach (RestoranDB.Restoran restoran in listaRestorana)
				{
					sviRestorani.Add(restoran.IDRestorana);
				}
				OnPropertyChanged("sviRestorani");
			}
			catch
			{
				MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih restorana", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}
