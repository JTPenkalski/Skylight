namespace Skylight.Forms.Guides
{
    public class LocationFormGuide : FormGuide
    {
        public required FormControl<string> City { get; set; }
        public required FormControl<string> Country { get; set; }
    }
}
