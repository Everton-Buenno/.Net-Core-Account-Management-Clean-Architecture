using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ClienteDto
    {

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cpf { get;  set; }
        public string Profissao { get; set; }
        public List<ContaBancariaDTO> ContasBancaria { get; set; }
    }
}
