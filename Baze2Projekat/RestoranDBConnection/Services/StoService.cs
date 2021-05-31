using RestoranDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDB.Services
{
	public class StoService : IStoService
	{
		public bool Azuriraj(int brojStola, int brojMesta, string tip, int IDRestoran)
		{
			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					Sto zaAzuriranje = dataBase.Stolovi.Find(brojStola, IDRestoran);

					if(zaAzuriranje == null)
					{
						return false;
					}
					else
					{
						dataBase.Stolovi.Remove(zaAzuriranje);
						dataBase.SaveChanges();

						Sto sto = null;

						switch (tip)
						{
							case "ZaDvoje":
								sto = new ZaDvoje();
								break;
							case "ZaCetvoro":
								sto = new ZaCetvoro();
								break;
							case "ZaSestoro":
								sto = new ZaSestoro();
								break;
						}

						sto.BrojStola = brojStola;
						sto.BrojMesta = brojMesta;
						sto.Tip = tip;
						sto.RestoranIDRestorana = zaAzuriranje.RestoranIDRestorana;

						dataBase.Stolovi.Add(sto);
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

		public Sto Dobavi(int brojStola, int IDRestoran)
		{
			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					return dataBase.Stolovi.Find(brojStola, IDRestoran);
				}
				catch
				{

				}
			}

			return null;
		}

		public List<Sto> DobaviSve()
		{
			List<Sto> izlaz = new List<Sto>();

			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					izlaz = dataBase.Stolovi.ToList();
				}
				catch
				{

				}
			}

			return izlaz;
		}

		public bool Dodaj(int brojStola, int brojMesta, string tip, int IDRestoran)
		{
			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					Sto sto = null;

					switch (tip)
					{
						case "ZaDvoje":
							sto = new ZaDvoje();
							break;
						case "ZaCetvoro":
							sto = new ZaCetvoro();
							break;
						case "ZaSestoro":
							sto = new ZaSestoro();
							break;
					}

					sto.BrojStola = brojStola;
					sto.BrojMesta = brojMesta;
					sto.Tip = tip;
					sto.RestoranIDRestorana = IDRestoran;

					dataBase.Stolovi.Add(sto);
					dataBase.SaveChanges();
				}
				catch
				{
					return false;
				}
			}

			return true;
		}

		public bool Izbrisi(int brojStola, int IDRestoran)
		{
			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					Sto zaBrisanje = dataBase.Stolovi.Find(brojStola, IDRestoran);

					if(zaBrisanje == null)
					{
						return false;
					}
					else
					{
						List<Musterija> musterije = dataBase.Musterije.ToList();

						foreach(Musterija musterija in musterije)
						{
							if(musterija.StoRestoranIDRestorana == IDRestoran && musterija.StoBrojStola == brojStola)
							{
								dataBase.Musterije.Remove(musterija);
							}
						}

						dataBase.Stolovi.Remove(zaBrisanje);
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
