using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composicao
{
    class Estudio
    {
        public string nome;
        public string ceo;
        public string sede;
        public int fundacao;

        public Estudio(string nome, string ceo, string sede, int fundacao)
        {
            this.nome = nome;
            this.ceo = ceo;
            this.sede = sede;
            this.fundacao = fundacao;
        }

        public void ExibirInfo(int id)
        {
            Console.WriteLine($"Nome: {nome}\nCEO: {ceo}\nSede: {sede}\nFundação: {fundacao}\nID: {id} ");
        }

    }
}
