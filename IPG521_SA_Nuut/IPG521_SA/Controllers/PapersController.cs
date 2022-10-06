using IPG521_SA.Data;
using IPG521_SA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IPG521_SA.Controllers
{
    [Authorize(Roles = "Client")]
    public class PapersController : Controller
    {        
            PapersDbContext PapersDb = new PapersDbContext();
            // GET: Product
            [AllowAnonymous]
            public ActionResult Index()
            {
                return View(PapersDb.Papers.ToList());
            }
            // GET: Product
            [AllowAnonymous]
            public ActionResult List()
            {
                var paper = PapersDb.Papers.Where(s => s.PaperAuthor == User.Identity.Name);
                var topics = PapersDb.Topics.ToList();
                var PaperView = new PaperView {papers = paper,topics = topics };
                return View(PaperView);
            }
            public ActionResult Create()
            {
                return View();
            }
            [HttpPost]
            public ActionResult Create(Papers paper, FormCollection formCollection)
            {
            if (ModelState.IsValid)
            {
                    paper.PaperAuthor = User.Identity.Name;
                    paper.TopicID = int.Parse(paper.TopicID.ToString());
                    paper.PaperDateSubmitted = DateTime.Now.ToShortDateString();
                    PapersDb.Papers.Add(paper);
                    PapersDb.SaveChanges();
                    return RedirectToAction("List");                
            }
                return View(paper);
            }
            [HttpGet]
            public ActionResult Edit(int id)
            {
                var papers = PapersDb.Papers.Find(id);
                return View(papers);
            }
            [HttpPost]
            public ActionResult Edit(int id, FormCollection collection)
            {
                var papers = PapersDb.Papers.Find(id);
                if (ModelState.IsValid)
                {
                    if (TryUpdateModel(papers))
                    {
                        PapersDb.SaveChanges();
                        return RedirectToAction("List");
                    }
                    else
                        ModelState.AddModelError("Database Failed to update", "");

                }
                return View(papers);
            }
            [HttpGet]
            public ActionResult Delete(int id)
            {
                var papers = PapersDb.Papers.Find(id);
                return View(papers);
            }
            [HttpPost]
            public ActionResult Delete(int id, FormCollection collection)
            {
                try
                {
                    var papers = PapersDb.Papers.Find(id);
                    PapersDb.Papers.Remove(papers);
                    PapersDb.SaveChanges();
                    return RedirectToAction("List");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(ex.Message, "");
                }
                return View();
            }
    }
}