namespace Fifa2026.Dominio.Entidade
{
    public class Compra
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int CategoriaIngressoId { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal PrecoTotal { get; set; }
        public string Status { get; set; } = "pending";
        public string? MetodoPagamento { get; set; }
        public string? TransacaoId { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
        public DateTime AtualizadoEm { get; set; } = DateTime.Now;
    }

}
