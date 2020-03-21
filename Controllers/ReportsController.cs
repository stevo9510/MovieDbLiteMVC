using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieDbLite.MVC.Models;
using System.Threading.Tasks;

namespace MovieDbLite.MVC.Controllers
{
    public class ReportsController : Controller
    {
        private readonly MovieDbLiteContext _context;

        public ReportsController(MovieDbLiteContext context)
        {
            _context = context;
        }

        // GET: Reports
        public async Task<IActionResult> Index()
        {
            var winnerInfo = _context.VwAwardWinnerInfo;
            return View(await winnerInfo.ToListAsync());
        }

        // GET: Reports/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

    }
}