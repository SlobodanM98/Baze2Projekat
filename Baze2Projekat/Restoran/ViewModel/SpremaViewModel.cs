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
		public ProizvodService ServiceProizvod;
		public ObservableCollection<Sprema> svaSpremanja { get; set; }
		public ObservableCollection<int> sviKuvari { get; set; }
		public ObservableCollection<string> sviProizvodi { get; set; }

		#region private
		private string addJMBG;
		private string addNaziv;
		private string deleteJMBG;
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
		#endregion

		public SpremaViewModel()
		{
			DodajCommand = new MyICommand(Dodaj);
			IzbrisiCommand = new MyICommand(Izbrisi);

			Service = new SpremaService();
			ServiceZaposleni = new ZaposleniService();
			ServiceProizvod = new ProizvodService();

			DobaviSveKuvare();
			DobaviSveProizvode();
			DobaviSve();

			addJMBG = "";
			addNaziv = "";
			deleteJMBG = "";
			deleteNaziv = "";
		}

		public void Dodaj()
		{
			if(addJMBG != "" && addNaziv != "")
			{
				int jmbg = Int32.Parse(addJMBG);

				if (!Service.Dodaj(jmbg, addNaziv))
				{
					MessageBox.Show("Greska pri dodavanju!", "Dodavanje novog spremanja", MessageBoxButton.OK, MessageBoxImage.Error);
				}
				else
				{
					DobaviSve();
					AddJMBG = "";
					AddNaziv = "";
				}
			}
			else
			{
				MessageBox.Show("Polja JMBG i Naziv ne smeju biti prazna!", "Dodavanje novog spremanja", MessageBoxButton.OK, MessageBoxImage.Error);
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
			if (deleteJMBG != "" && deleteNaziv != "")
			{
				try
				{
					int jmbg = Int32.Parse(deleteJMBG);

					if (jmbg > 0)
					{
						if (!Service.Izbrisi(jmbg, deleteNaziv))
						{
							MessageBox.Show("Uneti je nepostojeci JMBG i/ili Naziv!", "Brisanje spremanja", MessageBoxButton.OK, MessageBoxImage.Error);
						}
						else
						{
							DobaviSve();
							DeleteJMBG = "";
							DeleteNaziv = "";
						}
					}
					else
					{
						MessageBox.Show("Polje JMBG mora biti pozitivan broj!", "Brisanje spremanja", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}
				catch
				{
					MessageBox.Show("Polje JMBG mora biti broj!", "Brisanje spremanja", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBox.Show("Polja JMBG i Naziv ne smeju biti prazna!", "Brisanje spremanja", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}
