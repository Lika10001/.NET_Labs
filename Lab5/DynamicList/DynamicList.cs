using System.Collections;

namespace DynamicList;

public class DynamicList<T>: IEnumerable<T>
{
    private int _count;
    private T[] _items;

    public DynamicList(T[] initialItems)
    {
        _items = new T[initialItems.Length];
        Array.Copy(initialItems, _items, initialItems.Length);
        _count = initialItems.Length;
    }

   public int Count => _count;

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException();
            }

            return _items[index];
        }
        set
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException();
            }

            _items[index] = value;
        }
    }

    public void Add(T item)
    {
        if (_count == _items.Length)
        {
            Array.Resize(ref _items, _items.Length + 1);
        }
        _items[_count] = item;
        _count++;
    }

    public bool Remove(T item)
    {
        int index = Array.IndexOf(_items, item, 0, _count);
        if (index >= 0)
        {
            RemoveAt(index, 1);
            return true;
        }
        return false;
    }

    public void Clear()
    {
        Array.Clear(_items, 0, _count);
        _count = 0;
    }

    public void RemoveAt(int index, int count)
    {
        if (index < 0 || index >= _count)
        {
            throw new IndexOutOfRangeException();
        }

        if (count < 0 || index + count > _count)
        {
            throw new ArgumentException("Invalid range");
        }

        if (count == 0)
        {
            return;
        }

        Array.Copy(_items, index + count, _items, index, _count - index - count);
        Array.Clear(_items, this._count - count, count);
        _count -= count;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < _count; i++)
        {
            yield return _items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
}