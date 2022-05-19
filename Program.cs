using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composicao
{
    class Program
    {
        static void Main(string[] args)
        {
            bool escolheuSair = false;
            int opcao = 0;
            List<Filme> filmes = new List<Filme>();
            List<Estudio> estudios = new List<Estudio>();
            while (!escolheuSair)
            {
                ExibirMenu();
                opcao = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (opcao)
                {
                    case 0:
                            escolheuSair = true;
                        break;

                    case 1:
                            estudios = AdicionarEstudio(estudios);
                            Console.Clear();
                        break;
                    case 2:
                            filmes = AdicionarFilme(filmes, estudios);
                            Console.Clear();
                        break;
                    case 3:
                            ExibirEstudios(estudios);
                            Console.Clear();
                        break;
                    case 4:
                            ExibirFilmes(filmes);
                            Console.Clear();
                        break;
                    case 5:
                            ExibirFilmesPorEstudio(filmes);
                            Console.Clear();
                        break;
                }
            }
        }

        static void ExibirMenu()
        {
            Console.WriteLine("[1] - Adicionar Estúdio\n[2] - Adicionar Filme \n[3] - Exibir Estúdios\n[4] - Exibir Filmes\n[5] - Exibir Filmes por Estúdio\n[0] - Sair");
        }
        static List<Estudio> AdicionarEstudio(List<Estudio> NovaLista)
        {
            string nome, ceo, sede;
            int fundacao;
            Console.Write("Insira o nome do estúdio: ");
            nome = Console.ReadLine();
            Console.Write("Insira o nome do CEO do estúdio: ");
            ceo = Console.ReadLine();
            Console.Write("Insira o nome da sede do estúdio: ");
            sede = Console.ReadLine();
            Console.Write("Insira o ano de fundação do estúdio: ");
            fundacao = int.Parse(Console.ReadLine());
            NovaLista.Add(new Estudio(nome, ceo, sede, fundacao));
            return NovaLista;
        }
        static void ExibirEstudios(List<Estudio> estudios)
        {
            for(int i = 0; i<estudios.Count; i++)
            {
                estudios[i].ExibirInfo(i);
                Console.WriteLine("===============");
            }
            Console.ReadLine();
        }
        static void ExibirFilmesPorEstudio(List<Filme> Filmes)
        {
            string nomeestudio;
            bool encontrou = false;
            Console.Write("Insira o nome do estúdio: ");
            nomeestudio = Console.ReadLine();
            foreach(Filme filme in Filmes)
            {
                if (((filme.estudio.nome).ToUpper()) == (nomeestudio.ToUpper()))
                {
                    filme.ExibirInfo();
                    encontrou = true;
                }
            }

            if (!encontrou)
            {
                Console.WriteLine("Nenhum filme encontrado!");
            }

            Console.ReadLine();
        }
        static List<Filme> AdicionarFilme(List<Filme> NovaLista, List<Estudio> Estudios)
        {
            string nome, genero, nomeestudio;
            int ano, classificacao;
            float duracao;
            Estudio meuestudio;
            Console.Write("Insira o nome do filme: ");
            nome = Console.ReadLine();
            Console.Write("Insira o gênero do filme: ");
            genero = Console.ReadLine();
            Console.Write("Insira o ano de publicação do filme: ");
            ano = int.Parse(Console.ReadLine());
            do
            {
                Console.Write("Insira a classificação do filme [0 a 10]: ");
                classificacao = int.Parse(Console.ReadLine());
                if(classificacao<0 || classificacao > 10)
                {
                    Console.WriteLine("Nota Inválida! Insira uma classificação de 0 a 10");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (classificacao<0 || classificacao>10);
            Console.Write("Insira a duração do filme [em horas]: ");
            duracao = float.Parse(Console.ReadLine());
            Console.Clear();
            Console.Write("Insira o nome do estúdio do filme: ");
            nomeestudio = Console.ReadLine();
            meuestudio = Estudios.Find(estudio => estudio.nome == nomeestudio);
            if (meuestudio == null)
            {
                Console.WriteLine("Estúdio não encontrado! (Foi setado como 'indefinido')");
                Console.ReadLine();
                NovaLista.Add(new Filme(nome, ano, duracao, genero, classificacao, new Estudio("Indefinido", "", "", 0)));
            }
            else
            {
                NovaLista.Add(new Filme(nome, ano, duracao, genero, classificacao, meuestudio));
            }
            return NovaLista;
        }
        static void ExibirFilmes(List<Filme> filmes)
        {
            for (int i = 0; i < filmes.Count; i++)
            {
                filmes[i].ExibirInfo();
                Console.WriteLine("===============");
            }
            Console.ReadLine();
        }
    }
}
