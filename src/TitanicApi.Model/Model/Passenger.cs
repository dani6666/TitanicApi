namespace TitanicApi.Model;

public class Passenger
{
    public int Id { get; set; }
    public bool Survived { get; set; }
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

    public Passenger(PassengerEntity passengerEntity)
    {
        Id = Convert.ToInt32(passengerEntity.RowKey);
        Survived = passengerEntity.Survived == 1;
        Pclass = passengerEntity.Pclass;
        Name = passengerEntity.Name;
        Sex = passengerEntity.Sex;
        Age = passengerEntity.Age;
        SibSp = passengerEntity.SibSp;
        Parch = passengerEntity.Parch;
        Ticket = passengerEntity.Ticket;
        Fare = passengerEntity.Fare;
        Cabin = passengerEntity.Cabin;
        Embarked = passengerEntity.Embarked;
    }
}
