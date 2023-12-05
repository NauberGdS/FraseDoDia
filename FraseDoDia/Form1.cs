using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FraseDoDia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFrase_Click(object sender, EventArgs e)
        {
            string link = "https://apisenac.estevaorada.repl.co/api/frase";
            // Instanciar o "navegador" para acessar a internet
            WebClient navegador = new WebClient();  

            // Acessar o link
            string r = navegador.DownloadString(link);

            // Corrigir as letrinhas feias bugadas horrorosas // co
            r = Encoding.UTF8.GetString(Encoding.Default.GetBytes(r));


            // Documemtação do site JSON, tranformar em objeto
            FraseDiaria frase = JsonConvert.DeserializeObject<FraseDiaria>(r); 

            // Exibir no forms
            lblFrase.Text = frase.Frase;
            lblAutor.Text = frase.Autor;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //simular click inicial no GERAR FRASE
            btnFrase.PerformClick();
        }
    }
}
