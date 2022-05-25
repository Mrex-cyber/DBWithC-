using System.ComponentModel.DataAnnotations.Schema;

namespace DBTraining
{
    public class User
    {
        [Column("user_id")]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }        
        public int FullAges { get; set; }       
        public bool HaveJob { get; set; }
        private Company? company;

        public void Print() => Console.WriteLine($"{Id}. {FirstName} - {FullAges}.");
    }
    // [NotMapped]
    public class Country
    {
        [Column("country_id")]
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Name { get; set; }
        public Country (string name)
        {
            Name = name;
        }
    }

    public class Company 
    {                
        public int Id { get; set; }
        public string Name { get; set; }
        public int Employees { get; set; }
        public Company(string name)
        {
            Name = name;
        }        
    }
}
