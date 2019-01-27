
namespace SimpleMediaPlayer
{
    /// <summary>
    /// This class is used to represent a media file
    /// </summary>
    public class Media
    {
        /// <summary>
        /// Title of Media
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Path to Media File
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// Constructor to create an instance of Media class
        /// accepting the title and path of the media
        /// </summary>
        /// <param name="title">Title of media</param>
        /// <param name="path">Path to media</param>
        public Media ( string title, string path )
        {
            Title = title;
            Path = path;
        }

        /// <summary>
        /// Overrided ToString() method to return the title
        /// of the media when ToString() is called
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Title;
    }
}
