using Module3Homework2.Abstractions;

namespace Module3Homework2.Comparers
{
    public class ContactComparer : IComparer<IRecord>
    {
        public int Compare(IRecord? x, IRecord? y)
        {
            return x!.FirstName.CompareTo(y!.FirstName);
        }
    }
}
