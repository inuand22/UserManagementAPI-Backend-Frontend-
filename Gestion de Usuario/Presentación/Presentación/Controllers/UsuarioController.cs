using DTO;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace Presentación.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: UsuarioController
        public ActionResult Index()
        {
            string url = "http://localhost:5272/api/Usuario";
            try
            {
                HttpClient cliente = new HttpClient();
                Task<HttpResponseMessage> tarea1 = cliente.GetAsync(url);
                tarea1.Wait();

                HttpResponseMessage respuesta = tarea1.Result;

                HttpContent body = respuesta.Content;
                Task<string> tarea2 = body.ReadAsStringAsync();
                tarea2.Wait();

                if (respuesta.IsSuccessStatusCode)
                {
                    string json = tarea2.Result;
                    List<UsuarioDTO> dto = JsonConvert.DeserializeObject<List<UsuarioDTO>>(json);
                    return View(dto);
                }
                else
                {
                    string error = tarea2.Result;
                    ViewBag.Error = error;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ocurrió un error inesperado: " + ex.Message;
            }

            return View(new List<UsuarioDTO>());
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                string url = "http://localhost:5272/api/Usuario/" + id;
                HttpClient cliente = new HttpClient();
                Task<HttpResponseMessage> tarea1 = cliente.GetAsync(url);
                tarea1.Wait();

                HttpResponseMessage respuesta = tarea1.Result;
                HttpContent body = respuesta.Content;
                Task<string> tarea2 = body.ReadAsStringAsync();
                tarea2.Wait();

                if (respuesta.IsSuccessStatusCode)
                {
                    string json = tarea2.Result;
                    UsuarioDTO dto = JsonConvert.DeserializeObject<UsuarioDTO>(json);
                    return View(dto);
                }
                else
                {
                    string error = tarea2.Result;
                    ViewBag.Error = error;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioDTO dto)
        {
            try
            {
                string url = "http://localhost:5272/api/Usuario/";

                HttpClient cliente = new HttpClient();

                Task<HttpResponseMessage> tarea1 = cliente.PostAsJsonAsync(url, dto);
                tarea1.Wait();

                HttpResponseMessage respuesta = tarea1.Result;
                HttpContent body = respuesta.Content;
                if (respuesta.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    Task<string> tarea2 = body.ReadAsStringAsync();
                    tarea2.Wait();

                    ViewBag.Error = tarea2.Result;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                string url = "http://localhost:5272/api/Usuario/" + id;
                HttpClient cliente = new HttpClient();
                Task<HttpResponseMessage> tarea1 = cliente.GetAsync(url);
                tarea1.Wait();

                HttpResponseMessage respuesta = tarea1.Result;
                HttpContent body = respuesta.Content;

                Task<string> tarea2 = body.ReadAsStringAsync();
                tarea2.Wait();

                if (respuesta.IsSuccessStatusCode)
                {
                    string json = tarea2.Result;
                    UsuarioDTO dto = JsonConvert.DeserializeObject<UsuarioDTO>(json);
                    return View(dto);
                }
                else
                {
                    string error = tarea2.Result;
                    ViewBag.Error = error;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioDTO dto)
        {
            try
            {
                string url = "http://localhost:5272/api/Usuario/" + dto.Id;
                HttpClient cliente = new HttpClient();
                var tarea1 = cliente.PutAsJsonAsync(url, dto);
                tarea1.Wait();

                HttpResponseMessage respuesta = tarea1.Result;
                HttpContent body = respuesta.Content;
                if (respuesta.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    Task<string> tarea2 = body.ReadAsStringAsync();
                    string error = tarea2.Result;
                    ViewBag.Error = error;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            try
            {
                string url = "http://localhost:5272/api/Usuario/" + id;
                HttpClient cliente = new HttpClient();
                Task<HttpResponseMessage> tarea1 = cliente.GetAsync(url);
                tarea1.Wait();
                HttpResponseMessage respuesta = tarea1.Result;
                HttpContent body = respuesta.Content;

                Task<string> tarea2 = body.ReadAsStringAsync();
                tarea2.Wait();

                if (respuesta.IsSuccessStatusCode)
                {
                    string json = tarea2.Result;
                    UsuarioDTO dto = JsonConvert.DeserializeObject<UsuarioDTO>(json);
                    return View(dto);
                }
                else
                {
                    string error = tarea2.Result;
                    ViewBag.error = error;
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View();
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        public ActionResult Delete(UsuarioDTO dto)
        {
            string url = "http://localhost:5272/api/Usuario/" + dto.Id;
            HttpClient cliente = new HttpClient();
            Task<HttpResponseMessage> tarea1 = cliente.DeleteAsync(url);

            HttpResponseMessage respuesta = tarea1.Result;
            HttpContent body = respuesta.Content;
            if (respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
