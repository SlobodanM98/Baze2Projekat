﻿using RestoranDB;
using RestoranDB.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Restoran.ViewModel
{
	public class GradViewModel : BindableBase
	{
		public MyICommand DodajCommand { get; set; }
		public MyICommand IzbrisiCommand { get; set; }
		public MyICommand AzurirajCommand { get; set; }
		public MyICommand DobaviCommand { get; set; }
		public MyICommand DobaviSveCommand { get; set; }
		public GradService Service;
		public ObservableCollection<Grad> sviGradovi { get; set; }

		#region private
		private string addPostanskiBroj;
		private string addNaziv;
		private string deletePostanskiBroj;
		private string updatePostanskiBroj;
		private string updateNaziv;
		private string getPostanskiBroj;
		#endregion

		#region public
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

		public string DeletePostanskiBroj
		{
			get
			{
				return deletePostanskiBroj;
			}
			set
			{
				if (value != deletePostanskiBroj)
				{
					deletePostanskiBroj = value;
					OnPropertyChanged("DeletePostanskiBroj");
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
				if(value != updateNaziv)
				{
					updateNaziv = value;
					OnPropertyChanged("UpdateNaziv");
				}
			}
		}

		public string UpdatePostanskiBroj
		{
			get
			{
				return updatePostanskiBroj;
			}
			set
			{
				if (value != updatePostanskiBroj)
				{
					updatePostanskiBroj = value;
					OnPropertyChanged("UpdatePostanskiBroj");
				}
			}
		}

		public string GetPostanskiBroj
		{
			get
			{
				return getPostanskiBroj;
			}
			set
			{
				if (value != getPostanskiBroj)
				{
					getPostanskiBroj = value;
					OnPropertyChanged("GetPostanskiBroj");
				}
			}
		}
		#endregion

		public GradViewModel()
		{
			DodajCommand = new MyICommand(Dodaj);
			IzbrisiCommand = new MyICommand(Izbrisi);
			AzurirajCommand = new MyICommand(Azuriraj);
			DobaviCommand = new MyICommand(Dobavi);
			DobaviSveCommand = new MyICommand(DobaviSve);

			Service = new GradService();

			if (sviGradovi == null)
			{
				DobaviSve();
			}

			AddPostanskiBroj = "";
			AddNaziv = "";
			DeletePostanskiBroj = "";
			UpdatePostanskiBroj = "";
			UpdateNaziv = "";
			GetPostanskiBroj = "";
		}

		public void Dodaj()
		{
			if (addPostanskiBroj != "" && addNaziv != "")
			{
				try
				{
					int postanskiBroj = Int32.Parse(addPostanskiBroj);
					if(postanskiBroj > 0)
					{
						if (!Service.Dodaj(postanskiBroj, addNaziv))
						{
							MessageBox.Show("Greska pri dodavanju!", "Dodavanje novog grada", MessageBoxButton.OK, MessageBoxImage.Error);
						}
						else
						{
							DobaviSve();
							AddPostanskiBroj = "";
							AddNaziv = "";
						}
					}
					else
					{
						MessageBox.Show("Polje Postanski broj mora biti pozitivan broj!", "Dodavanje novog grada", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}
				catch
				{
					MessageBox.Show("Polje Postanski broj mora biti broj!", "Dodavanje novog grada", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBox.Show("Polja Postanski broj i Naziv ne smeju biti prazna!", "Dodavanje novog grada", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void DobaviSve()
		{
			try
			{
				List<Grad> listaGradova = Service.DobaviSve();
				sviGradovi = new ObservableCollection<Grad>();

				foreach (Grad grad in listaGradova)
				{
					sviGradovi.Add(grad);
				}
				OnPropertyChanged("sviGradovi");
			}
			catch
			{
				MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje svih gradova", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void Dobavi()
		{
			if (getPostanskiBroj != "")
			{
				try
				{
					int postanskiBroj = Int32.Parse(getPostanskiBroj);
					if (postanskiBroj > 0)
					{
						Grad grad = Service.Dobavi(postanskiBroj);

						if (grad == null)
						{
							MessageBox.Show("Greska pri dobavljanju!", "Dobavljanje grada", MessageBoxButton.OK, MessageBoxImage.Error);
						}
						else
						{
							sviGradovi = new ObservableCollection<Grad>();
							sviGradovi.Add(grad);
							OnPropertyChanged("sviGradovi");
							GetPostanskiBroj = "";
						}
					}
					else
					{
						MessageBox.Show("Polje Postanski broj mora biti pozitivan broj!", "Dobavljanje grada", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}
				catch
				{
					MessageBox.Show("Polje Postanski broj mora biti broj!", "Dobavljanje grada", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBox.Show("Polje Postanski broj ne sme biti prazno!", "Dobavljanje grada", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void Izbrisi()
		{
			if (deletePostanskiBroj != "")
			{
				try
				{
					int postanskiBroj = Int32.Parse(deletePostanskiBroj);
					if(postanskiBroj > 0)
					{
						if (!Service.Izbrisi(postanskiBroj))
						{
							MessageBox.Show("Unet je nepostojeci postanski broj!", "Brisanje grada", MessageBoxButton.OK, MessageBoxImage.Error);
						}
						else
						{
							DobaviSve();
							DeletePostanskiBroj = "";
						}
					}
					else
					{
						MessageBox.Show("Polje Postanski broj mora biti pozitivan broj!", "Brisanje grada", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}
				catch
				{
					MessageBox.Show("Polje Postanski broj mora biti broj!", "Brisanje grada", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBox.Show("Polje Postanski broj ne sme biti prazno!", "Brisanje grada", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void Azuriraj()
		{
			if(updatePostanskiBroj != "" && updateNaziv != "")
			{
				try
				{
					int postanskiBroj = Int32.Parse(updatePostanskiBroj);
					
					if(postanskiBroj > 0)
					{
						if (!Service.Azuriraj(postanskiBroj, updateNaziv))
						{
							MessageBox.Show("Unet je nepostojeci postanski broj!", "Azuriranje grada", MessageBoxButton.OK, MessageBoxImage.Error);
						}
						else
						{
							DobaviSve();
							UpdatePostanskiBroj = "";
							UpdateNaziv = "";
						}
					}
					else
					{
						MessageBox.Show("Polje Postanski broj mora biti pozitivan broj!", "Azuriranje grada", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}
				catch
				{
					MessageBox.Show("Polje Postanski broj mora biti broj!", "Azuriranje grada", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBox.Show("Polja Postanski broj i Naziv ne smeju biti prazna!", "Azuriranje grada", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}
