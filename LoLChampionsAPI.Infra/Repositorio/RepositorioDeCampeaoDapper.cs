using System.Data;
using System.Data.Common;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using Dapper;
using LoLChampionsAPI.Dominio.Entities;
using LoLChampionsAPI.Dominio.Interfaces;

namespace LoLChampionsAPI.Infra.Repositorio
{
    public class RepositorioDeCampeaoDapper : IRepositorioDeCampeao
    {
        private readonly IDbConnection _connection;

        public RepositorioDeCampeaoDapper(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Campeao> ObterTodos()
        {
            const string sql = "SELECT * FROM Campeoes WHERE Ativo = 1";
            return _connection.Query<Campeao>(sql);
        }

        public Campeao? ObterPorNome(string nome)
        {
            const string sql = "SELECT * FROM Campeoes WHERE Nome = @Nome";
            return _connection.QueryFirstOrDefault<Campeao>(sql, new { Nome = nome });
        }

        public IEnumerable<Campeao> ObterPorFuncao(string funcao)
        {
            const string sql = "SELECT * FROM Campeoes WHERE Funcao = @Funcao";
            return _connection.Query<Campeao>(sql, new { Funcao = funcao });
        }

        public void Adicionar(Campeao campeao)
        {
            const string sql = @"INSERT INTO Campeoes (Nome, Funcao, Regiao, Dificuldade, Rota)
                         VALUES (@Nome, @Funcao, @Regiao, @Dificuldade, @Rota)";
            _connection.Execute(sql, campeao);
        }

        public void Atualizar(Campeao campeao)
        {
            const string sql = @"UPDATE Campeoes SET Nome = @Nome, Funcao = @Funcao, Regiao = @Regiao, Dificuldade = @Dificuldade, Rota = @Rota
                         WHERE Id = @Id";


            _connection.Execute(sql, campeao);
        }
        public void Desativar(int id)
        {
            const string sql = "UPDATE Campeoes SET Ativo = 0 WHERE Id = @Id";
            _connection.Execute(sql, new { Id = id });
        }
        public void Reativar(int id)
        {
            const string sql = "UPDATE Campeoes SET Ativo = 1 WHERE Id = @Id";
            _connection.Execute(sql, new { Id = id });
        }

        public void DeletarPorId(int id)
        {
            const string sql = "DELETE FROM Campeoes WHERE Id = @Id";
            _connection.Execute(sql, new { Id = id });
        }

        public IEnumerable<Campeao> ObterInativos()
        {
            const string sql = "SELECT * FROM Campeoes WHERE Ativo = 0";
            return _connection.Query<Campeao>(sql);
        }


    }
}
