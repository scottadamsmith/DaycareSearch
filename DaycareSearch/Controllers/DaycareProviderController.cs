using DaycareSearch.Models;
using DaycareSearch.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Model = DaycareSearch.Models;
using System.Web;

namespace DaycareSearch.Controllers
{
    public class DaycareProviderController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Search([FromUri] Search search) 
        {
            var results = SearchService.GetList(search);
            return Ok<List<Model.DaycareProvider>>(results);
        }

        //TODO: look into MediaTypeFormatters to replace this function
        [HttpGet]
        public void SearchCSV([FromUri] Search search)
        {
            var providers = SearchService.GetList(search);

            var builder = new StringBuilder();
            builder.AppendLine("Name,Owner,ListingUrl,Location,Address,Phone,Email,DaysOfTheWeek,Hours,Website,LastUpdated,OutdoorPlayArea,Sandbox,FencedYard,IndoorPets,OutdoorPets,InfantOpenings");

            var providerLines = providers.Select(p =>
                p.name
                + "," + (p.owner ?? "").ToString().Replace(",", " ")
                + "," + (p.listingUrl ?? "").ToString().Replace(",", " ")
                + "," + (p.location ?? "").ToString().Replace(",", " ")
                + "," + (p.address ?? "").ToString().Replace(",", " ")
                + "," + (p.phone ?? "").ToString().Replace(",", " ")
                + "," + (p.email ?? "").ToString().Replace(",", " ")
                + "," + (p.daysOfTheWeek ?? "").ToString().Replace(",", " ")
                + "," + (p.hours ?? "").ToString().Replace(",", " ")
                + "," + (p.website ?? "").ToString().Replace(",", " ")
                + "," + (p.lastUpdated ?? "").ToString().Replace(",", " ")
                + "," + (p.outdoorPlayArea ?? "").ToString().Replace(",", " ")
                + "," + (p.sandbox ?? "").ToString().Replace(",", " ")
                + "," + (p.fencedYard ?? "").ToString().Replace(",", " ")
                + "," + (p.indoorPets ?? "").ToString().Replace(",", " ")
                + "," + (p.outdoorPets ?? "").ToString().Replace(",", " ")
                + "," + (p.infantOpenings ?? "").ToString().Replace(",", " ")
            ).ToList();

            foreach (var line in providerLines)
            {
                builder.AppendLine(line.Replace("\n", ""));
            }

            var response = HttpContext.Current.Response;
            response.Clear();
            response.ClearHeaders();
            response.ClearContent();
            response.AddHeader("content-disposition", "attachment; filename=daycareproviders.csv");
            response.ContentType = "text/csv";
            response.AddHeader("Pragma", "public");
            response.Write(builder.ToString());
            response.End();
        }
    }
}
