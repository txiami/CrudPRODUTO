using System;

public class Program
{
    static void Main(string[] args)
    {
        ProdutoRepository repo = new ProdutoRepository();

        string opcao;

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1 - Adicionar produto");
            Console.WriteLine("2 - Remover produto");
            Console.WriteLine("3 - Editar nome do produto");
            Console.WriteLine("4 - Listar produtos");
            Console.WriteLine("0 - Sair");

            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    adicionar(repo);
                    break;

                case "2":
                    remover(repo);
                    break;

                case "3":
                    editar(repo);
                    break;

                case "4":
                    listar(repo);
                    break;

                case "0":
                    return;
            }
        }
    }

    static void adicionar(ProdutoRepository repo)
    {
        Produto produto = new Produto();

        Console.Write("Informe o nome do produto: ");
        string nome = Console.ReadLine();

        produto.SetNome(nome);

        repo.Adicionar(produto);
    }

    static void remover(ProdutoRepository repo)
    {
        List<Produto> produtos = repo.Listar();

        if (verificarListaVazia(produtos))
        {
            return;
        }

        Console.Write("Informe o id do produto a ser removido: ");
        int id = int.Parse(Console.ReadLine());

        repo.Excluir(id);
    }

    static void editar(ProdutoRepository repo)
    {
        List<Produto> produtos = repo.Listar();

        if (verificarListaVazia(produtos))
        {
            return;
        }

        Console.Write("Informe o id do produto a ser editado: ");
        int id = int.Parse(Console.ReadLine());

        Produto produto = repo.Listar().Find(p => p.GetId() == id);

        Console.Write("Informe o novo nome: ");
        string nome = Console.ReadLine();

        produto.SetNome(nome);

        repo.Editar(produto);
    }

    static void listar(ProdutoRepository repo)
    {
        List<Produto> produtos = repo.Listar();

        if (verificarListaVazia(produtos))
        {
            return;
        }

        foreach (Produto produto in produtos)
        {
            Console.WriteLine("Id: " + produto.GetId());
            Console.WriteLine("Nome: " + produto.GetNome());
            Console.WriteLine();
        }
    }

    static bool verificarListaVazia(List<Produto> produtos)
    {
        if (produtos.Count == 0)
        {
            Console.WriteLine("Não existem produtos cadastrados.");
            return true;
        }
        return false;
    }
}
