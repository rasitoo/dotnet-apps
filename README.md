# P06_01_DI_Contactos_TAPIADOR_rodrigo
Es necesario lanzar una base de datos en SQLserver para utilizar la aplicación
## SQLserver
### Paquete de NuGet
        Microsoft.EntityFrameworkCore.SqlServer
### Contenedor SQLserver
        docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=PracticaWPFMVVMIoCRodrigo" -p 1433:1433 --name PracticaWPFMVVMIoCRodrigo -d mcr.microsoft.com/mssql/server:2022-latest
### Cadena de Conexión
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer("Server=localhost,1433;User Id=sa;Password=PracticaWPFMVVMIoCRodrigo;TrustServerCertificate=true;"));
