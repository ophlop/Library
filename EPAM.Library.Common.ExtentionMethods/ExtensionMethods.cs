using EPAM.Library.Entities;

namespace EPAM.Library.Common.ExtentionMethods
{
    public static class ExtensionMethods
    {
        public static bool Compare(this List<Author> authors1, List<Author> authors2)
        {
            if(authors1.Count != authors2.Count)
            {
                return false;
            }
            foreach(Author author in authors1)
            {
                if (!authors2.Any(i => i == author))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
