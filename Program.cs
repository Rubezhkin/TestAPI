using Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<APIData>(builder.Configuration.GetSection("Dadata"));
builder.Services.AddHttpClient();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AppMappingProfile));



builder.Services.AddCors(options =>

    options.AddPolicy("AllowLocalhost5100",
                        builder => builder.WithOrigins("http://localhost:5100")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowLocalhost5100");

app.MapControllers();

app.Run();
