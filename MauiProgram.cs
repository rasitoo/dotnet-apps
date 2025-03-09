using Microsoft.Extensions.Logging;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.PageModels;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Pages;
using CommunityToolkit.Maui;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Messages;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkitMediaElement()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddTransient<ArtistPage>();
        builder.Services.AddTransient<ArtistPageModel>();

        builder.Services.AddSingleton<FavoritesPage>();
        builder.Services.AddSingleton<FavoritesPageModel>();

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainPageModel>();

        builder.Services.AddTransient<SearchPage>();
        builder.Services.AddTransient<SearchPageModel>();

        builder.Services.AddTransient<SettingsPage>();
        builder.Services.AddTransient<SettingsPageModel>();

        builder.Services.AddSingleton<SongPage>();
        builder.Services.AddSingleton<SongPageModel>();

        builder.Services.AddTransient<PlaylistsPage>();
        builder.Services.AddTransient<PlaylistsPageModel>();

        builder.Services.AddTransient<PlaylistPage>();
        builder.Services.AddTransient<PlaylistPageModel>();

        builder.Services.AddTransient<AlbumPage>();
        builder.Services.AddTransient<AlbumPageModel>();

        builder.Services.AddTransient<GenrePage>();
        builder.Services.AddTransient<GenrePageModel>();

        builder.Services.AddHttpClient<ApiClientService>();
        builder.Services.AddScoped<IRestClient<Album>, RestClientAlbum>();
        builder.Services.AddScoped<IRestClient<Artist>, RestClientArtist>();
        builder.Services.AddScoped<IRestClient<Genre>, RestClientGenre>();
        builder.Services.AddScoped<IRestClient<Playlist>, RestClientPlaylist>();
        builder.Services.AddScoped<IRestClient<Song>, RestClientSong>();
        var app = builder.Build();

        var favoritesPageModel = app.Services.GetRequiredService<FavoritesPageModel>();

        return app;
    }
}
