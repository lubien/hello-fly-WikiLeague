using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoLChampionsAPI.Dominio.Entities
{
    public class Campeao
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Funcao { get; set; } = string.Empty;
        public string Regiao { get; set; } = string.Empty;
        public string Dificuldade { get; set; } = string.Empty;
        public bool Ativo { get; set; } = true;
        public string Rota { get; set; } = string.Empty;

    }
}