//netsh http add urlacl url=http://192.168.0.13:5000/ user=Все





var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();



var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
string APP_PATH;
try
{
    using (StreamReader ssr = new StreamReader(Directory.GetCurrentDirectory() + @"\ipconfig.txt"))
    {
        APP_PATH = ssr.ReadToEnd().Split('\n')[0];
    }
}
catch
{
    try
    {
        using (StreamReader ssr = new StreamReader(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName + @"\ipconfig.txt"))
        {
            APP_PATH = ssr.ReadToEnd().Split('\n')[0];
        }

    }
    catch
    {
        APP_PATH = "http://192.168.0.13:5000";
    }
    
}

app.Run(APP_PATH);



//app.Run("http://26.24.248.163:5000");
//app.Run("http://192.168.1.11:5000");





