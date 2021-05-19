using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;

using day24activityClient1.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


// In SDK-style projects such as this one, several assembly attributes that were historically
// defined in this file are now automatically added during build and populated with
// values defined in project properties. For details of which attributes are included
// and how to customise this process see: https://aka.ms/assembly-info-properties


// Setting ComVisible to false makes the types in this assembly not visible to COM
// components.  If you need to access a type in this assembly from COM, set the ComVisible
// attribute to true on that type.

//[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM.

//[assembly: Guid("716dbb7b-f034-468d-b595-3e8a3376beea")]

namespace day24activityClient1.Controllers
{
    public class SBAccountController : Controller
    {
        public async Task<ActionResult> Index()
        {
            string Baseurl = "http://localhost:5866/";
            var ProdInfo = new List<SBAccount>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/SBAccounts");
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var ProdResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    ProdInfo = JsonConvert.DeserializeObject<List<SBAccount>>(ProdResponse);
                }
                //returning the employee list to view  
                return View(ProdInfo);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(SBAccount sba)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(sba), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:5866/api/SBAccounts", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<SBAccount>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            SBAccount sba = new SBAccount();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5866/api/SBAccounts/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    sba = JsonConvert.DeserializeObject<SBAccount>(apiResponse);
                }
            }
            return View(sba);
        }

        public async Task<ActionResult> Delete(int id)
        {
            TempData["AccountID"] = id;
            SBAccount b = new SBAccount();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5866/api/SBAccounts/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    b = JsonConvert.DeserializeObject<SBAccount>(apiResponse);
                }
            }
            return View(b);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(SBAccount b)
        {
            int vid = Convert.ToInt32(TempData["AccountID"]);
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:5866/api/SBAccounts/" + vid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");

        }

        public async Task<ActionResult> Edit(int id)
        {
            TempData["AccountID"] = id;
            SBAccount b = new SBAccount();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5866/api/SBAccounts/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    b = JsonConvert.DeserializeObject<SBAccount>(apiResponse);
                }
            }
            return View(b);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(SBAccount b)
        {
            SBAccount receivedemp = new SBAccount();
            int vid = Convert.ToInt32(TempData["AccountID"]);
            using (var httpClient = new HttpClient())
            {
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(b), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("http://localhost:5866/api/SBAccounts/" + vid, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    receivedemp = JsonConvert.DeserializeObject<SBAccount>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }
    }
}


