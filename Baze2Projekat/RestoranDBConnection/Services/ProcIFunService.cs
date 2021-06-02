using RestoranDB.Interfaces;
using RestoranDB.PomocneKlase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDB.Services
{
	public class ProcIFunService : IProcIFunService
	{
		public int FunBrojLjudi(int idRestoran)
		{
			using (var dataBase = new ModelFirstDBContainer())
			{
				var rezultat = new SqlParameter { ParameterName = "rezultat", Direction = System.Data.ParameterDirection.Output, SqlDbType = System.Data.SqlDbType.Int };
				SqlParameter[] parameters = { new SqlParameter { ParameterName = "idRestoran", Value = idRestoran, SqlDbType = System.Data.SqlDbType.Int }, rezultat };
				dataBase.Database.ExecuteSqlCommand("exec @rezultat = FUNBrojLjudiZaStolovima @idRestoran", parameters);

				return (int)rezultat.Value;
			}
		}

		public int FunUkupnaCena(int redniBroj)
		{
			using (var dataBase = new ModelFirstDBContainer())
			{
				var rezultat = new SqlParameter { ParameterName = "rezultat", Direction = System.Data.ParameterDirection.Output, SqlDbType = System.Data.SqlDbType.Int };
				SqlParameter[] parameters = { new SqlParameter { ParameterName = "redniBroj", Value = redniBroj, SqlDbType = System.Data.SqlDbType.Int }, rezultat };
				dataBase.Database.ExecuteSqlCommand("exec @rezultat = FUNUkupnaCenaMusterije @redniBroj", parameters);

				return (int)rezultat.Value;
			}
		}

		public List<KuvarPodaci> ProcKuvar(int redniBroj)
		{
			using(var dataBase = new ModelFirstDBContainer())
			{
				return dataBase.Database.SqlQuery<KuvarPodaci>("PROCSviKuvariMusterije @redniBroj", new SqlParameter { ParameterName = "redniBroj", Value = redniBroj }).ToList();
			}
		}

		public List<RestoranPodaci> ProcRestoran(int redniBroj)
		{
			using (var dataBase = new ModelFirstDBContainer())
			{
				dataBase.Database.SqlQuery<RestoranPodaci>("PROCSviRestoraniMusterijeCursor @redniBroj", new SqlParameter { ParameterName = "redniBroj", Value = redniBroj });
				return dataBase.Database.SqlQuery<RestoranPodaci>("PROCSviRestoraniMusterije @redniBroj", new SqlParameter { ParameterName = "redniBroj", Value = redniBroj }).ToList();
			}
		}
	}
}
