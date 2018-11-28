using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExUDP
{
    public partial class Form1 : Form
    {
        private LibUDP.UDPSocket socket;


        public Form1()
        {
            InitializeComponent();

            socket = new LibUDP.UDPSocket(MensagemRecebida, 6000);

        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {

            string ip = txtIp.Text;
            byte[] bytes = new byte[10];

            bytes[0] = byte.Parse(txt1.Text);
            bytes[1] = byte.Parse(txt1.Text);
            bytes[2] = byte.Parse(txt1.Text);
            bytes[3] = byte.Parse(txt1.Text);
            bytes[4] = byte.Parse(txt1.Text);
            bytes[5] = byte.Parse(txt1.Text);
            bytes[6] = byte.Parse(txt1.Text);
            bytes[7] = byte.Parse(txt1.Text);
            bytes[8] = byte.Parse(txt1.Text);
            bytes[9] = byte.Parse(txt1.Text);



            socket.Send(bytes, ip, 6001);
        }

        private void MensagemRecebida(byte[] buffer, int size, string ip, int port)
        {
            txt1.Text = buffer[0].ToString();
            txt2.Text = buffer[1].ToString();
            txt3.Text = buffer[2].ToString();
            txt4.Text = buffer[3].ToString();
            txt5.Text = buffer[4].ToString();
            txt6.Text = buffer[5].ToString();
            txt7.Text = buffer[6].ToString();
            txt8.Text = buffer[7].ToString();
            txt9.Text = buffer[8].ToString();
            txt10.Text = buffer[9].ToString();



        }
    }
}
