namespace Owl.Overdrive.Domain.Utilities
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    public class TitleAttribute: Attribute
    {
        public string Title { get; set; }

        public TitleAttribute(string title)
        {
            Title = title;
        }
    }
}
