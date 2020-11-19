using MediatR;

namespace Application.Terrariums.Queries.GetTerrariumDetail
{
    public class GetTerrariumDetailQuery: IRequest<TerrariumDetailAm>
    {
        public int Id { get; set; }
    }
}