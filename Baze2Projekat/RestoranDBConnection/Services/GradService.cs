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
						List<Restoran> restorani = dataBase.Restorani.ToList();
						List<Nudi> nudis = dataBase.Nudis.ToList();
						List<Sprema> spremas = dataBase.Spremas.ToList();
						List<Kupuje> kupovine = dataBase.Kupovine.ToList();
						List<Radi> radis = dataBase.Radis.ToList();
						List<Sto> stolovi = dataBase.Stolovi.ToList();
						List<Musterija> musterije = dataBase.Musterije.ToList();

						int IDRestorana = -1;

						foreach(Restoran restoran in restorani)
						{
							if(restoran.GradPostanskiBroj == postanskiBroj)
							{
								dataBase.Restorani.Remove(restoran);
								IDRestorana = restoran.IDRestorana;
							}
						}
						foreach (Nudi nudi in nudis)
						{
							if (nudi.RestoranIDRestorana == IDRestorana)
							{
								dataBase.Nudis.Remove(nudi);
							}
						}
						foreach (Sprema sprema in spremas)
						{
							if (sprema.NudiRestoranIDRestorana == IDRestorana)
							{
								dataBase.Spremas.Remove(sprema);
							}
						}
						foreach (Kupuje kupuje in kupovine)
						{
							if (kupuje.SpremaNudiRestoranIDRestorana == IDRestorana)
							{
								dataBase.Kupovine.Remove(kupuje);
							}
						}
						foreach (Radi radi in radis)
						{
							if (radi.RestoranIDRestorana == IDRestorana)
							{
								dataBase.Radis.Remove(radi);
							}
						}
						foreach (Sto sto in stolovi)
						{
							if (sto.RestoranIDRestorana == IDRestorana)
							{
								dataBase.Stolovi.Remove(sto);
							}
						}
						foreach (Musterija musterija in musterije)
						{
							if (musterija.StoRestoranIDRestorana == IDRestorana)
							{
								Musterija novi = new Musterija();
								novi.Ime = musterija.Ime;
								novi.Prezime = musterija.Prezime;
								novi.RedniBroj = musterija.RedniBroj;
								novi.StoBrojStola = null;
								novi.StoRestoranIDRestorana = null;
								dataBase.Entry(novi).State = EntityState.Modified;
							}
						}

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
