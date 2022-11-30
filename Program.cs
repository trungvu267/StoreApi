using Microsoft.EntityFrameworkCore;
using StoreApi.Models;
using StoreApi.Services;

var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy  =>
                      {
                          policy.WithOrigins("http://localhost:8000",
                                              "http://www.contoso.com");
                      });
});
// Add scoped service in Program.cs
builder.Services.AddScoped<UsersService>();

// Add services to the container.
builder.Services.Configure<StoreDatabaseSettings>(
builder.Configuration.GetSection("StoreDatabase"));

builder.Services.AddSingleton<ProductsService>();
builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(opt =>
    opt.UseInMemoryDatabase("Store"));
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new() { Title = "TodoApi", Version = "v1" });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseSwagger();
    //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApi v1"));
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();