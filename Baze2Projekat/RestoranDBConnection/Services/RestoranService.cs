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

		public Restoran Dobavi(int IDRestorana)
		{
			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					return dataBase.Restorani.Find(IDRestorana);
				}
				catch
				{

				}
			}

			return null;
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
						List<Nudi> nudis = dataBase.Nudis.ToList();
						List<Sprema> spremas = dataBase.Spremas.ToList();
						List<Kupuje> kupovine = dataBase.Kupovine.ToList();
						List<Radi> radis = dataBase.Radis.ToList();
						List<Sto> stolovi = dataBase.Stolovi.ToList();
						List<Musterija> musterije = dataBase.Musterije.ToList();

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
						foreach(Radi radi in radis)
						{
							if(radi.RestoranIDRestorana == IDRestorana)
							{
								dataBase.Radis.Remove(radi);
							}
						}
						foreach(Sto sto in stolovi)
						{
							if(sto.RestoranIDRestorana == IDRestorana)
							{
								dataBase.Stolovi.Remove(sto);
							}
						}
						foreach(Musterija musterija in musterije)
						{
							if(musterija.StoRestoranIDRestorana == IDRestorana)
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
