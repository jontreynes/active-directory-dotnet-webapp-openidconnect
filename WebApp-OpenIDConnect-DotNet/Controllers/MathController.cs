using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApp_OpenIDConnect_DotNet.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace WebApp_OpenIDConnect_DotNet.Controllers
{
    public class MathController : Controller
    {
        [Authorize]
        // GET: Math
        public ActionResult MathForm()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> MathForm(MathModelClass model)
        {
            if (ModelState.IsValid)
            {
                var z = await AzFxnAdd(model.x_number, model.y_number);
                
                TempData["notice"] = "" + model.x_number + "+" + model.y_number + "= " + z;
            }

            return View();
        }

        //async static void AzFxnAdd(string x_number, string y_number)
        private async static Task<String> AzFxnAdd(int x_number, int y_number)
        {

            var model = new MathModelClass{x_number=x_number, y_number=y_number};



            using (var client = new HttpClient())
            {
                var uri = new Uri("<INSERT AZURE FUNCTION URL>");
                var json = new JavaScriptSerializer().Serialize(model);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(uri, stringContent);
                response.EnsureSuccessStatusCode();

                
                var res = await response.Content.ReadAsStringAsync();
                return res;
            }
            
        }
    }
}