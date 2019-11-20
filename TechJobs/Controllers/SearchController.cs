using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : TechJobsController
    {
        public IActionResult Index()
        {
            //ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            ViewBag.selected = "All";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

        
        public IActionResult Results(string searchType, string searchTerm)
        {
            if (searchTerm == null)
            {
                ViewBag.selected = searchType;
                ViewBag.error = "Please enter a keyword.";
                return View("Index");
                
            }
            IEnumerable<Dictionary<string, string>> jobs = new List<Dictionary<string, string>>();
            if (searchType == "All")
            {
                jobs = JobData.FindByValue(searchTerm);
            }
            else
            { 
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }
            ViewBag.jobs = jobs;
            //ViewBag.columns = ListController.columnChoices;
            ViewBag.selected = searchType;
            ViewBag.column = searchType;
            ViewBag.search = searchTerm;

            return View("Index");
        }

        
    }
}