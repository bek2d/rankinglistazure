﻿using Microsoft.AspNetCore.Mvc;


namespace MvcAppCollect.Controllers
{
    [Route("[controller]/[action]")]
    public class ItemController : Controller
    {
        //[HttpGet("{CollectionId}")]
        public IActionResult Index(int CollectionId)
        {
            ViewBag.message = CollectionId;
            return View();
        }
    }
}
