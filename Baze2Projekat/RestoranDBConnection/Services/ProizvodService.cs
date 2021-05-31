using RestoranDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDB.Services
{
	public class ProizvodService : IProizvodService
	{
		public bool Azuriraj(string naziv, string tip, int cena)
		{
			using(var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					Proizvod zaAzuriranje = dataBase.Proizvodi.Find(naziv);

					if (zaAzuriranje == null)
					{
						return false;
					}
					else
					{
						if (tip != "")
						{
							dataBase.Proizvodi.Remove(zaAzuriranje);
							dataBase.SaveChanges();

							int staraCena = zaAzuriranje.Cena;

							switch (tip)
							{
								case "Corba":
									zaAzuriranje = new Corba();
									break;
								case "GlavnoJelo":
									zaAzuriranje = new GlavnoJelo();
									break;
								case "Salata":
									zaAzuriranje = new Salata();
									break;
								case "Dezert":
									zaAzuriranje = new Dezert();
									break;
							}

							zaAzuriranje.Naziv = naziv;
							zaAzuriranje.Tip = tip;

							if (cena > 0)
							{
								zaAzuriranje.Cena = cena;
							}
							else
							{
								zaAzuriranje.Cena = staraCena;
							}

							dataBase.Proizvodi.Add(zaAzuriranje);
						}
						else if (cena > 0)
						{
							zaAzuriranje.Cena = cena;
							dataBase.Entry(zaAzuriranje).State = EntityState.Modified;
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

		public Proizvod Dobavi(string naziv)
		{
			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					return dataBase.Proizvodi.Find(naziv);
				}
				catch
				{

				}
			}

			return null;
		}

		public List<Proizvod> DobaviSve()
		{
			List<Proizvod> izlaz = new List<Proizvod>();

			using(var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					izlaz = dataBase.Proizvodi.ToList();
				}
				catch
				{

				}
			}

			return izlaz;
		}

		public bool Dodaj(string naziv, string tip, int cena)
		{
			using(var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					Proizvod proizvod = null;

					switch (tip)
					{
						case "Corba":
							proizvod = new Corba();
							break;
						case "GlavnoJelo":
							proizvod = new GlavnoJelo();
							break;
						case "Salata":
							proizvod = new Salata();
							break;
						case "Dezert":
							proizvod = new Dezert();
							break;
					}

					proizvod.Naziv = naziv;
					proizvod.Tip = tip;
					proizvod.Cena = cena;

					dataBase.Proizvodi.Add(proizvod);
					dataBase.SaveChanges();
				}
				catch
				{
					return false;
				}
			}

			return true;
		}

		public bool Izbrisi(string naziv)
		{
			using(var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					Proizvod zaBrisanje = dataBase.Proizvodi.Find(naziv);
					if (zaBrisanje == null)
					{
						return false;
					}
					else
					{
						List<Nudi> nudis = dataBase.Nudis.ToList();
						List<Sprema> spremas = dataBase.Spremas.ToList();
						List<Kupuje> kupovine = dataBase.Kupovine.ToList();

						foreach (Nudi nudi in nudis)
						{
							if(nudi.ProizvodNaziv == naziv)
							{
								dataBase.Nudis.Remove(nudi);
							}
						}
						foreach(Sprema sprema in spremas)
						{
							if(sprema.NudiProizvodNaziv == naziv)
							{
								dataBase.Spremas.Remove(sprema);
							}
						}
						foreach(Kupuje kupuje in kupovine)
						{
							if(kupuje.SpremaNudiProizvodNaziv == naziv)
							{
								dataBase.Kupovine.Remove(kupuje);
							}
						}

						dataBase.Proizvodi.Remove(zaBrisanje);
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
