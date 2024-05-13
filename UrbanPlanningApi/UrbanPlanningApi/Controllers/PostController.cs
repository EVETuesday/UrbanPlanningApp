using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using UrbanPlanningApi.Classes;
using static UrbanPlanningApi.Classes.CH;

namespace UrbanPlanningApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        public readonly IConfiguration _configuration;
        public PostController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllPosts")]
        public string GetPosts()
        {
            SqlConnection sqlConnection = new SqlConnection(gConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Post", sqlConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Post> posts = new List<Post>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Post post = new Post();
                    post.IDPost = Convert.ToInt32(dt.Rows[i]["IDPost"]);
                    post.PostTitle = Convert.ToString(dt.Rows[i]["PostTitle"]);
                    posts.Add(post);
                }
            }
            if (posts.Count > 0)
            {
                return JsonConvert.SerializeObject(posts);
            }
            else
            {
                return JsonConvert.SerializeObject(new Response() { Id = "100", Title = "Data not found" });
            }
        }
    }
}
