using System;
using System.IO;

using TwitterUCU;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Publica la imagen en Twiter
    /// </summary>
    public class FilterTwitterAPI : IFilter
    {

        public IPicture Filter(IPicture image)
        {
            string path = @$"..\Program\Temp\tempPost.jpg";
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image,path);
            this.PostTwitter(path);
            File.Delete(path);
            return image;
        }


        public void PostTwitter(string path)
        {
            var twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter("Jorge Avila.", path));

        }

    }
}