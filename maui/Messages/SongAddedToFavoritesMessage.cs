using CommunityToolkit.Mvvm.Messaging.Messages;
using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Messages;

public class SongAddedToFavoritesMessage : ValueChangedMessage<Song>
{
    public SongAddedToFavoritesMessage(Song song) : base(song) { }
}