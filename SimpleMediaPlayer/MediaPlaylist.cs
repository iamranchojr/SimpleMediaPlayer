

namespace SimpleMediaPlayer
{
    using System.IO;
    using System.Linq;
    using System.Collections.ObjectModel;

    /// <summary>
    /// This class is used to represent a Media Playlist
    /// </summary>
    public static class MediaPlaylist
    {
        /// <summary>
        /// Holds all media currently in the playlist
        /// </summary>
        public static ObservableCollection<Media> Playlist { get; } = new ObservableCollection<Media>();

        /// <summary>
        /// Used to hold the index of the current active media
        /// </summary>
        public static int ActiveIndex { get; set; }

        /// <summary>
        /// Adds a new media to the playlist
        /// </summary>
        /// <param name="path">Path to media</param>
        public static void AddMedia ( string path )
        {
            // If path points to an existing file
            if ( File.Exists(path) )
            {
                // get media title
                var title = Path.GetFileNameWithoutExtension(path);

                // create an instance of the Media class 
                // using the title and path of the file
                var media = (new Media(title, path));

                // If the file doesn't already exists 
                if (Playlist.SingleOrDefault(m => m.Path == path) == null)
                {
                    // add it to the playlist
                    Playlist.Add(media);
                }
            }
        }

        /// <summary>
        /// Deletes a media from the playlist
        /// </summary>
        /// <param name="indexOfMedia">Index of Media to delete</param>
        public static void DeleteMedia ( int indexOfMedia )
        {
            // perform this check to prevent IndexOutOfBoundsException
            if ( Playlist.Count > indexOfMedia)
                Playlist.RemoveAt(indexOfMedia);
        }

        //public static int SearchMedia ( Media media )
        //{
        //    int mediaIndex;
        //    try
        //    {
        //        mediaIndex = Playlist.IndexOf(media);
        //        return mediaIndex;
        //    }
        //    catch ( System.Exception ex )
        //    {
        //        MessageBox.Show(ex.Message);
        //        return 0;
        //    }
        //}
    }
}
