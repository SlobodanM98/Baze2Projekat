using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDB.Interfaces
{
	public interface ISpremaService
	{
		bool Dodaj(int JMBG, string naziv);
		List<Sprema> DobaviSve();
		bool Izbrisi(int JMBG, string naziv);
	}
}
