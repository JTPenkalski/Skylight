using System;

namespace Skylight.Attributes.Database
{
    [Obsolete("Use new PrimaryKeyAttribute instead.")] // TODO: Replace with PrimaryKeyAttribute
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CompositeKeyAttribute : Attribute { }
}