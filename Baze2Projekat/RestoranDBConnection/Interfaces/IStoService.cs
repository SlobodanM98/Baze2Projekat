using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDB.Interfaces
{
	public interface IStoService
	{
		bool Dodaj(int brojStola, int brojMesta, string tip, int IDRestoran);
		List<Sto> DobaviSve();
		Sto Dobavi(int brojStola, int IDRestoran);
		bool Izbrisi(int brojStola, int IDRestoran);
		bool Azuriraj(int brojStola, int brojMesta, string tip, int IDRestoran);
	}
}
