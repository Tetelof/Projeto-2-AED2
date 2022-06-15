using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_2_AED2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }


        private async Task<bool> checkDicionario(string palavra)
        {
            var linhas = File.ReadAllLines("../../../dicionario.txt", Encoding.GetEncoding("ISO-8859-1"));
            foreach (var linha in linhas)
            {
                foreach(var item in linha.Split(","))
                {
                    if (palavra == item)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void adcionaDicionario(string palavra)
        {
            var linhas = File.ReadAllLines("../../../dicionario.txt", Encoding.GetEncoding("ISO-8859-1"));
            linhas[linhas.Length - 1] += palavra + ",";
            File.WriteAllLines("../../../dicionario.txt", linhas, Encoding.GetEncoding("ISO-8859-1"));
        }

        private async void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                var txt = richTextBox1.Text.Split(" ");
                var palavra = txt[txt.Length - 1];

                if (!await checkDicionario(palavra))
                {
                    this.richTextBox1.SelectionStart = this.richTextBox1.Text.Length - palavra.Length;
                    this.richTextBox1.SelectionLength = palavra.Length;
                    richTextBox1.Text = (richTextBox1.SelectedText.ToUpper());
                    //this.richTextBox1.SelectionStart = 0;
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var text = this.richTextBox1.Text;
            var palavras = text.Split(" ");
            foreach(var palavra in palavras)
            {
                if (!await checkDicionario(palavra))
                {
                    adcionaDicionario(palavra);
                }
            }
        }
    }
}
