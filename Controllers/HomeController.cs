﻿using HiTech.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HiTech.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            if (TempData.Peek("id") != null)
            {

                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpPost]
        public IActionResult Index(Admin login)
        {
            DataSet ds = login.login(login.email, login.password);
            ViewBag.data = ds.Tables[0];
            foreach (System.Data.DataRow row in ViewBag.data.Rows)
            {
                TempData["id"] = row["id"].ToString();
                return RedirectToAction("Dashboard");
            }
            return RedirectToAction("Index");
        }

        
        public IActionResult Logout()
        {
            TempData.Clear();
            return RedirectToAction("Index");
        }
        public IActionResult Dashboard(Admin user)
        {
            if (TempData.Peek("id") != null)
            {
                DataSet ds = user.allproduct();
                ViewBag.data = ds.Tables[0];
                return View();
            }
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult User(Admin user, int a = 0)
        {
            DataSet ds = user.user();
            ViewBag.data = ds.Tables[0];
            ViewBag.active = user.status;
            return View();
        }
        [HttpPost]
        public IActionResult User(Admin user)
        {
            DataSet ds = user.user();
            ViewBag.data = ds.Tables[0];
            return RedirectToAction("User");
        }

        public IActionResult Delete(Admin db, int id = 0)
        {
            db.delete(id);
            return RedirectToAction("User");
        }
        [HttpGet]
        public IActionResult Update(Admin user, int id)
        {
            DataSet dataSet = user.select_data(id);
            ViewBag.data = dataSet.Tables[0];
            return View();
        }
        [HttpPost]
        public IActionResult Update(Admin user, int id, int a = 0)
        {
            user.update(user.name, user.email, user.password, id);
            return RedirectToAction("User");
        }

        [HttpGet]

        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Admin rg)
        {
            string status = "true";
            rg.insert(rg.name, rg.email, rg.password,status);
            return RedirectToAction("User");
        }

        [HttpGet]
        public IActionResult Product(Admin user)
        {
            DataSet ds = user.allproduct();
            ViewBag.data = ds.Tables[0];
            return View();
        }

        public IActionResult ProductInsert()
        {
            return View();
        }
        [HttpPost]
        public  IActionResult ProductInsert(Admin add)
        {
            //var image = ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim();
            //var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","NewProduct",formFile.FileName);
            //using (System.IO.Stream stream = new FileStream(path, FileMode.Create))
            //{
            //    await formFile.CopyToAsync(stream);
            //}
            //string seriallizableString = image.ToString();
            //TempData["p_image"]= seriallizableString;
            int id = int.Parse((string)TempData.Peek("id"));
            //add.product_image = image.ToString();
            add.productInsert(add.product_name,id, add.brand, add.color, add.condition, add.description, add.starting_bid, add.price, add.start_time, add.end_time);
            return RedirectToAction("Product");
        }
        [HttpGet]
        public IActionResult UpdateProduct(Admin user, int id)
        {
            DataSet dataSet = user.select_Product(id);
            ViewBag.Product = dataSet.Tables[0];
            return View();
        }
        [HttpPost]
        public IActionResult UpdateProduct(Admin add, int id, int a = 0)
        {
            int user_id = 1001;
            add.updateproduct(add.product_name, user_id,add.brand, add.color, add.condition, add.description, add.starting_bid, add.price, add.start_time, add.end_time,id);
            return RedirectToAction("Product");
        }
        public IActionResult DeleteProduct(Admin db, int id = 0)
        {
            db.deleteproduct(id);
            return RedirectToAction("Product");
        }
        [HttpGet]
        public IActionResult ContactUs(Admin user, int id)
        {
            DataSet dataSet = user.contact_data(id);
            ViewBag.contact = dataSet.Tables[0];
            return View();
        }
        [HttpGet]
        public IActionResult Team(Admin user)
        {
            DataSet ds = user.allTeam();
            ViewBag.data = ds.Tables[0];
            return View();
        }
        public IActionResult TeamInsert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TeamInsert(Admin add)
        {
            add.teamInsert(add.name, add.position, add.description);
            return RedirectToAction("Team");
        }
        public IActionResult DeleteTeam(Admin db, int id = 0)
        {
            db.deleteTeam(id);
            return RedirectToAction("Team");
        }
        public IActionResult UpdateTeam(Admin user, int id)
        {
            DataSet dataSet = user.select_Team(id);
            ViewBag.teamData = dataSet.Tables[0];
            return View();
        }
        [HttpPost]
        public IActionResult UpdateTeam(Admin user, int id, int a = 0)
        {
            user.updateTeam(user.name,user.position,user.description,id);
            return RedirectToAction("Team");
        }
        [HttpGet]
        public IActionResult Blog(Admin user)
        {
            DataSet ds = user.allblog();
            ViewBag.data = ds.Tables[0];
            return View();
        }
        public IActionResult BlogInsert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BlogInsert(Admin add)
        {
            add.bloginsert(add.b_title, add.b_description, add.b_name,add.date);
            return RedirectToAction("Blog");
        }
        public IActionResult DeleteBlog(Admin db, int id = 0)
        {
            db.deleteBlog(id);
            return RedirectToAction("Blog");
        }
        public IActionResult UpdateBlog(Admin user, int id)
        {
            DataSet dataSet = user.select_Blog(id);
            ViewBag.dataBlog = dataSet.Tables[0];
            return View();
        }
        [HttpPost]
        public IActionResult UpdateBlog(Admin user, int id, int a = 0)
        {
            user.updateBlog(user.b_title, user.b_description, user.b_name,user.date, id);
            return RedirectToAction("Blog");
        }

        [HttpGet]
        public IActionResult Update_status(Admin ad,int id)
        {

            DataSet ds = ad.select_data(id);

            ViewBag.dataStatus = ds.Tables[0];

            foreach (System.Data.DataRow row in ViewBag.dataStatus.Rows)
            {
                if (row["status"].ToString() == "true")
                { 
                    ad.update_false("false", id);
                }
                else
                {
                    ad.update_false("true", id);
                }
            }

            return RedirectToAction("User");
        }
        public IActionResult Admin_Profile(Admin admin)
        {
            DataSet ds = admin.admin();
            ViewBag.data = ds.Tables[0];
            return View();
        }
        public IActionResult UpdateAdmin(Admin user, int id)
        {
            DataSet dataSet = user.select_Admin(id);
            ViewBag.data = dataSet.Tables[0];
            return View();
        }
        [HttpPost]
        public IActionResult UpdateAdmin(Admin user, int id, int a = 0)
        {
            user.updateAdmin(user.email, user.password, id);
            TempData.Clear();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update_Product(Admin ad, int id)
        {

            DataSet ds = ad.allproduct_status(id);

            ViewBag.dataStatus = ds.Tables[0];

            foreach (System.Data.DataRow row in ViewBag.dataStatus.Rows)
            {
                if (row["status"].ToString() == "False")
                {
                    ad.update_Pfalse("True", id);
                }
                else
                {
                    ad.update_Pfalse("False", id);
                }
            }

            return RedirectToAction("Product");
        }
        public IActionResult ContactSelect(Admin add,int id)
        {
            DataSet dataSet = add.select_contact(id);
            ViewBag.contact = dataSet.Tables[0];
            return View();
            
        }
        [HttpPost]
        public IActionResult ContactSelect(Admin add,int a=0,int id=0)
        {
            int user_id = 0;
            DataSet dataSet = add.select_contact(id);
            ViewBag.contact = dataSet.Tables[0];
            foreach (System.Data.DataRow row in ViewBag.contact.Rows)
            {
                user_id = (int)row["user_id"];

           }
            add.Reply(user_id, add.message);
            return RedirectToAction("ContactUs");
        }
    }
}
