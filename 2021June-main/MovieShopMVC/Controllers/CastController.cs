using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopMVC.Controllers
{
    public class CastController : Controller
    {
        private ICastService _castSevice;
        public CastController(ICastService castService)
        {
            _castSevice = castService;
        }
        public async Task<IActionResult> CastDetail(int id)
        {
            var movie = await _castSevice.GetCastDetails(id);
            return View(movie);
        }
    }
}
