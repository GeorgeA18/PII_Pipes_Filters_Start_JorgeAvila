using System;
using System.IO;

using CognitiveCoreUCU;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Filtro condicional para el jercicio 4. Este detecta si una imagen tiene una cara o no, y devuelve un valor booleano.
    /// </summary>
    public class FilterConditional: IFilter
    {

        public bool FaceFound {get; protected set;}

        public FilterConditional()
        {
            this.FaceFound = false;
        }

        public IPicture Filter(IPicture image)
        {
            string path = @$"..\Program\Temp\tempConditional.jpg";
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image, path);

            CognitiveFace cog = new CognitiveFace(false);
            cog.Recognize(path);

            this.FaceFound = cog.FaceFound;

            File.Delete(path);

            return image;
        }

    }
}