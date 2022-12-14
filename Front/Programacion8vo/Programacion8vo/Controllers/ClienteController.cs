using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Programacion8vo.Controllers
{
    public class ClienteController : Controller
    {
        // GET: ClienteController
        public async Task<ActionResult> Index()
        {
            List<Models.clienteModel> clientes = new List<Models.clienteModel>();
            var  api = new HttpClient();
            var json = await api.GetStringAsync("https://localhost:7297/Listclientes/");
            clientes = JsonConvert.DeserializeObject<List<Models.clienteModel>>(json);
            return View(clientes);

           
            
          
        }

        // GET: ClienteController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            
            var api = new HttpClient();
            var json = await api.GetStringAsync("https://localhost:7297/clientes/"+id);
            Models.clienteModel cliente = JsonConvert.DeserializeObject<Models.clienteModel>(json);

            

            return View(cliente);
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Models.clienteModel cliente)
        {
            try
            {
                var json = JsonConvert.SerializeObject(cliente);
                var data = new StringContent(json, Encoding.UTF8, "Application/json");
                var api = new HttpClient();
                var response = await api.PostAsync("https://localhost:7297/clientes/", data);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id, Models.clienteModel cliente )
        {
            cliente.Id = id;
            var json = JsonConvert.SerializeObject(cliente);
            var data = new StringContent(json, Encoding.UTF8, "Application/json");
            var api = new HttpClient();
            var response = api.PostAsync("https://localhost:7297/clientes/", data);

            return View(model: cliente);

        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection )
        {
            try
            {
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id, Models.clienteModel cliente)
        {
            cliente.Id = id;
            var json = JsonConvert.SerializeObject(cliente);
            var data = new StringContent(json, Encoding.UTF8, "Application/json");
            var api = new HttpClient();
            var response = api.PostAsync("https://localhost:7297/clientes/", data);

            return View(model: cliente);
            return View();
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
