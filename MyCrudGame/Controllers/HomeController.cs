using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using MyCrudGame.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyCrudGame.Controllers
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
            try
            {

                #region Obtener libro
                string cadena1 = "Server=(localdb)\\MSSQLLocalDB;Database=CRUDMyGame1;Integrated Security=True;Trusted_Connection=false;MultipleActiveResultSets=true";
                SqlConnection con1 = new SqlConnection(cadena1);
                string sentencia1 = "select u.Id,NickName,icon,MaxExperience,MinExperience,s.Name from players as p inner join users as u on p.id = u.Id inner join ranks as r on u.Id = r.PlayerId inner join PlayerSkin as ps on p.id = ps.PlayerId inner join skins as s on ps.SkinId = s.id";
                SqlDataAdapter da1 = new SqlDataAdapter(sentencia1, con1);

                DataTable dt1 = new DataTable();
                //llenado datatable
                da1.Fill(dt1);

                #endregion
                TempData["MSG"] = "Estos son los usuarios";
                //return View("Index",dt1);
                return View(dt1);

            }
            catch (Exception ex)
            {
                TempData["ERROR"] = ex.Message;
                DataTable dt1 = new DataTable();
                //return View("Index");
                return View();
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
