using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDB.Interfaces
{
	public interface IMusterijaService
	{
		bool Dodaj(string ime, string prezime, string brojStola, string IDRestoran);
		List<Musterija> DobaviSve();
		bool Izbrisi(int redniBroj);
		bool Azuriraj(int redniBroj, string ime, string prezime, string brojStola, string IDRestoran);
	}
}
