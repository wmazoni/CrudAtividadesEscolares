using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CadastroAtividades5.Models;

namespace CadastroAtividades5.Controllers
{
    public class AtividadesController : Controller
    {
        private AtividadesEntities db = new AtividadesEntities();

        // GET: Atividades
        public async Task<ActionResult> Index()
        {
            return View(await db.tblAtividades.ToListAsync());
        }

        // GET: Atividades/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAtividade tblAtividade = await db.tblAtividades.FindAsync(id);
            if (tblAtividade == null)
            {
                return HttpNotFound();
            }
            return View(tblAtividade);
        }

        // GET: Atividades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Atividades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,nome,descricao,dataEntrega")] tblAtividade tblAtividade)
        {
            if (ModelState.IsValid)
            {
                db.tblAtividades.Add(tblAtividade);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tblAtividade);
        }

        // GET: Atividades/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAtividade tblAtividade = await db.tblAtividades.FindAsync(id);
            if (tblAtividade == null)
            {
                return HttpNotFound();
            }
            return View(tblAtividade);
        }

        // POST: Atividades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,nome,descricao,dataEntrega")] tblAtividade tblAtividade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblAtividade).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tblAtividade);
        }

        // GET: Atividades/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAtividade tblAtividade = await db.tblAtividades.FindAsync(id);
            if (tblAtividade == null)
            {
                return HttpNotFound();
            }
            return View(tblAtividade);
        }

        // POST: Atividades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tblAtividade tblAtividade = await db.tblAtividades.FindAsync(id);
            db.tblAtividades.Remove(tblAtividade);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
