namespace CollectionDefaultKata;

public class DefaultItemCollectionTests
{
  [Fact]
  public void CanCreateNewCollectionWithString()
  { 
    var defaultItem = "somePhoto.jpg";
    var collection = new DefaultItemCollection<string>(defaultItem);
    Assert.NotNull(collection);
  }

  [Fact]
  public void CanCreateNewCollectionWithInt()
  { 
    var defaultItem = 37;
    var collection = new DefaultItemCollection<int>(defaultItem);
    Assert.NotNull(collection);
  }

  [Fact]
  public void MustHaveDefaultItemOnCreationWithString()
  {
    var defaultItem = "somePhoto.jpg";
    var collection = new DefaultItemCollection<string>(defaultItem);
    Assert.Equal(defaultItem, collection.DefaultItem);
  }

  [Fact]
  public void MustHaveDefaultItemOnCreationWithInt()
  {
    var defaultItem = 37;
    var collection = new DefaultItemCollection<int>(defaultItem);
    Assert.Equal(defaultItem, collection.DefaultItem);
  }

  [Fact]
  public void CanAddItemsToCollectionWithString()
  {
    var items = new string[] {"somePhoto.jpg", "someOtherPhoto.jpg"};
    var collection = new DefaultItemCollection<string>(items[0]);
    collection.Add(items[1]);
    Assert.Equal(2, collection.Items.Count());
    Assert.Equal(items, collection.Items);
  }

  [Fact]
  public void CanAddItemsToCollectionWithInt()
  {
    var items = new int[] {37, 62};
    var collection = new DefaultItemCollection<int>(items[0]);
    collection.Add(items[1]);
    Assert.Equal(2, collection.Items.Count());
    Assert.Equal(items, collection.Items);
  }

  [Fact]
  public void CantAddDuplicateItemsToCollectionWithString()
  {
    var item = "somePhoto.jpg";
    var collection = new DefaultItemCollection<string>(item);
    collection.Add(item);
    Assert.Equal(1, collection.Items.Count());
    Assert.Equal(item, collection.Items.First());
  }

  [Fact]
  public void CantAddDuplicateItemsToCollectionWithInt()
  {
    var item = 37;
    var collection = new DefaultItemCollection<int>(item);
    collection.Add(item);
    Assert.Equal(1, collection.Items.Count());
    Assert.Equal(item, collection.Items.First());
  }

  [Fact]
  public void CanRemoveItemFromCollectionWithString()
  {
    var first = "somePhoto.jpg";
    var second = "someOtherPhoto.jpg";
    var album = new DefaultItemCollection<string>(first);
    album.Add(second);
    album.Remove(second);
    Assert.Equal(1, album.Items.Count());
    Assert.Equal(new string[] {first}, album.Items);
  }

  [Fact]
  public void CanRemoveItemFromCollectionWithInt()
  {
    var first = 37;
    var second = 62;
    var album = new DefaultItemCollection<int>(first);
    album.Add(second);
    album.Remove(second);
    Assert.Equal(1, album.Items.Count());
    Assert.Equal(new int[] {first}, album.Items);
  }

  [Fact]
  public void CantRemoveItemInCollectionOfOneItemWithString()
  {
    var item = "somePhoto.jpg";
    var album = new DefaultItemCollection<string>(item);
    Assert.Throws<InvalidOperationException>(() => album.Remove(item));
  }

  [Fact]
  public void CantRemoveItemInCollectionOfOneItemWithInt()
  {
    var item = 37;
    var album = new DefaultItemCollection<int>(item);
    Assert.Throws<InvalidOperationException>(() => album.Remove(item));
  }

  
  [Fact]
  public void WhenRemovingDefaultItemSetDefaultItemToFirstItemInCollectionWithString()
  {
    var items = new string[] { "somePhoto.jpg", "someOtherPhoto.jpg", "someThirdPhoto.jpg" };
    var collection = new DefaultItemCollection<string>(items[0]);
    collection.Add(items[1]);
    collection.Add(items[2]);
    collection.Remove(items[0]);
    Assert.Equal(items[1], collection.DefaultItem);
  }

  [Fact]
  public void WhenRemovingDefaultItemSetDefaultItemToFirstItemInCollectionWithInt()
  {
    var items = new int[] { 37, 62, 4 };
    var collection = new DefaultItemCollection<int>(items[0]);
    collection.Add(items[1]);
    collection.Add(items[2]);
    collection.Remove(items[0]);
    Assert.Equal(items[1], collection.DefaultItem);
  }


  [Fact]
  public void WhenRemovingAnItemThatIsNotTheDefaultItemDefaultItemShouldNotChangeWithString()
  {
    var items = new string[] { "somePhoto.jpg", "someOtherPhoto.jpg", "someThirdPhoto.jpg" };
    var collection = new DefaultItemCollection<string>(items[0]);
    collection.Add(items[1]);
    collection.Add(items[2]);

    var coverPhoto = collection.DefaultItem;

    collection.Remove(items[1]);

    Assert.Equal(coverPhoto, collection.DefaultItem);
  }

  [Fact]
  public void WhenRemovingAnItemThatIsNotTheDefaultItemDefaultItemShouldNotChangeWithInt()
  {
    var items = new int[] { 37, 62, 4 };
    var collection = new DefaultItemCollection<int>(items[0]);
    collection.Add(items[1]);
    collection.Add(items[2]);

    var coverPhoto = collection.DefaultItem;

    collection.Remove(items[1]);

    Assert.Equal(coverPhoto, collection.DefaultItem);
  }



  [Fact]
  public void CanSelectDefaultItemFromCollectionWithString()
  {
    var items = new string[] { "somePhoto.jpg", "someOtherPhoto.jpg", "someThirdPhoto.jpg" };
    var album = new DefaultItemCollection<string>(items[0]);
    album.Add(items[1]);
    album.Add(items[2]);

    Assert.Equal(items[0], album.DefaultItem);
    album.SetDefault(items[1]);
    Assert.Equal(items[1], album.DefaultItem);
  }

  [Fact]
  public void CanSelectDefaultItemFromCollectionWithInt()
  {
    var items = new int[] { 37, 62, 4 };
    var album = new DefaultItemCollection<int>(items[0]);
    album.Add(items[1]);
    album.Add(items[2]);

    Assert.Equal(items[0], album.DefaultItem);
    album.SetDefault(items[1]);
    Assert.Equal(items[1], album.DefaultItem);
  }

  [Fact]
  public void CantSetADefaultItemThatIsNotInCollectionWithString()
  {
    var items = new string[] { "somePhoto.jpg", "someOtherPhoto.jpg", "someThirdPhoto.jpg" };
    var album = new DefaultItemCollection<string>(items[0]);

    Assert.Throws<ArgumentException>(() => album.SetDefault("bigmonkey.jpg"));
  }

  [Fact]
  public void CantSetADefaultItemThatIsNotInCollectionWithInt()
  {
    var items = new int[] { 37, 62, 4 };
    var album = new DefaultItemCollection<int>(items[0]);

    Assert.Throws<ArgumentException>(() => album.SetDefault(999));
  }
}
