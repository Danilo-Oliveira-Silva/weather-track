using MediatR;
using Weather.Application.Measures.Responses;

namespace Weather.Application.Measures.Queries.GetMeasures;

public class GetMeasuresCommand : IRequest<List<MeasureResponse>>
{
    public DateTime InitialDate { get; set; }
    public DateTime FinalDate { get; set; }
}
