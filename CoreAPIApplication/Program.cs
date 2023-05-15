using CoreAPIApplication;
using CoreAPIApplication.Data;
using CoreAPIApplication.Interfaces;
using CoreAPIApplication.Repository;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using System;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddDbContext<ContractsDbContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("ContractsDbContext")
                    ?? throw new InvalidOperationException("Connection string 'ContractsDbContext' not found.")));



builder.Services.AddSingleton<IAssignmentRepository, AssignmentRepository>();
builder.Services.AddSingleton<IAssigneeRepository, AssigneeRepository>();
builder.Services.AddSingleton<IAssignmentManagementRepository, AssignmentManagementRepository>();

builder.Services.AddScoped<CoreAPIApplication.Interfaces.v2.IAssigneeRepository, CoreAPIApplication.Repository.v2.AssigneeRepository>();

//Add versioning to API
builder.Services.AddApiVersioning(opt =>
{
    opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    opt.AssumeDefaultVersionWhenUnspecified = true;
    opt.ReportApiVersions = true;
    opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                    new HeaderApiVersionReader("x-api-version"),
                                                    new MediaTypeApiVersionReader("x-api-version"));
});
// Add ApiExplorer to discover versions
builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => { c.CustomSchemaIds(i => i.FullName); });
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();


var app = builder.Build();

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
    });
}

// Migrate latest database changes during startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<ContractsDbContext>();

    // Here is the migration executed
    dbContext.Database.Migrate();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
