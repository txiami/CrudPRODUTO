public class ProdutoRepository
{
    private List<Produto> produtos = new List<Produto>();

    public void adicionar(Produto produto)
    {
        this.produtos.Add(produto);
    }

    public void editar(Produto produto)
    {
        int index = this.produtos.FindIndex(p => p.GetId() == produto.GetId());
        this.produtos[index] = produto;
    }

    public void excluir(int id)
    {
        this.produtos.RemoveAll(p => p.GetId() == id);
    }

    public List<Produto> listar()
    {
        return this.produtos;
    }
}
