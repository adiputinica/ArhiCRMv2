using ArhiCRMv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArhiCRMv2.Controllers
{
    public class AmplasamentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Amplasament
        public ActionResult Index()
        {
            return View();
        }

        [HttpPut]
        [Authorize(Roles = "Administrator,User")]
        public ContentResult Edit(int id, Proiect requestAmplasament)
        {
            Amplasament amplasament = db.Amplasaments.Find(id);
            try
            {
                if (User.IsInRole("Administrator") || User.IsInRole("User"))
                {
                    if (TryUpdateModel(amplasament))
                    {
                        amplasament.SuprafataTerenMasurata = requestAmplasament.Amplasament.SuprafataTerenMasurata;
                        amplasament.JudetID = requestAmplasament.Amplasament.JudetID;
                        amplasament.LocalitateID = requestAmplasament.Amplasament.LocalitateID;
                        amplasament.ComunaSat = requestAmplasament.Amplasament.ComunaSat;
                        amplasament.Strada = requestAmplasament.Amplasament.Strada;
                        amplasament.Numar = requestAmplasament.Amplasament.Numar;
                        amplasament.Tarla = requestAmplasament.Amplasament.Tarla;
                        amplasament.Parcela = requestAmplasament.Amplasament.Parcela;
                        amplasament.NumarCadastral = requestAmplasament.Amplasament.NumarCadastral;
                        amplasament.NumarCF = requestAmplasament.Amplasament.NumarCF;
                        amplasament.Judet = requestAmplasament.Amplasament.Judet;
                        amplasament.Localitate = requestAmplasament.Amplasament.Localitate;

                        db.SaveChanges();
                        TempData["message"] = "Detaliile amplasamentului au fost actualizate.";
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
            catch (Exception e)
            {
                TempData["message"] = "eroare" + e.ToString();
            }
            return Content("Eroare");
        }
    }
}