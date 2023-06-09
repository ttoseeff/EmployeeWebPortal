using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using EmployeeWebPortal.Builder.ConcreteBuilder;
using EmployeeWebPortal.Builder.Director;
using EmployeeWebPortal.Builder.IBuilder;
using EmployeeWebPortal.Factory.AbstractFactory;
using EmployeeWebPortal.Factory.FactoryMethod;
using EmployeeWebPortal.Models;

namespace EmployeeWebPortal.Controllers
{
    public class EmployeesController : BaseController
    {
        private EmployeePortalDBEntities db = new EmployeePortalDBEntities();

        [HttpGet]
        public ActionResult BuildSystem(int? employeeId)
        {
            Employee employee = db.Employees.Find(employeeId);
            if (employee.ComputerDetails.Contains("Laptop"))
            {
                return View("BuildLaptop", employeeId);
            }
            return View("BuildDesktop", employeeId);
        }

        [HttpPost]
        public ActionResult BuildSystem(int employeeId, string RAM, string HDDSize)
        {
            Employee employee = db.Employees.Find(employeeId);
            //ComputerSystem computerSystem = new ComputerSystem(RAM, HDDSize);
            //employee.SystemConfigurationDetails = computerSystem.Build();
            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult BuildDesktop(FormCollection formCollection)
        {
            // Step 1
            Employee employee = db.Employees.Find(Convert.ToInt32(formCollection["employeeId"]));

            // Step 2 Concrete Builder
            ISystemBuilder desktopBuilder = new DesktopBuilder();

            // Step 3 Director
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.BuildSystem(desktopBuilder, formCollection);

            // Step 4 return the system
            ComputerSystem system = desktopBuilder.GetSystem();

            employee.SystemConfigurationDetails = string.Format("RAM: {0}, HDDSize: {1}, Keyboard: {2}, Mouse: {3}",
                system.RAM, system.HDDSize, system.Keyboard, system.Mouse);

            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult BuildLaptop(FormCollection formCollection)
        {
            // Step 1
            Employee employee = db.Employees.Find(Convert.ToInt32(formCollection["employeeId"]));

            // Step 2 Concrete Builder
            ISystemBuilder desktopBuilder = new LaptopBuilder();

            // Step 3 Director
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.BuildSystem(desktopBuilder, formCollection);

            // Step 4 return the system
            ComputerSystem system = desktopBuilder.GetSystem();

            employee.SystemConfigurationDetails = string.Format("RAM: {0}, HDDSize: {1}, TouchScreen: {2}",
                system.RAM, system.HDDSize, system.TouchScreen);

            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Employee_Type);
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeTypeId = new SelectList(db.Employee_Type, "Id", "EmployeType");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,JobDescription,Number,Department,EmployeeTypeId,HourlyPay,Bonus")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                //This is tightly coupled code
                //if(employee.EmployeeTypeId == 1)
                //{
                //    employee.HourlyPay = 8;
                //    employee.Bonus = 10;
                //}
                //else if(employee.EmployeeTypeId == 2)
                //{
                //    employee.HourlyPay = 7;
                //    employee.Bonus = 5;
                //}
                // Simple Factory Design Pattern
                //FactoryEmployeeManager  factoryEmployeeManager= new FactoryEmployeeManager();
                //IEmployeeManager employeeManager = factoryEmployeeManager.GetEmployeeManager(employee.EmployeeTypeId);
                //employee.Bonus = employeeManager.GetBonus(employee.EmployeeTypeId);
                //employee.HourlyPay =   employeeManager.GetHourlyPay(employee.EmployeeTypeId);   

                // Factory Method Design Pattern
                //BaseEmployeeFactory baseEmployeeFactory = new EmployeeManagerFactory().CreateFactory(employee);
                //baseEmployeeFactory.ApplySalary();
                //db.Employees.Add(employee);
                //db.SaveChanges();
                //return RedirectToAction("Index");

                // Abstract Factory Pattern
                BaseEmployeeFactory baseEmployeeFactory = new EmployeeManagerFactory().CreateFactory(employee);
                baseEmployeeFactory.ApplySalary();
                IComputerFactory factory = new EmployeeSystemFactory().Create(employee);
                EmployeeSystemManager manager = new EmployeeSystemManager(factory);
                employee.ComputerDetails = manager.GetSystemDetails();
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            ViewBag.EmployeeTypeId = new SelectList(db.Employee_Type, "Id", "EmployeType", employee.EmployeeTypeId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeTypeId = new SelectList(db.Employee_Type, "Id", "EmployeType", employee.EmployeeTypeId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,JobDescription,Number,Department,EmployeeTypeId,HourlyPay,Bonus")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeTypeId = new SelectList(db.Employee_Type, "Id", "EmployeType", employee.EmployeeTypeId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
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
