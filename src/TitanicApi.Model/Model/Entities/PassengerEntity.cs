using Azure;
using Azure.Data.Tables;

namespace TitanicApi.Model;

public class PassengerEntity : ITableEntity
{
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }
    public int Survived { get; set; }
    public int Pclass { get; set; }
    public string Name { get; set; }
    public string Sex { get; set; }
    public decimal? Age { get; set; }
    public int SibSp { get; set; }
    public int Parch { get; set; }
    public string Ticket { get; set; }
    public decimal Fare { get; set; }
    public string Cabin { get; set; }
    public string Embarked { get; set; }
}
