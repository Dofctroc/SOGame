using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteC__Juego
{
    public partial class Form1 : Form
    {
        Socket server;
        Thread atender;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AtenderServidor()
        {
            while (true)
            {
                //Recibimos el mensaje del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                string[] mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0].Split('/');
                int codigo = Convert.ToInt32(mensaje[0]);

                switch (codigo)
                {
                    case 1:
                        MessageBox.Show("La longitud de tu nombre es: " + mensaje[1]);
                        break;
                    case 2:
                        if (mensaje[1] == "SI")
                            MessageBox.Show("Tu nombre ES bonito.");
                        else
                            MessageBox.Show("Tu nombre NO es bonito. Lo siento.");
                        break;
                    case 3:
                        MessageBox.Show(mensaje[1]);
                        break;
                    case 4:
                        label_cuantosServicios.Text = "Numero servicios: \n" + mensaje[1];
                        break;
                }
            }
        }

        private void button_Conectar_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, 9040);


            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.Green;
                MessageBox.Show("Conectado");

            }
            catch (SocketException ex)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }

            ThreadStart ts = delegate { AtenderServidor(); };
            atender = new Thread(ts);
            atender.Start();
        }

        private void button_Desconectar_Click(object sender, EventArgs e)
        {
            //Mensaje de desconexión
            string mensaje = "0/";

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // Nos desconectamos
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();
            atender.Abort();
        }

        private void button_enviar_Click(object sender, EventArgs e)
        {
            if (command_longitud.Checked)
            {
                string mensaje = "1/" + textbox_nombre.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else if (command_bonito.Checked)
            {
                string mensaje = "2/" + textbox_nombre.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            else
            {
                // Enviamos nombre y altura
                string mensaje = "3/" + textbox_nombre.Text + "/" + textbox_altura.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
        }
    }
}
