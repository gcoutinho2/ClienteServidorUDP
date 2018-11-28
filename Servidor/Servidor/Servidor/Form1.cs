using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servidor
{
    public partial class Form1 : Form
    {
        private LibUDP.UDPSocket socket;
        public Form1()
        {
            InitializeComponent();

            socket = new LibUDP.UDPSocket(MensagemRecebida, 6001);
        }

        private void MensagemRecebida(byte[] buffer, int size, string ip, int port)
        {
            int media = 0;
            for (int i = 0; i < 10; i++)
            {
                media = media + buffer[i];
            }
            media = media / 10;

            byte[] bytes = new byte[10];
            for (int i = 0; i < 10; i++)
            {
                if (buffer[i] < media)
                {
                    bytes[i] = 0;
                }
                else
                {
                    bytes[i] = buffer[i];
                }
            }

            socket.Send(bytes, ip, 6000);
        }
    }
}
