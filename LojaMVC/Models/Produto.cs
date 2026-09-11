using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace LojaMVC.Models
{
    public class Produto
    {
        [Key]
        public int Id_produto { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public bool Validation()
        {
            return Preco > 0 && Estoque > 0 &&  !string.IsNullOrEmpty(Nome);

        }

        //Versão simplificada disso aqui:
        //if (Preco > 0) { return true; }
        //else { return false; }


    }
}
