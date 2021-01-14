﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TheFront.Models;
using TheFront.Helper;
using Microsoft.AspNetCore.Authorization;

namespace TheFront.Controllers
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
            //return View();
            return View("~/Views/Home/Index.cshtml");
        }

        TheAPI _api = new TheAPI();
        [Authorize]
        public async Task<IActionResult> Home_DangKiem()
        {
            List<PhuongTiensModel> phuongTiens = new List<PhuongTiensModel>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/PhuongTiens");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                phuongTiens = JsonConvert.DeserializeObject<List<PhuongTiensModel>>(results);
            }
            return View(phuongTiens);
        }
        [Authorize]
        public async Task<IActionResult> Details_DangKiem(int id)
        {
            var phuongTien = new PhuongTiensModel();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/PhuongTiens/{id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                phuongTien = JsonConvert.DeserializeObject<PhuongTiensModel>(results);
            }
            return View(phuongTien);
        }
        [Authorize]
        public async Task<IActionResult> CheckHistory_DangKiem(int id)
        {
            var phuongTien = new PhuongTiensModel();
            var ttdkiem = new List<ThongTinDangKiemsModel>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/PhuongTiens/{id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                phuongTien = JsonConvert.DeserializeObject<PhuongTiensModel>(results);
                ttdkiem = phuongTien.ThongTinDangKiems.ToList();
            }
            return View(ttdkiem);
        }
        [Authorize]
        public async Task<IActionResult> CheckAppointment_DangKiem(int id)
        {
            var phuongTien = new PhuongTiensModel();
            var ttlichhen = new List<ThongTinLichHenModel>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/PhuongTiens/{id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                phuongTien = JsonConvert.DeserializeObject<PhuongTiensModel>(results);
                ttlichhen = phuongTien.ThongTinLichHens.ToList();
            }
            return View(ttlichhen);
        }
        [Authorize]
        public async Task<IActionResult> Details_LichHen(int id)
        {
            var thongtinlichhen = new ThongTinLichHenModel();
            var chitietlichhen = new List<DichVuDangKyModel>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"/api/ThongTinLichHen/{id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                thongtinlichhen = JsonConvert.DeserializeObject<ThongTinLichHenModel>(results);
                chitietlichhen = thongtinlichhen.DichVuDangKies.ToList();
            }
            return View(chitietlichhen);
        }



        [Authorize]
        public ActionResult Create_BB()
        {
            return View();
        }
        [HttpPost]
        public async Task<BienBanModel> Create_BB(BienBanModel bb)
        {
            BienBanModel o_bb = new BienBanModel();
            HttpClient client = _api.Initial();

            using (client)
            {
                //Http Post
                using (var postTask = await client.PostAsync("api/BienBan", new StringContent(JsonConvert.SerializeObject(bb), Encoding.UTF8, "application/json")))
                {
                    var api_response = await postTask.Content.ReadAsStringAsync();
                    o_bb = JsonConvert.DeserializeObject<BienBanModel>(api_response);
                }
            }
            //return RedirectToAction("Create");
            return o_bb;
        }
        [Authorize]
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
