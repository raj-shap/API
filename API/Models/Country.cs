using Mono.TextTemplating;

namespace API.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public ICollection<State> States { get; set; }
    }
}
