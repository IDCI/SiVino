using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Face;
using Emgu.CV.Features2D;
using SiVine.Class;
using System.IO;

namespace SiVine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Global variables
        private Capture capture;  
        private bool stateCamera;
        private CascadeClassifier classifierFaces;
        private CascadeClassifier classifierEyes;
        #endregion

        #region Events
        
        private void Form1_Load(object sender, EventArgs e)
        {
            if (capture == null)
            {
                try
                {
                    capture = new Capture(); //Inicializacion de Emgu.CV.Caputure
                }
                catch (NullReferenceException excpt)
                {
                    MessageBox.Show(excpt.Message);
                }
            }

            if (capture != null)
            {
                validateStream();//Iniciando captura de video stream

            }
        }
        private void ProcessFrame(object sender, EventArgs arg)
        {
            Mat mat = capture.QueryFrame(); //Almacena el frame de la captura actual
            Image<Bgr, Byte> ImageFrame = mat.ToImage<Bgr, Byte>(); //Convierte el frame actual a una imagen de estructura(Bgr,byte)

            foreach (Face f in detectedFaces()) //Recorre la lista de rostros detectados
            {
                ImageFrame.Draw(f.face.shape, f.face.color, f.face.thickness);//Dibuja un shape(figura), en el frame actual que identifica el rostro de la persona
                foreach (Shape feature in f.features)//Recorre la lista de caracteristicas de ese rostro
                {
                    ImageFrame.Draw(feature.shape, feature.color, feature.thickness);//Dibuja un shape(figura), en el frame actual que identifica las caracteristicas de la persona
                }
            }

            CamImageBox.Image = ImageFrame;//Carga el frame al picturebox
        }

        private void btn_takePicture_Click(object sender, EventArgs e)
        {
            imageCapturate.Image = capture.QueryFrame();//Asigna el frame actual del video stream al picture box 
        }
        private void btn_stream_Click(object sender, EventArgs e)
        {
            validateStream();//Iniciando captura de video stream
        }
        #endregion
        #region Methods
        /// <summary>
        /// Metodo para inicializar captura de video
        /// </summary>
        private void validateStream()
        {
            //stateCamera = El estado actual de la captura; 
            //-> true=La camara esta capturando
            //-> false=La camara esta detenida
            if (stateCamera)
            {
                btn_stream.Text = "Iniciar video stream";
                Application.Idle -= ProcessFrame; //Detiene el procesamiento de imagen
            }
            else
            {
                btn_stream.Text = "Detener video stream";
                Application.Idle += ProcessFrame; //Inicia el procesamiento de imagen
            }
            stateCamera = !stateCamera; //Cambia el estado de la camara
        }
        /// <summary>
        /// Metodo para detectar rostros
        /// </summary>
        /// <returns>Lista de rostros</returns>
        private List<Face> detectedFaces()
        {
            List<Face> faces = new List<Face>(); //Inicializando la lista de human
            classifierFaces = new CascadeClassifier(Application.StartupPath + "/Detection/XML/haarcascade_frontalface_default.xml"); //Inicializa una clasificacion en cascada para deteccion de rostro, con la estructura del archivo xml que proporciona opencv http://www.emgu.com/wiki/files/3.1.0/document/html/b5ce78f6-d5cc-a099-d1a8-25df92564f64.htm
            classifierEyes = new CascadeClassifier(Application.StartupPath + "/Detection/XML/haarcascade_eye.xml"); //Inicializa una clasificacion en cascada para deteccion de ojos y caracteristicas, con la estructura del archivo xml que proporciona opencv http://www.emgu.com/wiki/files/3.1.0/document/html/b5ce78f6-d5cc-a099-d1a8-25df92564f64.htm


            using (var imageFrame = capture.QueryFrame().ToImage<Bgr, Byte>()) // imageframe=Imagen Emgu con estructura (Bgr,byte)
            {
                if (imageFrame != null)
                {
                    var grayframe = imageFrame.Convert<Gray, byte>(); //Convierte imageFrame a escala de gris
                    var _faces = classifierFaces.DetectMultiScale(grayframe, 1.1, 10, Size.Empty); //Usamos la instancia de la clasificacion en cascada de rostros, para analizar la imagen en escala de gris, retorna una lista de rectangulos
                    var _features = classifierEyes.DetectMultiScale(grayframe, 1.1, 10, Size.Empty);//Usamos la instancia de la clasificacion en cascada de ojos, para analizar la imagen en escala de gris, retorna una lista de rectangulos

                    foreach (var _face in _faces)//Recorre la lista de rostros(Rectangulos), para cargar la lista que va a retornar
                    {
                        Shape face = new Shape(_face, new Bgr(Color.Green), 1);//Crea un objeto Shape(figura) para cada rostro en la lista 
                        List<Shape> features = new List<Shape>(); //Crea una lista de caracteristicas para cada rostro en la lista
                        foreach (var _feature in _features)//Recorre la lista de caracteristicas(Rectangulos), para cargar la lista al rostro
                        {
                            Shape feature = new Shape(_feature, new Bgr(Color.Green), 1);//Crea un objeto Shape(figura) para cada rostro en la lista 
                            features.Add(feature);//Agrega la caracteristica, a la lista de caracteristicas del rostro
                        }
                        Face faceDetected = new Face(face, features); //Crea un rostro
                        faces.Add(faceDetected);//Agrega el rostro creado, a la lista que va a retornar
                    }
                }
            }
            return faces;//Retorna la lista de rostros cargados con su rostro y sus caracteristicas
        }
        #endregion









        



    }
}
