using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.DTO;
using ZeroHunger.EF;


namespace ZeroHunger.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin


        public ActionResult Admin_Dashboard() {
            Session["order"] = null;
            var db = new ZeroHungerEntities1();
            var data_ent = db.requests.ToList();
            var data = ConvertTo(data_ent);

            return View(data);

        }

        public ActionResult show_all()
        {
            var db = new ZeroHungerEntities1();
            var data_ent = db.employees.ToList();
            var data = ConvertTo(data_ent);
            return View(data);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            Session["order"] = id;
            var db = new ZeroHungerEntities1();
            var data = db.employees.ToList();
            var list = ConvertTo(data);
            return View(list);
        }


        public ActionResult Assign(int id)
        {
            int order_id = Convert.ToInt32(Session["order"]);
            var db = new ZeroHungerEntities1();
            var result = db.employees.SingleOrDefault(b => b.emp_id == id);


            if (result != null)
            {
                result.availability = "Assigned";
                db.SaveChanges();
            }


            var result2 = db.requests.SingleOrDefault(b=>b.req_id == order_id);

            if (result2 != null)
            {
                result2.assigned_employee_id = id;
                result2.status = "Assigned";
                db.SaveChanges();
            }

            return RedirectToAction("Admin_Dashboard");


        }

        RequestDTO ConvertTo(request request)
        {
            return new RequestDTO()
            {
                req_id = request.req_id,
                food_type = request.food_type,
                Email = request.Email,
                Phone = request.Phone,
                quantity = request.quantity,
                max_preservation_time = request.max_preservation_time,
                location = request.location,
                status = request.status,
                rest_id = request.rest_id,
                assigned_employee_id = request.assigned_employee_id,
                details_food = request.details_food,
                date_of_order = request.date_of_order
            };
        }


        request ConvertTo(RequestDTO requestDTO)
        {
            return new request()
            {
                req_id = requestDTO.req_id,
                food_type = requestDTO.food_type,
                Email = requestDTO.Email,
                Phone = requestDTO.Phone,
                quantity = requestDTO.quantity,
                max_preservation_time = requestDTO.max_preservation_time,
                location = requestDTO.location,
                status = requestDTO.status,
                rest_id = requestDTO.rest_id,
                assigned_employee_id = requestDTO.assigned_employee_id,
                details_food = requestDTO.details_food,
                date_of_order = requestDTO.date_of_order
            };
        }


        List<RequestDTO>ConvertTo(List<request> requests)
        {
            var rq = new List<RequestDTO>();
            foreach (var request in requests)
            {
                rq.Add(ConvertTo(request));
            }
            return rq;
        }



        EmployeeDTO ConvertTo(employee emp)
        {
            return new EmployeeDTO()
            {
                emp_id = emp.emp_id,
                firstName = emp.firstName,
                lastName = emp.lastName,

                email = emp.email,
                phone = emp.phone,

                address = emp.address,

                availability = emp.availability,

                role = emp.role,
                username = emp.username,
                password = emp.password
            };
        }

        employee ConvertTo(EmployeeDTO emp)
        {
            return new employee()
            {

                emp_id = emp.emp_id,
                firstName = emp.firstName,
                lastName = emp.lastName,

                email = emp.email,
                phone = emp.phone,

                address = emp.address,

                availability = emp.availability,

                role = emp.role,
                username = emp.username,
                password = emp.password


            };
        }

        List<EmployeeDTO>ConvertTo(List<employee> employees) {
            
            var emp = new List<EmployeeDTO>();
            foreach(var employee in employees)
            {
                emp.Add(ConvertTo(employee));
            }
            return emp;
        
        }
    }
}