using RestoranDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDB.Services
{
	public class KupujeService : IKupujeService
	{
		public Kupuje Dobavi(int redniBroj, int JMBG, int IDRestoran, string naziv)
		{
			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					return dataBase.Kupovine.Find(redniBroj, JMBG, IDRestoran, naziv);
				}
				catch
				{

				}
			}

			return null;
		}

		public List<Kupuje> DobaviSve()
		{
			List<Kupuje> izlaz = new List<Kupuje>();

			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					izlaz = dataBase.Kupovine.ToList();
				}
				catch
				{

				}
			}

			return izlaz;
		}

		public bool Dodaj(int redniBroj, int JMBG, int IDRestoran, string naziv)
		{
			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					Kupuje kupuje = new Kupuje();
					kupuje.MusterijaRedniBroj = redniBroj;
					kupuje.SpremaKuvarJMBG = JMBG;
					kupuje.SpremaNudiRestoranIDRestorana = IDRestoran;
					kupuje.SpremaNudiProizvodNaziv = naziv;

					dataBase.Kupovine.Add(kupuje);
					dataBase.SaveChanges();
				}
				catch
				{
					return false;
				}
			}

			return true;
		}

		public bool Izbrisi(int redniBroj, int JMBG, int IDRestoran, string naziv)
		{
			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					Kupuje zaBrisanje = dataBase.Kupovine.Find(redniBroj, JMBG, IDRestoran, naziv);

					if (zaBrisanje == null)
					{
						return false;
					}
					else
					{
						dataBase.Kupovine.Remove(zaBrisanje);
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
