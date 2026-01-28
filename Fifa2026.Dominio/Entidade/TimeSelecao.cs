namespace Fifa2026.Dominio.Entidade
{
    public class TimeSelecao
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Codigo { get; set; } = null!;
        public string? Bandeira { get; set; }
        public string? Grupo { get; set; }
        public string? Confederacao { get; set; }
        public int? RankingFifa { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}
