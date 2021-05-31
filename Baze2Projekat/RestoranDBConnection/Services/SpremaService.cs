using RestoranDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDB.Services
{
	public class SpremaService : ISpremaService
	{
		public Sprema Dobavi(int JMBG, string naziv, int IDRestoran)
		{
			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					return dataBase.Spremas.Find(JMBG, IDRestoran, naziv);
				}
				catch
				{

				}
			}

			return null;
		}

		public List<Sprema> DobaviSve()
		{
			List<Sprema> izlaz = new List<Sprema>();

			using(var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					izlaz = dataBase.Spremas.ToList();
				}
				catch
				{

				}
			}

			return izlaz;
		}

		public bool Dodaj(int JMBG, string naziv, int IDRestoran)
		{
			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					Sprema sprema = new Sprema();
					sprema.KuvarJMBG = JMBG;
					sprema.NudiProizvodNaziv = naziv;
					sprema.NudiRestoranIDRestorana = IDRestoran;

					dataBase.Spremas.Add(sprema);
					dataBase.SaveChanges();
				}
				catch
				{
					return false;
				}
			}

			return true;
		}

		public bool Izbrisi(int JMBG, string naziv, int IDRestoran)
		{
			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					Sprema zaBrisanje = dataBase.Spremas.Find(JMBG, IDRestoran, naziv);

					if(zaBrisanje == null)
					{
						return false;
					}
					else
					{
						List<Kupuje> kupovine = dataBase.Kupovine.ToList();

						foreach (Kupuje kupuje in kupovine)
						{
							if (kupuje.SpremaKuvarJMBG == JMBG && kupuje.SpremaNudiRestoranIDRestorana == IDRestoran && kupuje.SpremaNudiProizvodNaziv == naziv)
							{
								dataBase.Kupovine.Remove(kupuje);
							}
						}

						dataBase.Spremas.Remove(zaBrisanje);
						dataBase.SaveChanges();
					}
				}
				catch
				{
					return false;
				}
			}

			return true;
		}
	}
}
