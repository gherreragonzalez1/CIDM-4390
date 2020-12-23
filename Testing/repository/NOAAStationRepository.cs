using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain;
using domain.NOAAStationAggregate;

namespace repository
{
    public class NOAAStationRepository : GenericRepository<NOAAStation>, INOAAStationRepository
    {
        public NOAAStationRepository(WebApiDbContext context) : base(context)
        {
            
        }

        //place data retrieval methods here
        public IEnumerable<NOAAStation> GetStationsByState(string StateAbbreviation) {
            return _context.Stations.Where(x => x.StateAbbreviation == StateAbbreviation);
        }
    }
}
