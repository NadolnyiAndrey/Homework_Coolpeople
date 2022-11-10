namespace TranslationManagement.DAL.Entities
{
    public class TranslatorModel : Entity
    {
        public string Name { get; set; }
        public string HourlyRate { get; set; }
        public string Status { get; set; }
        public string CreditCardNumber { get; set; }
    }
}
