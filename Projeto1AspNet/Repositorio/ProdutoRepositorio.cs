using MySql.Data.MySqlClient;
using Projeto1AspNet.Models;
using System.Configuration;
using System.Data;

namespace Projeto1AspNet.Repositorio
{
    public class ProdutoRepositorio(IConfiguration configuration)
    {
        // Declara um campo privado somente leitura para armazenar a string de conexão com o MySQL.
        private readonly string _conexaoMySQL = configuration.GetConnectionString("ConexaoMySQL");

        //METODO CADASTRAR Produto
        public void AdicionarProduto(Produto produto)
        {
            using (var db = new MySqlConnection(_conexaoMySQL))
            {
                db.Open();
                var cmd = db.CreateCommand();
                cmd.CommandText = "INSERT INTO Produto (Nome,Descricao,Preco) values (@nome,@descricao,@preco)";
                cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = produto.Nome;
                cmd.Parameters.Add("@descricao", MySqlDbType.VarChar).Value = produto.Descricao;
                cmd.Parameters.Add("@preco", MySqlDbType.VarChar).Value = produto.Preco;
                cmd.ExecuteNonQuery();
                db.Close();
            }
        }

        //MÉTODO BUSCAR TODOS OS USUARIOS

        public Produto ObterProduto(int id)
        {
            // Cria uma nova instância da conexão MySQL dentro de um bloco 'using'.
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                // Abre a conexão com o banco de dados MySQL.
                conexao.Open();
                // Cria um novo comando SQL para selecionar todos os campos da tabela 'Usuario' onde o campo 'Email' correspond
                // e ao parâmetro fornecido.
                MySqlCommand cmd = new("SELECT * FROM Produto WHERE Id = @id", conexao);
                // Adiciona um parâmetro ao comando SQL para o campo 'Email', especificando o tipo como VarChar e utilizando o valor do parâmetro 'email'.
                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;

                // Executa o comando SQL SELECT e obtém um leitor de dados (MySqlDataReader). O CommandBehavior.CloseConnection garante que a conexão
                // será fechada automaticamente quando o leitor for fechado.
                using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    // Cria uma nova instância do objeto 'produto'
                    Produto produto = new Produto();
                    // Lê a próxima linha do resultado da consulta. Retorna true se houver uma linha e false caso contrário.
                    while (dr.Read())
                    {
                        
                        {
                            // Lê o valor da coluna "Id" da linha atual do resultado, converte para inteiro e atribui à propriedade 'Id' do objeto 'usuario'.
                            produto.Id = Convert.ToInt32(dr["id"]);
                            //Lê o valor da coluna "Nome" da linha atual do resultado, converte para string e atribui à propriedade 'Nome' do objeto 'usuario'.
                            produto.Nome = dr["Nome"].ToString();
                            // Lê o valor da coluna "Email" da linha atual do resultado, converte para string e atribui à propriedade 'Email' do objeto 'usuario'.
                            produto.Descricao = dr["descricao"].ToString();
                            // Lê o valor da coluna "Senha" da linha atual do resultado, converte para string e atribui à propriedade 'Senha' do objeto 'usuario'.
                            produto.quantidade = Convert.ToInt32(dr["quantidade"]);
                        };
                    }
                    /* Retorna o objeto 'Produto'. Se nenhum usuário foi encontrado com o email fornecido, a variável 'usuario'
                     permanecerá null e será retornado.*/
                    return produto;
                }
            }
        }
    }
}
