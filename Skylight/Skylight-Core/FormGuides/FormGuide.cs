namespace Skylight.Forms
{
    /// <summary>
    /// Metadata which helps determine, or guide, how any form control should operate on the UI.
    /// </summary>
    public class FormGuide
    {
        public string Name { get; }

        public bool Required { get; set; }

        public bool ReadOnly { get; set; }

        public bool Hidden { get; set; }

        /// <summary>
        /// Constructs a new Form Guide instance.
        /// </summary>
        /// <param name="name">The name of the HTML element used for this form control.</param>
        public FormGuide(string name)
        {
            Name = name;
        }
    }
}