using AutoMapper;
using MediatR;
using Weather.Application.Common.Interfaces;
using Weather.Application.Measures.Responses;
using Weather.Domain;

namespace Weather.Application.Measures.Queries.GetMeasures;

public class GetMeasuresCommandHandler : IRequestHandler<GetMeasuresCommand, List<MeasureResponse>>
{
    protected readonly IMeasureRepository _measureRepository;
    protected readonly IMapper _mapper;
    public GetMeasuresCommandHandler(IMeasureRepository measureRepository, IMapper mapper)
    {
        _measureRepository = measureRepository;
        _mapper = mapper;
    }
    public async Task<List<MeasureResponse>> Handle(GetMeasuresCommand request, CancellationToken cancellationToken)
    {
        var measures = await _measureRepository.ListByPeriod(request.InitialDate, request.FinalDate);
        var measuresResponse = _mapper.Map<List<Measure>, List<MeasureResponse>>(measures);

        return await Task.FromResult(measuresResponse.ToList());
    }
}