namespace Fifa2026.Dominio.Entidade
{
    public class CategoriaIngresso
    {
        public int Id { get; set; }
        public int PartidaId { get; set; }
        public string Categoria { get; set; } = null!;
        public decimal Preco { get; set; }
        public int QuantidadeTotal { get; set; }
        public int QuantidadeDisponivel { get; set; }
        public string? Descricao { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}
