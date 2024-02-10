using Api.DTOs;
using Api.Mappers;
using Api.Models;
using Api.Repository;
using Api.Services;
using Api.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
                          //interfaz que usa ,   donde implementa
builder.Services.AddSingleton<IPeopleServices, PeopleServices>();

//POR KEY
//builder.Services.AddKeyedSingleton<IPeopleServices, PeopleServices>("PeopleServicesKey");


builder.Services.AddKeyedSingleton<IrandomServices, RandomServices>("RandomServicesSingleton");
builder.Services.AddKeyedScoped<IrandomServices, RandomServices>("RandomServicesScoped");
builder.Services.AddKeyedTransient<IrandomServices, RandomServices>("RandomServicesTransient");


builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ICommentsServices, CommentsServices>();

builder.Services.AddKeyedScoped<ICommonServices<BeerDto,BeerInsertDto,BeerUpdateDto>,BeerServices>("IBeerServices");

//repository
builder.Services.AddScoped<IRepository<Beer>, BeerRepository>();


//add factory httpclientes para urls

builder.Services.AddHttpClient<IPostService, PostService>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["BaseUrlPosts"]);
});

builder.Services.AddHttpClient<ICommentsServices, CommentsServices>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["BaseUrlComments"]);
});


//ENTITY FRAMEWORK

builder.Services.AddDbContext<StoreContext>(options =>
{               //RECIBE OPTIONS QUE SE LA PASA A STORE CONTEXT QUE SE LA PASA A SU PADRE QUE ES DBCONTEXT
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreContext"));
});

//VALIDATORS

builder.Services.AddScoped<IValidator<BeerInsertDto>, BeerInsertValidator>();


//AUTOMAPPERS
builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
