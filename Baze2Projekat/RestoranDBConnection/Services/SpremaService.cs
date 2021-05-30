﻿using RestoranDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDB.Services
{
	public class SpremaService : ISpremaService
	{
		public List<Sprema> DobaviSve()
		{
			List<Sprema> izlaz = new List<Sprema>();

			using(var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					izlaz = dataBase.Spremas.ToList();
				}
				catch
				{

				}
			}

			return izlaz;
		}

		public bool Dodaj(int JMBG, string naziv)
		{
			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					Sprema sprema = new Sprema();
					sprema.KuvarJMBG = JMBG;
					sprema.ProizvodNaziv = naziv;

					dataBase.Spremas.Add(sprema);
					dataBase.SaveChanges();
				}
				catch
				{
					return false;
				}
			}

			return true;
		}

		public bool Izbrisi(int JMBG, string naziv)
		{
			using (var dataBase = new ModelFirstDBContainer())
			{
				try
				{
					Sprema zaBrisanje = dataBase.Spremas.Find(naziv, JMBG);

					if(zaBrisanje == null)
					{
						return false;
					}
					else
					{
						dataBase.Spremas.Remove(zaBrisanje);
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