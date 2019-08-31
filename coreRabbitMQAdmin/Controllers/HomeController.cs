using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using coreRabbitMQAdmin.Models;

namespace coreRabbitMQAdmin.Controllers
{
    public class HomeController : Controller
    {
        public static List<Stoc> stocList = new List<Stoc>()
        {
            new Stoc(){ID=1,Name="NetaşTelekom",Value=Decimal.Parse("14.56")},
            new Stoc(){ID=2,Name="Bitcoin",Value=Decimal.Parse("41,583.99")},
            new Stoc(){ID=3,Name="Ethereum",Value=Decimal.Parse("1863.92")}
        };

        public List<Stoc> GetDummyData()
        {
            return stocList;
        }
        public IActionResult Index()
        {
            var data = GetDummyData();
            return View(data);
        }
        [HttpPost]
        public IActionResult Push(Stoc stoc)
        {
            UpdateDummyList(stoc);
            RabbitMQPost rabbitMq = new RabbitMQPost(stoc);
            Console.WriteLine(rabbitMq.Post());
            return RedirectToAction("Index");
        }
        public void UpdateDummyList(Stoc stoc)
        {
            int index = stocList.FindIndex(st => st.ID == stoc.ID);
            stocList[index] = stoc;
        }
    }
}
