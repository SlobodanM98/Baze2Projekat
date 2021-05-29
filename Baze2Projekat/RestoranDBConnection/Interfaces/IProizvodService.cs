using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDB.Interfaces
{
	public interface IProizvodService
	{
		bool Dodaj(string naziv, string tip, int cena);
		List<Proizvod> DobaviSve();
		bool Izbrisi(string naziv);
		bool Azuriraj(string naziv, string tip, int cena);
	}
}
