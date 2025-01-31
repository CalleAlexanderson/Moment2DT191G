
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Moment2.Models;

namespace Moment2.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly string[] nav = ["Index", "Media", "MediaList"];
        public IActionResult Index()
        {
            ViewData["Title"] = "Index";
            ViewData["Heading"] = "Index";
            string key = "caal2301_cookie";
            var cookieValue = Request.Cookies[key];
            ViewBag.user = cookieValue;
            ViewBag.nav = nav;
            ViewBag.loc = "Index";
            return View();
        }



        [HttpPost]
        public IActionResult Index(UserModel model)
        {
            string key = "caal2301_cookie";
            string value = model.User;
            CookieOptions options = new CookieOptions
            {
                Domain = "localhost",
                Expires = DateTime.Now.AddDays(1), // Cookie försvinner efter 1 dag
                Path = "/", // Cookie kan nås från hela webbplatsen
                Secure = true,
                HttpOnly = true,
                IsEssential = false
            };

            ModelState.Clear();
            Response.Cookies.Append(key, value, options);
            ViewData["Title"] = "Index";
            ViewData["Heading"] = "Index";
            ViewBag.user = model.User;
            ViewBag.nav = nav;
            ViewBag.loc = "Index";
            return View();
        }

        public IActionResult Media()
        {
            ViewData["Title"] = "Lägg till media";
            ViewData["Heading"] = "Lägg till media";
            ViewBag.nav = nav;
            ViewBag.loc = "Media";
            return View();
        }

        public IActionResult MediaList()
        {
            ViewData["Title"] = "Media lista";
            ViewData["Heading"] = "Media lista";
            ViewBag.nav = nav;
            ViewBag.loc = "MediaList";
            Text text = new Text() {
                BodyText = "Det här är en lista med olika former av media (filmer, serier och böcker), den har baserats på MyAnimeList listor.",
                DescText = "Filmer/Serier = Mörkblå. Böcker = Mörkgrön"
            };
            return View(text);
        }

        [HttpPost]
        public IActionResult Media(MediaModel model)
        {
            model.Date = DateTime.Now;

            // gör kategorierna till egna index i listan
            if (model.MediaTags[0] != null)
            {
                model.MediaTags = model.MediaTags[0].Split(',').Select(str => str.Trim()).ToArray();
            }
            else
            {
                model.MediaTags[0] = "";
            }

            // kollar om model följer MediaModel 
            if (ModelState.IsValid)
            {
                // läser json från filen media.json
                string jsondata = System.IO.File.ReadAllText("media.json");
                // ändrar json datan till en lista med MediaModel object
                var medias = JsonSerializer.Deserialize<List<MediaModel>>(jsondata);
                if (medias != null)
                {
                    // lägger till den nya median till listan
                    medias.Add(model);
                    // uppdaterar json datan
                    jsondata = JsonSerializer.Serialize(medias);
                    // skriver över filen med den nya json datan
                    System.IO.File.WriteAllText("media.json", jsondata);
                }
                // nollställer formuläret
                ModelState.Clear();
            }
            ViewData["Title"] = "Lägg till media";
            ViewData["Heading"] = "Lägg till media";
            ViewBag.nav = nav;
            ViewBag.loc = "Media";
            return View();
        }
    }
}