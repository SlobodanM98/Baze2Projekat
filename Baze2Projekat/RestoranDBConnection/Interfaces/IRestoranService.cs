using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDB.Interfaces
{
	public interface IRestoranService
	{
		bool Dodaj(int IDRestorana, string naziv, int postanskiBroj);
		List<Restoran> DobaviSve();
		bool Izbrisi(int IDRestorana);
		bool Azuriraj(int IDRestorana, string naziv);
	}
}
