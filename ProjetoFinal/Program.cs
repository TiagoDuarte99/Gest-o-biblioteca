using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;


namespace ProjetoFinal
{
    class Program
    {
        static int countLivros = 0;
        static int countUtilizadores = 0;
        static List<Livro> listaLivros = new List<Livro>();
        static List<Utilizador> listaUtilizadores = new List<Utilizador>();
        static void Main(string[] args)
        {
            int option = 100;
            var tentaNovamente = true;
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n\n\t\t\t\t\t\t==== Menu Principal ====\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t1 - Menu Livros\n");
                Console.WriteLine("\t\t2 - Menu Utilizadores\n");
                Console.WriteLine("\t\t3 - Menu Reservas/Empréstimos/Devoluções\n");
                Console.WriteLine("\t\t0 - Sair do programa\n");
                try
                {
                    Console.Write("\t\t");
                    option = int.Parse(Console.ReadLine());
                    tentaNovamente = false;

                    switch (option)
                    {
                        case 0: break;
                        case 1:
                            menuLivros();
                            break;
                        case 2:
                            menuUtilizadores();
                            break;
                        case 3:
                            menuReservasEmprestimosDevolucoes();
                            break;
                        default:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\t\tOpçao Inválida");
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\t\tOpçao Inválida, insira um numero inteiro.");
                }

                Console.ResetColor();
            } while (option != 0 || tentaNovamente == true);
        }


        private static void menuLivros()
        {
            int option = 100;
            var tentaNovamente = true;
            Console.Clear();
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n\n\t\t\t\t\t\t==== Menu Livros ====\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t1 - Inserir Livro\n");
                Console.WriteLine("\t\t2 - Listar Livros\n");
                Console.WriteLine("\t\t3 - Procurar Livro por id\n");
                Console.WriteLine("\t\t4 - Apagar Livro por id\n");
                Console.WriteLine("\t\t5 - Editar Livro\n");
                Console.WriteLine("\t\t0 - Voltar atrás\n");

                try
                {
                    Console.Write("\t\t");
                    option = int.Parse(Console.ReadLine());
                    tentaNovamente = false;
                    Console.Clear();
                    switch (option)
                    {
                        case 0:
                            break;

                        case 1:
                            inserirLivro();
                            pressionarEnterParaContinuar();
                            Console.Clear();
                            break;

                        case 2:
                            listarLivros();
                            pressionarEnterParaContinuar();
                            Console.Clear();
                            break;

                        case 3:
                            procurarLivro();
                            pressionarEnterParaContinuar();
                            Console.Clear();
                            break;

                        case 4:
                            apagarLivro();
                            pressionarEnterParaContinuar();
                            Console.Clear();
                            break;

                        case 5:
                            editarLivro();
                            pressionarEnterParaContinuar();
                            Console.Clear();
                            break;

                        default:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\t\tOpçao Inválida");
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\t\tOpçao Inválida, insira um numero inteiro.");
                }

                Console.ResetColor();
            } while (option != 0 || tentaNovamente == true);
        }

        private static void inserirLivro()
        {

            Console.WriteLine("\n\t\tTempo máximo de reserva de livros: 7 dias!!!");

            int id = ++countLivros;


            string nome = inputLivroNome();

            List<string> listaDeAutores = inputLivroAutores();

            int ano = inputLivroAno();

            int penalidadeEmCasoDeAtraso = inputLivroPenalidadeAtraso();

            Livro livro = new Livro(id, nome, listaDeAutores, ano, penalidadeEmCasoDeAtraso);
            listaLivros.Add(livro);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n\t\tLivro inserido com sucesso.");
            Console.ResetColor();
        }

