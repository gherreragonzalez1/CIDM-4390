using System.Collections.Generic;

namespace domain.NOAAStationAggregate
{
    public interface INOAAStationRepository : IGenericRepository<NOAAStation>
    {
        IEnumerable<NOAAStation> GetStationsByState(string State);
    }
}