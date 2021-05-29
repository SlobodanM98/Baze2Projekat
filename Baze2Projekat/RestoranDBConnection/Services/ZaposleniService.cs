using RestoranDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDB.Services
{
	public class ZaposleniService : IZaposleniService
	{
		public bool Azuriraj(int jmbg, string tip, string ime, string prezime)
		{
			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					Zaposleni zaAzuriranje = dataBase.Zaposleni.Find(jmbg);

					if (zaAzuriranje == null)
					{
						return false;
					}
					else
					{
						if (tip != "")
						{
							dataBase.Zaposleni.Remove(zaAzuriranje);
							dataBase.SaveChanges();

							Zaposleni zaposleni = null;

							switch (tip)
							{
								case "Konobar":
									zaposleni = new Konobar();
									break;
								case "Recepcionar":
									zaposleni = new Recepcionar();
									break;
								case "Kuvar":
									zaposleni = new Kuvar();
									break;
							}

							zaposleni.JMBG = jmbg;
							zaposleni.Tip = tip;

							if (ime != "")
							{
								zaposleni.Ime = ime;
							}
							else
							{
								zaposleni.Ime = zaAzuriranje.Ime;
							}

							if (prezime != "")
							{
								zaposleni.Prezime = prezime;
							}
							else
							{
								zaposleni.Prezime = zaAzuriranje.Prezime;
							}

							dataBase.Zaposleni.Add(zaposleni);
						}
						else if (ime != "")
						{
							zaAzuriranje.Ime = ime;
							if (prezime != "")
							{
								zaAzuriranje.Prezime = prezime;
							}
						}
						else if (prezime != "")
						{
							zaAzuriranje.Prezime = prezime;
						}

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

		public List<Zaposleni> DobaviSve()
		{
			List<Zaposleni> izlaz = new List<Zaposleni>();

			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					izlaz = dataBase.Zaposleni.ToList();
				}
				catch
				{

				}
			}

			return izlaz;
		}

		public bool Dodaj(int jmbg, string tip, string ime, string prezime)
		{
			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					Zaposleni zaposleni = null;

					switch (tip)
					{
						case "Konobar":
							zaposleni = new Konobar();
							break;
						case "Recepcionar":
							zaposleni = new Recepcionar();
							break;
						case "Kuvar":
							zaposleni = new Kuvar();
							break;
					}

					zaposleni.JMBG = jmbg;
					zaposleni.Tip = tip;
					zaposleni.Ime = ime;
					zaposleni.Prezime = prezime;

					dataBase.Zaposleni.Add(zaposleni);
					dataBase.SaveChanges();
				}
				catch
				{
					return false;
				}
			}

			return true;
		}

		public bool Izbrisi(int jmbg)
		{
			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					Zaposleni zaBrisanje = dataBase.Zaposleni.Find(jmbg);

					if (zaBrisanje == null)
					{
						return false;
					}
					else
					{
						dataBase.Zaposleni.Remove(zaBrisanje);
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
