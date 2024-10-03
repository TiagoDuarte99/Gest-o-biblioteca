using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal
{
    internal class Utilizador:Heranca
    {
        public string email;
        public string senha;
        public List<Livro> listaLivrosEmprestados = new List<Livro>();
        public List<Livro> listaLivrosReservados = new List<Livro>();        
        public bool premium = false;
        public int penalidade = 0;


        public Utilizador(int id, string nome, string senha, string email, bool premium)
        {
            this.id = id;
            this.nome = nome;
            this.senha = senha;
            this.email = email;
            this.premium = premium;
        }

        public string informacaoUtilizador()
        {
            string retorno = $"\n\t\tUtilizador\n\t\tNome: {nome}\n\t\tID: {id}\n\t\tEmail: {email}\n\t\tPenalidade: {penalidade}\n\t\tTipo: {tipo()}\n\n\n";

            if(penalidade > 5)
            {
                retorno += "\n\t\tO utilizador atingiu o máximo de penalidades e ficou impossibilitado de reservar um livro!!!\n\n\n";
            }

            retorno += informacaoLivrosEmprestados();
            retorno += informacaoLivrosReservados();

            return retorno;
        }
        private string informacaoLivrosEmprestados()
        {
            string retorno;

            if(listaLivrosEmprestados.Count > 0)
            {
                retorno = "\n\t\tLivros Emprestados\n\n";
                foreach (Livro livro in listaLivrosEmprestados)
                {
                    retorno = retorno + $"\n\t\t{livro.nome}; Data de empréstimo: {livro.dataEmprestimo}; Data para devolução: {livro.dataDevolucao}; {livro.informacaoLivro(false)}\n";
                }
            }
            else
            {
                retorno = "\n\t\tO utilizador não tem livros emprestados.\n";
            }
            
            

            return retorno;
        }
        private string informacaoLivrosReservados()
        {
            string retorno;
            if (listaLivrosReservados.Count > 0)
            {
                retorno = "\n\t\tLivros Reservados\n\n";

                foreach (Livro livro in listaLivrosReservados)
                {
                    retorno += $"\n\t\t{livro.informacaoLivro(true)}\n";
                }
            }
            else
            {
                retorno = "\n\t\tO utilizador não tem livros reservados.\n";
            }

            return retorno;
        }

        public string tipo()
        {
            return premium  ? "Premium" : "Normal";
             
        }
    }


}
