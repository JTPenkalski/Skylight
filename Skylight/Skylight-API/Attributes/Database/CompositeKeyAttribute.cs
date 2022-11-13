using System;

namespace Skylight.Attributes.Database
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CompositeKeyAttribute : Attribute { }
}