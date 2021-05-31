using RestoranDB;
using RestoranDB.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace Restoran.ViewModel
{
	public class RadiViewModel : BindableBase
	{
		public MyICommand DodajCommand { get; set; }
		public MyICommand IzbrisiCommand { get; set; }
		public MyICommand DobaviCommand { get; set; }
		public MyICommand DobaviSveCommand { get; set; }
		public RadiService Service;
		public ZaposleniService ServiceZaposleni;
		public RestoranService ServiceRestoran;
		public ObservableCollection<Radi> sviRadovi { get; set; }
		public ObservableCollection<int> sviZaposleni { get; set; }
		public ObservableCollection<int> sviRestorani { get; set; }

		#region private
		private string addJMBG;
		private string addIDRestoran;
		private string deleteJMBG;
		private string deleteIDRestoran;
		private string getJMBG;
		private string getIDRestoran;
		#endregion

		#region public
		public string AddJMBG
		{
			get
			{
				return addJMBG;
			}
			set
			{
				if (value != addJMBG)
				{
					addJMBG = value;
					OnPropertyChanged("AddJMBG");
				}
			}
		}

		public string AddIDRestoran
		{
			get
			{
				return addIDRestoran;
			}
			set
			{
				if (value != addIDRestoran)
				{
					addIDRestoran = value;
					OnPropertyChanged("AddIDRestoran");
				}
			}
		}

		public string DeleteJMBG
		{
			get
			{
				return deleteJMBG;
			}
			set
			{
				if (value != deleteJMBG)
				{
					deleteJMBG = value;
					OnPropertyChanged("DeleteJMBG");
				}
			}
		}

		public string DeleteIDRestoran
		{
			get
			{
				return deleteIDRestoran;
			}
			set
			{
				if (value != deleteIDRestoran)
				{
					deleteIDRestoran = value;
					OnPropertyChanged("DeleteIDRestoran");
				}
			}
		}

		public string GetJMBG
		{
			get
			{
				return getJMBG;
			}
			set
			{
				if (value != getJMBG)
				{
					getJMBG = value;
					OnPropertyChanged("GetJMBG");
				}
			}
		}

		public string GetIDRestoran
		{
			get
			{
				return getIDRestoran;
			}
			set
			{
				if (value != getIDRestoran)
				{
					getIDRestoran = value;
					OnPropertyChanged("GetIDRestoran");
				}
			}
		}
		#endregion

		public RadiViewModel()
		{
			DodajCommand = new MyICommand(Dodaj);
			IzbrisiCommand = new MyICommand(Izbrisi);
			DobaviCommand = new MyICommand(Dobavi);
			DobaviSveCommand = new MyICommand(DobaviSve);

			Service = new RadiService();
			ServiceZaposleni = new ZaposleniService();
			ServiceRestoran = new RestoranService();

			DobaviSveRestorane();
			DobaviSveZaposlene();
			DobaviSve();

			addJMBG = "";
			addIDRestoran = "";
			deleteJMBG = "";
			deleteIDRestoran = "";
			getJMBG = "";
			getIDRestoran = "";
		}

		public void Dodaj()
		{
			if(addJMBG != "" && addIDRestoran != "")
			{
				int jmbg = Int32.Parse(addJMBG);
				int IDRestoran = Int32.Parse(addIDRestoran);

				if(!Service.Dodaj(jmbg, IDRestoran))
				{
					MessageBox.Show("Greska pri dodavanju rada!", "Dodavanje novog rada", MessageBoxButton.OK, MessageBoxImage.Error);
				}
				else
				{
					DobaviSve();
					AddJMBG = "";
					AddIDRestoran = "";
				}
			}
			else
			{
				MessageBox.Show("Polja JMBG i IDRestoran ne smeju biti prazna!", "Dodavanje novog rada", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void DobaviSve()
		{
			try
			{
				List<Radi> listaRadova = Service.DobaviSve();
				sviRadovi = new ObservableCollection<Radi>();

				foreach (Radi radi in listaRadova)
				{
					sviRadovi.Add(radi);
				}
				OnPropertyChanged("sviRadovi");
			}
			catch
			{
				MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih radova", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void Dobavi()
		{
			if (getJMBG != "" && getIDRestoran != "")
			{
				int jmbg = Int32.Parse(getJMBG);
				int IDRestoran = Int32.Parse(getIDRestoran);

				Radi radi = Service.Dobavi(jmbg, IDRestoran);

				if (radi == null)
				{
					MessageBox.Show("Greska pri dobavljanju rada!", "Dobavljanje rada", MessageBoxButton.OK, MessageBoxImage.Error);
				}
				else
				{
					sviRadovi = new ObservableCollection<Radi>();
					sviRadovi.Add(radi);
					OnPropertyChanged("sviRadovi");

					GetJMBG = "";
					GetIDRestoran = "";
				}
			}
			else
			{
				MessageBox.Show("Polja JMBG i IDRestoran ne smeju biti prazna!", "Dobavljanje rada", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void DobaviSveRestorane()
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

		public void DobaviSveZaposlene()
		{
			try
			{
				List<Zaposleni> listaZaposlenih = ServiceZaposleni.DobaviSve();
				sviZaposleni = new ObservableCollection<int>();

				foreach (Zaposleni zaposleni in listaZaposlenih)
				{
					sviZaposleni.Add(zaposleni.JMBG);
				}
				OnPropertyChanged("sviZaposleni");
			}
			catch
			{
				MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih zaposlenih", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void Izbrisi()
		{
			if(deleteJMBG != "" && deleteIDRestoran != "")
			{
				int jmbg = Int32.Parse(deleteJMBG);
				int IDRestoran = Int32.Parse(deleteIDRestoran);

				if (!Service.Izbrisi(jmbg, IDRestoran))
				{
					MessageBox.Show("Unet je nepostojeci JMBG i/ili IDRestoran!", "Brisanje rada", MessageBoxButton.OK, MessageBoxImage.Error);
				}
				else
				{
					DobaviSve();
					DeleteJMBG = "";
					DeleteIDRestoran = "";
				}
			}
			else
			{
				MessageBox.Show("Polja JMBG i IDRestoran ne smeju biti prazna!", "Brisanje rada", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}
