using RestoranDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDB.Services
{
	public class RadiService : IRadiService
	{
		public Radi Dobavi(int JMBG, int IDRestoran)
		{
			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					return dataBase.Radis.Find(IDRestoran, JMBG);
				}
				catch
				{

				}
			}

			return null;
		}

		public List<Radi> DobaviSve()
		{
			List<Radi> izlaz = new List<Radi>();

			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					izlaz = dataBase.Radis.ToList();
				}
				catch
				{

				}
			}

			return izlaz;
		}

		public bool Dodaj(int JMBG, int IDRestoran)
		{
			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					Radi radi = new Radi();
					radi.ZaposleniJMBG = JMBG;
					radi.RestoranIDRestorana = IDRestoran;

					dataBase.Radis.Add(radi);
					dataBase.SaveChanges();
				}
				catch
				{
					return false;
				}
			}

			return true;
		}

		public bool Izbrisi(int JMBG, int IDRestoran)
		{
			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					Radi zaBrisanje = dataBase.Radis.Find(IDRestoran, JMBG);

					if (zaBrisanje == null)
					{
						return false;
					}
					else
					{
						dataBase.Radis.Remove(zaBrisanje);
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
