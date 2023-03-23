  namespace ApiEstoque.Models;

public class ItemSaida
{
    public ItemSaida(int id, string lote, int quantidade, double valor, int saidaId, int produtoId)
    {
      Id = id;
      Lote = lote;
      Quantidade = quantidade;
      Valor = valor;
      SaidaId = saidaId;
      ProdutoId = produtoId; 
    }

    public int Id { get; private set; }

    public string Lote { get; private set; }

    public int Quantidade { get; private set; }

    public double Valor { get; private set; }

    public int SaidaId { get; private set; }

    public int ProdutoId { get; private set; }

    public Saida Saida { get; private set; } = null!;

    public Produto Produto { get; private set; } = null!;
}