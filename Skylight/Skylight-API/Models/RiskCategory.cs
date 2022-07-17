namespace Skylight.Models
{
    public class RiskCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }

        public RiskCategory(int id, string name, string label, string description)
        {
            Id = id;
            Name = name;
            Label = label;
            Description = description;
        }
    }
}