using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.BLL;
using DataAccess.Models;

namespace RoamlerTest.Controllers
{
    public class SearchController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SearchController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetLocations(double latitude, double longitude, int maxDistance, int maxResults)
        {
            var VM = _unitOfWork.LocationsModel.GetLocations(latitude, longitude, maxDistance, maxResults);
            return View("/Views/Search/_GetLocations.cshtml", VM);
        }

    }
}
