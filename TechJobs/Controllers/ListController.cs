﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class ListController : TechJobsController
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Values(string column)
        {
            if (column.Equals("All"))
            {
                IEnumerable<Dictionary<string, string>> jobs = JobData.FindAll();
                ViewBag.title = "All Jobs";
                ViewBag.jobs = jobs;
                return View("Jobs");
            }
            else
            {
                IList<string> items = JobData.FindAll(column);
                ViewBag.title = "All " + columnChoices[column] + " Values";
                ViewBag.column = column;
                ViewBag.items = items;
                return View();
            }
        }

        public IActionResult Jobs(string column, string value)
        {
            IEnumerable<Dictionary<String, String>> jobs = JobData.FindByColumnAndValue(column, value);
            ViewBag.title = "Jobs with " + columnChoices[column] + ": " + value;
            ViewBag.jobs = jobs;

            return View();
        }
    }
}