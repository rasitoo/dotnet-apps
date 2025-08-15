# P07_01_DI_Contactos_TAPIADOR_rodrigo

Aplicación multiplataforma desarrollada con .NET MAUI para la gestión de contactos musicales, playlists, álbumes, artistas y géneros.

## Características

- Visualización y gestión de playlists, canciones, álbumes, artistas y géneros.
- Navegación entre páginas mediante Shell.
- Soporte para Android, iOS, Mac Catalyst y Windows.
- Uso de CommunityToolkit.Mvvm para MVVM y CommunityToolkit.Maui.MediaElement para reproducción multimedia.
- Consumo de servicios REST para la obtención y manipulación de datos.
- Interfaz moderna y responsiva.

## Requisitos

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Visual Studio 2022 (con soporte para .NET MAUI)
- Acceso a un backend REST compatible (ver configuración en `ApiClientService`)

## Instalación

1. Clona este repositorio:
   
```
   git clone https://github.com/tuusuario/P07_01_DI_Contactos_TAPIADOR_rodrigo.git
   
```
2. Abre la solución en Visual Studio 2022.
3. Restaura los paquetes NuGet.
4. Configura la URL del backend en `ApiClientService`.
5. Selecciona la plataforma de destino y ejecuta la aplicación.

## Estructura del Proyecto

- **Pages/**: Vistas XAML para cada entidad (Playlist, Álbum, Artista, etc.).
- **PageModels/**: ViewModels con lógica de presentación y navegación.
- **Data/Entities/**: Modelos de datos principales.
- **Data/Rest/**: Clientes REST para comunicación con el backend.
- **Resources/**: Imágenes, fuentes y recursos de la app.

## Dependencias Principales

- [CommunityToolkit.Mvvm](https://www.nuget.org/packages/CommunityToolkit.Mvvm)
- [CommunityToolkit.Maui.MediaElement](https://www.nuget.org/packages/CommunityToolkit.Maui.MediaElement)
- [Microsoft.Maui.Controls](https://www.nuget.org/packages/Microsoft.Maui.Controls)
- [Microsoft.Extensions.Http](https://www.nuget.org/packages/Microsoft.Extensions.Http)

## Licencia

Este proyecto está bajo la licencia MIT.
