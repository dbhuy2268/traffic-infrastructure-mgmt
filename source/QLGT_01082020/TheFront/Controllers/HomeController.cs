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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http.Extensions;
using Korzh.EasyQuery.Linq;

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

        [Authorize]
        public async Task<IActionResult> Home_GPLX()
        {
            List<GiayPhepLaiXeModel> gplx = new List<GiayPhepLaiXeModel>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/GiayPhepLaiXe");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                gplx = JsonConvert.DeserializeObject<List<GiayPhepLaiXeModel>>(results);
            }
            return View(gplx);
        }

        [Authorize]
        public ActionResult Create_GPLX()
        {
            return View();
        }
        [HttpPost]
        public async Task<GiayPhepLaiXeModel> Create_GPLX(GiayPhepLaiXeModel giay)
        {
            GiayPhepLaiXeModel gp = new GiayPhepLaiXeModel();
            HttpClient client = _api.Initial();

            using (client)
            {
                //Http Post
                using (var postTask = await client.PostAsync("api/GiayPhepLaiXe", new StringContent(JsonConvert.SerializeObject(giay), Encoding.UTF8, "application/json")))
                {
                    var api_response = await postTask.Content.ReadAsStringAsync();
                    gp = JsonConvert.DeserializeObject<GiayPhepLaiXeModel>(api_response);
                }
            }
            //return RedirectToAction("Create");
            return gp;
        }

        [Authorize]
        public ActionResult Create_HoSo()//sdfsd
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create_HoSo([FromBody] List<HoSoModel> o_HoSo_collection)
        {
            HoSoModel HS = new HoSoModel();
            HttpClient client = _api.Initial();

            using (client)
            {
                foreach (HoSoModel o_HoSo in o_HoSo_collection)
                {
                    //Http Post
                    using (var postTask = await client.PostAsync("api/HoSo", new StringContent(JsonConvert.SerializeObject(o_HoSo), Encoding.UTF8, "application/json")))
                    {
                        var api_response = await postTask.Content.ReadAsStringAsync();
                        HS = JsonConvert.DeserializeObject<HoSoModel>(api_response);
                        //var status = await postTask.Is
                        if (!postTask.IsSuccessStatusCode)
                        {
                            return BadRequest();
                        }
                    }
                }
            }
            return Ok();
            //return RedirectToAction("Create");
            //return HS;
        }

        [Authorize]
        public ActionResult Create_YeuCau()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create_YeuCau([FromBody] YeuCauXinModel o_YC)
        {
            YeuCauXinModel YC = new YeuCauXinModel();
            HttpClient client = _api.Initial();

            using (client)
            {
                //Http Post
                using (var postTask = await client.PostAsync("api/YeuCauXin", new StringContent(JsonConvert.SerializeObject(o_YC), Encoding.UTF8, "application/json")))
                {
                    var api_response = await postTask.Content.ReadAsStringAsync();
                    YC = JsonConvert.DeserializeObject<YeuCauXinModel>(api_response);
                    //if (!postTask.IsSuccessStatusCode)
                    //{
                    //    return Ok();
                    //}
                    postTask.EnsureSuccessStatusCode();

                }
            }
            //return RedirectToAction("Create");
            return Ok();
        }

        [Authorize]
        public ActionResult Create_LichHen()
        {
            return View();
        }
        [HttpPost]
        public async Task<ThongTinLichHenModel> Create_LichHen(ThongTinLichHenModel o_LichHen)
        {
            ThongTinLichHenModel LH = new ThongTinLichHenModel();
            HttpClient client = _api.Initial();

            using (client)
            {
                //Http Post
                using (var postTask = await client.PostAsync("api/ThongTinLichHen", new StringContent(JsonConvert.SerializeObject(o_LichHen), Encoding.UTF8, "application/json")))
                {
                    var api_response = await postTask.Content.ReadAsStringAsync();
                    LH = JsonConvert.DeserializeObject<ThongTinLichHenModel>(api_response);
                }
            }
            //return RedirectToAction("Create");
            return LH;
        }

        [Authorize]
        public async Task<ActionResult> XetDuyet_LichHen(int id = 0)
        {
            ThongTinLichHenModel LH = new ThongTinLichHenModel();
            HttpClient client = _api.Initial();

            using (client)
            {
                //Http Post
                using (var postTask = await client.PutAsync("api/ThongTinLichHen/" + id, new StringContent(JsonConvert.SerializeObject(LH), Encoding.UTF8, "application/json")))
                {
                    var api_response = await postTask.Content.ReadAsStringAsync();
                    LH = JsonConvert.DeserializeObject<ThongTinLichHenModel>(api_response);
                }
            }
            //return RedirectToAction("Create");
            return View(LH);
        }

        [Authorize]
        public IActionResult Home_TraCuuLuat()
        {
            List<LuatModel> luats = new List<LuatModel>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = client.GetAsync("api/Luats").GetAwaiter().GetResult();
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                luats = JsonConvert.DeserializeObject<List<LuatModel>>(results);
            }
            return View(luats);
        }

        //[Authorize]
        //[HttpPost]
        //public IActionResult Home_TraCuuLuat(LuatViewModel model)
        //{
        //    HttpClient client = _api.Initial();
        //    HttpResponseMessage res = client.GetAsync("api/Luats").GetAwaiter().GetResult();
        //    var results = res.Content.ReadAsStringAsync().Result;
        //    if (!string.IsNullOrEmpty(model.Text))
        //    {
        //        model.Luats = ((IQueryable<LuatModel>)JsonConvert.DeserializeObject<List<LuatModel>>(results)).FullTextSearchQuery(model.Text);
        //    }
        //    else
        //    {
        //        model.Luats = (IQueryable<LuatModel>)JsonConvert.DeserializeObject<List<LuatModel>>(results);
        //    }
        //    return View(model);
        //}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
