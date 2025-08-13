using System;
using System.Collections;
using System.Collections.Generic;

public class MySimpleDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
{
    private List<KeyValuePair<TKey, TValue>> _items;

    public MySimpleDictionary()
    {
        _items = new List<KeyValuePair<TKey, TValue>>();
    }

    // Broj elemenata
    public int Count => _items.Count;

    // Svi ključevi
    public ICollection<TKey> Keys
    {
        get
        {
            List<TKey> keys = new List<TKey>();
            foreach (var kvp in _items)
                keys.Add(kvp.Key);
            return keys;
        }
    }

    // Sve vrednosti
    public ICollection<TValue> Values
    {
        get
        {
            List<TValue> values = new List<TValue>();
            foreach (var kvp in _items)
                values.Add(kvp.Value);
            return values;
        }
    }

    // Dodavanje novog para (ključ, vrednost)
    public void Add(TKey key, TValue value)
    {
        if (ContainsKey(key))
            throw new ArgumentException("Element sa ovim ključem već postoji.");
        _items.Add(new KeyValuePair<TKey, TValue>(key, value));
    }

    // Uklanjanje po ključu
    public bool Remove(TKey key)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (EqualityComparer<TKey>.Default.Equals(_items[i].Key, key))
            {
                _items.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    // Provera da li postoji ključ
    public bool ContainsKey(TKey key)
    {
        foreach (var kvp in _items)
            if (EqualityComparer<TKey>.Default.Equals(kvp.Key, key))
                return true;
        return false;
    }

    // Provera da li postoji vrednost
    public bool ContainsValue(TValue value)
    {
        foreach (var kvp in _items)
            if (EqualityComparer<TValue>.Default.Equals(kvp.Value, value))
                return true;
        return false;
    }

    // Brisanje celog sadržaja
    public void Clear()
    {
        _items.Clear();
    }

    // Pristup po ključu, get i set
    public TValue this[TKey key]
    {
        get
        {
            foreach (var kvp in _items)
            {
                if (EqualityComparer<TKey>.Default.Equals(kvp.Key, key))
                    return kvp.Value;
            }
            throw new KeyNotFoundException("Ključ nije pronađen.");
        }
        set
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if (EqualityComparer<TKey>.Default.Equals(_items[i].Key, key))
                {
                    _items[i] = new KeyValuePair<TKey, TValue>(key, value);
                    return;
                }
            }
            // Ako ključ ne postoji, dodaj novi element
            _items.Add(new KeyValuePair<TKey, TValue>(key, value));
        }
    }

    // Iteracija kroz elemente
    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _items.GetEnumerator();
    }
}
