using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace API.Models
{
    public enum OpeningOptions
    {
          [Description("All")]
          Default = -1
        , [Description("Yes")] 
          Yes = 0
        , [Description("No")]
          No = 1
    }

    public enum LocationOptions 
    {
          [Description("All")]
          Default = -1
        , [Description("Belle Plaine")]  
          BellePlaine = 0
        , [Description("Elko")]
          Elko = 1
        , [Description("Lakeville")]
          Lakeville = 2
        , [Description("New Market")]
          NewMarket = 3
        , [Description("Webster")]
          Webster = 4
        , [Description("Jordan")]
          Jordan = 5
        , [Description("New Prague")]
          NewPrague = 6
        , [Description("Prior Lake")]
          PriorLake = 7
        , [Description("Savage")]
          Savage = 8
        , [Description("Shakopee")]
          Shakopee = 9
        , [Description("Montgomery")]
          Montgomery = 10
        , [Description("Le Center")]
          LeCenter = 11
        , [Description("Le Sueur")]
          LeSueur = 12
        , [Description("Henderson")]
          Henderson = 14
        , [Description("Lonsdale")]
          Lonsdale = 15
        , [Description("Chaska")]
          Chaska = 16
        , [Description("Norwood Young America")]
          NorwoodYoungAmerica = 17
        , [Description("Burnsville")]
          Burnsville = 18
    }
    
    public class Search
    {
        public LocationOptions Location { get; set; }
        public OpeningOptions InfantOpenings { get; set; }
        public OpeningOptions ToddlerOpenings { get; set; }
        public OpeningOptions PreschoolOpenings { get; set; }
        public OpeningOptions SchoolAgeOpenings { get; set; }

        public Search()
        {
            this.Location = LocationOptions.Default;
            this.InfantOpenings = OpeningOptions.Default;
            this.ToddlerOpenings = OpeningOptions.Default;
            this.PreschoolOpenings = OpeningOptions.Default;
            this.SchoolAgeOpenings = OpeningOptions.Default;
        }

        public Dictionary<string, int> GetCriteria() 
        {
            var criteria = new Dictionary<string, int>();
            criteria.Add("Location", (int)this.Location);
            criteria.Add("InfantOpenings", (int)this.InfantOpenings);
            criteria.Add("ToddlerOpenings", (int)this.ToddlerOpenings);
            criteria.Add("PreschoolOpenings", (int)this.PreschoolOpenings);
            criteria.Add("SchoolAgeOpenings", (int)this.SchoolAgeOpenings);
            return criteria;
        }
    }
}