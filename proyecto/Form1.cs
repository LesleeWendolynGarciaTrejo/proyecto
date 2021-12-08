using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto
{
    public partial class Form1 : Form
    {
        Stack<int> cartas = new Stack<int>();
        Random rnd = new Random();
        int i = 0;
        const int CANTIDAD_CARTAS = 54;
        //private PictureBox[] cartas;
        private PictureBox[] tabla;
        public Form1()
        {
            InitializeComponent();
            //cartas = new PictureBox[CANTIDAD_CARTAS];
            tabla = new PictureBox[25];
            inicializarTabla();
        }

        private void inicializarTabla()
        {
            int r = 0, c = 0;

            int[] cartas = new int[34];


            for (int i = 0; i < cartas.Length; i++)
            {
                cartas[i] = i + 1;
            }
            // Recorrer el arreglo para SWAP - Triangular INTERCAMBIAR un elemento con otro al azar
            Random rnd = new Random();
            int a, aux;
            for (int i = 0; i < cartas.Length; i++)
            {
                a = rnd.Next(cartas.Length);
                aux = cartas[i];
                cartas[i] = cartas[a];
                cartas[a] = aux;
            }
            for (int i = 0; i < tabla.Length; i++)
            {
                tabla[i] = new PictureBox();
                tabla[i].Location = new System.Drawing.Point(100 + (c * 90), 25 + (r * 125));
                tabla[i].Name = "picTabla" + i;
                tabla[i].Size = new System.Drawing.Size(85, 120);
                tabla[i].TabIndex = 0 + i;
                tabla[i].SizeMode = PictureBoxSizeMode.StretchImage;
                tabla[i].TabStop = false;
                tabla[i].Image = Image.FromFile(@"C:\Users\w10\Desktop\Wendo1\Programacion\plotmex\plotmex\bin\Debug\Cartas\" + (cartas[i]) + ".jpg");
                this.Controls.Add(tabla[i]);
                c++;
                if (c == 5)
                {
                    r++;
                    c = 0;
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.listView1.View = View.LargeIcon;
            this.imageList1.ImageSize = new Size(150, 220);
            this.listView1.LargeImageList = this.imageList1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = (54 - cartas.Count()).ToString();
            bool bandera = false;
            if (cartas.Count() == 54) {
                bandera = true;
                MessageBox.Show("Son todas las cartas", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            while (!bandera) {
                int num = rnd.Next(1, 54);
                if (!cartas.Contains(num)) {
                    pbcarta.Image = Image.FromFile(@"C:\Users\w10\Desktop\Wendo1\Programacion\plotmex\plotmex\bin\Debug\Cartas\" + num+".jpg");
                    pbcarta.SizeMode = PictureBoxSizeMode.StretchImage;
                    cartas.Push(num);
                    this.imageList1.Images.Add(Image.FromFile(@"C:\Users\w10\Desktop\Wendo1\Programacion\plotmex\plotmex\bin\Debug\Cartas\" + num + ".jpg"));
                    ListViewItem item = new ListViewItem();
                    item.ImageIndex = 1;
                    this.listView1.Items.Add(item);
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\w10\Desktop\Wendo1\Programacion\plotmex\plotmex\bin\Debug\sonido\"+num+".wav");
                    player.Play();
                    bandera = true;
                    i++;
                }
            
            }
        }


      

        private void button3_Click_1(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\w10\Desktop\Wendo1\Programacion\plotmex\plotmex\bin\Debug\buenas.wav");
            player.Play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cartas.Clear();
            imageList1.Images.Clear();
            listView1.Items.Clear();
            pbcarta.Image = null;
            i = 0;
            label1.Text = "";
        }
    }
}
