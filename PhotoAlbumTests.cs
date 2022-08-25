namespace CollectionDefaultKata;

public class PhotoAlbumTests
{
  [Fact]
  public void CanCreateNewAlbum()
  {
    var album = new PhotoAlbum("somePhoto.jpg");
    Assert.NotNull(album);
  }

  [Fact]
  public void MustHavePhotoOnCreation()
  {
    var photo = "somePhoto.jpg";
    var album = new PhotoAlbum(photo);
    Assert.Equal(photo, album.CoverPhoto);
  }

  [Fact]
  public void CanAddPhotosToAlbum()
  {
    var photos = new string[] { "somePhoto.jpg", "someOtherPhoto.jpg" };
    var album = new PhotoAlbum(photos[0]);
    album.Add(photos[1]);
    Assert.Equal(2, album.Photos.Count());
    Assert.Equal(photos, album.Photos);
  }

  [Fact]
  public void CanRemovePhotosFromAlbum()
  {
    var photos = new string[] { "somePhoto.jpg", "someOtherPhoto.jpg" };
    var album = new PhotoAlbum(photos[0]);
    album.Add(photos[1]);
    album.Remove(photos[1]);
    Assert.Equal(1, album.Photos.Count());
    Assert.Equal(new string[] {photos[0]}, album.Photos);
  }
}