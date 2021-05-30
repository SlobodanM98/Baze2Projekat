using RestoranDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDB.Services
{
	public class MusterijaService : IMusterijaService
	{
		public bool Azuriraj(int redniBroj, string ime, string prezime, string brojStola, string IDRestoran)
		{
			using(var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					Musterija zaAzuriranje = dataBase.Musterije.Find(redniBroj);

					if (zaAzuriranje == null)
					{
						return false;
					}
					else
					{
						if(ime != "")
						{
							zaAzuriranje.Ime = ime;
						}
						if(prezime != "")
						{
							zaAzuriranje.Prezime = prezime;
						}
						if (brojStola != "" && IDRestoran != "")
						{
							zaAzuriranje.StoBrojStola = Int32.Parse(brojStola);
							zaAzuriranje.StoRestoranIDRestorana = Int32.Parse(IDRestoran);
						}

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

		public List<Musterija> DobaviSve()
		{
			List<Musterija> izlaz = new List<Musterija>();

			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					izlaz = dataBase.Musterije.ToList();
				}
				catch
				{

				}
			}

			return izlaz;
		}

		public bool Dodaj(string ime, string prezime, string brojStola, string IDRestoran)
		{
			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					Musterija musterija = new Musterija();
					musterija.Ime = ime;
					musterija.Prezime = prezime;

					if (brojStola != "" && IDRestoran != "")
					{
						musterija.StoBrojStola = Int32.Parse(brojStola);
						musterija.StoRestoranIDRestorana = Int32.Parse(IDRestoran);
					}

					dataBase.Musterije.Add(musterija);
					dataBase.SaveChanges();
				}
				catch
				{
					return false;
				}
			}

			return true;
		}

		public bool Izbrisi(int redniBroj)
		{
			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					Musterija zaBrisanje = dataBase.Musterije.Find(redniBroj);

					if(zaBrisanje == null)
					{
						return false;
					}
					else
					{
						dataBase.Musterije.Remove(zaBrisanje);
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
