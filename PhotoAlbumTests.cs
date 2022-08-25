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
  public void CantAddDuplicatePhotosToAlbum()
  {
    var photo = "somePhoto.jpg";
    var album = new PhotoAlbum(photo);
    album.Add(photo);
    Assert.Equal(1, album.Photos.Count());
    Assert.Equal(photo, album.Photos.First());
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

  [Fact]
  public void CantRemovePhotoInAlbumOfWithOnlyOnePhoto()
  {
    var photo = "somePhoto.jpg";
    var album = new PhotoAlbum(photo);
    Assert.Throws<InvalidOperationException>(() => album.Remove(photo));
  }

  [Fact]
  public void CanSelectCoverPhotoFromAlbum()
  {
    var photos = new string[] { "somePhoto.jpg", "someOtherPhoto.jpg", "someThirdPhoto.jpg" };
    var album = new PhotoAlbum(photos[0]);
    album.Add(photos[1]);
    album.Add(photos[2]);

    Assert.Equal(photos[0], album.CoverPhoto);
    album.SetCover(photos[1]);
    Assert.Equal(photos[1], album.CoverPhoto);
  }

  [Fact]
  public void CantSetACoverPhotoThatIsNotInAlbum()
  {
    var photos = new string[] { "somePhoto.jpg", "someOtherPhoto.jpg", "someThirdPhoto.jpg" };
    var album = new PhotoAlbum(photos[0]);

    Assert.Throws<ArgumentException>(() => album.SetCover("bigmonkey.jpg"));
  }
}