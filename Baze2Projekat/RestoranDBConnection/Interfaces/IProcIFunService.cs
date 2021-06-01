using RestoranDB.PomocneKlase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDB.Interfaces
{
	public interface IProcIFunService
	{
		List<KuvarPodaci> ProcKuvar(int redniBroj);
		List<RestoranPodaci> ProcRestoran(int redniBroj);
		int FunUkupnaCena(int redniBroj);
		int FunBrojLjudi(int idRestoran);
	}
}
