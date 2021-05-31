using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDB.Interfaces
{
	public interface IGradService
	{
		bool Dodaj(int postanskiBroj, string naziv);
		List<Grad> DobaviSve();
		Grad Dobavi(int postanskiBroj);
		bool Izbrisi(int postanskiBroj);
		bool Azuriraj(int postanskiBroj, string naziv);
	}
}
