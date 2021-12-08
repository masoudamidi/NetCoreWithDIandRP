using BusinessLogic.BLL;
using BusinessLogic.Interfaces;
using DataAccess.Models;

public interface ILocationsRepository : IGenericRepository<LocationsModel>
{
    SearchResult GetLocations(double Latitude, double Longitude, int maxDistance, int maxResults);
}