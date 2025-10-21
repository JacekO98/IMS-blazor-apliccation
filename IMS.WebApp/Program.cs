using IMS.Plugins.InMemory;
using IMS.UseCases.Inventories;
using IMS.UseCases.Inventories.interfaces;
using IMS.UseCases.PluginInterfaces;
using IMS.WebApp.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents();

/// poni¿ej pokazuje programowi jakie interfejsy bêda ³¹czy³y siê z którymi klasami i 
/// jak d³ugo bêd¹ trwa³y w pamieci
///"Singleton" Te obiekty s¹ d³ugo trzymane w pamiêci w zasadzie tak d³ugo jak ¿yje aplikacja bo apka ca³y czas musi pamiêtaæ bazê danych i co do dp niej dodajemy.
builder.Services.AddSingleton<IInventoryRepository, InventoryRepository>(); ///tutaj mo¿e coœ nie graæ bo podœwietli³o siê na inny kolor ni¿ na filmie 2.15 7:49min. 
///"Transient" Te obiekty s¹ którko trzymane w pamieci bo nie potrzebujemy ¿eby apka pamieta³a nasze zapytania
builder.Services.AddTransient<IViewInventoriesByNameUseCase, ViewInventoriesByNameUseCase>(); ///tutaj te¿ coœ mo¿e byæ nie tak bo w ogóle siê nie podœwietla a na filmie tam 2.16 1:40min. 
///builder.Services.AddScoped<IViewInventoriesByNameUseCase, ViewInventoriesByNameUseCase>(); /// to ma ró¿n¹ ¿ywotnoœæ w zale¿noœci np. od ¿ywotnoœci serwera
///
builder.Services.AddTransient<IAddInventoryUseCase, AddInventoryUseCase>();

builder.Services.AddSingleton<IEditInventoryUseCase, EditInventoryUseCase>();
builder.Services.AddTransient<IViewInventoryByIdUseCase, ViewInventoryByIdUseCase>();

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
