using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.Data;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Repositories;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.UI.Views;
using System.Windows;

namespace P06_01_DI_Contactos_TAPIADOR_rodrigo;


public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
        if (serviceProvider == null)
        {
            throw new InvalidOperationException("ServiceProvider no se pudo inicializar.");
        }
        GenerarDummies(serviceProvider);

        var mainWindow = serviceProvider.GetService<MainWindow>();
        if (mainWindow == null)
        {
            throw new InvalidOperationException("MainWindow no se pudo inicializar.");
        }
        mainWindow.DataContext = serviceProvider.GetRequiredService<MainViewModel>();
        mainWindow.Show();
    }
    // Solo para cargar datos dummy, quitar en aplicación en producción. Generado con Copilot
    private void GenerarDummies(ServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            dbContext.Database.EnsureCreated();
            if (dbContext.Categories.Count<Category>() == 0)
            {
                var categories = new List<Category>
                {
                    new Category { Name = "Verduras" },
                    new Category { Name = "Carnes" },
                    new Category { Name = "Herramientas" },
                    new Category { Name = "Menaje" }
                };
                dbContext.Categories.AddRange(categories);
                dbContext.SaveChanges();
                var products = new List<Product>
                {
                    // Verduras
                    new Product { Name = "Tomate", Description = "Tomate fresco", Price = 1.5, CategoryId = categories[0].Id, ImageUri = "https://picsum.photos/250/250" },
                    new Product { Name = "Lechuga", Description = "Lechuga verde", Price = 1.0, CategoryId = categories[0].Id, ImageUri = "https://picsum.photos/250/250" },
                    new Product { Name = "Zanahoria", Description = "Zanahoria orgánica", Price = 0.8, CategoryId = categories[0].Id, ImageUri = "https://picsum.photos/250/250" },
                    new Product { Name = "Pepino", Description = "Pepino fresco", Price = 1.2, CategoryId = categories[0].Id, ImageUri = "https://picsum.photos/250/250" },
                    new Product { Name = "Espinaca", Description = "Espinaca fresca", Price = 1.3, CategoryId = categories[0].Id, ImageUri = "https://picsum.photos/250/250" },

                    // Carnes
                    new Product { Name = "Pollo", Description = "Pollo fresco", Price = 5.0, CategoryId = categories[1].Id, ImageUri = "https://picsum.photos/250/250" },
                    new Product { Name = "Ternera", Description = "Ternera de primera", Price = 10.0, CategoryId = categories[1].Id, ImageUri = "https://picsum.photos/250/250" },
                    new Product { Name = "Cerdo", Description = "Cerdo fresco", Price = 7.0, CategoryId = categories[1].Id, ImageUri = "https://picsum.photos/250/250" },
                    new Product { Name = "Cordero", Description = "Cordero fresco", Price = 12.0, CategoryId = categories[1].Id, ImageUri = "https://picsum.photos/250/250" },
                    new Product { Name = "Pavo", Description = "Pavo fresco", Price = 8.0, CategoryId = categories[1].Id, ImageUri = "https://picsum.photos/250/250" },

                    // Herramientas
                    new Product { Name = "Martillo", Description = "Martillo de acero", Price = 15.0, CategoryId = categories[2].Id, ImageUri = "https://picsum.photos/250/250" },
                    new Product { Name = "Destornillador", Description = "Destornillador de estrella", Price = 5.0, CategoryId = categories[2].Id, ImageUri = "https://picsum.photos/250/250" },
                    new Product { Name = "Llave inglesa", Description = "Llave inglesa ajustable", Price = 20.0, CategoryId = categories[2].Id, ImageUri = "https://picsum.photos/250/250" },
                    new Product { Name = "Taladro", Description = "Taladro eléctrico", Price = 50.0, CategoryId = categories[2].Id, ImageUri = "https://picsum.photos/250/250" },
                    new Product { Name = "Sierra", Description = "Sierra manual", Price = 25.0, CategoryId = categories[2].Id, ImageUri = "https://picsum.photos/250/250" },

                    // Menaje
                    new Product { Name = "Plato", Description = "Plato de cerámica", Price = 3.0, CategoryId = categories[3].Id, ImageUri = "https://picsum.photos/250/250" },
                    new Product { Name = "Vaso", Description = "Vaso de cristal", Price = 2.0, CategoryId = categories[3].Id, ImageUri = "https://picsum.photos/250/250" },
                    new Product { Name = "Cuchara", Description = "Cuchara de acero inoxidable", Price = 1.5, CategoryId = categories[3].Id, ImageUri = "https://picsum.photos/250/250" },
                    new Product { Name = "Tenedor", Description = "Tenedor de acero inoxidable", Price = 1.5, CategoryId = categories[3].Id, ImageUri = "https://picsum.photos/250/250" },
                    new Product { Name = "Cuchillo", Description = "Cuchillo de cocina", Price = 2.5, CategoryId = categories[3].Id, ImageUri = "https://picsum.photos/250/250" }
                };
                dbContext.Products.AddRange(products);
                dbContext.SaveChanges();
            }
        }
    }
    //
    private void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<MainWindow>();
        services.AddTransient<MainViewModel>();
        services.AddTransient<CategoryView>();
        services.AddTransient<CategoryViewModel>();
        services.AddTransient<ProductView>();
        services.AddTransient<ProductViewModel>();
        services.AddTransient<SettingsView>();
        services.AddTransient<SettingsViewModel>();
        services.AddTransient<HomeView>();
        services.AddTransient<HomeViewModel>();
        services.AddScoped<IRepository<Product>, ProductRepository>();
        services.AddScoped<IRepository<Category>, CategoryRepository>();
        services.AddScoped<IRepositoryService<Product>, ProductService>();
        services.AddScoped<IRepositoryService<Category>, CategoryService>();
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer("Server=localhost,1433;User Id=sa;Password=Interfaces-2425;TrustServerCertificate=true;"));
    }
}