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
    public class TestController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public TestController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllClients")]
        public string GetClients() //Получение списка клиентов JS
        {
            SqlConnection sqlConnection = new SqlConnection(gConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Client", sqlConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Client> clients = new List<Client>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Client client = new Client();
                    client.IDClient = Convert.ToInt32(dt.Rows[i]["IDClient"]);
                    client.LastName = Convert.ToString(dt.Rows[i]["LastName"]);
                    client.FirstName = Convert.ToString(dt.Rows[i]["FirstName"]);
                    client.Patronymic = Convert.ToString(dt.Rows[i]["Patronymic"]);
                    client.Birthday = Convert.ToDateTime(dt.Rows[i]["Birthday"]);
                    client.Phone = Convert.ToString(dt.Rows[i]["Phone"]);
                    client.IsLegalEntity = Convert.ToBoolean(dt.Rows[i]["IsLegalEntity"]);
                    client.PasportSeries = Convert.ToString(dt.Rows[i]["PasportSeries"]);
                    client.PasportNumber = Convert.ToString(dt.Rows[i]["PasportNumber"]);
                    client.CompanyTitle = Convert.ToString(dt.Rows[i]["CompanyTitle"]);
                    client.INN = Convert.ToString(dt.Rows[i]["INN"]);
                    client.KPP = Convert.ToString(dt.Rows[i]["KPP"]);
                    client.OGRN = Convert.ToString(dt.Rows[i]["OGRN"]);
                    client.PaymentAccount = Convert.ToString(dt.Rows[i]["PaymentAccount"]);
                    client.CorrespondentAccount = Convert.ToString(dt.Rows[i]["CorrespondentAccount"]);
                    client.BIK = Convert.ToString(dt.Rows[i]["BIK"]);
                    client.IDGender = Convert.ToInt32(dt.Rows[i]["IDGender"]);
                    client.Login = Convert.ToString(dt.Rows[i]["Login"]);
                    client.Password = Convert.ToString(dt.Rows[i]["Password"]);
                    clients.Add(client);
                }
            }
            if (clients.Count > 0)
            {
                return JsonConvert.SerializeObject(clients);
            }
            else
            {
                return JsonConvert.SerializeObject(new Response() { Id = "100", Title = "Data not found" });
            }
        }

        //[HttpPost, ActionName("AddNewClient")]
        //[Route("AddNewClient")]

        //public string AddClient(Client client) //Добавление нового клиента
        //{
        //    if (Convert.ToInt32(Convert.ToBoolean(client.IsLegalEntity)) == 1)
        //    {
        //        client.PasportNumber = "NULL";
        //        client.PasportSeries = "NULL";

        //        client.CompanyTitle = "'" + client.CompanyTitle + "'";
        //        client.INN = "'" + client.INN + "'";
        //        client.KPP = "'" + client.KPP + "'";
        //        client.OGRN = "'" + client.OGRN + "'";
        //        client.PaymentAccount = "'" + client.PaymentAccount + "'";
        //        client.CorrespondentAccount = "'" + client.CorrespondentAccount + "'";
        //        client.BIK = "'" + client.BIK + "'";
        //    }
        //    else
        //    {
        //        client.CompanyTitle = "NULL";
        //        client.INN = "NULL";
        //        client.KPP = "NULL";
        //        client.OGRN = "NULL";
        //        client.PaymentAccount = "NULL";
        //        client.CorrespondentAccount = "NULL";
        //        client.BIK = "NULL";

        //        client.PasportNumber = "'" + client.PasportNumber + "'";
        //        client.PasportSeries = "'" + client.PasportSeries + "'";
        //    }
        //    SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        //    SqlCommand sc = new SqlCommand("insert into Client(LastName, FirstName,Patronymic,Birthday,Phone,IsLegalEntity,PasportSeries,PasportNumber, CompanyTitle,INN,KPP,OGRN,PaymentAccount,CorrespondentAccount,BIK,IDGender)\r\nvalues('" + client.LastName + "','" + client.FirstName + "','" + client.Patronymic + "','" + client.Birthday + "','" + client.Phone + "'," + Convert.ToInt32(Convert.ToBoolean(client.IsLegalEntity)) + "," + client.PasportSeries + "," + client.PasportNumber + "," + client.CompanyTitle + "," + client.INN + "," + client.KPP + "," + client.OGRN + "," + client.PaymentAccount + "," + client.CorrespondentAccount + "," + client.BIK + "," + client.IDGender + ")", sqlConnection);
        //    sqlConnection.Open();
        //    int i = sc.ExecuteNonQuery();
        //    sqlConnection.Close();
        //    if (i > 0)
        //    {
        //        return "Data is added";
        //    }
        //    else
        //    {
        //        return "Data isn't added";
        //    }

        //}



        //[HttpPost, ActionName("DeleteClient")]
        //[Route("DeleteClient")]

        //public string DeleteClient(Client client)//Удаление клиента
        //{
        //    SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        //    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Client", sqlConnection);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    List<Client> clients = new List<Client>();
        //    if (dt.Rows.Count > 0)
        //    {
        //        for (int j = 0; j < dt.Rows.Count; j++)
        //        {
        //            Client client2 = new Client();
        //            client2.IDClient = Convert.ToInt32(dt.Rows[j]["IDClient"]);
        //            client2.LastName = Convert.ToString(dt.Rows[j]["LastName"]);
        //            client2.FirstName = Convert.ToString(dt.Rows[j]["FirstName"]);
        //            client2.Patronymic = Convert.ToString(dt.Rows[j]["Patronymic"]);
        //            client2.Birthday = Convert.ToString(dt.Rows[j]["Birthday"]);
        //            client2.Phone = Convert.ToString(dt.Rows[j]["Phone"]);
        //            client2.IsLegalEntity = Convert.ToString(dt.Rows[j]["IsLegalEntity"]);
        //            client2.PasportSeries = Convert.ToString(dt.Rows[j]["PasportSeries"]);
        //            client2.PasportNumber = Convert.ToString(dt.Rows[j]["PasportNumber"]);
        //            client2.CompanyTitle = Convert.ToString(dt.Rows[j]["CompanyTitle"]);
        //            client2.INN = Convert.ToString(dt.Rows[j]["INN"]);
        //            client2.KPP = Convert.ToString(dt.Rows[j]["KPP"]);
        //            client2.OGRN = Convert.ToString(dt.Rows[j]["OGRN"]);
        //            client2.PaymentAccount = Convert.ToString(dt.Rows[j]["PaymentAccount"]);
        //            client2.CorrespondentAccount = Convert.ToString(dt.Rows[j]["CorrespondentAccount"]);
        //            client2.BIK = Convert.ToString(dt.Rows[j]["BIK"]);
        //            client2.IDGender = Convert.ToInt32(dt.Rows[j]["IDGender"]);
        //            clients.Add(client2);
        //        }
        //    }
        //    var o = clients.Where(j => j == client).FirstOrDefault();
        //    if (o == null)
        //    {
        //        return "CLient id not found";
        //    }
        //    SqlCommand sc = new SqlCommand("Delete from Client where IDClient=" + client.IDClient, sqlConnection);
        //    sqlConnection.Open();
        //    int i = sc.ExecuteNonQuery();
        //    sqlConnection.Close();
        //    if (i > 0)
        //    {
        //        return "Data is deleted";
        //    }
        //    else
        //    {
        //        return "Data isn't deleted";
        //    }

        //}

        //[HttpPost, ActionName("ChangeClient")]
        //[Route("ChangeClient")]

        //public string ChangeClient(Client unionClient)//Изменение клиента
        //{
        //    string unionLastname = unionClient.LastName;
        //    Client newClient = unionClient;
        //    newClient.LastName = newClient.LastName.Split('|')[0];
        //    unionClient.LastName = unionLastname;
        //    SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        //    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Client", sqlConnection);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    List<Client> clients = new List<Client>();
        //    if (dt.Rows.Count > 0)
        //    {
        //        for (int j = 0; j < dt.Rows.Count; j++)
        //        {
        //            Client client2 = new Client();
        //            client2.IDClient = Convert.ToInt32(dt.Rows[j]["IDClient"]);
        //            client2.LastName = Convert.ToString(dt.Rows[j]["LastName"]);
        //            client2.FirstName = Convert.ToString(dt.Rows[j]["FirstName"]);
        //            client2.Patronymic = Convert.ToString(dt.Rows[j]["Patronymic"]);
        //            client2.Birthday = Convert.ToString(dt.Rows[j]["Birthday"]);
        //            client2.Phone = Convert.ToString(dt.Rows[j]["Phone"]);
        //            client2.IsLegalEntity = Convert.ToString(dt.Rows[j]["IsLegalEntity"]);
        //            client2.PasportSeries = Convert.ToString(dt.Rows[j]["PasportSeries"]);
        //            client2.PasportNumber = Convert.ToString(dt.Rows[j]["PasportNumber"]);
        //            client2.CompanyTitle = Convert.ToString(dt.Rows[j]["CompanyTitle"]);
        //            client2.INN = Convert.ToString(dt.Rows[j]["INN"]);
        //            client2.KPP = Convert.ToString(dt.Rows[j]["KPP"]);
        //            client2.OGRN = Convert.ToString(dt.Rows[j]["OGRN"]);
        //            client2.PaymentAccount = Convert.ToString(dt.Rows[j]["PaymentAccount"]);
        //            client2.CorrespondentAccount = Convert.ToString(dt.Rows[j]["CorrespondentAccount"]);
        //            client2.BIK = Convert.ToString(dt.Rows[j]["BIK"]);
        //            client2.IDGender = Convert.ToInt32(dt.Rows[j]["IDGender"]);
        //            clients.Add(client2);
        //        }
        //    }
        //    Client oldClient = clients.Where(j => j.IDClient == Convert.ToInt32(unionClient.LastName.Split('|')[1])).FirstOrDefault();
        //    if (oldClient == null)
        //    {
        //        return "CLient id not found";
        //    }

        //    if (Convert.ToInt32(Convert.ToBoolean(newClient.IsLegalEntity)) == 1)
        //    {
        //        newClient.PasportNumber = "NULL";
        //        newClient.PasportSeries = "NULL";

        //        newClient.CompanyTitle = "'" + newClient.CompanyTitle + "'";
        //        newClient.INN = "'" + newClient.INN + "'";
        //        newClient.KPP = "'" + newClient.KPP + "'";
        //        newClient.OGRN = "'" + newClient.OGRN + "'";
        //        newClient.PaymentAccount = "'" + newClient.PaymentAccount + "'";
        //        newClient.CorrespondentAccount = "'" + newClient.CorrespondentAccount + "'";
        //        newClient.BIK = "'" + newClient.BIK + "'";
        //    }
        //    else
        //    {
        //        newClient.CompanyTitle = "NULL";
        //        newClient.INN = "NULL";
        //        newClient.KPP = "NULL";
        //        newClient.OGRN = "NULL";
        //        newClient.PaymentAccount = "NULL";
        //        newClient.CorrespondentAccount = "NULL";
        //        newClient.BIK = "NULL";

        //        newClient.PasportNumber = "'" + newClient.PasportNumber + "'";
        //        newClient.PasportSeries = "'" + newClient.PasportSeries + "'";
        //    }

        //    SqlCommand sc = new SqlCommand("update Client set LastName = " + newClient.LastName + ", FirstName = " + newClient.FirstName + ",Patronymic = " + newClient.Patronymic + ",Birthday = '" + newClient.Birthday + "',Phone = " + newClient.Phone + ",IsLegalEntity = " + newClient.IsLegalEntity + ",PasportSeries = " + newClient.PasportSeries + ",PasportNumber = " + newClient.PasportNumber + ", CompanyTitle = " + newClient.CompanyTitle + ",INN = " + newClient.INN + ",KPP = " + newClient.KPP + ",OGRN = " + newClient.OGRN + ",PaymentAccount = " + newClient.PaymentAccount + ",CorrespondentAccount = " + newClient.CorrespondentAccount + ",BIK = " + newClient.BIK + ",IDGender = " + newClient.IDGender + " Where IDClient=" + oldClient.IDClient, sqlConnection);
        //    sqlConnection.Open();
        //    int i = sc.ExecuteNonQuery();
        //    sqlConnection.Close();
        //    if (i > 0)
        //    {
        //        return "Data is changed";
        //    }
        //    else
        //    {
        //        return "Data isn't changed";
        //    }
        //}
    }

}
