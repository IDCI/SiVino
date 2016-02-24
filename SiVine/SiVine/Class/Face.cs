using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiVine.Class
{
    class Face
    {
        /// <summary>
        /// Face , almacena la figura(detección) del rostro de una persona
        /// Features, almacena una lista de figuras(detección) de las caracteristicas basicas del rostro de una persona (ojos,barbilla)
        /// </summary>
        public Shape face;
        public List<Shape> features;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_face">Figura(detección) del rostro</param>
        /// <param name="_features">Lista de figras(detección) de las caracteristicas del rostro</param>
        public Face(Shape _face, List<Shape> _features) {
            face = _face;
            features = _features;
        }
    }
}
