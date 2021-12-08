using System;
using System.Collections.Generic;

namespace DataAccess.Models
{

    public class SearchResult
    {
        public bool? Status { get; set; }
        public string? Message { get; set; }
        public List<LocationsModel> locations = new List<LocationsModel>();
    }
    
}