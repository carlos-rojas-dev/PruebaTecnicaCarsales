using API;
using API.External;
using API.NewFolder;
using API.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddScoped<IApiService, ApiService>();
builder.Services.AddScoped<IUrlHelperService, UrlHelperService>();
builder.Services.AddHttpClient<IExternalApi, ExternalApi>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiSettings:ExternalApiUrl"]);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});
// Servicios
builder.Services.AddScoped<ICharacterService, CharacterService>();

// Cliente HTTP base
/*builder.Services.AddHttpClient<IRickAndMortyClient, RickAndMortyClient>(client =>
{
    client.BaseAddress = new Uri("https://rickandmortyapi.com");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});*/

builder.Services.AddRazorPages();

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PoliticaCors", policy =>
    {
        policy.WithOrigins("*")                    // Orígenes permitidos
              .AllowAnyHeader()                    // Permite cualquier header
              .AllowAnyMethod();                   // Permite GET, POST, PUT, DELETE, etc.
    });
});

// Vincular la configuración de ApiSettings
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));
var apiSettings = builder.Configuration.GetSection("ApiSettings").Get<ApiSettings>();
 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


// Habilitar CORS
app.UseCors("PoliticaCors");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();

app.Run();
