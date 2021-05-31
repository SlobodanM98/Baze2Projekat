using RestoranDB;
using RestoranDB.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace Restoran.ViewModel
{
	public class MusterijaViewModel : BindableBase
	{
		public MyICommand DodajCommand { get; set; }
		public MyICommand IzbrisiCommand { get; set; }
		public MyICommand AzurirajCommand { get; set; }
		public MusterijaService Service;
		public StoService ServiceSto;
		public RestoranService ServiceRestoran;
		public ObservableCollection<Musterija> sveMusterije { get; set; }
		public ObservableCollection<int> sviBrojeviStolova { get; set; }
		public ObservableCollection<int> sviBrojeviRestorana { get; set; }

		#region private
		private string addIme;
		private string addPrezime;
		private string addBrojStola;
		private string addIDRestoran;
		private string deleteRedniBroj;
		private string updateRedniBroj;
		private string updateIme;
		private string updatePrezime;
		private string updateBrojStola;
		private string updateIDRestoran;
		#endregion

		#region public
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

		public string AddBrojStola
		{
			get
			{
				return addBrojStola;
			}
			set
			{
				if (value != addBrojStola)
				{
					addBrojStola = value;
					OnPropertyChanged("AddBrojStola");
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
						DobaviSveStolove(addIDRestoran);
					}
					OnPropertyChanged("AddIDRestoran");
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
					OnPropertyChanged("DeleteRedniBroj");
				}
			}
		}

		public string UpdateRedniBroj
		{
			get
			{
				return updateRedniBroj;
			}
			set
			{
				if (value != updateRedniBroj)
				{
					updateRedniBroj = value;
					OnPropertyChanged("UpdateRedniBroj");
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

		public string UpdateBrojStola
		{
			get
			{
				return updateBrojStola;
			}
			set
			{
				if (value != updateBrojStola)
				{
					updateBrojStola = value;
					OnPropertyChanged("UpdateBrojStola");
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
					if (updateIDRestoran != "" && updateIDRestoran != null)
					{
						DobaviSveStolove(updateIDRestoran);
					}
					OnPropertyChanged("UpdateIDRestoran");
				}
			}
		}
		#endregion

		public MusterijaViewModel()
		{
			DodajCommand = new MyICommand(Dodaj);
			IzbrisiCommand = new MyICommand(Izbrisi);
			AzurirajCommand = new MyICommand(Azuriraj);

			Service = new MusterijaService();
			ServiceSto = new StoService();
			ServiceRestoran = new RestoranService();

			DobaviSveRestorane();
			DobaviSve();

			addIme = "";
			addPrezime = "";
			addBrojStola = "";
			addIDRestoran = "";
			deleteRedniBroj = "";
			updateRedniBroj = "";
			updateIme = "";
			updatePrezime = "";
			updateBrojStola = "";
			updateIDRestoran = "";
		}

		public void Dodaj()
		{
			if (addIme != "" && addPrezime != "")
			{
				if((addBrojStola == "" && addIDRestoran == "") || (addBrojStola != "" && addIDRestoran != ""))
				{
					if (!Service.Dodaj(addIme, addPrezime, addBrojStola, addIDRestoran))
					{
						MessageBox.Show("Greska pri dodavanju!", "Dodavanje nove musterije", MessageBoxButton.OK, MessageBoxImage.Error);
					}
					else
					{
						DobaviSve();
						AddIme = "";
						AddPrezime = "";
						AddBrojStola = "";

						sviBrojeviStolova = new ObservableCollection<int>();
					}
				}
				else
				{
					MessageBox.Show("Polja Broj stola i IDRestoran moraju oba biti prazna ili oba popunjena!", "Dodavanje nove musterije", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBox.Show("Polja Ime i Prezime ne smeju biti prazna!", "Dodavanje nove musterije", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void DobaviSve()
		{
			try
			{
				List<Musterija> listaMusterija = Service.DobaviSve();
				sveMusterije = new ObservableCollection<Musterija>();

				foreach (Musterija musterija in listaMusterija)
				{
					sveMusterije.Add(musterija);
				}
				OnPropertyChanged("sveMusterije");
			}
			catch
			{
				MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih musterija", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void DobaviSveStolove(string IDRestoran)
		{
			try
			{
				List<Sto> listaStolova = ServiceSto.DobaviSve();
				sviBrojeviStolova = new ObservableCollection<int>();

				foreach (Sto sto in listaStolova)
				{
					int id = Int32.Parse(IDRestoran);
					if(sto.RestoranIDRestorana == id)
					{
						sviBrojeviStolova.Add(sto.BrojStola);
					}
				}
				OnPropertyChanged("sviBrojeviStolova");
			}
			catch
			{
				MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih stolova", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void DobaviSveRestorane()
		{
			try
			{
				List<RestoranDB.Restoran> listaRestorana = ServiceRestoran.DobaviSve();
				sviBrojeviStolova = new ObservableCollection<int>();
				sviBrojeviRestorana = new ObservableCollection<int>();

				foreach (RestoranDB.Restoran restoran in listaRestorana)
				{
					sviBrojeviRestorana.Add(restoran.IDRestorana);
				}
				OnPropertyChanged("sviBrojeviRestorana");
			}
			catch
			{
				MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih restorana", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void Izbrisi()
		{
			if(deleteRedniBroj != "")
			{
				try
				{
					int redniBroj = Int32.Parse(deleteRedniBroj);

					if(redniBroj > 0)
					{
						if (!Service.Izbrisi(redniBroj))
						{
							MessageBox.Show("Unet je nepostojeci redni broj!", "Brisanje musterije", MessageBoxButton.OK, MessageBoxImage.Error);
						}
						else
						{
							DobaviSve();
							DeleteRedniBroj = "";
						}
					}
					else
					{
						MessageBox.Show("Polje Redni broj mora biti pozitivan broj!", "Brisanje musterije", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}
				catch
				{
					MessageBox.Show("Polje Redni broj mora biti broj!", "Brisanje musterije", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBox.Show("Polje Redni broj ne sme biti prazno!", "Brisanje musterije", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void Azuriraj()
		{
			if(updateRedniBroj != "" && (updateIme != "" || updatePrezime != "" || (updateBrojStola != "" && updateIDRestoran != "")))
			{
				try
				{
					if((updateBrojStola == "" && updateIDRestoran == "") || (updateBrojStola != "" && updateIDRestoran != ""))
					{
						int redniBroj = Int32.Parse(updateRedniBroj);
						if (!Service.Azuriraj(redniBroj, updateIme, updatePrezime, updateBrojStola, updateIDRestoran))
						{
							MessageBox.Show("Unet je nepostojeci redni broj!", "Brisanje musterije", MessageBoxButton.OK, MessageBoxImage.Error);
						}
						else
						{
							DobaviSve();
							UpdateRedniBroj = "";
							UpdateIme = "";
							UpdatePrezime = "";

							sviBrojeviStolova = new ObservableCollection<int>();
						}
					}
					else
					{
						MessageBox.Show("Polja Broj stola i IDRestoran moraju oba biti prazna ili oba popunjena!", "Azuriranje musterije", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}
				catch
				{
					MessageBox.Show("Polje Redni broj mora biti broj!", "Azuriranje musterije", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBox.Show("Polja Redni broj i Ime ili Prezime ili Broj stola i IDRestoran ne smeju biti prazna!", "Azuriranje musterije", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}
