using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composicao
{
    class Filme
    {
        public string nome;
        public int ano;
        public float duracao;
        public string genero;
        public int classificacao;
        public Estudio estudio;

        public Filme(string nome, int ano, float duracao, string genero, int classificacao, Estudio estudio)
        {
            this.nome = nome;
            this.ano = ano;
            this.duracao = duracao;
            this.genero = genero;
            this.classificacao = classificacao;
            this.estudio = estudio;
        }

        public void ExibirInfo()
        {
            Console.WriteLine($"Nome: {nome}\nAno: {ano}\nGênero: {genero}\nDuração: {duracao} horas\nClassificação: {classificacao}/10\nEstúdio: {estudio.nome}");
            Console.Write("===================");
        }

    }
}
