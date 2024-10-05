namespace Weather.Infrastructure.Data.Repositories;

using MongoDB.Driver;
using Weather.Infrastructure.Data.Models;
using Weather.Infrastructure.Data.Connection;
using Weather.Application.Common.Interfaces;
using Weather.Domain;
public class MeasureRepository : IMeasureRepository
{
    private readonly IMongoCollection<MeasureModel> _measureCollection;

    public MeasureRepository()
    {
        var mongoDatabase = DataConnection.GetOpenDatabase();
        _measureCollection = mongoDatabase.GetCollection<MeasureModel>("data");
    }

    public async Task<List<Measure>> List()
    {
        var allMeasures =  _measureCollection.Find(_ => true)
                            .ToList().Select(m => new Measure {
                                preciptation = m.preciptation,
                                temperature = m.temperature,
                                pressure = m.pressure,
                                ts = m.ts,
                                label = m.label,
                                position = m.position,
                                sId = m.Guid
                            }).ToList();
        return allMeasures;
    }

    public async Task<List<Measure>> ListByPeriod(DateTime InitialDate, DateTime FinalDate)
    {
        var allMeasures =  _measureCollection.Find(_ => true)
                            .ToList()
                            .Where(m => m.ts.date >= InitialDate && m.ts.date <= FinalDate + new TimeSpan(23, 59, 59))
                            .Select(m => new Measure {
                                preciptation = m.preciptation,
                                temperature = m.temperature,
                                pressure = m.pressure,
                                ts = m.ts,
                                label = m.label,
                                position = m.position,
                                sId = m.Guid
                            }).ToList();
        return allMeasures;
    }

}