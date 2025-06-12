using System;
using System.Collections.Generic;

class Programa
{
    // Representa uma tabela criada pelo usuário
    class Tabela
    {
        public string Nome { get; set; }
        public List<string> Colunas { get; set; } = new List<string>();
    }

    static List<Tabela> tabelas = new List<Tabela>();

    static void Main(string[] args)
    {
        Console.WriteLine("=== Sistema da Fazenda Tio José ===");

        bool executando = true;
        while (executando)
        {
            Console.WriteLine("\nMenu Principal:");
            Console.WriteLine("1 - Criar nova tabela");
            Console.WriteLine("2 - Listar tabelas criadas");
            Console.WriteLine("3 - Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    CriarTabela();
                    break;
                case "2":
                    ListarTabelas();
                    break;
                case "3":
                    executando = false;
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }
        }
    }

    static void CriarTabela()
    {
        Console.Write("Digite o nome da nova tabela: ");
        string nomeTabela = Console.ReadLine();

        Console.Write("Quantas colunas terá essa tabela? ");
        if (!int.TryParse(Console.ReadLine(), out int quantidadeColunas) || quantidadeColunas <= 0)
        {
            Console.WriteLine("Número inválido de colunas.");
            return;
        }

        Tabela novaTabela = new Tabela { Nome = nomeTabela };

        for (int i = 1; i <= quantidadeColunas; i++)
        {
            Console.Write($"Nome da coluna {i}: ");
            string nomeColuna = Console.ReadLine();
            novaTabela.Colunas.Add(nomeColuna);
        }

        tabelas.Add(novaTabela);

        Console.WriteLine($"Tabela '{nomeTabela}' criada com sucesso!");
    }

    static void ListarTabelas()
    {
        if (tabelas.Count == 0)
        {
            Console.WriteLine("Nenhuma tabela criada ainda.");
            return;
        }

        Console.WriteLine("\nTabelas criadas:");
        foreach (var tabela in tabelas)
        {
            Console.WriteLine($"- {tabela.Nome} (Colunas: {string.Join(", ", tabela.Colunas)})");
        }
    }
}
