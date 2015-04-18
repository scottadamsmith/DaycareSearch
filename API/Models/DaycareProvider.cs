using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DaycareSearch.API.Models
{
    public class DaycareProvider
    {
        public string name { get; set; }
        public string owner { get; set; }
        public string listingUrl { get; set; }
        public string location { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string daysOfTheWeek { get; set; }
        public string hours { get; set; }
        public string website { get; set; }
        public string lastUpdated { get; set; }
        public string outdoorPlayArea { get; set; }
        public string sandbox { get; set; }
        public string fencedYard { get; set; }
        public string indoorPets { get; set; }
        public string outdoorPets { get; set; }
        public string infantOpenings { get; set; }
        public HtmlString htmlAddress
        {
            get
            {
                if (this.address != null)
                {
                    return new HtmlString(this.address.Replace(",", "<br />"));
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
