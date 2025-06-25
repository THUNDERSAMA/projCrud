namespace projCrud.Models
{
    public class Donor {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string BloodGroup { get; set; }
    public DateTime DonationDate { get; set; }

    public int CenterId { get; set; }
    public Center Center { get; set; }
}
}