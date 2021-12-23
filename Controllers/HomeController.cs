using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVC221202021.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC221202021.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sobre()
        {
            return View();
        }

        public IActionResult Pessoas()
        {
            Context context = new Context();
            List<Pessoa> pessoas = (from Pessoa p in context.Pessoas select p).Include(e => e.Emails).ToList<Pessoa>();
            return View(pessoas);
        }

        public IActionResult PessoaID(int id)
        {
            Context context = new Context();
            Pessoa? p = context.Pessoas.Find(id);
            return View(p);
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Pessoa p)
        {
            Context context = new Context();
            context.Pessoas.Add(p);
            context.SaveChanges();

            return RedirectToAction("PessoaID", new { id = p.Id});
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
