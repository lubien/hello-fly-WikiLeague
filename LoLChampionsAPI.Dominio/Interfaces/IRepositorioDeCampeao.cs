using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoLChampionsAPI.Dominio.Entities;

namespace LoLChampionsAPI.Dominio.Interfaces
{
    public interface IRepositorioDeCampeao
    {
        IEnumerable<Campeao> ObterTodos();
        Campeao? ObterPorNome(string nome);
        IEnumerable<Campeao> ObterPorFuncao(string funcao);
        void Adicionar(Campeao campeao);
        void Atualizar(Campeao campeao);
        void Desativar(int id);
        void Reativar(int id);
        void DeletarPorId(int id);

        IEnumerable<Campeao> ObterInativos();
    }
}