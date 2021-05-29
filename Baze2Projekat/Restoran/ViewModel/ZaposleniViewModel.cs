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
		public ZaposleniService Service;
		public ObservableCollection<Zaposleni> sviZaposleni { get; set; }

		#region private
		private string addJMBG;
		private string addTip;
		private string addIme;
		private string addPrezime;
		private string deleteJMBG;
		private string updateJMBG;
		private string updateTip;
		private string updateIme;
		private string updatePrezime;
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
		#endregion

		public ZaposleniViewModel()
		{
			DodajCommand = new MyICommand(Dodaj);
			IzbrisiCommand = new MyICommand(Izbrisi);
			AzurirajCommand = new MyICommand(Azuriraj);

			Service = new ZaposleniService();

			if(sviZaposleni == null)
			{
				DobaviSve();
			}

			addJMBG = "";
			addTip = "";
			addIme = "";
			addPrezime = "";
			deleteJMBG = "";
			updateJMBG = "";
			updateTip = "";
			updateIme = "";
			updatePrezime = "";
		}

		public void Dodaj()
		{
			if(addJMBG != "" && addTip != "" && addIme != "" && addPrezime != "")
			{
				try
				{
					int jmbg = Int32.Parse(addJMBG);

					if(jmbg > 0)
					{
						addTip = addTip.Split(' ')[1];
						bool izlaz = Service.Dodaj(jmbg, addTip, addIme, addPrezime);

						if (!izlaz)
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
				MessageBox.Show("Polja JMBG, Tip, Ime i Prezime ne smeju biti prazna!", "Dodavanje novog zaposlenog", MessageBoxButton.OK, MessageBoxImage.Error);
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

		public void Izbrisi()
		{
			if(deleteJMBG != "")
			{
				try
				{
					int jmbg = Int32.Parse(deleteJMBG);

					if (jmbg > 0)
					{
						bool izlaz = Service.Izbrisi(jmbg);

						if (!izlaz)
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
						if (updateTip != "" && updateTip.Split(' ').Length > 1)
						{
							updateTip = updateTip.Split(' ')[1];
						}

						bool izlaz = Service.Azuriraj(jmbg, updateTip, updateIme, updatePrezime);

						if (!izlaz)
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
