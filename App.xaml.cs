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
        try
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider() ?? throw new InvalidOperationException("ServiceProvider no se pudo inicializar.");
            GenerarDummies(serviceProvider);

            var mainWindow = serviceProvider.GetService<MainWindow>() ?? throw new InvalidOperationException("MainWindow no se pudo inicializar.");
            mainWindow.DataContext = serviceProvider.GetRequiredService<MainViewModel>();
            mainWindow.Show();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            Current.Shutdown();
        }
    }
    // Solo para cargar datos dummy, quitar en aplicación en producción. Generado con Copilot
    private static void GenerarDummies(ServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.EnsureCreated();
        if (!dbContext.Categories.Any() || !dbContext.Products.Any())
        {
            var categories = new List<Category>
                {
                    new() { Name = "Verduras" },
                    new() { Name = "Carnes" },
                    new() { Name = "Herramientas" },
                    new() { Name = "Menaje" }
                };
            dbContext.Categories.AddRange(categories);
            dbContext.SaveChanges();
            var products = new List<Product>
                {
                    // Verduras
                    new() { Name = "Tomate", Description = "Tomate fresco", Price = 1.5, CategoryId = categories[0].Id, ImageUri = "https://www.fervalle.com/wp-content/uploads/2022/07/580b57fcd9996e24bc43c23b-1024x982.png" },
                    new() { Name = "Lechuga", Description = "Lechuga verde", Price = 1.0, CategoryId = categories[0].Id, ImageUri = "https://th.bing.com/th/id/OIP.tIJM0wby8ZD6dnEoY1FgrwHaFn?w=239&h=181&c=7&r=0&o=5&dpr=1.3&pid=1.7" },
                    new() { Name = "Zanahoria", Description = "Zanahoria orgánica", Price = 0.8, CategoryId = categories[0].Id, ImageUri = "https://i1.wp.com/enterateahora.com.mx/wp-content/uploads/2016/08/bigstock-132268460.jpg?fit=1600%2C1067&ssl=1" },
                    new() { Name = "Pepino", Description = "Pepino fresco", Price = 1.2, CategoryId = categories[0].Id, ImageUri = "https://nectarfruit.es/wp-content/uploads/2020/05/39.-Pepino-1.jpg" },
                    new() { Name = "Espinaca", Description = "Espinaca fresca", Price = 1.3, CategoryId = categories[0].Id, ImageUri = "https://www.gob.mx/cms/uploads/article/main_image/11271/espinass.jpg" },

                    // Carnes
                    new() { Name = "Pollo", Description = "Pollo fresco", Price = 5.0, CategoryId = categories[1].Id, ImageUri = "https://carnicaslosarcos.com/wp-content/uploads/2020/10/pollo-de-corral.jpg" },
                    new() { Name = "Ternera", Description = "Ternera de primera", Price = 10.0, CategoryId = categories[1].Id, ImageUri = "https://laalacenaroja.com/wp-content/uploads/2022/11/F-1-Ternera-Gallega-Suprema-1080x675.jpg" },
                    new() { Name = "Cerdo", Description = "Cerdo fresco", Price = 7.0, CategoryId = categories[1].Id, ImageUri = "https://actualidadporcina.com/wp-content/uploads/2020/05/carnecerdomexicoprecio-580x418.jpg" },
                    new() { Name = "Cordero", Description = "Cordero fresco", Price = 12.0, CategoryId = categories[1].Id, ImageUri = "https://meatlovers.com.gt/wp-content/uploads/2022/01/7-pierna-de-cordero.jpg" },
                    new() { Name = "Pavo", Description = "Pavo fresco", Price = 8.0, CategoryId = categories[1].Id, ImageUri = "https://thumbs.dreamstime.com/b/pavo-crudo-de-carne-fina-aislado-en-fondo-blanco-sobre-205226418.jpg" },

                    // Herramientas
                    new() { Name = "Martillo", Description = "Martillo de acero", Price = 15.0, CategoryId = categories[2].Id, ImageUri = "https://www.hmat.cl/wp-content/uploads/2022/09/49_31af8d6c-c8d5-4f46-9a7e-ea5cc2aea198_1200x1200-1-1.jpg" },
                    new() { Name = "Destornillador", Description = "Destornillador de estrella", Price = 5.0, CategoryId = categories[2].Id, ImageUri = "https://shopdelta.eu/shop_image/product/st-0-64-932_d.jpg" },
                    new() { Name = "Llave inglesa", Description = "Llave inglesa ajustable", Price = 20.0, CategoryId = categories[2].Id, ImageUri = "https://www.wurth.com.ar/blog/wp-content/uploads/2022/10/90715-221-12-scaled-e1665593239403.jpg" },
                    new() { Name = "Taladro", Description = "Taladro eléctrico", Price = 50.0, CategoryId = categories[2].Id, ImageUri = "https://woove.mx/assets/files/products/img/10798/woove_18154_16561104220.png" },
                    new() { Name = "Sierra", Description = "Sierra manual", Price = 25.0, CategoryId = categories[2].Id, ImageUri = "https://th.bing.com/th/id/OIP.voSI0gy6QyGbvWQwo3F4fAHaHa?rs=1&pid=ImgDetMain" },

                    // Menaje
                    new() { Name = "Plato", Description = "Plato de cerámica", Price = 3.0, CategoryId = categories[3].Id, ImageUri = "https://img.freepik.com/fotos-premium/imagenes-plato-vacio_796580-917.jpg" },
                    new() { Name = "Vaso", Description = "Vaso de cristal", Price = 2.0, CategoryId = categories[3].Id, ImageUri = "https://ss152.liverpool.com.mx/xl/1086663020.jpg" },
                    new() { Name = "Cuchara", Description = "Cuchara de acero inoxidable", Price = 1.5, CategoryId = categories[3].Id, ImageUri = "https://th.bing.com/th/id/R.023027de27bd23c5d033f040d4d88165?rik=jKwAFjGGg9%2frzw&pid=ImgRaw&r=0" },
                    new() { Name = "Tenedor", Description = "Tenedor de acero inoxidable", Price = 1.5, CategoryId = categories[3].Id, ImageUri = "https://th.bing.com/th/id/OIP.C8GQg-BevYelZrnUl0fu1QHaHa?rs=1&pid=ImgDetMain" },
                    new() { Name = "Cuchillo", Description = "Cuchillo de cocina", Price = 2.5, CategoryId = categories[3].Id, ImageUri = "https://assets.katogroup.eu/i/katogroup/ZW31070-080_01_zwilling-4ster-31070-officemes-8cm-d1" }
                };
            dbContext.Products.AddRange(products);
            dbContext.SaveChanges();
        }

    }
    //
    private static void ConfigureServices(IServiceCollection services)
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