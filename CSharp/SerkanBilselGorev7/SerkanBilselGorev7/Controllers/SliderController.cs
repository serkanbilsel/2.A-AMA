using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SerkanBilselGorev7.Data;
using SerkanBilselGorev7.Models;

namespace SerkanBilselGorev7.Controllers
{
    public class SliderController : Controller
    {

        private readonly DatabaseContext _context;
        // GET: SlidersController
        public SliderController(DatabaseContext context) // S.O.L.I.D Prensipleri - Clean Code ARAŞTIR
        {
            _context = context;
        }

      
    }

}
