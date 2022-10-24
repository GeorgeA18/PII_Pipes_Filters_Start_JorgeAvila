using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;
using CompAndDel.Filters;

namespace CompAndDel.Pipes
{
    public class PipeConditional : IPipe
    {
        protected FilterConditional filtro;
        protected IPipe nextPipe1;
        protected IPipe nextPipe2;
        
        /// <summary>
        /// La cañería recibe una imagen, le aplica un filtro y la envía a la siguiente cañería
        /// </summary>
        /// <param name="filtro">Filtro que se debe aplicar sobre la imagen</param>
        /// <param name="nextPipe">Siguiente cañería</param>
        public PipeConditional(FilterConditional filtro, IPipe nextPipe1,IPipe nextPipe2)
        {
            this.nextPipe1 = nextPipe1;
            this.nextPipe2 = nextPipe2;
            this.filtro = filtro;
        }
        /// <summary>
        /// Devuelve el proximo IPipe1
        /// </summary>
        public IPipe Next1
        {
            get { return this.nextPipe1; }
        }
        /// <summary>
        /// Devuelve el proximo IPipe2
        /// </summary>
        public IPipe Next2
        {
            get { return this.nextPipe2; }
        }
        /// <summary>
        /// Devuelve el IFilter que aplica este pipe
        /// </summary>
        public IFilter Filter
        {
            get { return this.filtro; }
        }
        /// <summary>
        /// Recibe una imagen, le aplica un filtro y la envía al siguiente Pipe
        /// </summary>
        /// <param name="picture">Imagen a la cual se debe aplicar el filtro</param>
        public IPicture Send(IPicture picture)
        {
            picture = this.filtro.Filter(picture);
            if (this.filtro.FaceFound)
            {

                return this.nextPipe1.Send(picture);
            }
            else
            {
                return this.nextPipe2.Send(picture);

            }
        }
    }
}
