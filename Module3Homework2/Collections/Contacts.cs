using System.Globalization;
using Module3Homework2.Abstractions;
using Module3Homework2.Comparers;
using Module3Homework2.Utils;

namespace Module3Homework2.Collections
{
    public class Contacts : IContacts<IRecord>
    {
        private readonly CultureInfo _cultureInfo;
        private Dictionary<string, List<IRecord>> _contacts;
        public Contacts(CultureInfo cultureInfo)
        {
            _cultureInfo = cultureInfo;
            _contacts = new Dictionary<string, List<IRecord>>();
            InitialiseContactsWithSelectedCultureInfo();
        }

        public void AddRecordToContacts(IRecord record)
        {
            if (_cultureInfo.Name.Equals("en-US") &&
                !WordsHandler.IsFirstLetterInWordDigit(record.FirstName))
            {
                if (WordsHandler.IsEnglishWord(record.FirstName))
                {
                    _contacts["A-Z"].Add(record);
                }
                else
                {
                    _contacts["#"].Add(record);
                }
            }
            else if (!WordsHandler.IsFirstLetterInWordDigit(record.FirstName))
            {
                if (WordsHandler.IsEnglishWord(record.FirstName))
                {
                    _contacts["#"].Add(record);
                }
                else
                {
                    _contacts["А-Я"].Add(record);
                }
            }
            else
            {
                _contacts["0-9"].Add(record);
            }
        }

        public Dictionary<string, List<IRecord>> GetAllContacts()
        {
            return _contacts.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }

        public void PrintAllContacts()
        {
            for (int i = 0; i < _contacts.Count; i++)
            {
                _contacts.ElementAt(i).Value.Sort(new ContactComparer());
            }

            foreach (var contact in _contacts)
            {
                Console.WriteLine(Environment.NewLine + $"{contact.Key}");
                foreach (var record in contact.Value)
                {
                    Console.WriteLine($"- {record.FirstName}: {record.Phone}");
                }
            }
        }

        public void InitialiseContactsWithSelectedCultureInfo()
        {
            if (_cultureInfo.Equals(new CultureInfo("ua-UA")))
            {
                _contacts.Add("А-Я", new List<IRecord>());
            }
            else
            {
                _contacts.Add("A-Z", new List<IRecord>());
            }

            _contacts.Add("0-9", new List<IRecord>());
            _contacts.Add("#", new List<IRecord>());
        }
    }
}
