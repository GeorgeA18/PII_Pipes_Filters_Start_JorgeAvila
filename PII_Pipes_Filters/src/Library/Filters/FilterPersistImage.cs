using System;
using System.Drawing;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;


namespace CompAndDel.Filters
{
    /// <summary>
    /// Devuelve una copia de la imagen y la guarda en la carpeta "Program\Steps_Filters.
    /// </summary>
    public class FilterPersistImage : IFilter
    {

        protected int numberSteps;

        public FilterPersistImage()
        {
            this.numberSteps = 0;
        }


        public IPicture Filter(IPicture image)
        {
            this.SavePicture(image);
            return image;
        }

        public void SavePicture(IPicture picture)
        {
            int width = picture.Width;
            int height = picture.Height;
            using (Image<Rgba32> image = new Image<Rgba32>(width, height)) // creates a new image with all the pixels set as transparent
            {
                for (int h = 0; h < picture.Height; h++)
                {
                    for (int w = 0; w < picture.Width; w++)
                    {
                        System.Drawing.Color c = picture.GetColor(w, h);
                        image[w, h] = new Rgba32(c.R, c.G, c.B, c.A);
                    }
                }
                this.numberSteps += 1;
                image.Save(@$"..\step{this.numberSteps}.jpg");
            }
        }
    }
}