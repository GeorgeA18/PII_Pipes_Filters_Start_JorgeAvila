using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            // ! Ejercicio 3   ---------------------------------------
            PictureProvider provider = new PictureProvider();

            // Obtener los valores de la imagen
            IPicture picture = provider.GetPicture(@"luke.jpg");

            // Se declaran los filtros que se van a utilizar.
            FilterGreyscale filterGrey = new FilterGreyscale();
            FilterNegative filterNegative = new FilterNegative();
            FilterPersistImage persistImage = new FilterPersistImage();
            FilterTwitterAPI filterTwitter = new FilterTwitterAPI();
            FilterConditional filterConditional = new FilterConditional();



            PipeNull pipeNull = new PipeNull();

            // Si la imagen tiene cara ira al pipeSerial4.
            PipeSerial pipeSerial4 = new PipeSerial(filterTwitter, pipeNull);

            // Si la imagen NO tiene cara ira al pipeSerial3.
            PipeSerial pipeSerial3 = new PipeSerial(filterNegative, pipeNull);

            PipeConditional pipeConditional = new PipeConditional(filterConditional, pipeSerial4,pipeSerial3);

            PipeSerial pipeSerial2 = new PipeSerial(persistImage, pipeConditional);
            // PipeSerial pipeSerial1 = new PipeSerial(filterGrey, pipeSerial2);


            picture = pipeSerial2.Send(picture);


            // Guardar la imagen
            provider.SavePicture(picture, @"beer2.jpg");


            Console.WriteLine("Proceso Finalizado.");


            // ! Ejercicio 3   ---------------------------------------
            /*
            PictureProvider provider = new PictureProvider();

            // Obtener los valores de la imagen
            IPicture picture = provider.GetPicture(@"beer.jpg");

            // Se declaran los filtros que se van a utilizar.
            FilterGreyscale filterGrey = new FilterGreyscale();
            FilterNegative filterNegative = new FilterNegative();
            FilterPersistImage persistImage = new FilterPersistImage();
            FilterTwitterAPI  filterTwitter = new FilterTwitterAPI();



            PipeNull pipeNull = new PipeNull();

            PipeSerial pipeSerial4 = new PipeSerial(filterNegative, pipeNull);
            PipeSerial pipeSerial3 = new PipeSerial(filterTwitter, pipeSerial4);
            PipeSerial pipeSerial2 = new PipeSerial(persistImage, pipeSerial3);
            PipeSerial pipeSerial1 = new PipeSerial(filterGrey, pipeSerial2);


            picture = pipeSerial1.Send(picture);


            // Guardar la imagen
            provider.SavePicture(picture, @"beer2.jpg");


            Console.WriteLine("Proceso Finalizado.");
            */


            // ! Ejercicio 2   ---------------------------------------
            /*
            PictureProvider provider = new PictureProvider();

            // Obtener los valores de la imagen
            IPicture picture = provider.GetPicture(@"beer.jpg");

            // Se declaran los filtros que se van a utilizar.
            FilterGreyscale filterGrey = new FilterGreyscale();
            FilterNegative filterNegative = new FilterNegative();
            FilterPersistImage persistImage = new FilterPersistImage();



            PipeNull pipeNull = new PipeNull();

            PipeSerial pipeSerial3 = new PipeSerial(filterNegative, pipeNull);
            PipeSerial pipeSerial2 = new PipeSerial(persistImage, pipeSerial3);
            PipeSerial pipeSerial1 = new PipeSerial(filterGrey, pipeSerial2);


            picture = pipeSerial1.Send(picture);


            // Guardar la imagen
            provider.SavePicture(picture, @"beer2.jpg");


            Console.WriteLine("Proceso Finalizado.");
            */


            // ! Ejercicio 1   ---------------------------------------
            /*
            PictureProvider provider = new PictureProvider();

            // Obtener los valores de la imagen
            IPicture picture = provider.GetPicture(@"beer.jpg");

            // Se declaran los filtros que se van a utilizar.
            FilterGreyscale filterGrey = new FilterGreyscale();
            FilterNegative filterNegative = new FilterNegative();


            PipeNull pipeNull = new PipeNull();
            PipeSerial pipeSerial2 = new PipeSerial(filterNegative, pipeNull);
            PipeSerial pipeSerial1 = new PipeSerial(filterGrey, pipeSerial2);

            
            picture = pipeSerial1.Send(picture);

            // Guardar la imagen
            provider.SavePicture(picture, @"beer2.jpg");


            Console.WriteLine("Proceso Finalizado.");
            */
        }
    }
}
