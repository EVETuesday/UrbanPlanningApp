using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using UrbanPlanningApp.DataBasesClasses;

namespace UrbanPlanningApp.CH
{
    public static class Context
    {
        public static ObservableCollection<Check> Checks = new ObservableCollection<Check>();
        public static ObservableCollection<Client> Clients = new ObservableCollection<Client>();
        public static ObservableCollection<Employee> Employees = new ObservableCollection<Employee>();
        public static ObservableCollection<EstateObject> EstateObjects = new ObservableCollection<EstateObject>();
        public static ObservableCollection<EstatePhoto> EstatePhotos = new ObservableCollection<EstatePhoto>();
        public static ObservableCollection<EstateRelation> EstateRelations = new ObservableCollection<EstateRelation>();
        public static ObservableCollection<FlatRelation> FlatRelations = new ObservableCollection<FlatRelation>();
        public static ObservableCollection<Format> Formats = new ObservableCollection<Format>();
        public static ObservableCollection<Gender> Genders = new ObservableCollection<Gender>();
        public static ObservableCollection<Post> Posts = new ObservableCollection<Post>();
        public static ObservableCollection<Postindex> Postindices = new ObservableCollection<Postindex>();
        public static ObservableCollection<TypeOfActivity> TypeOfActivities = new ObservableCollection<TypeOfActivity>();

        private const string APP_PATH = @"http://192.168.0.13:5000";


        //-------------------------------------------------------Сертификат SSL
        //dotnet tool install -g Microsoft.dotnet-httprepl
        //dotnet dev-certs https --trust



