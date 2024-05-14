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

app.Run("http://192.168.0.13:5000");


var builder2 = WebApplication.CreateBuilder(args);

// Add services to the container.


//app.Run("http://26.24.248.163:5000");





