using RestoranDB;
using RestoranDB.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace Restoran.ViewModel
{
	public class KupujeViewModel : BindableBase
	{
		public MyICommand DodajCommand { get; set; }
		public MyICommand IzbrisiCommand { get; set; }
		public KupujeService Service;
		public RestoranService ServiceRestoran;
		public MusterijaService ServiceMusterija;
		public SpremaService ServiceSprema;
		public ObservableCollection<Kupuje> sveKupovine { get; set; }
		public ObservableCollection<int> sveMusterije { get; set; }
		public ObservableCollection<int> sviRestorani { get; set; }
		public ObservableCollection<int> sviKuvari { get; set; }
		public ObservableCollection<string> sviProizvodi { get; set; }

		#region private
		private string addJMBG;
		private string addIDRestoran;
		private string addRedniBroj;
		private string addNaziv;
		private string deleteJMBG;
		private string deleteIDRestoran;
		private string deleteRedniBroj;
		private string deleteNaziv;
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
					if(addIDRestoran != "" && addIDRestoran != null)
					{
						DobaviSveProizvode(addIDRestoran);
					}
					OnPropertyChanged("AddIDRestoran");
				}
			}
		}

		public string AddRedniBroj
		{
			get
			{
				return addRedniBroj;
			}
			set
			{
				if (value != addRedniBroj)
				{
					addRedniBroj = value;
					if(addRedniBroj != "" && addRedniBroj != null)
					{
						DobaviSveRestorane(addRedniBroj);
					}
					OnPropertyChanged("AddRedniBroj");
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
					if(addNaziv != "" && addNaziv != null)
					{
						DobaviSveKuvare(addNaziv, addIDRestoran);
					}
					OnPropertyChanged("AddNaziv");
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
					if (deleteIDRestoran != "" && deleteIDRestoran != null)
					{
						DobaviSveProizvode(deleteIDRestoran);
					}
					OnPropertyChanged("DeleteIDRestoran");
				}
			}
		}

		public string DeleteRedniBroj
		{
			get
			{
				return deleteRedniBroj;
			}
			set
			{
				if (value != deleteRedniBroj)
				{
					deleteRedniBroj = value;
					if (deleteRedniBroj != "" && deleteRedniBroj != null)
					{
						DobaviSveRestorane(deleteRedniBroj);
					}
					OnPropertyChanged("DeleteRedniBroj");
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
					if (deleteNaziv != "" && deleteNaziv != null)
					{
						DobaviSveKuvare(deleteNaziv, deleteIDRestoran);
					}
					OnPropertyChanged("DeleteNaziv");
				}
			}
		}
		#endregion

		public KupujeViewModel()
		{
			DodajCommand = new MyICommand(Dodaj);
			IzbrisiCommand = new MyICommand(Izbrisi);

			Service = new KupujeService();
			ServiceRestoran = new RestoranService();
			ServiceMusterija = new MusterijaService();
			ServiceSprema = new SpremaService();

			DobaviSveMusterije();
			DobaviSve();

			addJMBG = "";
			addIDRestoran = "";
			addRedniBroj = "";
			addNaziv = "";
			deleteJMBG = "";
			deleteIDRestoran = "";
			deleteRedniBroj = "";
			deleteNaziv = "";
		}

		public void Dodaj()
		{
			if (addRedniBroj != "" && addIDRestoran != "" && addNaziv != "" && addJMBG != "")
			{
				int jmbg = Int32.Parse(addJMBG);
				int IDRestoran = Int32.Parse(addIDRestoran);
				int redniBroj = Int32.Parse(addRedniBroj);

				if (!Service.Dodaj(redniBroj, jmbg, IDRestoran, addNaziv))
				{
					MessageBox.Show("Greska pri dodavanju kupovine!", "Dodavanje nove kupovine", MessageBoxButton.OK, MessageBoxImage.Error);
				}
				else
				{
					DobaviSve();
					AddJMBG = "";
					AddIDRestoran = "";
					AddRedniBroj = "";
					AddNaziv = "";

					sviRestorani = new ObservableCollection<int>();
					sviProizvodi = new ObservableCollection<string>();
					sviKuvari = new ObservableCollection<int>();
				}
			}
			else
			{
				MessageBox.Show("Polja Redni broj, IDRestoran, Naziv i JMBG ne smeju biti prazna!", "Dodavanje nove kupovine", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void DobaviSve()
		{
			try
			{
				List<Kupuje> listaKupovina = Service.DobaviSve();
				sveKupovine = new ObservableCollection<Kupuje>();

				foreach (Kupuje kupuje in listaKupovina)
				{
					sveKupovine.Add(kupuje);
				}
				OnPropertyChanged("sveKupovine");
			}
			catch
			{
				MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih kupovina", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void DobaviSveRestorane(string RedniBroj)
		{
			try
			{
				List<RestoranDB.Restoran> listaRestorana = ServiceRestoran.DobaviSve();
				sviRestorani = new ObservableCollection<int>();

				List<Musterija> listaMusterija = ServiceMusterija.DobaviSve();
				int redniBroj = Int32.Parse(RedniBroj);
				bool pronadjen = false;

				foreach (Musterija musterija in listaMusterija)
				{
					if(musterija.RedniBroj == redniBroj)
					{
						if(musterija.StoRestoranIDRestorana != null)
						{
							pronadjen = true;
							sviRestorani.Add((int)musterija.StoRestoranIDRestorana);
						}
						break;
					}
				}

				if (!pronadjen)
				{
					foreach (RestoranDB.Restoran restoran in listaRestorana)
					{
						sviRestorani.Add(restoran.IDRestorana);
					}
				}
				OnPropertyChanged("sviRestorani");
			}
			catch
			{
				MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih restorana", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void DobaviSveMusterije()
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

		public void DobaviSveProizvode(string idRestoran)
		{
			try
			{
				List<Sprema> listaSpremanja = ServiceSprema.DobaviSve();
				sviProizvodi = new ObservableCollection<string>();
				int IDRestoran = Int32.Parse(idRestoran);

				foreach (Sprema sprema in listaSpremanja)
				{
					if(sprema.NudiRestoranIDRestorana == IDRestoran && !sviProizvodi.Contains(sprema.NudiProizvodNaziv))
					{
						sviProizvodi.Add(sprema.NudiProizvodNaziv);
					}
				}
				OnPropertyChanged("sviProizvodi");
			}
			catch
			{
				MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih proizvoda", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void DobaviSveKuvare(string naziv, string idRestoran)
		{
			try
			{
				List<Sprema> listaSpremanja = ServiceSprema.DobaviSve();
				sviKuvari = new ObservableCollection<int>();
				int IDRestoran = Int32.Parse(idRestoran);

				foreach (Sprema sprema in listaSpremanja)
				{
					if (sprema.NudiRestoranIDRestorana == IDRestoran && sprema.NudiProizvodNaziv == naziv)
					{
						sviKuvari.Add(sprema.KuvarJMBG);
					}
				}
				OnPropertyChanged("sviKuvari");
			}
			catch
			{
				MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih kuvara", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void Izbrisi()
		{
			if (deleteRedniBroj != "" && deleteIDRestoran != "" && deleteNaziv != "" && deleteJMBG != "")
			{
				int jmbg = Int32.Parse(deleteJMBG);
				int IDRestoran = Int32.Parse(deleteIDRestoran);
				int redniBroj = Int32.Parse(deleteRedniBroj);

				if (!Service.Izbrisi(redniBroj, jmbg, IDRestoran, deleteNaziv))
				{
					MessageBox.Show("Ne postoji kupovina sa unetim podacima!", "Brisanje kupovine", MessageBoxButton.OK, MessageBoxImage.Error);
				}
				else
				{
					DobaviSve();
					DeleteJMBG = "";
					DeleteIDRestoran = "";
					DeleteRedniBroj = "";
					DeleteNaziv = "";

					sviRestorani = new ObservableCollection<int>();
					sviProizvodi = new ObservableCollection<string>();
					sviKuvari = new ObservableCollection<int>();
				}
			}
			else
			{
				MessageBox.Show("Polja Redni broj, IDRestoran, Naziv i JMBG ne smeju biti prazna!", "Brisanje kupovine", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}
