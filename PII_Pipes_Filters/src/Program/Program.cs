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
            picture = pipeSerial2.Send(picture);

            // Guardar la imagen
            provider.SavePicture(picture, @"beer2.jpg");


            Console.WriteLine("Proceso Finalizado.");
            */
        }
    }
}
