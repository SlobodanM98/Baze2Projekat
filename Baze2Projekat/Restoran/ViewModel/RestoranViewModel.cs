using RestoranDB;
using RestoranDB.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace Restoran.ViewModel
{
	public class RestoranViewModel : BindableBase
	{
		public MyICommand DodajCommand { get; set; }
		public MyICommand IzbrisiCommand { get; set; }
		public MyICommand AzurirajCommand { get; set; }
		public RestoranService Service;
		public GradService ServiceGrad;
		public ObservableCollection<RestoranDB.Restoran> sviRestorani { get; set; }
		public ObservableCollection<int> sviBrojeviGradova { get; set; }

		#region private
		private string addIDRestoran;
		private string addNaziv;
		private string addPostanskiBroj;
		private string deleteIDRestoran;
		private string updateIDRestoran;
		private string updateNaziv;
		#endregion

		#region public
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

		public string AddPostanskiBroj
		{
			get
			{
				return addPostanskiBroj;
			}
			set
			{
				if (value != addPostanskiBroj)
				{
					addPostanskiBroj = value;
					OnPropertyChanged("AddPostanskiBroj");
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

		public string UpdateIDRestoran
		{
			get
			{
				return updateIDRestoran;
			}
			set
			{
				if (value != updateIDRestoran)
				{
					updateIDRestoran = value;
					OnPropertyChanged("UpdateIDRestoran");
				}
			}
		}
		#endregion

		public RestoranViewModel()
		{
			DodajCommand = new MyICommand(Dodaj);
			IzbrisiCommand = new MyICommand(Izbrisi);
			AzurirajCommand = new MyICommand(Azuriraj);

			Service = new RestoranService();
			ServiceGrad = new GradService();

			DobaviSveGradove();

			DobaviSve();

			addIDRestoran = "";
			addNaziv = "";
			deleteIDRestoran = "";
			updateIDRestoran = "";
			updateNaziv = "";
		}

		public void Dodaj()
		{
			if (addIDRestoran != "" && addNaziv != "" && addPostanskiBroj != "")
			{
				try
				{
					int IDRestoran = Int32.Parse(addIDRestoran);
					int postanskiBroj = Int32.Parse(addPostanskiBroj);
					if (IDRestoran > 0 && postanskiBroj > 0)
					{
						bool rezultat = Service.Dodaj(IDRestoran, addNaziv, postanskiBroj);

						if (!rezultat)
						{
							MessageBox.Show("Greska pri dodavanju!", "Dodavanje novog restorana", MessageBoxButton.OK, MessageBoxImage.Error);
						}
						else
						{
							DobaviSve();
							AddIDRestoran = "";
							AddNaziv = "";
						}
					}
					else
					{
						MessageBox.Show("Polja IDRestoran i Postanski broj moraju biti pozitivni brojevi!", "Dodavanje novog restorana", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}
				catch
				{
					MessageBox.Show("Polja IDRestoran i Postanski broj moraju biti brojevi!", "Dodavanje novog restorana", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBox.Show("Polja IDRestoran, Naziv i Postanski broj ne smeju biti prazna!", "Dodavanje novog restorana", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void DobaviSve()
		{
			try
			{
				List<RestoranDB.Restoran> listaRestorana = Service.DobaviSve();
				sviRestorani = new ObservableCollection<RestoranDB.Restoran>();

				foreach (RestoranDB.Restoran restoran in listaRestorana)
				{
					sviRestorani.Add(restoran);
				}
				OnPropertyChanged("sviRestorani");
			}
			catch
			{
				MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih restorana", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void DobaviSveGradove()
		{
			try
			{
				List<Grad> listaGradova = ServiceGrad.DobaviSve();
				sviBrojeviGradova = new ObservableCollection<int>();

				foreach (Grad grad in listaGradova)
				{
					sviBrojeviGradova.Add(grad.PostanskiBroj);
				}
				OnPropertyChanged("sviGradovi");
			}
			catch
			{
				MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih gradova", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void Izbrisi()
		{
			if (deleteIDRestoran != "")
			{
				try
				{
					int IDRestoran = Int32.Parse(deleteIDRestoran);
					if(IDRestoran > 0)
					{
						bool rezultat = Service.Izbrisi(IDRestoran);

						if (!rezultat)
						{
							MessageBox.Show("Unet je nepostojeci IDRestorana!", "Brisanje restorana", MessageBoxButton.OK, MessageBoxImage.Error);
						}
						else
						{
							DobaviSve();
							DeleteIDRestoran = "";
						}
					}
					else
					{
						MessageBox.Show("Polje IDRestoran mora biti pozitivan broj!", "Brisanje restorana", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}
				catch
				{
					MessageBox.Show("Polje IDRestoran mora biti broj!", "Brisanje restorana", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBox.Show("Polje IDRestoran ne sme biti prazno!", "Brisanje restorana", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void Azuriraj()
		{
			if (updateIDRestoran != "" && updateNaziv != "")
			{
				try
				{
					int IDRestoran = Int32.Parse(updateIDRestoran);

					if (IDRestoran > 0)
					{
						bool rezultat = Service.Azuriraj(IDRestoran, updateNaziv);

						if (!rezultat)
						{
							MessageBox.Show("Unet je nepostojeci IDRestorana!", "Azuriranje restoran", MessageBoxButton.OK, MessageBoxImage.Error);
						}
						else
						{
							DobaviSve();
							UpdateIDRestoran = "";
							UpdateNaziv = "";
						}
					}
					else
					{
						MessageBox.Show("Polje IDRestoran mora biti pozitivan broj!", "Azuriranje restoran", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}
				catch
				{
					MessageBox.Show("Polje IDRestoran mora biti broj!", "Azuriranje restoran", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBox.Show("Polja IDRestoran i Naziv ne smeju biti prazna!", "Azuriranje restoran", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}
