using day25activityClient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

// In SDK-style projects such as this one, several assembly attributes that were historically
// defined in this file are now automatically added during build and populated with
// values defined in project properties. For details of which attributes are included
// and how to customise this process see: https://aka.ms/assembly-info-properties


// Setting ComVisible to false makes the types in this assembly not visible to COM
// components.  If you need to access a type in this assembly from COM, set the ComVisible
// attribute to true on that type.

//[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM.

//[assembly: Guid("74444364-e33c-4752-bfa5-d0bb99ca1377")]

namespace day25activityClient.Controllers
{
    public class SBTransactionController : Controller
   {
    public async Task<ActionResult> Index()
    {
        string Baseurl = "http://localhost:37797/";  //http://localhost:37797/api/SBTransactions
        var ProdInfo = new List<SBTransaction>();
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(Baseurl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage Res = await client.GetAsync("api/SBTransactions");
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var ProdResponse = Res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api and storing into the Employee list  
                ProdInfo = JsonConvert.DeserializeObject<List<SBTransaction>>(ProdResponse);
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
        public async Task<ActionResult> Create(SBTransaction sbt)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(sbt), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:37797/api/SBTransactions", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<SBTransaction>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            SBTransaction sba = new SBTransaction();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:37797/api/SBTransactions/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    sba = JsonConvert.DeserializeObject<SBTransaction>(apiResponse);
                }
            }
            return View(sba);
        }

        public async Task<ActionResult> Delete(int id)
        {
            TempData["TransactionID"] = id;
            SBTransaction b = new SBTransaction();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:37797/api/SBTransactions/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    b = JsonConvert.DeserializeObject<SBTransaction>(apiResponse);
                }
            }
            return View(b);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(SBTransaction b)
        {
            int vid = Convert.ToInt32(TempData["TransactionID"]);
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:37797/api/SBTransactions/" + vid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");

        }

        public async Task<ActionResult> Edit(int id)
        {
            TempData["TransactionID"] = id;
            SBTransaction b = new SBTransaction();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:37797/api/SBTransactions/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    b = JsonConvert.DeserializeObject<SBTransaction>(apiResponse);
                }
            }
            return View(b);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(SBTransaction b)
        {
            int vid = Convert.ToInt32(TempData["TransactionID"]);
             b.TransactionID = vid;
            SBTransaction receivedemp = new SBTransaction();
            
           
            using (var httpClient = new HttpClient())
            {
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(b), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("http://localhost:37797/api/SBTransactions/" + vid, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    receivedemp = JsonConvert.DeserializeObject<SBTransaction>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }



    }
}
