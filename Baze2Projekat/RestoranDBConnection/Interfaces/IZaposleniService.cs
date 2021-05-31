using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDB.Interfaces
{
	interface IZaposleniService
	{
		bool Dodaj(int jmbg, string tip, string ime, string prezime);
		List<Zaposleni> DobaviSve();
		Zaposleni Dobavi(int jmbg);
		bool Izbrisi(int jmbg);
		bool Azuriraj(int jmbg, string tip, string ime, string prezime);
	}
}
