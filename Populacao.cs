using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmo_genettico
{
    class Populacao
    {
        public int NumPop;
        public int MaxGeracoes;
        public string TipoMutacao;
        public string TipoCrossover;

        int i;
        Random rdn = new Random();

        public void InicializaPopulacao(int N, Individuo[] individuo)
        {
            for (i = 0; i < N; i++)
            {
                individuo[N].genes = rdn.Next(0, 1000);
            }

        }


        public void AvaliaIndividuo(int N, Individuo[] individuo)
        {
            int[] x = new int[N];
            for (i = 0; i < N; i++) {
                x[i] = -1 + (3 * individuo[i].genes / 1000);
            }

            for (i = 0; i < N; i++)
            {
                individuo[i].aptidao = x[i] * Math.Sin(10 * Math.PI * x[i]) + 1; 
            }

        }
        public int Selecao (int N, Individuo[] individuo )
        {
            double soma = 0;
            double rand = 0;
            double aleatorio = rdn.NextDouble();
            double total_parcial=0;
            int t=0;
            for (i = 0; i < N; i++)
            {
                soma = individuo[i].aptidao + soma;
            }

            rand =  ( aleatorio  * soma );
            for (i = 0; i < N; i++)
            {
                total_parcial = total_parcial + individuo[i].aptidao;
                if(total_parcial >= rand)
                {
                    break;
                    
                }
                t = t + 1;
            }
            return individuo[t].genes;
        }

        public int CrossoverIndividuo(Individuo individuo1, Individuo individuo2)
        {
            return (individuo1.genes + individuo2.genes) / 2 ;
        }

        public int MutacaoIndividuo (Individuo individuo)
        {
            double rand = rdn.NextDouble();
            if(rand> 0.001 || rand < 0.05)
            {
                return individuo.genes = rdn.Next(0, 1000);
            }
            return individuo.genes;
        }


    }

}

