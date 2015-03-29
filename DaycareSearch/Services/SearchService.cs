using DaycareSearch.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DaycareSearch.Services
{
    public static class SearchService
    {
        private static string serviceUrl = "http://www.sclfcca.com";

        public static List<DaycareProvider> GetList(Search search)
        {
            var links = GetAllPages(search);
            var providers = new List<DaycareProvider>();

            foreach (var link in links)
            {
                providers.Add(ScrapeDaycareProvider(link.OriginalString));
            }

            return providers;
        }

        private static Uri BuildInitialRequest(Search search)
        {
            var queryString = HttpUtility.ParseQueryString(String.Empty);
            queryString["zoom_sort"] = "0";
            queryString["zoom_query"] = "";
            queryString["zoom_per_page"] = "10";
            queryString["zoom_and"] = "0";

            var criteria = search.GetCriteria();
            foreach (var criterion in criteria)
            {
                queryString[criterion.Key] = criterion.Value.ToString();
            }

            return new Uri(serviceUrl + "/search.php?" + queryString.ToString());
        }

        private static List<Uri> GetAllPages(Search search)
        {
            var resultUrls = new List<Uri>();
            var nextLink = BuildInitialRequest(search).OriginalString;

            while (nextLink.Length > 0)
            {
                HtmlWeb hweb = new HtmlWeb();
                HtmlDocument hdoc = hweb.Load(nextLink);

                resultUrls.AddRange(GetPageLinks(hdoc));

                var nextLinks = hdoc.DocumentNode.SelectNodes("//div[@class='result_pages']").Descendants("a").Where(a => a.InnerText.Contains("Next"));
                nextLink = nextLinks.Count() > 0
                    ? serviceUrl + HttpUtility.HtmlDecode(nextLinks.First().Attributes["href"].Value) 
                    : ""
                ;
                    
            }

            return resultUrls;
        }

        private static List<Uri> GetPageLinks(HtmlDocument doc)
        {
            return doc.DocumentNode
                .SelectNodes("//div[@class='result_title']")
                .Descendants("a")
                .Where(a => a.Attributes["href"].Value.Contains("www.sclfcca.com") 
                    && a.Attributes["href"].Value.Split('.').Last() != "pdf"
                )
                .Select(a => new Uri(a.Attributes["href"].Value))
                .ToList<Uri>();
        }

        private static DaycareProvider ScrapeDaycareProvider(string url)
        {

            HtmlWeb hweb = new HtmlWeb();
            HtmlDocument hdoc = hweb.Load(url);
            var provider = new DaycareProvider();

            provider.listingUrl = url;
            AddNameOwnerInformation(provider, hdoc);
            AddLocationInformation(provider, hdoc);
            AddContactInformation(provider, hdoc);
            AddOperationInformation(provider, hdoc);

            return provider;
        }

        private static void AddNameOwnerInformation(DaycareProvider provider, HtmlDocument doc)
        {
            var headers = doc.DocumentNode.Descendants("h2").ToList();
            provider.name = headers[0].InnerText;
            provider.owner = headers[1].InnerText;
        }

        private static void AddLocationInformation(DaycareProvider provider, HtmlDocument doc)
        {
            var header = doc.DocumentNode.Descendants("h4").Where(d => d.InnerText.Contains("Location:"));

            if (header.Count() > 0)
            {
                var headerContent = header.First();
                provider.location = headerContent.InnerText.Split(new char[] { ' ' }, 2).Last();

                var sibling = headerContent.NextSibling;

                while (sibling != null && sibling.Name != "h4")
                {
                    if (sibling.InnerText.Trim().Length > 0 && sibling.Name != "a")
                    {
                        provider.address += sibling.InnerText.Replace("\n", "") + ", ";
                    }
                    sibling = sibling.NextSibling;
                }

                if (provider.address != null)
                {
                    provider.address = provider.address.Trim().TrimEnd(',');
                }
            }

        }

        private static void AddContactInformation(DaycareProvider provider, HtmlDocument doc)
        {
            var header = doc.DocumentNode.Descendants("h4").Where(d => d.InnerText.Contains("Contact Information"));

            if (header.Count() > 0)
            {
                var headerContent = header.First();

                var sibling = headerContent.NextSibling;

                while (sibling != null && sibling.Name != "h4")
                {
                    if (sibling.InnerText.Trim().StartsWith("Email address:"))
                    {
                        provider.email = sibling.NextSibling.InnerText;
                    }

                    if (sibling.InnerText.Trim().StartsWith("Phone:"))
                    {
                        provider.phone = sibling.InnerText.Replace("Phone:", "").Trim();
                    }

                    if (sibling.InnerText.Trim().StartsWith("Web Site Link:"))
                    {
                        provider.website = sibling.NextSibling.Attributes["href"].Value;
                    }

                    sibling = sibling.NextSibling;
                }

            }

        }

        private static void AddOperationInformation(DaycareProvider provider, HtmlDocument doc)
        {
            var header = doc.DocumentNode.Descendants("h4").Where(d => d.InnerText.Contains("Days/Hours"));

            if (header.Count() > 0)
            {
                var headerContent = header.First();

                var sibling = headerContent.NextSibling;

                while (sibling != null && sibling.Name != "h4")
                {
                    if (sibling.InnerText.Trim().StartsWith("Days of the Week:"))
                    {
                        provider.daysOfTheWeek = sibling.InnerText.Replace("Days of the Week:", "").Trim();
                    }

                    if (sibling.InnerText.Trim().StartsWith("Hours:"))
                    {
                        provider.hours = sibling.InnerText.Replace("Hours:", "").Trim();
                    }

                    sibling = sibling.NextSibling;
                }

            }

        }
    }
}