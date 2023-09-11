namespace MaxPrimeNumber.Entities
{

    public class EnteredNumber : BaseEntity
    {
        public Guid EnteredNumberUserId { get; set; }
        
        public int MaxPrimeNumber { get; set; }
        
        public string EnteredNumbers { get; set; }

        /*public EnteredNumber(Guid enteredNumberUserId, int maxPrimeNumber, string enteredNumbers)
        {
            Id = new Guid();
            EnteredNumberUserId = enteredNumberUserId;
            MaxPrimeNumber = maxPrimeNumber;
            EnteredNumbers = enteredNumbers;
        }*/

    }
}