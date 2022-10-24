

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

            string path = @$"..\Program\Steps_Filters\step{this.numberSteps}.jpg";
            PictureProvider provider = new PictureProvider();
            this.numberSteps += 1;
            provider.SavePicture(image, path);
            return image;
        }
    }
}