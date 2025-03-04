using Microsoft.Extensions.Logging;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.PageModels;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Pages;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        //Meter singletons, transients de repositories models
        //
        //Este codigo añade una vista con su model desde una ruta específica
        //builder.Services.AddTransientWithShellRoute<ProjectDetailPage, ProjectDetailPageModel>("project");
        //builder.Services.AddTransientWithShellRoute<TaskDetailPage, TaskDetailPageModel>("task");
        builder.Services.AddTransient<ArtistPage>();
        builder.Services.AddTransient<ArtistPageModel>();
        builder.Services.AddTransient<FavoritesPage>();
        builder.Services.AddTransient<FavoritesPageModel>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<MainPageModel>();
        builder.Services.AddTransient<SearchPage>();
        builder.Services.AddTransient<SearchPageModel>();
        builder.Services.AddTransient<SettingsPage>();
        builder.Services.AddTransient<SettingsPageModel>();
        builder.Services.AddTransient<SongPage>();
        builder.Services.AddTransient<SongPageModel>();
        builder.Services.AddTransient<PlaylistsPage>();
        builder.Services.AddTransient<PlaylistsPageModel>();
        builder.Services.AddHttpClient<ApiClientService>();
        builder.Services.AddScoped<IRestClient<Album>, RestClientAlbum>();
        builder.Services.AddScoped<IRestClient<Artist>, RestClientArtist>();
        builder.Services.AddScoped<IRestClient<Genre>, RestClientGenre>();
        builder.Services.AddScoped<IRestClient<Playlist>, RestClientPlaylist>();
        builder.Services.AddScoped<IRestClient<Song>, RestClientSong>();
        return builder.Build();
    }
}
