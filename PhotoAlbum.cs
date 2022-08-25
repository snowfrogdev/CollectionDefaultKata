namespace CollectionDefaultKata
{
  public class PhotoAlbum
  {
    public string CoverPhoto { get; private set; }

    private List<string> _photos = new();

    public IEnumerable<string> Photos
    {
        get => _photos;
        private set => _photos = value.ToList();
    }

    public PhotoAlbum(string coverPhoto)
    {
      CoverPhoto = coverPhoto;
      Add(coverPhoto);
    }

    public void Add(string photo)
    {
      _photos.Add(photo);
    }

    public void Remove(string photo)
    {
      _photos.Remove(photo);
    }
  }
}