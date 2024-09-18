using Domain.Enums;

namespace Application.DTOs
{
    public class CriarContaRequest
    {
            public Guid ClienteId { get; set; }
            public TipoConta TipoConta { get; set; }
    }
}
