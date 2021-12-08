using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Models;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.BLL
{
    public class LocationsRepository : GenericRepository<LocationsModel>, ILocationsRepository
    {
        public LocationsRepository(NetCoreWithDIandRPContext context) : base(context)
        {
        }

        public SearchResult GetLocations(double Latitude, double Longitude, int maxDistance, int maxResults)
        {
            var Result = new SearchResult();

            if (maxDistance < 1)
            {
                Result.Status = false;
                Result.Message = "Please Insert Valid Distance";
                return Result;
            }

            if (maxResults < 1)
            {
                Result.Status = false;
                Result.Message = "Please Insert Valid Result Count";

                return Result;
            }

            try
            {
                var locations = dbSet.FromSqlInterpolated($"EXEC dbo.GetNearTasks {Latitude}, {Longitude}, {maxDistance}, {maxResults}").ToList();

                if (locations.Count() > 0)
                {
                    Result.Status = true;
                    Result.Message = "";
                    Result.locations = locations;

                }
                else
                {
                    Result.Status = false;
                    Result.Message = "There is no task near you with conditions you asked.";
                }
            }
            catch (System.Exception e)
            {
                Result.Status = false;
                Result.Message = "Something went wrong, Please try again later.";
                return Result;
            }

            return Result;
        }
    }
}
