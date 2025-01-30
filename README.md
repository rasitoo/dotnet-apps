# P06_01_DI_Contactos_TAPIADOR_rodrigo
Es necesario lanzar una base de datos en SQLserver para utilizar la aplicación
## SQLserver
### Paquete de NuGet
        Microsoft.EntityFrameworkCore.SqlServer
### Contenedor SQLserver
        docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=WPF-MVVM-IoC-Rodrigo" -p 1433:1433 --name MVVMIoCRodrigo -d mcr.microsoft.com/mssql/server:2022-latest
### Cadena de Conexión
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer("Server=localhost,1433;User Id=sa;Password=WPF-MVVM-IoC-Rodrigo;TrustServerCertificate=true;",
            sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 10,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
            }));
