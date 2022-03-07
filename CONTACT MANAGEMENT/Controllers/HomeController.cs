using CONTACT_MANAGEMENT.Models;
using CONTACT_MANAGEMENT.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CONTACT_MANAGEMENT.Controllers
{
    public class HomeController : Controller
    {
        ContactManagementDB _database = new ContactManagementDB();
        public ActionResult Index()
        {
            return View(GetContactList());
        }

        public List<ContactManagementModel> GetContactList()
        {
            var model = _database.ContactManagements.Select(x => new ContactManagementModel()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                EmailAddress = x.EmailAddress,
                IsFav = x.IsFav

            }).ToList();
            return model;
        }

        public ActionResult SaveContect(ContactManagementModel model)
        {
            if (model.submit.Equals("edit"))
            {
                var data = _database.ContactManagements.FirstOrDefault(x => x.Id == model.Id);
                if (data != null)
                {
                    data.FirstName = model.FirstName;
                    data.LastName = model.LastName;
                    data.EmailAddress = model.EmailAddress;
                    data.UserName = model.UserName;
                    data.Password = model.Password;
                    data.PhoneNumber = model.PhoneNumber;
                    data.Address = model.Address;
                    _database.SaveChanges();
                }
            }
            else
            {
                using (var cn = _database)
                {
                    cn.ContactManagements.Add(
                        new ContactManagement
                        {
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            EmailAddress = model.EmailAddress,
                            UserName = model.UserName,
                            Password = model.Password,
                            PhoneNumber = model.PhoneNumber,
                            Address = model.Address
                        }
                        );
                    cn.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult About(int? id)
        {
            ViewBag.Message = "Your application description page.";
            var model = new ContactManagementModel();
            if (id != null)
            {
                model = GetContact(id);
            }
            return View(model);
        }

        public ContactManagementModel GetContact(int? id)
        {
            var model = _database.ContactManagements.Select(x => new ContactManagementModel()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                EmailAddress = x.EmailAddress,
                UserName = x.UserName,
                Password = x.Password,
                ConfirmPassword = x.Password,
                PhoneNumber = x.PhoneNumber,
                Address = x.Address,
                IsFav = x.IsFav

            }).FirstOrDefault(x=>x.Id == id);
            return model;
        }

        public ActionResult DeleteContact(int id)
        {
            var data = _database.ContactManagements.FirstOrDefault(x => x.Id == id);
            if(data != null)
            {
                _database.ContactManagements.Remove(data);
                _database.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult AddFav(int id, bool status)
        {
            var data = _database.ContactManagements.FirstOrDefault(x => x.Id == id);
            if (data != null)
            {
                data.IsFav = status;
                _database.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}