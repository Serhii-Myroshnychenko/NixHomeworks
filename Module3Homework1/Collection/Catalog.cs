using System.Collections;
using Module3Homework1.Enumerator;

namespace Module3Homework1.Collection
{
    public class Catalog<T> : IEnumerable<T>
    {
        private T[] _catalog;
        public Catalog()
        {
            _catalog = Array.Empty<T>();
        }

        public Catalog(IEnumerable<T> collection)
        {
            if (collection is null)
            {
                throw new ArgumentNullException($"{collection} is null");
            }

            _catalog = collection.ToArray();
        }

        public void Add(T item)
        {
            Array.Resize(ref _catalog, _catalog.Length + 1);
            _catalog[^1] = item;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            if (collection is null)
            {
                throw new ArgumentNullException($"{collection} is null");
            }
            else
            {
                foreach (T item in collection)
                {
                    Add(item);
                }
            }
        }

        public bool Remove(T item)
        {
            int firstFoundIndex = Array.IndexOf(_catalog, item);
            if (firstFoundIndex != -1)
            {
                RemoveAt(firstFoundIndex);
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _catalog.Length)
            {
                throw new ArgumentOutOfRangeException($"{index} is incorrect.");
            }

            _catalog = _catalog.Where((elem, ind) => ind != index).ToArray();
        }

        public void Sort() => Array.Sort(_catalog);

        public IEnumerator<T> GetEnumerator()
        {
            return new CatalogEnumerator<T>(_catalog);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetCatalogEnumerator();
        }

        private IEnumerator GetCatalogEnumerator()
        {
            return GetEnumerator();
        }
    }
}