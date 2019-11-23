using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algoritmo_genettico
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

        private void buttonGerar_Click(object sender, EventArgs e)
        {
            Populacao Pop = new Populacao();
            Pop.NumPop = int.Parse(txtNumPop.Text);
            Pop.MaxGeracoes = int.Parse(txtMaxGer.Text);

            Individuo[] IndiInicial = new Individuo[Pop.NumPop];
            Individuo[] IndiIntermediario = new Individuo[2];
            Individuo[] IndiFinal= new Individuo[Pop.NumPop];
            int t = 0;
            int j = 0;

            Pop.InicializaPopulacao(Pop.NumPop, IndiInicial);
            Pop.AvaliaIndividuo(Pop.NumPop, IndiInicial);
            while (j < Pop.MaxGeracoes)
            {
               
                while (t < Pop.NumPop)
                {
                    IndiIntermediario[0].genes = Pop.Selecao(Pop.NumPop, IndiInicial);
                    IndiIntermediario[1].genes = Pop.Selecao(Pop.NumPop, IndiInicial);
                    IndiFinal[t].genes = Pop.CrossoverIndividuo(IndiIntermediario[0], IndiIntermediario[1]);
                    IndiFinal[t].genes = Pop.MutacaoIndividuo(IndiFinal[t]);
                    t = t + 1;
                }
                Pop.AvaliaIndividuo(Pop.NumPop, IndiFinal);





            }

            



        }
    }
}
