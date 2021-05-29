using RestoranDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDB.Services
{
	public class RestoranService : IRestoranService
	{
		public bool Azuriraj(int IDRestorana, string naziv)
		{
			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					Restoran zaAzuriranje = dataBase.Restorani.Find(IDRestorana);

					if (zaAzuriranje == null)
					{
						return false;
					}
					else
					{
						zaAzuriranje.Naziv = naziv;
						dataBase.Entry(zaAzuriranje).State = EntityState.Modified;
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

		public List<Restoran> DobaviSve()
		{
			List<Restoran> izlaz = new List<Restoran>();

			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					izlaz = dataBase.Restorani.ToList();
				}
				catch
				{

				}
			}

			return izlaz;
		}

		public bool Dodaj(int IDRestorana, string naziv, int postanskiBroj)
		{
			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					Restoran restoran = new Restoran();
					restoran.IDRestorana = IDRestorana;
					restoran.Naziv = naziv;
					restoran.GradPostanskiBroj = postanskiBroj;

					dataBase.Restorani.Add(restoran);
					dataBase.SaveChanges();
				}
				catch
				{
					return false;
				}
			}

			return true;
		}

		public bool Izbrisi(int IDRestorana)
		{
			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					Restoran zaBrisanje = dataBase.Restorani.Find(IDRestorana);

					if (zaBrisanje == null)
					{
						return false;
					}
					else
					{
						dataBase.Restorani.Remove(zaBrisanje);
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
