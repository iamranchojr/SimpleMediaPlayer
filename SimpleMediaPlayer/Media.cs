
//MIT License

//Copyright(c) 2019 Samuel Jr.Berkoh


//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.

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
