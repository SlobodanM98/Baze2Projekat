using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDB.Interfaces
{
	public interface IKupujeService
	{
		bool Dodaj(int redniBroj, int JMBG, int IDRestoran, string naziv);
		List<Kupuje> DobaviSve();
		bool Izbrisi(int redniBroj, int JMBG, int IDRestoran, string naziv);
	}
}
