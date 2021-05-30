using RestoranDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDB.Services
{
	public class NudiService : INudiService
	{
		public List<Nudi> DobaviSve()
		{
			List<Nudi> izlaz = new List<Nudi>();

			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					izlaz = dataBase.Nudis.ToList();
				}
				catch
				{

				}
			}

			return izlaz;
		}

		public bool Dodaj(int IDRestoran, string naziv)
		{
			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					Nudi nudi = new Nudi();
					nudi.RestoranIDRestorana = IDRestoran;
					nudi.ProizvodNaziv = naziv;

					dataBase.Nudis.Add(nudi);
					dataBase.SaveChanges();
				}
				catch
				{
					return false;
				}
			}

			return true;
		}

		public bool Izbrisi(int IDRestoran, string naziv)
		{
			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					Nudi zaBrisanje = dataBase.Nudis.Find(IDRestoran, naziv);

					if (zaBrisanje == null)
					{
						return false;
					}
					else
					{
						dataBase.Nudis.Remove(zaBrisanje);
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
