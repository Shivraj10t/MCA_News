using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json;


namespace MCA_News.Controllers.Admin
{
    public class DistrictController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MCA_News"].ToString());
        // GET: District
        public ActionResult Index()
        {
           

            return View();
        }
        public JsonResult Listing()
        {
            string json = string.Empty;
            DataSet ds = new DataSet();

            SqlCommand cmd = new SqlCommand("pro_District", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
             cmd.Parameters.AddWithValue("@mode", 1);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            json = JsonConvert.SerializeObject(ds);
            return Json(json, JsonRequestBehavior.AllowGet);

        }
        public ActionResult AddDistrict()
        {
           
            return View();
        }
        public JsonResult AddNewDistrict(string District)
        {
            string json = string.Empty;
            DataSet ds = new DataSet();
 
            SqlCommand cmd = new SqlCommand("pro_District", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@District", District);
            cmd.Parameters.AddWithValue("@mode", 2);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            json = JsonConvert.SerializeObject(ds);
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(string Id)
        {
            string json = string.Empty;
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("pro_District", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@DistrictId", Id);
            cmd.Parameters.AddWithValue("@mode", 4);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            json = "delete Sucessfully";

            return Json(json, JsonRequestBehavior.AllowGet);
        }
         public JsonResult NEWID()
        {
            string json = string.Empty;
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("pro_District", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
             cmd.Parameters.AddWithValue("@mode", 6);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            ViewBag.DistictId = ds.Tables[0].Rows[0][0].ToString();

            json= JsonConvert.SerializeObject(ds);
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}