using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDB.Interfaces
{
	public interface IRadiService
	{
		bool Dodaj(int JMBG, int IDRestoran);
		List<Radi> DobaviSve();
		Radi Dobavi(int JMBG, int IDRestoran);
		bool Izbrisi(int JMBG, int IDRestoran);
	}
}
