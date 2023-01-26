using MySqlConnector;
using ProcessEntryPlus.Repositories;
using ProcessEntryPlus.Services;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.


builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<MySqlConnection>(_ => new MySqlConnection(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddTransient<CourtsRepository>();
builder.Services.AddTransient<CourtsService>();

builder.Services.AddTransient<ProcessEntriesRepository>();
builder.Services.AddTransient<ProcessEntriesService>();

builder.Services.AddTransient<AddressesRepository>();
builder.Services.AddTransient<AddressesService>();

builder.Services.AddTransient<ContactsRepository>();
builder.Services.AddTransient<ContactsService>();

builder.Services.AddTransient<CompaniesRepository>();
builder.Services.AddTransient<CompaniesService>();

builder.Services.AddTransient<ServersRepository>();
builder.Services.AddTransient<ServersService>();

builder.Services.AddTransient<ServiceSubjectsRepository>();
builder.Services.AddTransient<ServiceSubjectsService>();

builder.Services.AddTransient<AffidavitTypesRepository>();
builder.Services.AddTransient<AffidavitTypesService>();

builder.Services.AddTransient<DocumentsRepository>();
builder.Services.AddTransient<DocumentsService>();

builder.Services.AddTransient<InstructionsRepository>();
builder.Services.AddTransient<InstructionsService>();

builder.Services.AddTransient<LitigantTypesRepository>();
builder.Services.AddTransient<LitigantTypesService>();

builder.Services.AddTransient<MethodsRepository>();
builder.Services.AddTransient<MethodsService>();

builder.Services.AddTransient<CapacitiesRepository>();
builder.Services.AddTransient<CapacitiesService>();

builder.Services.AddTransient<SsAddressesRepository>();
builder.Services.AddTransient<SsAddressesService>();

builder.Services.AddTransient<ContactCompaniesRepository>();
builder.Services.AddTransient<ContactCompaniesService>();

builder.Services.AddTransient<ServiceAttemptsRepository>();
builder.Services.AddTransient<ServiceAttemptsService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}



app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
