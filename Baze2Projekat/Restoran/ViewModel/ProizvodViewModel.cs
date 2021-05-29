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
		#endregion

		public ProizvodViewModel()
		{
			DodajCommand = new MyICommand(Dodaj);
			IzbrisiCommand = new MyICommand(Izbrisi);
			AzurirajCommand = new MyICommand(Azuriraj);

			Service = new ProizvodService();

			DobaviSve();

			addNaziv = "";
			addTip = "";
			addCena = "";
			deleteNaziv = "";
			updateNaziv = "";
			updateTip = "";
			updateCena = "";
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
						addTip = addTip.Split(' ')[1];
						bool rezultat = Service.Dodaj(addNaziv, addTip, cena);

						if (!rezultat)
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

		public void Izbrisi()
		{
			if (deleteNaziv != "")
			{
				try
				{
					bool rezultat = Service.Izbrisi(deleteNaziv);

					if (!rezultat)
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
							MessageBox.Show("Polje Cena mora biti pozitivan broj!", "Dodavanje novog proizvoda", MessageBoxButton.OK, MessageBoxImage.Error);
						}
					}
					catch
					{
						MessageBox.Show("Polje Cena mora biti broj!", "Azuriranje proizvoda", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}

				if (ispravnaCena)
				{
					if (updateTip != "" && updateTip.Split(' ').Length > 1)
					{
						updateTip = updateTip.Split(' ')[1];
					}

					bool izlaz = Service.Azuriraj(updateNaziv, updateTip, cena);

					if (!izlaz)
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
