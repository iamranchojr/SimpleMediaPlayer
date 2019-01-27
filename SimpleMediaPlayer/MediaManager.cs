
namespace SimpleMediaPlayer
{
    using System;
    using System.Windows.Controls;
    using static SimpleMediaPlayer.MediaPlaylist;

    /// <summary>
    /// This class is the brain of the media player responsible for 
    /// handling playbacks. It contains methods to play a media, 
    /// pause or stop a currently playing media, play the next or previous media etc...
    /// </summary>
    public class MediaManager
    {
        /// <summary>
        /// A flag used to indicate whether a media is paused or not
        /// </summary>
        bool _isPaused = false;

        /// <summary>
        /// A flag used to indicate whether if a media is being played
        /// </summary>
        bool _isPlaying = false;

        /// <summary>
        /// Used to hold an instance of the MediaElement class that will be used
        /// throughout the lifetime of the application to hanle media files
        /// </summary>
        readonly MediaElement _simplePlayer;

        /// <summary>
        /// Holds the path to the current active media 
        /// </summary>
        public string CurrentMedia { get; private set; }

        /// <summary>
        /// Constructor that creates an instance of MediaManager 
        /// with an instance of MediaElement
        /// </summary>
        /// <param name="simplePlayer">Media Element</param>
        public MediaManager (MediaElement simplePlayer)
        {
            _simplePlayer = simplePlayer;
        }

        /// <summary>
        /// Adds media to the playlist using its paths
        /// </summary>
        public void AddMedia(string[] mediaPaths)
        {
            // loop through the media paths
            foreach (string mediaPath in mediaPaths)
            {
                // add media to playlist
                MediaPlaylist.AddMedia(mediaPath);
            }
        }

        /// <summary>
        /// Plays or pause the current active index media
        /// </summary>
        /// <param name="mediaIndex">Index of media to play</param>
        /// <returns>Playing status</returns>
        public string Play (int mediaIndex = -1)
        {
            // if mediaIndex is not -1
            if (mediaIndex != -1)
            {
                // set active index
                ActiveIndex = mediaIndex;

                // stop the current active media
                Stop();

                // if is not within boundary
                if (ActiveIndex > MediaPlaylist.Playlist.Count)
                {
                    // decrease active index by 1
                    ActiveIndex--;
                }
            }

            // if media is playing
            if (_isPlaying )
            {
                // pause media
                Pause();
                return "Play";
            }

            // if media is not paused && playlist is empty
            if ( !_isPaused && MediaPlaylist.Playlist.Count == 0 )
                return null; // return null

            // if media is not paused and playlist is greater than active index
            if (!_isPaused && MediaPlaylist.Playlist.Count > ActiveIndex)
            {
                // play the current active index
                Media mediaToPlay = MediaPlaylist.Playlist[ActiveIndex];
                _simplePlayer.Source = new Uri(mediaToPlay.Path);
                CurrentMedia = mediaToPlay.Title;
            }

            // Play the media
            _simplePlayer.Play();

            // set is paused to false
            _isPaused = false;

            // set is playing to true
            _isPlaying = true;

            return "Pause";
        }

        /// <summary>
        /// Pause the current active media playing
        /// </summary>
        public void Pause ()
        {
            // puase media
            _simplePlayer.Pause();

            // set is paused to true
            _isPaused = true;

            // set is playing to false
            _isPlaying = false;
        }

        /// <summary>
        /// Stops the current active media playing
        /// </summary>
        public string Stop ()
        {
            // stop media
            _simplePlayer.Stop();

            // set is paused and is playing to false
            _isPlaying = false;
            _isPaused = false;

            return "Play";
        }

        /// <summary>
        /// Plays the next track in the playlist
        /// </summary>
        public void Next()
        {
            // first stop the current active media playing
            Stop();

            // increment active index
            ActiveIndex ++;

            // if is not within boundary
            if ( ActiveIndex >= MediaPlaylist.Playlist.Count )
            {
                // set index to first track
                ActiveIndex = 0;
            }
           
            // play media
            Play();      
        }

        /// <summary>
        /// Plays the previous track in the playlist
        /// </summary>
        public void Prev()
        {
            // first stop the current active media playing
            Stop();

            // decrease active index by 1
            ActiveIndex --;

            // if is not within boundary
            if ( ActiveIndex < 0 )
            {
                // set active index to the last track
                ActiveIndex = MediaPlaylist.Playlist.Count - 1;
            }

            // play media
            Play();
        }

        /// <summary>
        /// Deletes media from the playlist
        /// </summary>
        /// <param name="indexOfMedia">Index of media to delete</param>
        public void DeleteMediaFromPlaylist ( int indexOfMedia )
        {
            DeleteMedia(indexOfMedia);
        }

        public void SearchMediaFromPlaylist ( string query )
        {
            throw new NotImplementedException("Not implmeneted method");
        }
    }
}
