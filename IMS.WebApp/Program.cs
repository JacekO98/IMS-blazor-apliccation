using IMS.Plugins.InMemory;
using IMS.UseCases.Inventories;
using IMS.UseCases.PluginInterfaces;
using IMS.WebApp.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents();

/// poni�ej pokazuje programowi jakie interfejsy b�da ��czy�y si� z kt�rymi klasami i 
/// jak d�ugo b�d� trwa�y w pamieci
///"Singleton" Te obiekty s� d�ugo trzymane w pami�ci w zasadzie tak d�ugo jak �yje aplikacja bo apka ca�y czas musi pami�ta� baz� danych i co do dp niej dodajemy.
builder.Services.AddSingleton<IInventoryRepository, InventoryRepository>(); ///tutaj mo�e co� nie gra� bo pod�wietli�o si� na inny kolor ni� na filmie 2.15 7:49min. 
///"Transient" Te obiekty s� kt�rko trzymane w pamieci bo nie potrzebujemy �eby apka pamieta�a nasze zapytania
builder.Services.AddTransient<IViewInventoriesByNameUseCase, ViewInventoriesByNameUseCase>(); ///tutaj te� co� mo�e by� nie tak bo w og�le si� nie pod�wietla a na filmie tam 2.16 1:40min. 
///builder.Services.AddScoped<IViewInventoriesByNameUseCase, ViewInventoriesByNameUseCase>(); /// to ma r�n� �ywotno�� w zale�no�ci np. od �ywotno�ci serwera
///
builder.Services.AddTransient<IAddInventoryUseCase, AddInventoryUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>();

app.Run();
