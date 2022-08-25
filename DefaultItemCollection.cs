namespace CollectionDefaultKata;
public class DefaultItemCollection<T>
  where T: IEquatable<T>
{
  public T DefaultItem { get; private set; }

  private List<T> _items = new();

  public IEnumerable<T> Items
  {
    get => _items;
  }

  public DefaultItemCollection(T defaultItem)
  {
    DefaultItem = defaultItem;
    Add(defaultItem);
  }

  public void Add(T item)
  {
    if (_items.Contains(item)) return;
    _items.Add(item);
  }

  public void Remove(T item)
  {
    if(_items.Count() == 1)
    {
      throw new InvalidOperationException("Cannot remove the only item in the collection");
    }

    _items.Remove(item);

    if(DefaultItem.Equals(item))
    {
      DefaultItem = _items.First();
    }
  }

  public void SetDefault(T item)
  {
    if (!_items.Contains(item))
    {
      throw new ArgumentException("Photo not found in album");
    }

    DefaultItem = item;
  }
}
