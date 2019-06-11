using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;
        private readonly ILogger<ListModel> logger;

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, IRestaurantData restaurantData, ILogger<ListModel> logger)
        {
            this.config = config;
            this.restaurantData = restaurantData;
            this.logger = logger;
        }

        // Method wwith tags and helpers
        public void OnGet()
        {
            logger.LogError("Executing get");
            Message = config["Message"];
            Restaurants = restaurantData.GetRestaurantByName(SearchTerm);
        }

        /*
         * Method for QueryString
        public void OnGet(string searchTerm)
        {

            //HttpContext.Request.QueryString

            Message = config["Message"];
            //Message = "Hello world !";
            //Restaurants = restaurantData.GetAll();
            Restaurants = restaurantData.GetRestaurantByName(searchTerm);
        }
        */
    }
}