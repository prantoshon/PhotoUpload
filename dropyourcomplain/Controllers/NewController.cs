using System;
using System.Data;
using  System.Data.SqlClient;
using System.IO;
using dropyourcomplain.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dropyourcomplain.Controllers
{
    public class NewController : Controller
    {
        //
        // GET: /New/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddComplain()
        {
            var list = new List<string> { "Main Hall Missing", "Draingae", "Road Damage", "Dustbin Problem" };

            var ComplainArea = new List<string> { "Mohammadpur", "MirPur-1", "Dhamondli" };
            ViewBag.ComplainArea = ComplainArea;

            ViewBag.list = list;
            return View();
        }
        ComplainAddEntities1 db = new ComplainAddEntities1();
        public ActionResult AddNeCompain()
        {
            var list = new List<string> { "Main Hall Missing", "Draingae", "Road Damage", "Dustbin Problem" };

            var ComplainArea = new List<string> { "Mohammadpur", "MirPur-1", "Dhamondli" };
            ViewBag.ComplainArea = ComplainArea;

            ViewBag.list = list;
            return View();
        }
        [HttpPost]
        public ActionResult AddNeCompain(AddComplain addComplainData, HttpPostedFileBase imgfile)
        {
            var list = new List<string> { "Main Hall Missing", "Draingae", "Road Damage", "Dustbin Problem" };

            var ComplainArea = new List<string> { "Mohammadpur", "MirPur-1", "Dhamondli" };
            ViewBag.ComplainArea = ComplainArea;

            ViewBag.list = list;
            AddComplain di = new AddComplain();
            string path = uploadimage(imgfile);
            db.AddComplains.Add(addComplainData);
            di.ComplainType = ComplainType;
            di.ComplainArea = ComplainArea;
            di.RoadNumber = RoadNumber;
            di.ComplainDetails = ComplainDetails;
            di.Photo = Photo;
            di.Compailer_Name = Complainer_Name;
            di.Cotract_Number = Contract_Number;
            di.Email = Email;
            db.SaveChanges();
            ModelState.Clear();
            ViewBag.msg = "data added";
            return View();
        }

        public string uploadimage(HttpPostedFileBase file)
        {

            Random r = new Random();

            string path = "-1";

            int random = r.Next();

            if (file != null && file.ContentLength > 0)
            {

                string extension = Path.GetExtension(file.FileName);

                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                {

                    try
                    {



                        path = Path.Combine(Server.MapPath("~/Content/upload"), random + Path.GetFileName(file.FileName));

                        file.SaveAs(path);

                        path = "~/Content/upload/" + random + Path.GetFileName(file.FileName);



                        //    ViewBag.Message = "File uploaded successfully";

                    }

                    catch (Exception ex)
                    {

                        path = "-1";

                    }

                }

                else
                {

                    Response.Write("<script>alert('Only jpg ,jpeg or png formats are acceptable....'); </script>");

                }

            }



            else
            {

                Response.Write("<script>alert('Please select a file'); </script>");

                path = "-1";

            }







            return path;

        }
	}
}