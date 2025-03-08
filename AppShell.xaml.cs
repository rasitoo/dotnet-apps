using P07_01_DI_Contactos_TAPIADOR_rodrigo.Pages;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            InitializeRouting();
        }
        private static void InitializeRouting()
        {
            Routing.RegisterRoute("song", typeof(SongPage));
            Routing.RegisterRoute("album", typeof(AlbumPage));
            Routing.RegisterRoute("artist", typeof(ArtistPage));
            Routing.RegisterRoute("playlist", typeof(PlaylistPage));
        }
    }
}
