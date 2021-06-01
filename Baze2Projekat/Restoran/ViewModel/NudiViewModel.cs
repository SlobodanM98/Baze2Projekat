using RestoranDB;
using RestoranDB.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace Restoran.ViewModel
{
	public class NudiViewModel : BindableBase
	{
		public MyICommand DodajCommand { get; set; }
		public MyICommand IzbrisiCommand { get; set; }
		public MyICommand DobaviCommand { get; set; }
		public MyICommand DobaviSveCommand { get; set; }
		public NudiService Service;
		public ProizvodService ServiceProizvod;
		public RestoranService ServiceRestoran;
		public ObservableCollection<Nudi> sviNudi { get; set; }
		public ObservableCollection<string> sviProizvodi { get; set; }
		public ObservableCollection<int> sviRestorani { get; set; }

		#region private
		private string addNaziv;
		private string addIDRestoran;
		private string deleteNaziv;
		private string deleteIDRestoran;
		private string getNaziv;
		private string getIDRestoran;
		#endregion

		#region public
		public string AddNaziv
		{
			get
			{
				return addNaziv;
			}
			set
			{
				if (value != addNaziv)
				{
					addNaziv = value;
					OnPropertyChanged("AddNaziv");
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

		public string DeleteNaziv
		{
			get
			{
				return deleteNaziv;
			}
			set
			{
				if (value != deleteNaziv)
				{
					deleteNaziv = value;
					OnPropertyChanged("DeleteNaziv");
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

		public string GetNaziv
		{
			get
			{
				return getNaziv;
			}
			set
			{
				if (value != getNaziv)
				{
					getNaziv = value;
					OnPropertyChanged("GetNaziv");
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

		public NudiViewModel()
		{
			DodajCommand = new MyICommand(Dodaj);
			IzbrisiCommand = new MyICommand(Izbrisi);
			DobaviCommand = new MyICommand(Dobavi);
			DobaviSveCommand = new MyICommand(DobaviSve);

			Service = new NudiService();
			ServiceProizvod = new ProizvodService();
			ServiceRestoran = new RestoranService();

			DobaviSveRestorane();
			DobaviSveProizvode();
			DobaviSve();

			AddNaziv = "";
			AddIDRestoran = "";
			DeleteNaziv = "";
			DeleteIDRestoran = "";
			GetNaziv = "";
			GetIDRestoran = "";
		}

		public void Dodaj()
		{
			if (addNaziv != "" && addIDRestoran != "")
			{
				int IDRestoran = Int32.Parse(addIDRestoran);

				if (!Service.Dodaj(IDRestoran, addNaziv))
				{
					MessageBox.Show("Greska pri dodavanju nudjenja!", "Dodavanje novog nudjenja", MessageBoxButton.OK, MessageBoxImage.Error);
				}
				else
				{
					DobaviSve();
					AddNaziv = "";
					AddIDRestoran = "";
				}
			}
			else
			{
				MessageBox.Show("Polja Naziv i IDRestoran ne smeju biti prazna!", "Dodavanje novog rada", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void Dobavi()
		{
			if (getNaziv != "" && getIDRestoran != "")
			{
				int IDRestoran = Int32.Parse(getIDRestoran);

				Nudi nudi = Service.Dobavi(IDRestoran, getNaziv);

				if (nudi == null)
				{
					MessageBox.Show("Greska pri dobavljanju nudjenja!", "Dobavljanje nudjenja", MessageBoxButton.OK, MessageBoxImage.Error);
				}
				else
				{
					sviNudi = new ObservableCollection<Nudi>();
					sviNudi.Add(nudi);
					OnPropertyChanged("sviNudi");

					GetNaziv = "";
					GetIDRestoran = "";
				}
			}
			else
			{
				MessageBox.Show("Polja Naziv i IDRestoran ne smeju biti prazna!", "Dobavljanje rada", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void DobaviSve()
		{
			try
			{
				List<Nudi> listaNudi = Service.DobaviSve();
				sviNudi = new ObservableCollection<Nudi>();

				foreach (Nudi nudi in listaNudi)
				{
					sviNudi.Add(nudi);
				}
				OnPropertyChanged("sviNudi");
			}
			catch
			{
				MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih nudjenja", MessageBoxButton.OK, MessageBoxImage.Error);
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

		public void DobaviSveProizvode()
		{
			try
			{
				List<Proizvod> listaProizvoda = ServiceProizvod.DobaviSve();
				sviProizvodi = new ObservableCollection<string>();

				foreach (Proizvod proizvod in listaProizvoda)
				{
					sviProizvodi.Add(proizvod.Naziv);
				}
				OnPropertyChanged("sviProizvodi");
			}
			catch
			{
				MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih proizvoda", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void Izbrisi()
		{
			if (deleteNaziv != "" && deleteIDRestoran != "")
			{
				int IDRestoran = Int32.Parse(deleteIDRestoran);

				if (!Service.Izbrisi(IDRestoran, deleteNaziv))
				{
					MessageBox.Show("Unet je nepostojeci Naziv i/ili IDRestoran!", "Brisanje rada", MessageBoxButton.OK, MessageBoxImage.Error);
				}
				else
				{
					DobaviSve();
					DeleteNaziv = "";
					DeleteIDRestoran = "";
				}
			}
			else
			{
				MessageBox.Show("Polja Naziv i IDRestoran ne smeju biti prazna!", "Brisanje nudjenja", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}
