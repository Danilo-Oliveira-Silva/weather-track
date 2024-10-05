using Weather.Domain;

namespace Weather.Application.Common.Interfaces;


public interface IMeasureRepository
{
    Task<List<Measure>> List();
    Task<List<Measure>> ListByPeriod(DateTime InitialDate, DateTime FinalDate);
}