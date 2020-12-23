using System.Collections.Generic;

namespace domain.NOAAStationAggregate
{
    public interface INOAAStationRepository : IGenericRepository<NOAAStation>
    {
        // Method inside repository/NOAAStationRepository.cs
        IEnumerable<NOAAStation> GetStationsByState(string State);
    }
}