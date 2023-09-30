using System;
using System.Collections.Generic;
using System.Linq;

namespace Skylight.Forms
{
    /// <summary>
    /// Metadata which helps determine, or guide, how any form control should operate on the UI.
    /// </summary>
    public class FormGuide
    {
        public required IEnumerable<FormGuideControl> Controls { get; set; }

        public FormGuide(IEnumerable<FormGuideControl> controls)
        {
            Controls = controls;
        }

        public void ToReadOnly() => Controls.ToList().ForEach(control => control.ReadOnly = true);
    }
}


public class FormGuideControl
{
    public required string ElementName { get; set; }
    public required FormGuideControlType Type { get; set; }
    public required FormGuideControlValidation Validation { get; set; }

    public object? DefaultValue { get; set; } = null;
    public bool ReadOnly { get; set; } = false;
    public bool Hidden { get; set; } = false;

    public FormGuideControl(
        string elementName,
        FormGuideControlType type,
        FormGuideControlValidation validation
    )
    {
        ElementName = elementName;
        Type = type;
        Validation = validation;
    }
}

public enum FormGuideControlType
{
    String,
    Numeric,
    DateTime,
    Array,
    Object
}

public class FormGuideControlValidation
{
    public bool Required { get; set; } = false;
}

public class StringFormGuideControlValidation : FormGuideControlValidation
{
    public int MinLength { get; set; } = int.MinValue;
    public int MaxLength { get; set; } = int.MaxValue;
    public string? Pattern { get; set; } = null;
}

public class NumericFormGuideControlValidation : FormGuideControlValidation
{
    public float MinValue { get; set; } = float.MinValue;
    public float MaxValue { get; set; } = float.MaxValue;
}

public class DateTimeFormGuideControlValidation : FormGuideControlValidation
{
    public DateTimeOffset MinValue { get; set; } = DateTimeOffset.MinValue;
    public DateTimeOffset MaxValue { get; set; } = DateTimeOffset.MaxValue;
}

public class ArrayFormGuideControlValidation : FormGuideControlValidation
{
    public int MinElements { get; set; } = 0;
    public int MaxElements { get; set; } = int.MaxValue;
}