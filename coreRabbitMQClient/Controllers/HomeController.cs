using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using coreRabbitMQClient.Models;

namespace coreRabbitMQClient.Controllers
{
    public class HomeController : Controller
    {
        public static List<Stoc> stocList = new List<Stoc>()
        {
            new Stoc(){ID=1,Name="NetasTelekom",Value=Decimal.Parse("14.56")},
            new Stoc(){ID=2,Name="Bitcoin",Value=Decimal.Parse("41,583.99")},
            new Stoc(){ID=3,Name="Ethereum",Value=Decimal.Parse("1863.92")}
        };

        public IActionResult Index()
        {
            return View(stocList);
        }

        [HttpPost]
        public IActionResult Detail(int ID)
        {
            Stoc stoc = stocList.FirstOrDefault(s => s.ID == ID);
            return View(stoc);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
