using System.Collections;

namespace Module3Homework1.Enumerator
{
    public class CatalogEnumerator<T> : IEnumerator<T>
    {
        private readonly T[] _catalog;
        private int _position;

        public CatalogEnumerator(T[] catalog)
        {
            _catalog = catalog;
            _position = -1;
        }

        public T Current
        {
            get
            {
                if (_position == -1 || _position >= _catalog.Length)
                {
                    throw new InvalidOperationException();
                }

                return _catalog[_position];
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            if (_position < _catalog.Length - 1)
            {
                _position++;
                return true;
            }

            return false;
        }

        public void Reset() => _position = -1;

        public void Dispose()
        {
        }
    }
}
