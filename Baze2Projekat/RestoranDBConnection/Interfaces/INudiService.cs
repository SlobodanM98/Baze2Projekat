using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDB.Interfaces
{
	public interface INudiService
	{
		bool Dodaj(int IDRestoran, string naziv);
		List<Nudi> DobaviSve();
		bool Izbrisi(int IDRestoran, string naziv);
	}
}
