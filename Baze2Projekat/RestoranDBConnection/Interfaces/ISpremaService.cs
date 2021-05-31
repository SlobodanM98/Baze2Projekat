using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDB.Interfaces
{
	public interface ISpremaService
	{
		bool Dodaj(int JMBG, string naziv, int IDRestoran);
		List<Sprema> DobaviSve();
		Sprema Dobavi(int JMBG, string naziv, int IDRestoran);
		bool Izbrisi(int JMBG, string naziv, int IDRestoran);
	}
}
