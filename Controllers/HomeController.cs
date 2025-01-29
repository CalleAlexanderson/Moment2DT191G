using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Moment2.Models;

namespace Moment2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Media()
        {
            return View();
        }

        public IActionResult Site3()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Media(MediaModel model){
            if (ModelState.IsValid)
            {
                string jsondata = System.IO.File.ReadAllText("media.json");
                var medias = JsonSerializer.Deserialize<List<MediaModel>>(jsondata);
                if (medias != null)
                {
                    medias.Add(model);
                    jsondata = JsonSerializer.Serialize(medias);
                    System.IO.File.WriteAllText("media.json", jsondata);
                }

                ModelState.Clear();
            }
            return View();
        }
    }
}