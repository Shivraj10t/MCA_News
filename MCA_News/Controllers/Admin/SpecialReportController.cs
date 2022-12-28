using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCA_News.Controllers.Admin
{
    public class SpecialReportController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MCA_News"].ToString());

        // GET: SpecialReport
        public ActionResult Index()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("pro_SpecialReportingType", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@mode", 1);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            return PartialView(ds);
        }
        public ActionResult AddReportType()
        {
           
            return View();
        }
        public ActionResult Edit(int id)
        {
            string json = string.Empty;
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("pro_SpecialReportingType", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@specialReportingTypeId", id);
            cmd.Parameters.AddWithValue("@mode", 1);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);

          return  View(ds);
        }
        public JsonResult AddNewReportType(string ReportingType)
        {
            string json = string.Empty;
            DataSet ds = new DataSet();

            SqlCommand cmd = new SqlCommand("pro_SpecialReportingType", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@specialReportingType", ReportingType);
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
            SqlCommand cmd = new SqlCommand("pro_SpecialReportingType", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@specialReportingTypeId", Id);
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
            SqlCommand cmd = new SqlCommand("pro_SpecialReportingType", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@mode", 6);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            //ViewBag.DistictId = ds.Tables[0].Rows[0][0].ToString();

            json = JsonConvert.SerializeObject(ds);
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}