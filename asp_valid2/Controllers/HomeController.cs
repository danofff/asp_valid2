using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asp_valid2.Models;

namespace asp_valid2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (EmployeeModel db= new EmployeeModel())
            {
                List<Employee> emp = new List<Employee>();
                emp = db.Employee.Include(d=>d.Department).Include(l=>l.Language).ToList();
                return View(emp);
            }
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            EmployeeModel db = new EmployeeModel();

            List<string> dep = db.Department.Select(s => s.Name).ToList();
            SelectList departments = new SelectList(db.Department, "DepartmentId", "Name");
            ViewBag.departments = departments;

            SelectList languages = new SelectList(db.Language, "LanguageId", "LanguageName");
            ViewBag.languages = languages;
        
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(string firstName=null,string familyName=null, int? age=null,int? Department = null, int? Language=null)
        {
            try
            {
                // TODO: Add insert logic here            
                EmployeeModel db = new EmployeeModel();
                Employee emp = new Employee();
                if (db.Employee.ToList().Count == 0)
                {
                    emp.Id = 1;
                }
                else
                {
                    emp.Id = db.Employee.ToList().Count + 1;
                }

                emp.FirstName = firstName;
                emp.FamilyName = familyName;
                emp.Age = age;
                emp.DepartmentId = Department;
                emp.LanguageId = Language;

                db.Employee.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            using (EmployeeModel db = new EmployeeModel())
            {
                Employee emp = new Employee();
                List<string> dep = db.Department.Select(s => s.Name).ToList();
                SelectList departments = new SelectList(db.Department.ToList(), "DepartmentId", "Name");
                ViewBag.departments = departments;

                SelectList languages = new SelectList(db.Language.ToList(), "LanguageId", "LanguageName");
                ViewBag.languages = languages;
                
                emp =db.Employee.Select(s=>s).Where(w=>w.Id==id) as Employee;
                return View(emp);
            }            
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, string firstName = null, string familyName = null, int? age = null, int? Department = null, int? Language = null)
        {
            try
            {
                using (EmployeeModel db= new EmployeeModel())
                {
                    var editingEmployee = db.Employee.FirstOrDefault(f => f.Id == id);
                    if (editingEmployee != null)
                    {
                        editingEmployee.FirstName = firstName;
                        editingEmployee.FamilyName = familyName;
                        editingEmployee.Age = age;
                        editingEmployee.DepartmentId = Department;
                        editingEmployee.LanguageId = Language;
                        db.SaveChanges();
                    }
                }
               
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            using (EmployeeModel db= new EmployeeModel())
            {
                var employee = db.Employee.FirstOrDefault(f => f.Id == id);
                if (employee != null)
                {
                    db.Employee.Remove(employee);
                }

                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
