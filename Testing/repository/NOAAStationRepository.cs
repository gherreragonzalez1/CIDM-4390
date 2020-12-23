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

        // Place data retrieval methods here
        // Also declare the methods in domain/NOAAStationAggregate/INOAAStationRepository.cs
        public IEnumerable<NOAAStation> GetStationsByState(string StateAbbreviation) {
            return _context.Stations.Where(x => x.StateAbbreviation == StateAbbreviation);
        }
    }
}