        private static void listarLivros()
        {

            if (listaLivros.Count > 0)
            {
                foreach (Livro livro in listaLivros)
                {
                    Console.WriteLine(livro.informacaoLivro(true));
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\tNão existem livros.");
                Console.ResetColor();
            }
        }

        private static void procurarLivro()
        {
            int idLivro = inputLivroId();
            int index = listaLivros.FindIndex(livro => livro.id == idLivro);

            if (index != -1)
            {
                Livro livroEncontrado = listaLivros[index];
                Console.WriteLine(livroEncontrado.informacaoLivro(true));

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\tLivro não encontrado.");
                Console.ResetColor();
            }
        }

        public static void apagarLivro()
        {
            int idLivro = inputLivroId();
            int index = listaLivros.FindIndex(livro => livro.id == idLivro);

            if (index != -1)
            {
                listaLivros.RemoveAt(index);

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n\t\tLivro apagado com sucesso.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\tLivro não encontrado.");
                Console.ResetColor();
            }
        }

        private static void editarLivro()
        {
            int idLivro = inputLivroId();
            int index = listaLivros.FindIndex(livro => livro.id == idLivro);
            if (index != -1)
            {
                Console.WriteLine($"\n\t\tNome: {listaLivros[index].nome}");
                if (perguntar("\n\t\tDeseja alterar o nome atual?"))
                {
                    listaLivros[index].nome = inputLivroNome();
                }

                Console.WriteLine("\n\t\tAutor/es: ");
                foreach (string autor in listaLivros[index].listaDeAutores)
                {
                    Console.WriteLine($"\t\t- {autor}");
                }
                if (perguntar("\t\tDeseja alterar os autores?"))
                {
                    listaLivros[index].listaDeAutores = inputLivroAutores();
                }

                Console.WriteLine($"\n\t\tAno: {listaLivros[index].ano}");
                if (perguntar("\n\t\tDeseja alterar o ano?\n"))
                {
                    listaLivros[index].ano = inputLivroAno();
                }

                Console.WriteLine($"\n\t\tPenalidade em caso de atraso: {listaLivros[index].penalidadeEmCasoDeAtraso} - {listaLivros[index].penalidade()}");
                if (perguntar("\n\t\tDeseja alterar a penalidade em caso de atraso?"))
                {
                    listaLivros[index].penalidadeEmCasoDeAtraso = inputLivroPenalidadeAtraso();
                }

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n\t\tLivro editado com sucesso.");
                Console.ResetColor();

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\tLivro não encontrado.");
                Console.ResetColor();
            }
        }


        private static void menuUtilizadores()
        {
            int option = 100;
            Console.Clear();
            var tentaNovamente = true;
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n\n\t\t\t\t\t\t==== Menu Utilizador ====\n");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t1 - Inserir Utilizador\n");
                Console.WriteLine("\t\t2 - Listar Utilizadores\n");
                Console.WriteLine("\t\t3 - Procurar Utilizador por id\n");
                Console.WriteLine("\t\t4 - Apagar Utilizador por id\n");
                Console.WriteLine("\t\t5 - Editar Utilizador por id\n");
                Console.WriteLine("\t\t0 - Voltar atrás\n");

                try
                {
                    Console.Write("\t\t");
                    option = int.Parse(Console.ReadLine());
                    tentaNovamente = false;
                    Console.Clear();
                    switch (option)
                    {
                        case 0:
                            break;

                        case 1:
                            inserirUtilizador();
                            pressionarEnterParaContinuar();
                            Console.Clear();
                            break;

                        case 2:
                            listarUtilizadores();
                            pressionarEnterParaContinuar();
                            Console.Clear();
                            break;

                        case 3:
                            procurarUtilizador();
                            pressionarEnterParaContinuar();
                            Console.Clear();
                            break;

                        case 4:
                            apagarUtilizador();
                            pressionarEnterParaContinuar();
                            Console.Clear();
                            break;

                        case 5:
                            editarUtilizador();
                            pressionarEnterParaContinuar();
                            Console.Clear();
                            break;

                        default:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\t\tOpçao Inválida");
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\t\tOpçao Inválida, insira um numero inteiro.");
                }

                Console.ResetColor();
            } while (option != 0 || tentaNovamente == true);
        }
        private static void inserirUtilizador()
        {
            int id = ++countUtilizadores;

            string nome = inputUtilizadorNome();

            string senha = inputUtilizadorSenha();

            string email = inputUtilizadorEmail();

            bool premium = inputUtilizadorTipo();

            Utilizador utilizador = new Utilizador(id, nome, senha, email, premium);
            listaUtilizadores.Add(utilizador);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n\t\tUtilizador inserido com sucesso.");
            Console.ResetColor();
        }
        private static void listarUtilizadores()
        {
            if (listaUtilizadores.Count > 0)
            {
                Console.WriteLine("\n\t\tUtilizadores registados: \n");
                foreach (Utilizador utilizador in listaUtilizadores)
                {
                    Console.WriteLine(utilizador.informacaoUtilizador());
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\tNão existem utilizadores.");
                Console.ResetColor();
            }
        }
        private static void procurarUtilizador()
        {
            int idUtilizador = inputUtilizadorId();
            int index = listaUtilizadores.FindIndex(utilizador => utilizador.id == idUtilizador);
            if (index != -1)
            {
                var utilizadorEncontrado = listaUtilizadores[index];
                Console.WriteLine(utilizadorEncontrado.informacaoUtilizador());
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\tUtilizador não encontrado.");
                Console.ResetColor();
            }

        }
        public static void apagarUtilizador()
        {
            int idUtilizador = inputUtilizadorId();
            int index = listaUtilizadores.FindIndex(utilizador => utilizador.id == idUtilizador);
            if (index != -1)
            {
                listaUtilizadores.RemoveAt(index);

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n\t\tUtilizador removido com sucesso.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\tUtilizador não encontrado.");
                Console.ResetColor();
            }
        }
        private static void editarUtilizador()
        {
            int idUtilizador = inputUtilizadorId();
            int index = listaUtilizadores.FindIndex(utilizador => utilizador.id == idUtilizador);
            if (index != -1)
            {

                Console.WriteLine($"\n\t\tNome: {listaUtilizadores[index].nome}");
                if (perguntar("\n\t\tDeseja alterar o nome?"))
                {
                    listaUtilizadores[index].nome = inputUtilizadorNome();
                }

                if (perguntar("\n\t\tDeseja alterar a senha?"))
                {
                    listaUtilizadores[index].senha = inputUtilizadorSenha();
                }

                Console.WriteLine($"\n\t\tEmail: {listaUtilizadores[index].email}");
                if (perguntar("\n\t\tDeseja alterar o email?"))
                {
                    listaUtilizadores[index].email = inputUtilizadorEmail();
                }

                if (perguntar($"\n\t\tUtilizador " + listaUtilizadores[index].tipo() + ", deseja alterar?"))
                {
                    listaUtilizadores[index].premium = inputUtilizadorTipo();
                }


                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n\t\tUtilizador editado com sucesso.");
                Console.ResetColor();

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\tUtilizador não encontrado.");
                Console.ResetColor();
            }
        }


        private static void menuReservasEmprestimosDevolucoes()
        {
            int option = 0;
            Console.Clear();
            var tentaNovamente = true;
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n\n\t\t\t\t\t\t==== Menu Empréstimos/Devoluçoes/Reservas====\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t1 - Verificar se o livro está emprestado\n");
                Console.WriteLine("\t\t2 - Emprestar livro\n");
                Console.WriteLine("\t\t3 - Devolver livro\n");
                Console.WriteLine("\t\t4 - Verificar se o livro está reservado\n");
                Console.WriteLine("\t\t5 - Renovar empréstimo\n");
                Console.WriteLine("\t\t6 - Reservar Livro\n");
                Console.WriteLine("\t\t7 - Apagar reserva\n");
                Console.WriteLine("\t\t0 - Voltar atrás\n");

                try
                {
                    Console.Write("\t\t");
                    option = int.Parse(Console.ReadLine());
                    tentaNovamente = false;
                    Console.Clear();
                    switch (option)
                    {
                        case 0:
                            break;
                        case 1:
                            verificarLivroEstaEmprestado();
                            pressionarEnterParaContinuar();
                            Console.Clear();
                            break;
                        case 2:
                            emprestimoLivro();
                            pressionarEnterParaContinuar();
                            Console.Clear();
                            break;
                        case 3:
                            devolverLivro();
                            pressionarEnterParaContinuar();
                            Console.Clear();
                            break;
                        case 4:
                            verificarLivroEstaReservado();
                            pressionarEnterParaContinuar();
                            Console.Clear();
                            break;
                        case 5:
                            renovarEmprestimo();
                            pressionarEnterParaContinuar();
                            Console.Clear();
                            break;
                        case 6:
                            reservarLivro();
                            pressionarEnterParaContinuar();
                            Console.Clear();
                            break;
                        case 7:
                            apagarReserva();
                            pressionarEnterParaContinuar();
                            Console.Clear();
                            break;

                        default:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\t\tOpçao Inválida");
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\t\tOpçao Inválida, insira um numero inteiro.");
                }

                Console.ResetColor();
            } while (option != 0 || tentaNovamente == true);
        }
        private static void verificarLivroEstaEmprestado()
        {
            int idLivro = inputLivroId();
            Livro livro = listaLivros.Find(livro => livro.id == idLivro);
            if (livro != null)
            {
                Console.WriteLine(livro.estaEmprestado ? "\n\t\tLivro ja está emprestado" : "\n\t\tLivro não está emprestado");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\tLivro não encontrado.");
                Console.ResetColor();
            }

        }

        private static void emprestimoLivro()
        {
            int idLivro = inputLivroId();
            Livro livro = listaLivros.Find(livro => livro.id == idLivro);


            if (livro != null)
            {

                int idUtilizador = inputUtilizadorId();
                Utilizador utilizador = listaUtilizadores.Find(utilizador => utilizador.id == idUtilizador);

                if (!livro.estaEmprestado && !livro.estaReservado)
                {

                    if (utilizador != null)
                    {

                        if ((utilizador.premium && utilizador.listaLivrosEmprestados.Count >= 10)
                            || (!utilizador.premium && utilizador.listaLivrosEmprestados.Count >= 3))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\t\tO utilizador atingiu o máximo de livros emprestados.");
                            Console.ResetColor();
                        }
                        else
                        {
                            emprestarLivro(utilizador, livro);
                        }

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\t\tUtilizador não existe!!");
                        Console.ResetColor();
                    }
                }
                else if (livro.estaReservado)
                {
                    if (utilizador != null)
                    {

                        int index = utilizador.listaLivrosReservados.FindIndex(livro => livro.id == idLivro);

                        if (index != -1)
                        {
                            utilizador.listaLivrosReservados.RemoveAt(index);
                            emprestarLivro(utilizador, livro);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\t\tO livro já está emprestado ou reservado!!");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\t\tUtilizador não existe!!");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\t\tO livro já está emprestado ou reservado!!");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\tLivro não encontrado.");
                Console.ResetColor();
            }


        }
        private static void devolverLivro()
        {
            int idUtilizador = inputUtilizadorId();
            Utilizador utilizador = listaUtilizadores.Find(utilizador => utilizador.id == idUtilizador);

            if (utilizador != null)
            {

                int idlivro = inputLivroId();
                int index = listaLivros.FindIndex(livro => livro.id == idlivro);
                if (index != -1)
                {
                    Livro livro = listaLivros[index];

                    if (livro.estaEmprestado == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\t\tO Livro não está emprestado.");
                        Console.ResetColor();
                    }
                    else
                    {
                        DateTime dataEntrega = DateTime.Now;
                        if (dataEntrega > livro.dataDevolucao)
                        {
                            utilizador.penalidade += livro.penalidadeEmCasoDeAtraso;
                        }

                        int indexEmprestimo = utilizador.listaLivrosEmprestados.FindIndex(livro => livro.id == idlivro);
                        utilizador.listaLivrosEmprestados.RemoveAt(indexEmprestimo);

                        livro.estaEmprestado = false;


                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("\n\t\tLivro devolvido.");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\t\tLivro não encontrado.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\tUtilizador não encontrado.");
                Console.ResetColor();
            }
        }
        private static void renovarEmprestimo()
        {
            int idUtilizador = inputUtilizadorId();
            int indexUtili = listaUtilizadores.FindIndex(utilizador => utilizador.id == idUtilizador);

            if (indexUtili != -1)
            {
                int idlivro = inputLivroId();
                int indexLivro = listaLivros.FindIndex(livro => livro.id == idlivro);
                if (indexLivro != -1)
                {
                    int indexEmprestimo = listaUtilizadores[indexUtili].listaLivrosEmprestados.FindIndex(livro => livro.id == idlivro);

                    if (indexEmprestimo != -1)
                    {

                        listaLivros[indexLivro].dataDevolucao = listaLivros[indexLivro].dataDevolucao.AddDays(7);

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("\n\t\tEmpréstimo renovado com sucesso por mais 7 dias.");
                        Console.WriteLine($"\n\t\tNova data de devolução: {listaLivros[indexLivro].dataDevolucao}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\t\tUtilizador não emprestou livro.");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\t\tLivro não encontrado.");
                    Console.ResetColor();
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\tUtilizador não encontrado.");
                Console.ResetColor();
            }
        }

        private static void verificarLivroEstaReservado()
        {
            int idLivro = inputLivroId();
            Livro livro = listaLivros.Find(livro => livro.id == idLivro);

            if (livro != null)
            {
                Console.WriteLine(livro.estaReservado ? "\n\t\tLivro já está reservado." : "\n\t\tO Livro não está reservado.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\tLivro não encontrado.");
                Console.ResetColor();
            }
        }

        private static void reservarLivro()
        {
            int idlivro = inputLivroId();
            int indexlivro = listaLivros.FindIndex(livro => livro.id == idlivro);

            if (indexlivro != -1)
            {
                Livro livro = listaLivros[indexlivro];

                if (!livro.estaReservado && !livro.estaEmprestado)
                {
                    int idUtilizador = inputUtilizadorId();
                    int indexUtili = listaUtilizadores.FindIndex(utilizador => utilizador.id == idUtilizador);

                    if (indexUtili != -1)
                    {
                        Utilizador utilizador = listaUtilizadores[indexUtili];
                        if (utilizador.penalidade > 5)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\n\t\tO utilizador atingiu o máximo de penalidades e ficou impossibilitado de reservar um livro.");
                            Console.ResetColor();
                        }
                        else
                        {

                            if (!utilizador.premium && utilizador.listaLivrosReservados.Count >= 5)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("\n\t\tO utilizador atingiu o máximo de livros reservados.");
                                Console.ResetColor();
                            }
                            else
                            {
                                utilizador.listaLivrosReservados.Add(livro);
                                livro.estaReservado = true;

                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine("\n\t\tLivro reservado com sucesso.");
                                Console.ResetColor();
                            }

                        }
                    }
                    else
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\t\tUtilizador não existe.");
                        Console.ResetColor();
                    }
                }
                else
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\t\tO livro já está reservado ou emprestado.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\tLivro não encontrado.");
                Console.ResetColor();
            }
        }
        private static void apagarReserva()
        {
            int idLivro = inputLivroId();
            Livro livro = listaLivros.Find(livro => livro.id == idLivro);

            if (livro != null)
            {
                if (livro.estaReservado)
                {
                    int idUtilizador = inputUtilizadorId();
                    int indexUtilizador = listaUtilizadores.FindIndex(utilizador => utilizador.id == idUtilizador);

                    if (indexUtilizador != -1)
                    {
                        int indexReserva = listaUtilizadores[indexUtilizador].listaLivrosReservados.FindIndex(livro => livro.id == idLivro);

                        if (indexReserva != -1)
                        {
                            livro.estaReservado = false;
                            listaUtilizadores[indexUtilizador].listaLivrosReservados.RemoveAt(indexReserva);

                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("\n\t\tReserva do livro apagada com sucesso.");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\t\tLivro não está reservado para este utilizador.");
                            Console.ResetColor();
                        }


                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\t\tUtilizador não encontrado.");
                        Console.ResetColor();
                    }


                }
                else
                {
                    Console.WriteLine("\n\t\tO Livro não está reservado.");
                }


            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\tLivro não encontrado.");
                Console.ResetColor();
            }
        }


        private static void pressionarEnterParaContinuar()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("");
            Console.WriteLine("\n\t\tPressione enter para continuar...");
            Console.Write("\t\t");
            Console.ReadKey();
            Console.ResetColor();
        }


        private static int inputLivroId()
        {
            int id = 0;
            var tentaNovamente = true;
            while (tentaNovamente == true)
            {
                try
                {
                    Console.Write("\n\t\tEscreva o id do Livro: ");
                    id = int.Parse(Console.ReadLine());
                    tentaNovamente = false;
                }
                catch
                {
                    Console.WriteLine("\n\t\tOpçao Inválida, insira um numero inteiro.");
                }
            }
            return id;
        }


        private static List<string> inputLivroAutores()
        {

            List<string> autores = new List<string>();
            int posicao = 1;

            bool outrosAutores = true;

            while (outrosAutores)
            {
                Console.Write("\n\t\tDigite o nome do " + posicao++ + "º Autor/a: ");
                autores.Add(Console.ReadLine());

                outrosAutores = perguntar("\n\t\tExiste outro autor?");

            }

            return autores;
        }

        private static string inputLivroNome()
        {
            Console.Write("\n\t\tInsira o nome do livro: ");
            string nome = Console.ReadLine();

            return nome.Trim();
        }

        private static int inputLivroAno()
        {
            int ano = 0;
            var tentaNovamente = true;
            while (tentaNovamente == true)
            {
                try
                {
                    Console.Write("\n\t\tInsira o ano do livro: ");
                    ano = int.Parse(Console.ReadLine());
                    tentaNovamente = false;
                }
                catch
                {
                    Console.WriteLine("\n\t\tOpçao Inválida, insira um numero inteiro.");
                }
            }
            return ano;
        }

        private static int inputLivroPenalidadeAtraso()
        {
            int penalidadeAtraso = 0;
            do
            {
                Console.WriteLine("\n\t\tInsira a penalidade em caso de atraso do livro: ");
                Console.WriteLine("\t\t1 - Ligeira\n");
                Console.WriteLine("\t\t2 - Media\n");
                Console.WriteLine("\t\t3 - Grave\n");
                Console.Write("\t\t");
                string entrada = Console.ReadLine();

                switch (entrada)
                {
                    case "1":
                        penalidadeAtraso = 1;
                        break;
                    case "2":
                        penalidadeAtraso = 2;
                        break;
                    case "3":
                        penalidadeAtraso = 3;
                        break;

                    default:
                        Console.WriteLine("\n\t\tOpçao Inválida");
                        break;
                }

            } while (penalidadeAtraso != 1 && penalidadeAtraso != 2 && penalidadeAtraso != 3);

            return penalidadeAtraso;
        }



        private static int inputUtilizadorId()
        {
            int id = 0;
            var tentaNovamente = true;
            while (tentaNovamente == true)
            {
                try
                {
                    Console.Write("\n\t\tEscreva o id do Utilizador: ");
                    id = int.Parse(Console.ReadLine());
                    tentaNovamente = false;
                }
                catch
                {
                    Console.WriteLine("\n\t\tOpçao Inválida, insira um numero inteiro.");
                }
            }
            return id;
        }

        private static string inputUtilizadorNome()
        {
            Console.Write("\n\t\tInsira o nome do utilizador: ");
            string nome = Console.ReadLine();

            return nome;
        }

        private static string inputUtilizadorSenha()
        {
            Console.Write("\n\t\tInsira a senha do utilizador: ");
            string senha = Console.ReadLine();

            return senha;
        }

        private static string inputUtilizadorEmail()
        {
            Console.Write("\n\t\tInsira o email do utilizador: ");
            string email = Console.ReadLine();

            return email;
        }

        private static bool inputUtilizadorTipo()
        {
            int option = 0;
            bool premium = false;

            do
            {
                Console.WriteLine("\n\t\tO utilizador vai ter conta premium?\n");
                Console.WriteLine("\t\t1 - Para conta premium\n");
                Console.WriteLine("\t\t2 - Para conta normal\n");
                Console.Write("\t\t");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        premium = true;
                        break;

                    case 2:
                        premium = false;
                        break;
                    default:
                        Console.WriteLine("\n\t\tOpçao Inválida");
                        option = 0;
                        break;
                }
            } while (option == 0);

            return premium;
        }


