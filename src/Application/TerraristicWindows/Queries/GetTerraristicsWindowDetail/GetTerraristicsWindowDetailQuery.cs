using MediatR;

namespace Application.TerraristicWindows.Queries.GetTerraristicsWindowDetail
{
    public class GetTerraristicsWindowDetailQuery: IRequest<TerraristicsWindowDetailAm>
    {
        public int Id { get; set; }
    }
}