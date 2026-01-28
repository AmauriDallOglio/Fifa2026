namespace Fifa2026.Dominio.Entidade
{
    public class Partida
    {
        public int Id { get; set; }
        public int TimeCasaId { get; set; }
        public int TimeVisitanteId { get; set; }
        public int EstadioId { get; set; }
        public DateTime Data { get; set; }
        public string Hora { get; set; } = null!;
        public string Etapa { get; set; } = null!;
        public string? Grupo { get; set; }
        public int? PlacarCasa { get; set; }
        public int? PlacarVisitante { get; set; }
        public string Status { get; set; } = "scheduled";
        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}
