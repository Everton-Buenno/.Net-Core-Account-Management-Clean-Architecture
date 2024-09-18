using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cliente
    {
        public Cliente(string nome, string cpf, string endereco, string profissao)
        {
            Nome = nome;
            Cpf = cpf;
            Endereco = endereco;
            Profissao = profissao;
        }

        public Guid Id { get;private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Endereco { get; private set; }
        public string Profissao { get; private set; }

        public IEnumerable<ContaBancaria> Contas { get; private set; }



    }
}
