using RestoranDB;
using RestoranDB.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace Restoran.ViewModel
{
	public class SpremaViewModel : BindableBase
	{
		public MyICommand DodajCommand { get; set; }
		public MyICommand IzbrisiCommand { get; set; }
		public SpremaService Service;
		public ZaposleniService ServiceZaposleni;
		public NudiService ServiceNudi;
		public RadiService ServiceRadi;
		public ObservableCollection<Sprema> svaSpremanja { get; set; }
		public ObservableCollection<int> sviKuvari { get; set; }
		public ObservableCollection<string> sviProizvodi { get; set; }
		public ObservableCollection<int> sviRestorani { get; set; }

		#region private
		private string addJMBG;
		private string addNaziv;
		private string addIDRestoran;
		private string deleteJMBG;
		private string deleteNaziv;
		private string deleteIDRestoran;
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
					if(addJMBG != "" && addJMBG != null)
					{
						DobaviSveRestorane(addJMBG);
					}
					OnPropertyChanged("AddJMBG");
				}
			}
		}

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
					if (addIDRestoran != "" && addIDRestoran != null)
					{
						DobaviSveProizvode(addIDRestoran);
					}
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
					if(deleteJMBG != "" && deleteJMBG != null)
					{
						DobaviSveRestorane(deleteJMBG);
					}
					OnPropertyChanged("DeleteJMBG");
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
					if(deleteIDRestoran != "" && deleteIDRestoran != null)
					{
						DobaviSveProizvode(deleteIDRestoran);
					}
					OnPropertyChanged("DeleteIDRestoran");
				}
			}
		}
		#endregion

		public SpremaViewModel()
		{
			DodajCommand = new MyICommand(Dodaj);
			IzbrisiCommand = new MyICommand(Izbrisi);

			Service = new SpremaService();
			ServiceZaposleni = new ZaposleniService();
			ServiceNudi = new NudiService();
			ServiceRadi = new RadiService();

			DobaviSveKuvare();
			DobaviSve();

			addJMBG = "";
			addNaziv = "";
			deleteJMBG = "";
			deleteNaziv = "";
		}

		public void Dodaj()
		{
			if(addJMBG != "" && addNaziv != "" && addIDRestoran != "")
			{
				int jmbg = Int32.Parse(addJMBG);
				int IDRestoran = Int32.Parse(addIDRestoran);

				if (!Service.Dodaj(jmbg, addNaziv, IDRestoran))
				{
					MessageBox.Show("Greska pri dodavanju!", "Dodavanje novog spremanja", MessageBoxButton.OK, MessageBoxImage.Error);
				}
				else
				{
					DobaviSve();
					AddJMBG = "";
					AddNaziv = "";
					AddIDRestoran = "";

					sviRestorani = new ObservableCollection<int>();
					sviProizvodi = new ObservableCollection<string>();
				}
			}
			else
			{
				MessageBox.Show("Polja JMBG, Naziv i IDRestoran ne smeju biti prazna!", "Dodavanje novog spremanja", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void DobaviSve()
		{
			try
			{
				List<Sprema> listaSpremanja = Service.DobaviSve();
				svaSpremanja = new ObservableCollection<Sprema>();

				foreach (Sprema sprema in listaSpremanja)
				{
					svaSpremanja.Add(sprema);
				}
				OnPropertyChanged("svaSpremanja");
			}
			catch
			{
				MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih spremanja", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void DobaviSveKuvare()
		{
			try
			{
				List<Zaposleni> listaZaposlenih = ServiceZaposleni.DobaviSve();
				sviKuvari = new ObservableCollection<int>();

				foreach (Zaposleni zaposleni in listaZaposlenih)
				{
					if(zaposleni.Tip == "Kuvar")
					{
						sviKuvari.Add(zaposleni.JMBG);
					}
				}
				OnPropertyChanged("sviKuvari");
			}
			catch
			{
				MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih kuvara", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void DobaviSveRestorane(string JMBG)
		{
			try
			{
				List<Radi> listaRadi = ServiceRadi.DobaviSve();
				sviRestorani = new ObservableCollection<int>();

				foreach (Radi radi in listaRadi)
				{
					int jmbg = Int32.Parse(JMBG);
					if(radi.ZaposleniJMBG == jmbg)
					{
						sviRestorani.Add(radi.RestoranIDRestorana);
					}
				}
				OnPropertyChanged("sviRestorani");
			}
			catch
			{
				MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih restorana", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void DobaviSveProizvode(string IDRestoran)
		{
			try
			{
				List<Nudi> listaNudi = ServiceNudi.DobaviSve();
				sviProizvodi = new ObservableCollection<string>();

				foreach (Nudi nudi in listaNudi)
				{
					int id = Int32.Parse(IDRestoran);
					if(nudi.RestoranIDRestorana == id)
					{
						sviProizvodi.Add(nudi.ProizvodNaziv);
					}
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
			if (deleteJMBG != "" && deleteNaziv != "" && deleteIDRestoran != "")
			{
				int jmbg = Int32.Parse(deleteJMBG);
				int IDRestoran = Int32.Parse(deleteIDRestoran);

				if (!Service.Izbrisi(jmbg, deleteNaziv, IDRestoran))
				{
					MessageBox.Show("Uneti je nepostojeci JMBG i/ili Naziv!", "Brisanje spremanja", MessageBoxButton.OK, MessageBoxImage.Error);
				}
				else
				{
					DobaviSve();
					DeleteJMBG = "";
					DeleteNaziv = "";
					DeleteIDRestoran = "";

					sviRestorani = new ObservableCollection<int>();
					sviProizvodi = new ObservableCollection<string>();
				}
			}
			else
			{
				MessageBox.Show("Polja JMBG, Naziv i IDRestoran ne smeju biti prazna!", "Brisanje spremanja", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}
