using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampeonatoFut.Shared.Data.BD
{
    public class DAL
    {
        private readonly CampeonatoFutContext context;
        public DAL()
        {
            context = new CampeonatoFutContext();
        }
    }
}
