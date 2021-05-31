using RestoranDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDB.Services
{
	public class GradService : IGradService
	{
		public bool Azuriraj(int postanskiBroj, string naziv)
		{
			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					Grad zaAzuriranje = dataBase.Gradovi.Find(postanskiBroj);

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

		public Grad Dobavi(int postanskiBroj)
		{
			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					return dataBase.Gradovi.Find(postanskiBroj);
				}
				catch
				{

				}
			}

			return null;
		}

		public List<Grad> DobaviSve()
		{
			List<Grad> izlaz = new List<Grad>();

			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					izlaz = dataBase.Gradovi.ToList();
				}
				catch
				{

				}
			}

			return izlaz;
		}

		public bool Dodaj(int postanskiBroj, string naziv)
		{
			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					Grad grad = new Grad();
					grad.PostanskiBroj = postanskiBroj;
					grad.Naziv = naziv;

					dataBase.Gradovi.Add(grad);
					dataBase.SaveChanges();
				}
				catch
				{
					return false;
				}
			}

			return true;
		}

		public bool Izbrisi(int postanskiBroj)
		{
			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					Grad zaBrisanje = dataBase.Gradovi.Find(postanskiBroj);

					if (zaBrisanje == null)
					{
						return false;
					}
					else
					{
						dataBase.Gradovi.Remove(zaBrisanje);
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
