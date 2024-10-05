namespace Weather.Domain;

public class Measure {
    public string sId { get; set; }
    public MeasureTs ts { get; set; }
    public double preciptation { get; set; }
    public double temperature { get; set; }
    public double pressure { get; set; }
    public string label { get; set; }
    public GeoPosition position { get; set; }

}

public class MeasureTs {
    public DateTime date { get; set; }
}