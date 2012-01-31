using System.Web.Mvc;
using System.Web.Routing;
using KyivBeerNCode;
using KyivBeerNCode.Domain.Meetings;
using UI.Models.Meetings;

namespace UI.Controllers
{
    public class MeetingsController : Controller
    {
        //
        // GET: /Meetings/

        public ActionResult Index()
        {
            // In most cases this is not best idea to query 
            // object for view from though repositories
            // This is huge antipattern, because of performance
            // possible side effects, and well just lack
            // or concern separation.
            // I hope to change this code to direct access to store
            // or to denormalized views. To something more suitable.

            var env = ExecutionEnvironment.Default();
            var meetings = env.Resolve<MeetingRepository>();
            var meetingsToShow = meetings.GetAll();
            return View(new MeetingIndexModel
            {
                Meetings = meetingsToShow,                
            });
        }        

        //
        // GET: /Meetings/Details/5

        public ActionResult Details(string id)
        {
            var env = ExecutionEnvironment.Default();
            var meetings = env.Resolve<MeetingRepository>();
            var meeting = meetings.GetByID(id);

            return View(new MeetingDetailsModel
            {
                Meeting = meeting
            });
        }

        //
        // GET: /Meetings/Details/5/Register

        public ActionResult Register(string id)
        {
            var env = ExecutionEnvironment.Default();
            var meetings = env.Resolve<MeetingRepository>();
            var meeting = meetings.GetByID(id);

            return View(new MeetingDetailsModel
            {
                Meeting = meeting
            });
        } 

        //
        // POST: /Meetings/Details/5/Register

        [HttpPost]
        public ActionResult Create(string id, FormCollection collection)
        {
            try
            {
                


                return RedirectToAction("Details", new { id });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Meetings/Create

        //public ActionResult Create()
        //{
        //    return View();
        //} 

        //
        // POST: /Meetings/Create

        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        
        //
        // GET: /Meetings/Edit/5
 
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //
        // POST: /Meetings/Edit/5

        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here
 
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


    }
}
