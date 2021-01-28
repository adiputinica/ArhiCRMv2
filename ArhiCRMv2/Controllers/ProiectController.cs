using ArhiCRMv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArhiCRMv2.Controllers
{
    public class ProiectController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Proiect
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            Proiect proiect = new Proiect();
            ViewBag.ListaTP = GetAllTipuriProiect();

            return View(proiect);
        }

        [HttpPost]
        [Authorize(Roles="Administrator,User")]
        public ActionResult Create(Proiect proiect)
        {
            var pro = new Proiect();
            var now = DateTime.Now.ToString("yyyy");
            int nrProAnCurent = db.Proiects.Where(p => p.An == now).Count();
            
            ViewBag.ListaTP = GetAllTipuriProiect();

            pro.TipProiectID = proiect.TipProiectID;
            pro.TipProiect = proiect.TipProiect;
            pro.Nume = proiect.Nume;
            pro.An = now;
            pro.NrProiect =(nrProAnCurent+1).ToString() + "/" + pro.An;
            pro.CreateDate = DateTime.Now;
            pro.StatusID = 1;
            pro.Status = db.Status.Find(pro.StatusID);

            db.Proiects.Add(pro);
            int ok = db.SaveChanges();
            int proiectID = pro.ID;
            Console.WriteLine(proiect.ID);
            Console.WriteLine(proiectID);
            if (ok == 1)
            {    
                return RedirectToAction("Edit", new {id=proiectID});
            }

            return View(proiect);
        }

        [Authorize(Roles="Administrator,User")]
        public ActionResult Edit(int id)
        {
            Proiect proiect = db.Proiects.Find(id);
            ViewBag.ListaStatus = GetAllStatuses();
            return View(proiect);
        }

        [HttpPut]
        [Authorize(Roles="Administrator,User")]
        public ActionResult Edit(int id, Proiect requestProiect)
        {
            Proiect proiect = db.Proiects.Find(id);
            try
            {
                if (User.IsInRole("Administrator") || User.IsInRole("User"))
                {
                    if (TryUpdateModel(proiect))
                    {
                        proiect.Nume = requestProiect.Nume;
                        proiect.NrContract = requestProiect.NrContract;
                        proiect.Valoare = requestProiect.Valoare;
                        proiect.Recomandare = requestProiect.Recomandare;
                        proiect.StatusID = requestProiect.StatusID;
                        proiect.BeneficiarID = requestProiect.BeneficiarID;
                        proiect.AmplasamentID = requestProiect.AmplasamentID;
                        proiect.Status = requestProiect.Status;
                        proiect.Beneficiar = requestProiect.Beneficiar;
                        proiect.Amplasament = requestProiect.Amplasament;
                        db.SaveChanges();
                        TempData["message"] = "Detaliile proiectului au fost actualizate.";
                    }
                    return RedirectToAction("Details", new {id});
                }
                else
                {
                    TempData["message"] = "Nu aveti drepturi pentru aceasta actiune.";
                    return RedirectToAction("Details", new {id});
                }
            }catch (Exception e)
            {
                return View(requestProiect);
            }
        }

        [HttpGet]
        [Authorize(Roles="Administrator,User,Client")]
        public ActionResult Details(int id)
        {
            Proiect proiect = db.Proiects.Find(id);
            ViewBag.ListaStatus = GetAllStatuses();
            return View(proiect);
        }

        [HttpPut]
        [Authorize(Roles="Administrator,User")]
        public ActionResult Details(int id, Proiect requestProiect)
        {
            Proiect proiect = db.Proiects.Find(id);
            try
            {
                if (User.IsInRole("Administrator") || User.IsInRole("User"))
                {
                    if (TryUpdateModel(proiect))
                    {
                        proiect.StatusID = requestProiect.StatusID;
                        proiect.Status = requestProiect.Status;
                        
                        db.SaveChanges();
                        TempData["message"] = "Detaliile proiectului au fost actualizate.";
                        return Content("Succes");
                    }
                    //return RedirectToAction("Details", new {id});
                }
                else
                {
                    TempData["message"] = "Nu aveti drepturi pentru aceasta actiune.";
                }
            }
            catch(Exception e)
            {
                TempData["message"] = "eroare" + e.ToString();
            }
            return Content("Eroare");
            //return View(proiect);
        }


        #region Helpere

        public IEnumerable<SelectListItem> GetAllTipuriProiect()
        {
            var selectList = new List<SelectListItem>();
            var types = from tp in db.TipProiects
                             select tp;

            foreach (var type in types)
            {
                selectList.Add(new SelectListItem
                {
                    Value = type.ID.ToString(),
                    Text = type.Nume.ToString()
                });
            }
            return selectList;
        }

        public IEnumerable<SelectListItem> GetAllStatuses()
        {
            var selectList = new List<SelectListItem>();
            var statuses = from tp in db.Status
                        select tp;

            foreach (var status in statuses)
            {
                selectList.Add(new SelectListItem
                {
                    Value = status.ID.ToString(),
                    Text = status.Descriere.ToString()
                });
            }
            return selectList;
        }
        #endregion

    }
}