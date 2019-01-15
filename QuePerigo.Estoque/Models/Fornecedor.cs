using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace QuePerigo.Estoque.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        //public List<Endereco> Enderecos { get; set; }
        //public List<Telefone> Telefones { get; set; }
        //public MailMessage Email { get; set; }
    }
}
