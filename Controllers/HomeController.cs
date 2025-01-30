using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Moment2.Models;

namespace Moment2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Index";
            ViewData["Heading"] = "Index";
            return View();
        }

        public IActionResult Media()
        {
            ViewData["Title"] = "Lägg till media";
            ViewData["Heading"] = "Lägg till media";
            return View();
        }

        public IActionResult MediaList()
        {
            ViewData["Title"] = "Media lista";
            ViewData["Heading"] = "Media lista";
            return View();
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
            return View();
        }
    }
}