        public static void GetData()
        {
            HttpWebRequest httpWebRequest;
            HttpWebResponse httpWebResponse;
            Stream stream;
            StreamReader sr;
            string json;


            httpWebRequest = (HttpWebRequest)WebRequest.Create(APP_PATH + "/api/Gender/GetAllGenders");
            httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            stream = httpWebResponse.GetResponseStream();
            sr = new StreamReader(stream);
            json = sr.ReadToEnd();
            ObservableCollection<Gender> genders = new ObservableCollection<Gender>();
            genders = JsonConvert.DeserializeObject<ObservableCollection<Gender>>(json);

            httpWebRequest = (HttpWebRequest)WebRequest.Create(APP_PATH + "/api/Employee/GetAllEmployees");
            httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            stream = httpWebResponse.GetResponseStream();
            sr = new StreamReader(stream);
            json = sr.ReadToEnd();
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
            employees = JsonConvert.DeserializeObject<ObservableCollection<Employee>>(json);

            httpWebRequest = (HttpWebRequest)WebRequest.Create(APP_PATH + "/api/EstateObject/GetAllEstateObjects");
            httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            stream = httpWebResponse.GetResponseStream();
            sr = new StreamReader(stream);
            json = sr.ReadToEnd();
            ObservableCollection<EstateObject> estateObjects = new ObservableCollection<EstateObject>();
            estateObjects = JsonConvert.DeserializeObject<ObservableCollection<EstateObject>>(json);

            httpWebRequest = (HttpWebRequest)WebRequest.Create(APP_PATH + "/api/Check/GetAllChecks");
            httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            stream = httpWebResponse.GetResponseStream();
            sr = new StreamReader(stream);
            json = sr.ReadToEnd();
            ObservableCollection<Check> checks = new ObservableCollection<Check>();
            checks = JsonConvert.DeserializeObject<ObservableCollection<Check>>(json);

            httpWebRequest = (HttpWebRequest)WebRequest.Create(APP_PATH + "/api/Test/GetAllClients");
            httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            stream = httpWebResponse.GetResponseStream();
            sr = new StreamReader(stream);
            json = sr.ReadToEnd();
            ObservableCollection<Client> clients = new ObservableCollection<Client>();
            clients = JsonConvert.DeserializeObject<ObservableCollection<Client>>(json);

            httpWebRequest = (HttpWebRequest)WebRequest.Create(APP_PATH + "/api/EstatePhoto/GetAllEstatePhotos");
            httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            stream = httpWebResponse.GetResponseStream();
            sr = new StreamReader(stream);
            json = sr.ReadToEnd();
            ObservableCollection<EstatePhoto> estatePhotos = new ObservableCollection<EstatePhoto>();
            estatePhotos = JsonConvert.DeserializeObject<ObservableCollection<EstatePhoto>>(json);

            httpWebRequest = (HttpWebRequest)WebRequest.Create(APP_PATH + "/api/EstateRelation/GetAllEstateRelations");
            httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            stream = httpWebResponse.GetResponseStream();
            sr = new StreamReader(stream);
            json = sr.ReadToEnd();
            ObservableCollection<EstateRelation> estateRelations = new ObservableCollection<EstateRelation>();
            estateRelations = JsonConvert.DeserializeObject<ObservableCollection<EstateRelation>>(json);

            httpWebRequest = (HttpWebRequest)WebRequest.Create(APP_PATH + "/api/FlatRelation/GetAllFlatRelations");
            httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            stream = httpWebResponse.GetResponseStream();
            sr = new StreamReader(stream);
            json = sr.ReadToEnd();
            ObservableCollection<FlatRelation> flatRelations = new ObservableCollection<FlatRelation>();
            flatRelations = JsonConvert.DeserializeObject<ObservableCollection<FlatRelation>>(json);

            httpWebRequest = (HttpWebRequest)WebRequest.Create(APP_PATH + "/api/Format/GetAllFormats");
            httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            stream = httpWebResponse.GetResponseStream();
            sr = new StreamReader(stream);
            json = sr.ReadToEnd();
            ObservableCollection<Format> formats = new ObservableCollection<Format>();
            formats = JsonConvert.DeserializeObject<ObservableCollection<Format>>(json);

            httpWebRequest = (HttpWebRequest)WebRequest.Create(APP_PATH + "/api/Post/GetAllPosts");
            httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            stream = httpWebResponse.GetResponseStream();
            sr = new StreamReader(stream);
            json = sr.ReadToEnd();
            ObservableCollection<Post> posts = new ObservableCollection<Post>();
            posts = JsonConvert.DeserializeObject<ObservableCollection<Post>>(json);

            httpWebRequest = (HttpWebRequest)WebRequest.Create(APP_PATH + "/api/Postindex/GetAllPostindexes");
            httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            stream = httpWebResponse.GetResponseStream();
            sr = new StreamReader(stream);
            json = sr.ReadToEnd();
            ObservableCollection<Postindex> postindexes = new ObservableCollection<Postindex>();
            postindexes = JsonConvert.DeserializeObject<ObservableCollection<Postindex>>(json);

            httpWebRequest = (HttpWebRequest)WebRequest.Create(APP_PATH + "/api/TypeOfActivity/GetAllTypeOfActivity");
            httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            stream = httpWebResponse.GetResponseStream();
            sr = new StreamReader(stream);
            json = sr.ReadToEnd();
            ObservableCollection<TypeOfActivity> typeOfActivities = new ObservableCollection<TypeOfActivity>();
            typeOfActivities = JsonConvert.DeserializeObject<ObservableCollection<TypeOfActivity>>(json);

            Clients = clients;
            Employees = employees;
            Posts = posts;
            Checks = checks;
            EstateObjects = estateObjects;
            EstatePhotos = estatePhotos;
            EstateRelations = estateRelations;
            FlatRelations = flatRelations;
            Formats = formats;
            Genders = genders;
            Postindices = postindexes;
            TypeOfActivities = typeOfActivities;

            foreach (Client item in Clients)
            {
                item.Gender=Genders.Where(i=> item.IDGender==i.IDGender).FirstOrDefault();
            }
            foreach (Employee item in Employees)
            {
                item.Gender = Genders.Where(i => item.IDGender == i.IDGender).FirstOrDefault();
                item.Post = Posts.Where(i => item.IDPost == i.IDPost).FirstOrDefault();
            }
            foreach (Check item in Checks)
            {
                item.Client = Clients.Where(i => item.IDClient == i.IDClient).FirstOrDefault();
                item.Employee = Employees.Where(i => item.IDEmployee == i.IDEmployee).FirstOrDefault();
                item.EstateObject = EstateObjects.Where(i => item.IDEstateObject == i.IDEstateObject).FirstOrDefault();
            }
            foreach (EstateObject item in EstateObjects)
            {
                item.Format = Formats.Where(i => item.IDFormat == i.IDFormat).FirstOrDefault();
                item.Postindex = Postindices.Where(i => i.IDPostindex == item.IDPostIndex).FirstOrDefault();
                item.TypeOfActivity = TypeOfActivities.Where(i => item.IDTypeOfActivity == i.IDTypeOfActivity).FirstOrDefault();
                item.OwnerClient = (from Check c in Checks join Client cl in Clients on c.IDClient equals cl.IDClient join EstateObject e in EstateObjects on c.IDEstateObject equals e.IDEstateObject where e.IDEstateObject==item.IDEstateObject select cl).LastOrDefault();
                try
                {
                    item.MainPhoto = EstatePhotos.Where(i => i.IDEstateObject == item.IDEstateObject).FirstOrDefault().PhotoPath;
                }
                catch 
                {
                    item.MainPhoto = null;
                }
                
            }

            foreach (EstatePhoto item in EstatePhotos)
            {
                item.Employee = Employees.Where(i => item.IDEmployee == i.IDEmployee).FirstOrDefault();
                item.EstateObject = EstateObjects.Where(i => item.IDEstateObject == i.IDEstateObject).FirstOrDefault();
            }

            foreach (EstateRelation item in EstateRelations)
            {
                item.EstateObject=EstateObjects.Where(i=>i.IDEstateObject==item.IDPlaceEstate).FirstOrDefault();
                item.EstateObject1 = EstateObjects.Where(i => i.IDEstateObject == item.IDBuildingEstate).FirstOrDefault();
            }

            foreach (FlatRelation item in FlatRelations)
            {
                item.EstateObject = EstateObjects.Where(i => i.IDEstateObject == item.IDBuildEstate).FirstOrDefault();
                item.EstateObject1 = EstateObjects.Where(i => i.IDEstateObject == item.IDFlatRelation).FirstOrDefault();
            }
        }
    }
    
}
