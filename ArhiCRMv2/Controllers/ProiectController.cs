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
            pro.BeneficiarID = creareBeneficiar();
            pro.AmplasamentID = creareAmplasament();
           
            db.Proiects.Add(pro);
            int ok = db.SaveChanges();
            int proiectID = pro.ID;
            if (ok == 3)
            {    
                return RedirectToAction("Edit", new {id=proiectID});
            }
            else
            {
                RedirectToAction("Index");
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
                        proiect.Status = requestProiect.Status;
                        db.SaveChanges();
                        TempData["message"] = "Detaliile proiectului au fost actualizate.";
                    }
                    return RedirectToAction("Details", new {id = id});
                }
                else
                {
                    TempData["message"] = "Nu aveti drepturi pentru aceasta actiune.";
                    return RedirectToAction("Details", new {id = id});
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
            if(proiect.Amplasament.JudetID == null)
            {
                proiect.LocalitateSubCategory = new[] { new SelectListItem { Value = "", Text = "" } };
            }
            else
            {
                var idJudetCurent = Int32.Parse(proiect.Amplasament.JudetID.ToString());
                proiect.LocalitateSubCategory = GetLocalitati(idJudetCurent);
            }
            ViewBag.ListaStatus = GetAllStatuses();
            ViewBag.ListaJudete = GetAllJudete();
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

        public IEnumerable<SelectListItem> GetAllJudete()
        {
            var selectList = new List<SelectListItem>();
            var judete = from tp in db.Judets
                           select tp;

            foreach (var judet in judete)
            {
                selectList.Add(new SelectListItem
                {
                    Value = judet.ID.ToString(),
                    Text = judet.Nume.ToString()
                });
            }
            return selectList;
        }

        public IEnumerable<SelectListItem> GetLocalitati(int id)
        {
            var selectList = new List<SelectListItem>();
            var localitati = from tp in db.Localitates
                         select tp;
            var local = localitati.Where(a => a.JudetID == id).OrderBy(a => a.Nume);
            foreach (var localitate in local)
            {
                selectList.Add(new SelectListItem
                {
                    Value = localitate.ID.ToString(),
                    Text = localitate.Nume.ToString()
                });
            }

            return selectList;
        }

        public ActionResult GetSub(int id)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var localitati = from tp in db.Localitates
                         select tp;
            var local = localitati.Where(a => a.JudetID == id).OrderBy(a => a.Nume);

            foreach (var localitate in local)
            {
                items.Add(new SelectListItem
                {
                    Value = localitate.ID.ToString(),
                    Text = localitate.Nume.ToString()
                });
            }

            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public int creareBeneficiar()
        {
            var benef = new Beneficiar();
            db.Beneficiars.Add(benef);
            return benef.ID;
        }

        public int creareAmplasament()
        {
            var amplas = new Amplasament();
            db.Amplasaments.Add(amplas);
            return amplas.ID;
        }
        #endregion

    }
}