namespace UrbanPlanningApi.Classes
{
    public static class CH
    {
        public static string gConnectionString { get {

                string serverAndDatabase;
                try
                {
                    using (StreamReader ssr = new StreamReader(Directory.GetCurrentDirectory() + @"\ipconfig.txt"))
                    {
                        serverAndDatabase = ssr.ReadToEnd().Split('\n')[1];
                    }
                    return @$"{serverAndDatabase}User Id=AppConnection;password=C0nnecti0n;Integrated Security=False;TrustServerCertificate=True";
                }
                catch 
                {
                    return @"Server=EVE-PC\SQLEXPRESS;DataBase=UrbanPlanning;User Id=AppConnection;password=C0nnecti0n;Integrated Security=False;TrustServerCertificate=True";
                }
                
            
            } }
    }
}
