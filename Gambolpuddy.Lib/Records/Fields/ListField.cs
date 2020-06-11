using System;
using System.Collections;
using System.Collections.Generic;

namespace Gambolpuddy.Lib.Records.Fields
{
    public abstract class ListField<T> : IList<T>
    {
        private Cursor _cursor;
        private string _itemPath;

        public ListField(string itemPath, Cursor cursor)
        {
            _cursor = cursor;
            _itemPath = itemPath;
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            for (var x = 0; x < Count; x++)
            {
                yield return this[x];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new System.NotImplementedException();
        }

        public int Count => (int)XEditLib.ElementCount(_cursor.ElementPath, _itemPath);
        public bool IsReadOnly => false;

        protected abstract T MakeField(string path, Cursor c);

        public int IndexOf(T item)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new System.NotImplementedException();
        }

        public T this[int index]
        {
            get
            {
                var path = MakeField( $"{_itemPath}\\[{index}]", _cursor);
                return path;
            }
            set
            {
                var path = MakeField($"{_itemPath}\\[{index}]", _cursor);
                throw new NotImplementedException();
            }
        }
    }
}