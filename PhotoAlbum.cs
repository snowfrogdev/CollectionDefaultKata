namespace CollectionDefaultKata;

public class PhotoAlbum
{
  public string CoverPhoto { get; private set; }

  private List<string> _photos = new();

  public IEnumerable<string> Photos
  {
    get => _photos;
  }

  public PhotoAlbum(string coverPhoto)
  {
    CoverPhoto = coverPhoto;
    Add(coverPhoto);
  }

  public void Add(string photo)
  {
    if (_photos.Contains(photo)) return;
    _photos.Add(photo);
  }

  public void Remove(string photo)
  {
    if(_photos.Count() == 1)
    {
      throw new InvalidOperationException("Cannot remove the only photo in the album");
    }

    _photos.Remove(photo);

    if(CoverPhoto == photo)
    {
      CoverPhoto = _photos.First();
    }
  }

  public void SetCover(string photo)
  {
    if (!_photos.Contains(photo))
    {
      throw new ArgumentException("Photo not found in album");
    }

    CoverPhoto = photo;
  }
}
