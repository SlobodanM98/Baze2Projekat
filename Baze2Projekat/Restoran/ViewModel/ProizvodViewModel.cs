using RestoranDB;
using RestoranDB.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace Restoran.ViewModel
{
	public class ProizvodViewModel : BindableBase
	{
		public MyICommand DodajCommand { get; set; }
		public MyICommand IzbrisiCommand { get; set; }
		public MyICommand AzurirajCommand { get; set; }
		public MyICommand DobaviCommand { get; set; }
		public MyICommand DobaviSveCommand { get; set; }
		public ProizvodService Service;
		public ObservableCollection<Proizvod> sviProizvodi { get; set; }

		#region private
		private string addNaziv;
		private string addTip;
		private string addCena;
		private string deleteNaziv;
		private string updateNaziv;
		private string updateTip;
		private string updateCena;
		private string getNaziv;
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
		public string AddCena
		{
			get
			{
				return addCena;
			}
			set
			{
				if (value != addCena)
				{
					addCena = value;
					OnPropertyChanged("AddCena");
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

		public string UpdateNaziv
		{
			get
			{
				return updateNaziv;
			}
			set
			{
				if (value != updateNaziv)
				{
					updateNaziv = value;
					OnPropertyChanged("UpdateNaziv");
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
		public string UpdateCena
		{
			get
			{
				return updateCena;
			}
			set
			{
				if (value != updateCena)
				{
					updateCena = value;
					OnPropertyChanged("UpdateCena");
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
		#endregion

		public ProizvodViewModel()
		{
			DodajCommand = new MyICommand(Dodaj);
			IzbrisiCommand = new MyICommand(Izbrisi);
			AzurirajCommand = new MyICommand(Azuriraj);
			DobaviCommand = new MyICommand(Dobavi);
			DobaviSveCommand = new MyICommand(DobaviSve);

			Service = new ProizvodService();

			if(sviProizvodi == null)
			{
				DobaviSve();
			}

			AddNaziv = "";
			AddTip = "";
			AddCena = "";
			DeleteNaziv = "";
			UpdateNaziv = "";
			UpdateTip = "";
			UpdateCena = "";
			GetNaziv = "";
		}

		public void Dodaj()
		{
			if (addNaziv != "" && addTip != "" && addCena != "")
			{
				try
				{
					int cena = Int32.Parse(addCena);
					if(cena > 0)
					{
						string[] tekst = addTip.Split(' ');
						string tip = tekst[1];

						for (int i = 2; i < tekst.Length; i++)
						{
							tip += " " + tekst[i];
						}

						if (!Service.Dodaj(addNaziv, tip, cena))
						{
							MessageBox.Show("Greska pri dodavanju!", "Dodavanje novog proizvoda", MessageBoxButton.OK, MessageBoxImage.Error);
						}
						else
						{
							DobaviSve();
							AddNaziv = "";
							AddTip = "";
							AddCena = "";
						}
					}
					else
					{
						MessageBox.Show("Polje Cena mora biti pozitivan broj!", "Dodavanje novog proizvoda", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}
				catch
				{
					MessageBox.Show("Polje Cena mora biti broj!", "Dodavanje novog proizvoda", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBox.Show("Polja Naziv, Tip i Cena ne smeju biti prazna!", "Dodavanje novog proizvoda", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void DobaviSve()
		{
			try
			{
				List<Proizvod> listaProizvoda = Service.DobaviSve();
				sviProizvodi = new ObservableCollection<Proizvod>();

				foreach (Proizvod proizvod in listaProizvoda)
				{
					sviProizvodi.Add(proizvod);
				}
				OnPropertyChanged("sviProizvodi");
			}
			catch
			{
				MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih proizvoda", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void Dobavi()
		{
			if (getNaziv != "")
			{
				Proizvod proizvod = Service.Dobavi(getNaziv);

				if (proizvod == null)
				{
					MessageBox.Show("Greski pri dobavljanju proizvoda!", "Dobavljanje proizvoda", MessageBoxButton.OK, MessageBoxImage.Error);
				}
				else
				{
					sviProizvodi = new ObservableCollection<Proizvod>();
					sviProizvodi.Add(proizvod);
					OnPropertyChanged("sviProizvodi");

					GetNaziv = "";
				}
			}
			else
			{
				MessageBox.Show("Polje Naziv ne sme biti prazno!", "Dobavljanje proizvoda", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void Izbrisi()
		{
			if (deleteNaziv != "")
			{
				try
				{
					if (!Service.Izbrisi(deleteNaziv))
					{
						MessageBox.Show("Unet je nepostojeci naziv!", "Brisanje proizvoda", MessageBoxButton.OK, MessageBoxImage.Error);
					}
					else
					{
						DobaviSve();
						DeleteNaziv = "";
					}
				}
				catch
				{
					MessageBox.Show("Greska pri brisanju!", "Brisanje proizvoda", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBox.Show("Polje Naziv ne sme biti prazno!", "Brisanje proizvoda", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void Azuriraj()
		{
			if(updateNaziv != "" && (updateTip != "" || updateCena != ""))
			{
				bool ispravnaCena = true;
				int cena = -1;
				if(updateCena != "")
				{
					try
					{
						cena = Int32.Parse(updateCena);
						if(cena < 0)
						{
							ispravnaCena = false;
							MessageBox.Show("Polje Cena mora biti pozitivan broj!", "Azuriranje proizvoda", MessageBoxButton.OK, MessageBoxImage.Error);
						}
					}
					catch
					{
						MessageBox.Show("Polje Cena mora biti broj!", "Azuriranje proizvoda", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}

				if (ispravnaCena)
				{
					string tip = "";
					if(addTip != "")
					{
						string[] tekst = updateTip.Split(' ');
						tip = tekst[1];

						for (int i = 2; i < tekst.Length; i++)
						{
							tip += " " + tekst[i];
						}
					}

					if (!Service.Azuriraj(updateNaziv, tip, cena))
					{
						MessageBox.Show("Unet je nepostojeci naziv!", "Azuriranje proizvoda", MessageBoxButton.OK, MessageBoxImage.Error);
					}
					else
					{
						DobaviSve();

						UpdateNaziv = "";
						UpdateTip = "";
						UpdateCena = "";
					}
				}
			}
			else
			{
				MessageBox.Show("Polje Naziv i Tip ili Cena ne smeju biti prazna!", "Azuriranje proizvoda", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}
