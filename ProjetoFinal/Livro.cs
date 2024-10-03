using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal
{
    class Livro : Heranca
    {
        public List<string> listaDeAutores;
        public int ano;
        public int tempoMaximoReserva = 7;
        public int penalidadeEmCasoDeAtraso;
        public bool estaEmprestado = false;
        public bool estaReservado = false;
        public DateTime dataDevolucao;
        public DateTime dataEmprestimo;

        public Livro(int id, string nome, List<string> listaDeAutores, int ano, int penalidadeEmCasoDeAtraso)
        {
            this.id = id;
            this.nome = nome;
            this.listaDeAutores = listaDeAutores;
            this.ano = ano;
            this.penalidadeEmCasoDeAtraso = penalidadeEmCasoDeAtraso;
        }

        public string penalidade()
        {
            string penalidade;

            if (penalidadeEmCasoDeAtraso == 1)
            {
                penalidade = "Ligeira";
            }
            else if (penalidadeEmCasoDeAtraso == 2)
            {
                penalidade = "Média";
            }
            else
            {
                penalidade = "Grave";
            }

            return penalidade;
        }

        
        public string informacaoLivro(bool comNome)
        {
            string retorno = $"\n\t\tId: {id};\n\t\tAutor(es): {string.Join(", ", listaDeAutores)};\n\t\tAno {ano};\n\t\tTempo máximo de reserva {tempoMaximoReserva} dias;\n\t\tPenalidade em caso de atraso {penalidade()};\n";

            if (comNome)
            {
                retorno = $"\n\t\tNome: {nome}; " + retorno;
            }
            

            return retorno;
        }

    }
}
