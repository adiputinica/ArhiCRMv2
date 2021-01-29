using ArhiCRMv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArhiCRMv2.Controllers
{
    public class BeneficiarController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Beneficiar
        public ActionResult Index()
        {
            return View();
        }

        [HttpPut]
        [Authorize(Roles = "Administrator,User")]
        public ContentResult Edit(int id, Proiect requestBeneficiar)
        {
            Beneficiar beneficiar = db.Beneficiars.Find(id);
            try
            {
                if (User.IsInRole("Administrator") || User.IsInRole("User")){
                    if (TryUpdateModel(beneficiar))
                    {
                        beneficiar.Nume = requestBeneficiar.Beneficiar.Nume;
                        beneficiar.Adresa = requestBeneficiar.Beneficiar.Adresa;
                        beneficiar.CNP = requestBeneficiar.Beneficiar.CNP;
                        beneficiar.SerieCI = requestBeneficiar.Beneficiar.SerieCI;
                        beneficiar.NumarCI = requestBeneficiar.Beneficiar.NumarCI;
                        beneficiar.Telefon = requestBeneficiar.Beneficiar.Telefon;
                        beneficiar.Email = requestBeneficiar.Beneficiar.Email;
                        beneficiar.PersoanaContact = requestBeneficiar.Beneficiar.PersoanaContact;
                        beneficiar.TelefonPersoanaContact = requestBeneficiar.Beneficiar.TelefonPersoanaContact;
                        db.SaveChanges();
                        TempData["message"] = "Detaliile beneficiarului au fost actualizate.";
                        return Content("Succes");
                    }
                    else
                    {
                        return Content("Eroare");
                    }
                }
                else
                {
                    TempData["message"] = "Nu aveti drepturi pentru aceasta actiune.";
                    return Content("Eroare");
                }
            }
            catch(Exception e)
            {
                TempData["message"] = "eroare" + e.ToString();
            }
            return Content("Eroare");
        }
    }
}