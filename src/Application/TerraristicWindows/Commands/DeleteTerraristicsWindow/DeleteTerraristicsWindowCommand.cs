using MediatR;

namespace Application.TerraristicWindows.Commands.DeleteTerraristicsWindow
{
    public class DeleteTerraristicsWindowCommand : IRequest
    {
        public int Id { get; set; }
    }
}