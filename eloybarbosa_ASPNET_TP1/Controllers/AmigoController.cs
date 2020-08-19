using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using eloybarbosa_ASPNET_TP1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain;
using Repository;

namespace eloybarbosa_ASPNET_TP1.Controllers
{
    public class AmigoController : Controller
    {
        private AmigoRepository Repository { get; set; }

        public AmigoController()
        {
            this.Repository = new AmigoRepository();
        }



        // GET: AmigoController
        public ActionResult Index()
        {
            return View(this.Repository.GetAll());
        }

        // GET: AmigoController/Details/5
        public ActionResult Detalhes(Guid id)
        {
            var amigo = this.Repository.GetAmigoById(id);

            return View(amigo);
        }

        // GET: AmigoController/Create
        public ActionResult CadastrarAmigos()
        {
            return View();
        }

        // POST: AmigoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarAmigos(Amigo amigo)
        {
            try
            {
                if (this.Repository.GetAmigoByEmail(amigo.Email) != null)
                {
                    ModelState.AddModelError("Email_Existente", "Já Existe um amigo com este email, por favor cadastre outro email");
                    return View(amigo);
                }

                amigo.Status = Status.EM_CONFIRMACAO_EMAIL;
                amigo.Id = Guid.NewGuid();

                this.Repository.Save(amigo);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AmigoController/Delete/5
       public ActionResult Deletar(Guid id)
        {

            var amigo = this.Repository.GetAmigoById(id);

            return View(amigo);
        }

        // POST: AmigoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletar(Guid id, Amigo amigo)
        {
            try
            {
                this.Repository.Deletar(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
