using Microsoft.Extensions.DependencyInjection;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Repositories;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.UI.Controls;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.UI.Views;
using System.Windows;

namespace P06_01_DI_Contactos_TAPIADOR_rodrigo;


public partial class App : Application
{

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        ServiceCollection services = new();

        services.AddTransient<MainWindow>();
        services.AddTransient<MainViewModel>();
        services.AddTransient<CategoryView>();
        services.AddTransient<ListViewCategories>();
        services.AddTransient<CategoryViewModel>();
        services.AddTransient<ProductView>();
        services.AddTransient<ListViewProducts>();
        services.AddTransient<ProductViewModel>();
        services.AddTransient<SettingsView>();
        services.AddTransient<SettingsViewModel>();
        services.AddTransient<HomeView>();
        services.AddTransient<HomeViewModel>();
        services.AddScoped<IRepositoryService<Product>, ProductService>();
        services.AddScoped<IRepositoryService<Category>, CategoryService>();
        //services.AddDbContext<AppDbContext>(options => options.UseSqlServer("Server=localhost,1433;Database=TuBaseDeDatos;User Id=sa;Password=Interfaces-2425;TrustServerCertificate=true;"));
        services.AddScoped<IRepository<Product>,ProductRepository>();
        services.AddScoped<IRepository<Category>, CategoryRepository>();

        var serviceProvider = services.BuildServiceProvider();


        //// Solo para cargar datos dummy, quitar en aplicación en producción.
        //using (var scope = serviceProvider.CreateScope())
        //{
        //    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        //    dbContext.Database.EnsureCreated();

        //    if (dbContext.Categories.Count<Category>() == 0)
        //    {
        //        dbContext.Categories.Add(new Category { Name = "Cosas" });
        //        dbContext.Categories.Add(new Category { Name = "Más cosas" });
        //        dbContext.Items.Add(new Item { Name = "Cosa 1", Description = "Descripción de la cosa", CategoryId = 1, ImageUri = "https://picsum.photos/250/250" });
        //        dbContext.Items.Add(new Item { Name = "Cosa 2", Description = "Descripción de la cosa", CategoryId = 2, ImageUri = "https://picsum.photos/250/250" });
        //        dbContext.Items.Add(new Item { Name = "Cosa 3", Description = "Descripción de la cosa", CategoryId = 1, ImageUri = "https://picsum.photos/250/250" });
        //        dbContext.Items.Add(new Item { Name = "Cosa 4", Description = "Descripción de la cosa", CategoryId = 1, ImageUri = "https://picsum.photos/250/250" });
        //        dbContext.Items.Add(new Item { Name = "Cosa 5", Description = "Descripción de la cosa", CategoryId = 2, ImageUri = "https://picsum.photos/250/250" });
        //    }

        //    dbContext.SaveChanges();
        //}
        ////
        ///

        var view = serviceProvider.GetService<MainWindow>();
        view.DataContext = serviceProvider.GetService<MainViewModel>();

        var listViewProducts = serviceProvider.GetService<ListViewProducts>();
        listViewProducts.DataContext = serviceProvider.GetService<ProductViewModel>();

        // var ProductView = serviceProvider.GetService<ProductView>();
        //ProductView.DataContext = serviceProvider.GetService<ProductViewModel>();

         var listViewCategories = serviceProvider.GetService<ListViewCategories>();
        listViewCategories.DataContext = serviceProvider.GetService<CategoryViewModel>();

        // var CategoryView = serviceProvider.GetService<CategoryView>();
        //CategoryView.DataContext = serviceProvider.GetService<CategoryViewModel>();

        view.Show();
    }
}
