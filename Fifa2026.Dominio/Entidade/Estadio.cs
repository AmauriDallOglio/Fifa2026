namespace Fifa2026.Dominio.Entidade
{
    public class Estadio
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Cidade { get; set; } = null!;
        public string Pais { get; set; } = null!;
        public int Capacidade { get; set; }
        public string? Imagem { get; set; }
        public string? Descricao { get; set; }
        public string? Endereco { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}
