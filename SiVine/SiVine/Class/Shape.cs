using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using System.Drawing;
using Emgu.CV.Structure;

namespace SiVine.Class
{
    class Shape
    {
        
        public Rectangle shape;
        public Bgr color;
        public int thickness;

        /// <summary>
        /// Constructor de figura
        /// </summary>
        /// <param name="_shape">Figura (Rectangulo) que se enmarca en la detección</param>
        /// <param name="_color">Color de la figura</param>
        /// <param name="_thick">Espesor de la figura</param>
        public Shape(Rectangle _shape, Bgr _color, int _thick)
        {
            shape = _shape;
            color = _color;
            thickness = _thick;
        }
    }
}
