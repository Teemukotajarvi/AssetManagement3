using AssetManagement3.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using AssetManagement3.Models;
using AssetManagement3.Database;

namespace AssetManagement3.Controllers
{
    public class AssetController : Controller
    {
        // GET: Asset
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Test()
        {
            return View();
        }
        // GET: Asset/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Asset/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AssignLocation()
        {
            string json = Request.InputStream.ReadToEnd();
            AssignLocatioModel inputData =
                JsonConvert.DeserializeObject<AssignLocatioModel>(json);

            bool success = false;
            string error = "";
           Omat_tietokannatEntities entities = new Omat_tietokannatEntities();
            try
            {
                // haetaan ensin paikan id-numero koodin perusteella
                int locationId = (from l in entities.AssetLocations
                                  where l.Code == inputData.LocationCode
                                  select l.Id).FirstOrDefault();

                // haetaan laitteen id-numero koodin perusteella
                int assetId = (from a in entities.Assets
                               where a.Code == inputData.AssetCode
                               select a.Id).FirstOrDefault();

                if ((locationId > 0) && (assetId > 0))
                {
                    // tallennetaan uusi rivi aikaleiman kanssa kantaan
                    AssetLocation1 newEntry = new AssetLocation1();
                    newEntry.LocationId = locationId;
                    newEntry.AssetId = assetId;
                    newEntry.LastSeen = DateTime.Now;

                    entities.AssetLocations1.Add(newEntry);
                    entities.SaveChanges();

                    success = true;
                }
            }
            catch (Exception ex)
            {
                error = ex.GetType().Name + ": " + ex.Message;
            }
            finally
            {
                entities.Dispose();
            }

            // palautetaan JSON-muotoinen tulos kutsujalle
            var result = new { success = success, error = error };
            return Json(result);



        }
    }
}


        