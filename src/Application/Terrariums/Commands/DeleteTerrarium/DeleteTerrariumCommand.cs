using MediatR;

namespace Application.Terrariums.Commands.DeleteTerrarium
{
    public class DeleteTerrariumCommand : IRequest
    {
        public int Id { get; set; }
    }
}