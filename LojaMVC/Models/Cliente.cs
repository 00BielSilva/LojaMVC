using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace LojaMVC.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Idade { get; set; }
        public bool Ativo { get; set; }

        public bool Validation()
        {
            return Idade >= 18 && Email.Contains('@') && !string.IsNullOrEmpty(Nome);
        }

        public bool Permission()
        {
            return Idade >= 18 && Ativo == true;
        }
    }
}
