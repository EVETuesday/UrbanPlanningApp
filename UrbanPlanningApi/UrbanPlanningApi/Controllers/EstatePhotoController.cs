﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using UrbanPlanningApi.Classes;
using static UrbanPlanningApi.Classes.CH;

namespace UrbanPlanningApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstatePhotoController : Controller
    {
        public readonly IConfiguration _configuration;
        public EstatePhotoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllEstatePhotos")]
        public string GetEstatePhotos()
        {
            SqlConnection sqlConnection = new SqlConnection(gConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM EstatePhoto", sqlConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<EstatePhoto> estatePhotos = new List<EstatePhoto>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    EstatePhoto estatePhoto = new EstatePhoto();
                    estatePhoto.IDEstatePhoto = Convert.ToInt32(dt.Rows[i]["IDEstatePhoto"]);
                    estatePhoto.IDEmployee = Convert.ToInt32(dt.Rows[i]["IDEmployee"]);
                    estatePhoto.IDEstateObject = Convert.ToInt32(dt.Rows[i]["IDEstateObject"]);
                    estatePhoto.PhotoPath = Convert.ToString(dt.Rows[i]["PhotoPath"]);
                    estatePhotos.Add(estatePhoto);
                }
            }
            if (estatePhotos.Count > 0)
            {
                return JsonConvert.SerializeObject(estatePhotos);
            }
            else
            {
                return JsonConvert.SerializeObject(new Response() { Id = "100", Title = "Data not found" });
            }
        }

        [HttpPost, ActionName("AddNewEstatePhoto")]
        [Route("AddNewEstatePhoto")]

        public string AddNewEstatePhoto(EstatePhoto estatePhoto)
        {
            SqlConnection sqlConnection = new SqlConnection(gConnectionString);
            SqlCommand sc = new SqlCommand($"Insert into EstatePhoto (PhotoPath, IDEstateObject, IDEmployee) Values(\'{estatePhoto.PhotoPath}\', {estatePhoto.IDEstateObject}, {estatePhoto.IDEmployee})", sqlConnection);
            sqlConnection.Open();
            int i = sc.ExecuteNonQuery();
            sqlConnection.Close();
            if (i > 0)
            {
                return "Data is added";
            }
            else
            {
                return "Data isn't added";
            }
        }

        [HttpPost, ActionName("DeleteEstatePhoto")]
        [Route("DeleteEstatePhoto")]

        public string DeleteEstatePhoto(EstatePhoto estatePhoto)
        {
            SqlConnection sqlConnection = new SqlConnection(gConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM EstatePhoto", sqlConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<EstatePhoto> estatePhotos = new List<EstatePhoto>();
            if (dt.Rows.Count > 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    EstatePhoto estatePhoto2 = new EstatePhoto();
                    estatePhoto2.IDEstatePhoto = Convert.ToInt32(dt.Rows[j]["IDEstatePhoto"]);
                    estatePhoto2.IDEmployee = Convert.ToInt32(dt.Rows[j]["IDEmployee"]);
                    estatePhoto2.IDEstateObject = Convert.ToInt32(dt.Rows[j]["IDEstateObject"]);
                    estatePhoto2.PhotoPath = Convert.ToString(dt.Rows[j]["PhotoPath"]);
                    estatePhotos.Add(estatePhoto);
                }
            }
            var o = estatePhotos.Where(j => j == estatePhoto).FirstOrDefault();
            if (o == null)
            {
                return "EstatePhoto id not found";
            }
            SqlCommand sc = new SqlCommand("Delete from EstatePhoto where IDEstatePhoto=" + estatePhoto.IDEstatePhoto, sqlConnection);
            sqlConnection.Open();
            int i = sc.ExecuteNonQuery();
            sqlConnection.Close();
            if (i > 0)
            {
                return "Data is deleted";
            }
            else
            {
                return "Data isn't deleted";
            }

        }
    }
}
