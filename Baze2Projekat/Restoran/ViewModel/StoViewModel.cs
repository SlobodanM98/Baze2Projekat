﻿using RestoranDB;
using RestoranDB.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace Restoran.ViewModel
{
	public class StoViewModel : BindableBase
	{
		public MyICommand DodajCommand { get; set; }
		public MyICommand IzbrisiCommand { get; set; }
		public MyICommand AzurirajCommand { get; set; }
		public MyICommand DobaviCommand { get; set; }
		public MyICommand DobaviSveCommand { get; set; }
		public StoService Service;
		public RestoranService ServiceRestoran;
		public ObservableCollection<Sto> sviStolovi { get; set; }
		public ObservableCollection<int> sviIDRestorana { get; set; }


		#region private
		private string addBrojStola;
		private string addTip;
		private string addIDRestoran;
		private string deleteBrojStola;
		private string deleteIDRestoran;
		private string updateBrojStola;
		private string updateTip;
		private string updateIDRestoran;
		private string getBrojStola;
		private string getIDRestoran;
		#endregion

		#region public
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

		public string DeleteBrojStola
		{
			get
			{
				return deleteBrojStola;
			}
			set
			{
				if (value != deleteBrojStola)
				{
					deleteBrojStola = value;
					OnPropertyChanged("DeleteBrojStola");
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

		public string GetBrojStola
		{
			get
			{
				return getBrojStola;
			}
			set
			{
				if (value != getBrojStola)
				{
					getBrojStola = value;
					OnPropertyChanged("GetBrojStola");
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

		public StoViewModel()
		{
			DodajCommand = new MyICommand(Dodaj);
			IzbrisiCommand = new MyICommand(Izbrisi);
			AzurirajCommand = new MyICommand(Azuriraj);
			DobaviCommand = new MyICommand(Dobavi);
			DobaviSveCommand = new MyICommand(DobaviSve);

			Service = new StoService();
			ServiceRestoran = new RestoranService();

			DobaviSveRestorane();
			DobaviSve();

			AddBrojStola = "";
			AddTip = "";
			AddIDRestoran = "";
			DeleteBrojStola = "";
			DeleteIDRestoran = "";
			UpdateBrojStola = "";
			UpdateTip = "";
			UpdateIDRestoran = "";
			GetBrojStola = "";
			GetIDRestoran = "";
		}

		public void Dodaj()
		{
			if (addBrojStola != "" && addTip != "" && addIDRestoran != "")
			{
				try
				{
					int IDRestoran = Int32.Parse(addIDRestoran);
					int brojStola = Int32.Parse(addBrojStola);
					if (IDRestoran > 0 && brojStola > 0)
					{
						int brojMesta = 0;
						string tip = addTip.Split(' ')[1];

						switch (tip)
						{
							case "ZaDvoje":
								brojMesta = 2;
								break;
							case "ZaCetvoro":
								brojMesta = 4;
								break;
							case "ZaSestoro":
								brojMesta = 6;
								break;
						}

						if (!Service.Dodaj(brojStola, brojMesta, tip, IDRestoran))
						{
							MessageBox.Show("Greska pri dodavanju!", "Dodavanje novog stola", MessageBoxButton.OK, MessageBoxImage.Error);
						}
						else
						{
							DobaviSve();
							AddBrojStola = "";
							AddTip = "";
							AddIDRestoran = "";
						}
					}
					else
					{
						MessageBox.Show("Polje Broj stola mora biti pozitivan broj!", "Dodavanje novog stola", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}
				catch
				{
					MessageBox.Show("Polje Broj stola mora biti broj!", "Dodavanje novog stola", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBox.Show("Polja Broj stola, Tip i IDRestoran ne smeju biti prazna!", "Dodavanje novog stola", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void DobaviSve()
		{
			try
			{
				List<Sto> listaStolova = Service.DobaviSve();
				sviStolovi = new ObservableCollection<Sto>();

				foreach (Sto sto in listaStolova)
				{
					sviStolovi.Add(sto);
				}
				OnPropertyChanged("sviStolovi");
			}
			catch
			{
				MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih stolova", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void Dobavi()
		{
			if (getBrojStola != "" && getIDRestoran != "")
			{
				try
				{
					int BrojStola = Int32.Parse(getBrojStola);
					int IDRestoran = Int32.Parse(getIDRestoran);
					if (BrojStola > 0)
					{
						Sto sto = Service.Dobavi(BrojStola, IDRestoran);

						if (sto == null)
						{
							MessageBox.Show("Greska pri dobavljanju stola!", "Dobavljanje stola", MessageBoxButton.OK, MessageBoxImage.Error);
						}
						else
						{
							sviStolovi = new ObservableCollection<Sto>();
							sviStolovi.Add(sto);

							GetBrojStola = "";
							GetIDRestoran = "";
						}
					}
					else
					{
						MessageBox.Show("Polje Broj stola mora biti pozitivan broj!", "Dobavljanje stola", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}
				catch
				{
					MessageBox.Show("Polje Broj stola mora biti broj!", "Dobavljanje stola", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBox.Show("Polja Broj stola i IDrestoran ne smeju biti prazna!", "Dobavljanje stola", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void DobaviSveRestorane()
		{
			try
			{
				List<RestoranDB.Restoran> listaRestorana = ServiceRestoran.DobaviSve();
				sviIDRestorana = new ObservableCollection<int>();

				foreach (RestoranDB.Restoran restoran in listaRestorana)
				{
					sviIDRestorana.Add(restoran.IDRestorana);
				}
				OnPropertyChanged("sviIDRestorana");
			}
			catch
			{
				MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih restorana", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void Izbrisi()
		{
			if (deleteBrojStola != "" && deleteIDRestoran != "")
			{
				try
				{
					int BrojStola = Int32.Parse(deleteBrojStola);
					int IDRestoran = Int32.Parse(deleteIDRestoran);
					if (BrojStola > 0)
					{
						if (!Service.Izbrisi(BrojStola, IDRestoran))
						{
							MessageBox.Show("Unet je nepostojeci Broj stola!", "Brisanje stola", MessageBoxButton.OK, MessageBoxImage.Error);
						}
						else
						{
							DobaviSve();
							DeleteBrojStola = "";
							DeleteIDRestoran = "";
						}
					}
					else
					{
						MessageBox.Show("Polje Broj stola mora biti pozitivan broj!", "Brisanje stola", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}
				catch
				{
					MessageBox.Show("Polje Broj stola mora biti broj!", "Brisanje stola", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBox.Show("Polja Broj stola i IDrestoran ne smeju biti prazna!", "Brisanje stola", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void Azuriraj()
		{
			if(updateBrojStola != "" && updateTip != "" && updateIDRestoran != "")
			{
				try
				{
					int brojStola = Int32.Parse(updateBrojStola);
					int IDRestoran = Int32.Parse(updateIDRestoran);
					if (brojStola > 0)
					{
						int brojMesta = 0;

						string tip = updateTip.Split(' ')[1];

						switch (tip)
						{
							case "ZaDvoje":
								brojMesta = 2;
								break;
							case "ZaCetvoro":
								brojMesta = 4;
								break;
							case "ZaSestoro":
								brojMesta = 6;
								break;
						}

						if (!Service.Azuriraj(brojStola, brojMesta, tip, IDRestoran))
						{
							MessageBox.Show("Unet je nepostojeci Broj stola!", "Azuriranje stola", MessageBoxButton.OK, MessageBoxImage.Error);
						}
						else
						{
							DobaviSve();
							UpdateBrojStola = "";
							UpdateTip = "";
						}
					}
					else
					{
						MessageBox.Show("Polje Broj stola mora biti pozitivan broj!", "Azuriranje stola", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}
				catch
				{
					MessageBox.Show("Polje Broj stola mora biti broj!", "Azuriranje stola", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBox.Show("Polja Broj stola, Tip i IDRestoran ne smeju biti prazna!", "Azuriranje stola", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}
