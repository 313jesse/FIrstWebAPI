using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Configuration;

namespace Testnumbersapi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HttpWebRequest apiRequest = WebRequest.CreateHttp("https://numbersapi.p.mashape.com/1492/year?fragment=true&json=true");

            apiRequest.Headers.Add("X-Mashape-Key", ConfigurationManager.AppSettings["X-Mashape-Key"]); //used to add keys. 
            apiRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0";


            HttpWebResponse apiResponse = (HttpWebResponse)apiRequest.GetResponse();  //represents actual response from API

            //need to check if anything actual comes back with anything. 

            if(apiResponse.StatusCode == HttpStatusCode.OK)  //we got a 200 response, things are good. 
            {
                //get data and then parse it here. 


                StreamReader ResponseData = new StreamReader(apiResponse.GetResponseStream());

                    string Trivia = ResponseData.ReadToEnd();
                JObject jsonTrivia = JObject.Parse(Trivia);
                ViewBag.TriviaText = jsonTrivia["text"];
                ViewBag.TriviaYear = jsonTrivia["year"];

                ViewBag.Trivia = Trivia;

            }


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}