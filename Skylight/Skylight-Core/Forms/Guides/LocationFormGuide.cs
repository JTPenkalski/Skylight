namespace Skylight.Forms.Guides
{
    public class LocationFormGuide : FormGuide
    {
        public required FormControlGuide<string> City { get; set; }
        public required FormControlGuide<string> Country { get; set; }
    }
}
