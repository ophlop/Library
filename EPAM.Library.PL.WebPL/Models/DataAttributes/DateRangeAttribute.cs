namespace System.ComponentModel.DataAnnotations
{

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class DateRangeAttribute : RangeAttribute
    {
        public DateRangeAttribute(string minimum) : base(typeof(DateTime), minimum, DateTime.Now.Date.ToShortDateString())
        {
        }
    }
}