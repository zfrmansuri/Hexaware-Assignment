using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using VirtualArtGallery.BusinessLayer.Repository;
using VirtualArtGallery.BusinessLayer.Service;
using VirtualArtGallery.Entity;
using VirtualArtGallery.BusinessLayer.Exceptions;

namespace VirtualArtGallery.Testing
{
    [TestFixture]
    public class TestingArtwork 
    {
        VirtualArtGalleryRepository virtualArtGalleryRepository;

        [SetUp]
        public void initialiazation()
        {
            virtualArtGalleryRepository = new VirtualArtGalleryRepository();
        }

        // a. Test the ability to upload a new artwork to the gallery.
        [Test]
        public void UploadArtworkTest()
        {
            var result = virtualArtGalleryRepository.AddArtwork(new Artwork()
            {
                Title = "Sample Artwork",
                Description = "This is a Sample artwork description.",
                CreationDate = DateTime.Now,
                Medium = "Digital",
                ImageURL = "test/image.com",
                ArtistID = 1
            });
            Assert.IsTrue(result);
            Assert.That(result, Is.Not.Null);

        }

        // b. Verify that updating artwork details works correctly.
        [Test]
        public void UpdateArtworkTest()
        {
            var result = virtualArtGalleryRepository.UpdateArtwork(new Artwork()
            {
                ArtworkID = 4,
                Title = "Updated Artwork",
                Description = "Updated Artwork Description",
                CreationDate = DateTime.Now,
                Medium = "Pastel",
                ImageURL = "sample.com",
                ArtistID = 2
            });
            Assert.That(result, Is.True);
        }

        // c. Test removing an artwork from the gallery.  Not working 
        [Test]
        public void RemoveArtworkTest()
        {
            var result = virtualArtGalleryRepository.RemoveArtwork(1);  // Assuming artworkID = 1 exists
            Assert.IsTrue(result, "Artwork should be successfully removed.");
        }

        // d. Check if searching for artworks returns the expected results.
        [Test]
        public void SearchArtworkTest()
        {
            var searchResults = virtualArtGalleryRepository.SearchArtworks("City Lights");
            Assert.IsNotNull(searchResults, "Search results should not be null.");
            Assert.IsTrue(searchResults.Count > 0, "At least one artwork should match the search query.");
            Assert.IsTrue(searchResults[0].Title.Contains("City Lights"), "Search result title should contain 'City Lights'.");
        }

        [TearDown]
        public void TearDown()
        {

        }
    }  
}



