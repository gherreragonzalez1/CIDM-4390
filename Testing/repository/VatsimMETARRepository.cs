using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using domain;
using domain.VatsimMETARAggregate;

namespace repository
{
    public class VatsimMETARRepository : GenericRepository<VatsimMETAR>, IVatsimMETARRepository
    {

        public VatsimMETARRepository(WebApiDbContext context) : base(context)
        {
            
        }

        // Place data retrieval methods here
        // Also declare the methods in domain/VatsimMETARAggregate/VatsimMETARRepository.cs
        // public async Task<IEnumerable<VatsimMETAR>> GetAll() {
        //     return await _context.VatsimMETARs;
        // }
        
    }
}