using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.DTO;
using ZeroHunger.EF;

namespace ZeroHunger.Controllers
{
    public class RestaurantController : Controller
    {

        public ActionResult Restaurant_Dashboard()
        {
            var us_id = Convert.ToInt32(Session["res_id"]);
            var db = new ZeroHungerEntities1();
            var data = (from s in db.requests
                        where s.rest_id == us_id && (s.status == "pending" || s.status == "Assigned")
                        select s).ToList();

            var list = ConvertTo(data);
            return View(list);
        }


        [HttpGet]
        public ActionResult Show_All_Donation()
        {
            var us_id = Convert.ToInt32(Session["res_id"]);
            var db = new ZeroHungerEntities1();
            var data = (from s in db.requests
                        where s.rest_id == us_id
                        select s).ToList();
            var list = ConvertTo(data);
            return View(list);
        }


        [HttpGet]
        public ActionResult Request_Send()
        {
            ViewBag.now = new DateTime();
            ViewBag.res_id = Convert.ToInt32(Session["res_id"]);
            var us_id = Convert.ToInt32(Session["res_id"]);
            var db = new ZeroHungerEntities1();
            var data = (from s in db.restaurants
                        where s.restaurants_id == us_id
                        select s).FirstOrDefault();
            var list = ConvertTo(data);
            return View(list);
        }


        [HttpPost]
        public ActionResult Request_Send(RequestDTO r)
        {
            var db = new ZeroHungerEntities1();
            var req = ConvertTo(r);
            db.requests.Add(req);
            db.SaveChanges();

            return RedirectToAction("Restaurant_Dashboard");
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


        List<RequestDTO> ConvertTo(List<request> requests)
        {
            var rq = new List<RequestDTO>();
            foreach (var request in requests)
            {
                rq.Add(ConvertTo(request));
            }
            return rq;
        }


        RestaurantDTO ConvertTo(restaurant res)
        {

            return new RestaurantDTO()
            {

                restaurants_id = res.restaurants_id,
                rest_name = res.rest_name ?? string.Empty,
                rest_type = res.rest_type ?? string.Empty,
                res_email = res.res_email ?? string.Empty,
                res_location = res.res_location ?? string.Empty,
                res_phone = res.res_phone ?? string.Empty,
                res_username = res.res_username ?? string.Empty,
                res_password = res.res_password ?? string.Empty

            };

        }


        restaurant ConvertTo(RestaurantDTO res)
        {

            return new restaurant()
            {
                restaurants_id = res.restaurants_id,
                rest_name = res.rest_name ?? string.Empty,
                rest_type = res.rest_type ?? string.Empty,
                res_email = res.res_email ?? string.Empty,
                res_location = res.res_location ?? string.Empty,
                res_phone = res.res_phone ?? string.Empty,
                res_username = res.res_username ?? string.Empty,
                res_password = res.res_password ?? string.Empty

            };

        }

    }
}