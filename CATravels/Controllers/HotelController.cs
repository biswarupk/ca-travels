namespace CATravels.Controllers
{
    using System;
    using System.Threading.Tasks;
    using CATravels.Models;
    using CatTravels.Service.Abstract;
    using CatTravels.Utility.Abstract;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    public class HotelController : Controller
    {
        private readonly IConfiguration config;
        private readonly ILogger log;
        private readonly IHotelService apiService;
        public HotelController(IConfiguration config,ILogger log,IHotelService apiService)
        {
            this.config = config;
            this.log = log;
            this.apiService = apiService;
        }

        /// <summary>
        /// This action method loads the index page with text field Nights and Dropdown list field name Destination to search hotels from API endpoint.
        /// </summary>
        /// <returns>Returns the ViewResult for Index.cshtml</returns>
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        /// <summary>
        /// This action results returns the view result showing the number of hotels available along with its booking Board Type,Hotel Type,Base Price,Actual Price,Rate Type
        /// /// </summary>                                                                                                
        /// <param name="destinationId"> Destination Id on basis of Country</param>                                   
        /// <param name="nights"> No of Nights for booking a room</param>                                             
        /// <returns>Returns the ViewResult for Index.cshtml and Error.cshtml for any occurance of error</returns>   
        public async Task<ActionResult> Index(int destinationId, int nights)
        {
            ViewResult view = null;
            try
            { 
                ViewData["ResultSet"] = await this.apiService.GetHotelDetailsList(destinationId, nights);
                view =  View();
            }
            catch(Exception ex)
            {
                //exception to logged in log file.
                this.log.WriteErrorLog(ex.Message);
                view = View("Error", new ErrorViewModel { RequestId = new Guid().ToString(), ExceptionMessage = ex.Message });
            }
            return view;
        }
    }
}