        private static bool perguntar(string texto)
        {
            bool resposta = false;
            string pergunta = $"\n\t\t{texto.Trim()}(S/N) ";

            string entrada;
            bool entradaValida = false;


            while (!entradaValida)
            {

                Console.Write(pergunta);
                entrada = Console.ReadLine();

                switch (entrada)
                {
                    case "S":
                    case "s":
                        resposta = true;
                        entradaValida = true;
                        break;


                    case "N":
                    case "n":
                        resposta = false;
                        entradaValida = true;
                        break;

                    default:
                        Console.WriteLine("\n\t\tEntrada inválida!!!");
                        entradaValida = false;
                        break;
                }
            }


            return resposta;
        }

        public static void emprestarLivro(Utilizador utilizador, Livro livro)
        {
            utilizador.listaLivrosEmprestados.Add(livro);
            livro.estaEmprestado = true;
            livro.dataEmprestimo = DateTime.Now;
            livro.dataDevolucao = livro.dataEmprestimo.AddDays(7);
            Console.WriteLine($"\n\t\tData empréstimo: {livro.dataEmprestimo}");
            Console.WriteLine($"\n\t\tData para devolução: {livro.dataDevolucao}");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n\t\tLivro emprestado.");
            Console.ResetColor();
        }
    }
}
