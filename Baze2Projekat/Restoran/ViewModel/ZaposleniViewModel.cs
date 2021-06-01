using RestoranDB;
using RestoranDB.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace Restoran.ViewModel
{
	public class ZaposleniViewModel : BindableBase
	{
		public MyICommand DodajCommand { get; set; }
		public MyICommand IzbrisiCommand { get; set; }
		public MyICommand AzurirajCommand { get; set; }
		public MyICommand DobaviCommand { get; set; }
		public MyICommand DobaviSveCommand { get; set; }
		public ZaposleniService Service;
		public RestoranService ServiceRestoran;
		public RadiService ServiceRadi;
		public ObservableCollection<Zaposleni> sviZaposleni { get; set; }
		public ObservableCollection<int> sviRestorani { get; set; }

		#region private
		private string addJMBG;
		private string addTip;
		private string addIme;
		private string addPrezime;
		private string addIDRestoran;
		private string deleteJMBG;
		private string updateJMBG;
		private string updateTip;
		private string updateIme;
		private string updatePrezime;
		private string getJMBG;
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

		public string AddTip
		{
			get
			{
				return addTip;
			}
			set
			{
				if (value != addTip)
				{
					addTip = value;
					OnPropertyChanged("AddTip");
				}
			}
		}
		public string AddIme
		{
			get
			{
				return addIme;
			}
			set
			{
				if (value != addIme)
				{
					addIme = value;
					OnPropertyChanged("AddIme");
				}
			}
		}

		public string AddPrezime
		{
			get
			{
				return addPrezime;
			}
			set
			{
				if (value != addPrezime)
				{
					addPrezime = value;
					OnPropertyChanged("AddPrezime");
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

		public string UpdateJMBG
		{
			get
			{
				return updateJMBG;
			}
			set
			{
				if (value != updateJMBG)
				{
					updateJMBG = value;
					OnPropertyChanged("UpdateJMBG");
				}
			}
		}

		public string UpdateTip
		{
			get
			{
				return updateTip;
			}
			set
			{
				if (value != updateTip)
				{
					updateTip = value;
					OnPropertyChanged("UpdateTip");
				}
			}
		}
		public string UpdateIme
		{
			get
			{
				return updateIme;
			}
			set
			{
				if (value != updateIme)
				{
					updateIme = value;
					OnPropertyChanged("UpdateIme");
				}
			}
		}

		public string UpdatePrezime
		{
			get
			{
				return updatePrezime;
			}
			set
			{
				if (value != updatePrezime)
				{
					updatePrezime = value;
					OnPropertyChanged("UpdatePrezime");
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
		#endregion

		public ZaposleniViewModel()
		{
			DodajCommand = new MyICommand(Dodaj);
			IzbrisiCommand = new MyICommand(Izbrisi);
			AzurirajCommand = new MyICommand(Azuriraj);
			DobaviCommand = new MyICommand(Dobavi);
			DobaviSveCommand = new MyICommand(DobaviSve);

			Service = new ZaposleniService();
			ServiceRestoran = new RestoranService();
			ServiceRadi = new RadiService();

			DobaviSveRestorane();
			DobaviSve();

			AddJMBG = "";
			AddTip = "";
			AddIme = "";
			AddPrezime = "";
			AddIDRestoran = "";
			DeleteJMBG = "";
			UpdateJMBG = "";
			UpdateTip = "";
			UpdateIme = "";
			UpdatePrezime = "";
			GetJMBG = "";
		}

		public void Dodaj()
		{
			if(addJMBG != "" && addTip != "" && addIme != "" && addPrezime != "" && addIDRestoran != "")
			{
				try
				{
					int jmbg = Int32.Parse(addJMBG);
					int IDRestoran = Int32.Parse(addIDRestoran);

					if(jmbg > 0)
					{
						string tip = addTip.Split(' ')[1];

						if (!Service.Dodaj(jmbg, tip, addIme, addPrezime))
						{
							MessageBox.Show("Greska pri dodavanju!", "Dodavanje novog zaposlenog", MessageBoxButton.OK, MessageBoxImage.Error);
						}
						else
						{
							if (!ServiceRadi.Dodaj(jmbg, IDRestoran))
							{
								MessageBox.Show("Greska pri dodavanju!", "Dodavanje novog zaposlenog", MessageBoxButton.OK, MessageBoxImage.Error);
							}
							else
							{
								DobaviSve();

								AddJMBG = "";
								AddTip = "";
								AddIme = "";
								AddPrezime = "";
								AddIDRestoran = "";
							}
						}
					}
					else
					{
						MessageBox.Show("Polje JMBG mora biti pozitivan broj!", "Dodavanje novog zaposlenog", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}
				catch
				{
					MessageBox.Show("Polje JMBG mora biti broj!", "Dodavanje novog zaposlenog", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBox.Show("Polja JMBG, Tip, Ime, Prezime i IDRestoran ne smeju biti prazna!", "Dodavanje novog zaposlenog", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void DobaviSve()
		{
			try
			{
				List<Zaposleni> listaZaposlenih = Service.DobaviSve();
				sviZaposleni = new ObservableCollection<Zaposleni>();

				foreach (Zaposleni zaposleni in listaZaposlenih)
				{
					sviZaposleni.Add(zaposleni);
				}
				OnPropertyChanged("sviZaposleni");
			}
			catch
			{
				MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih zaposlenih", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void Dobavi()
		{
			if (getJMBG != "")
			{
				try
				{
					int jmbg = Int32.Parse(getJMBG);

					if (jmbg > 0)
					{
						Zaposleni zaposleni = Service.Dobavi(jmbg);

						if (zaposleni == null)
						{
							MessageBox.Show("Greska pri dobavljanju zaposlenog!", "Dobavljanje zaposlenog", MessageBoxButton.OK, MessageBoxImage.Error);
						}
						else
						{
							sviZaposleni = new ObservableCollection<Zaposleni>();
							sviZaposleni.Add(zaposleni);
							OnPropertyChanged("sviZaposleni");

							GetJMBG = "";
						}
					}
					else
					{
						MessageBox.Show("Polje JMBG mora biti pozitivan broj!", "Dobavljanje zaposlenog", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}
				catch
				{
					MessageBox.Show("Polje JMBG mora biti broj!", "Dobavljanje zaposlenog", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBox.Show("Polje JMBG ne sme biti prazno!", "Dobavljanje zaposlenog", MessageBoxButton.OK, MessageBoxImage.Error);
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

		public void Izbrisi()
		{
			if(deleteJMBG != "")
			{
				try
				{
					int jmbg = Int32.Parse(deleteJMBG);

					if (jmbg > 0)
					{
						if (!Service.Izbrisi(jmbg))
						{
							MessageBox.Show("Unet je nepostojeci JMBG!", "Brisanje zaposlenog", MessageBoxButton.OK, MessageBoxImage.Error);
						}
						else
						{
							DobaviSve();

							DeleteJMBG = "";
						}
					}
					else
					{
						MessageBox.Show("Polje JMBG mora biti pozitivan broj!", "Brisanje zaposlenog", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}
				catch
				{
					MessageBox.Show("Polje JMBG mora biti broj!", "Brisanje zaposlenog", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBox.Show("Polje JMBG ne sme biti prazno!", "Brisanje zaposlenog", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void Azuriraj()
		{
			if(updateJMBG != "" && (updateTip != "" || updateIme != "" || updatePrezime != ""))
			{
				try
				{
					bool ispravanJMBG = true;
					int jmbg = Int32.Parse(updateJMBG);
					
					if (jmbg < 0)
					{
						ispravanJMBG = false;
						MessageBox.Show("Polje JMBG mora biti pozitivan broj!", "Azuriranje zaposlenog", MessageBoxButton.OK, MessageBoxImage.Error);
					}

					if (ispravanJMBG)
					{
						string tip = updateTip.Split(' ')[1];

						if (!Service.Azuriraj(jmbg, tip, updateIme, updatePrezime))
						{
							MessageBox.Show("Unet je nepostojeci JMBG!", "Azuriranje zaposlenog", MessageBoxButton.OK, MessageBoxImage.Error);
						}
						else
						{
							DobaviSve();

							UpdateJMBG = "";
							UpdateTip = "";
							UpdateIme = "";
							UpdatePrezime = "";
						}
					}
				}
				catch
				{
					MessageBox.Show("Polje JMBG mora biti broj!", "Azuriranje zaposlenog", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBox.Show("Polja JMBG i Tip, Ime ili Prezime ne smeju biti prazna!", "Azuriranje zaposlenog", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}
