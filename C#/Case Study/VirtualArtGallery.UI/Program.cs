using System;
using System.Collections.Generic;
using VirtualArtGallery.Entity;
using VirtualArtGallery.BusinessLayer.Repository;
using VirtualArtGallery.BusinessLayer.Service;
using VirtualArtGallery.BusinessLayer.Exceptions;

namespace VirtualArtGallery.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IVirtualArtGalleryRepository myRepository = new VirtualArtGalleryRepository();
            IVirtualArtGalleryImpl myService = new VirtualArtGalleryImpl(myRepository);

            bool continueRunning = true;

            while (continueRunning)
            {
                try
                {
                    ShowMainMenu();
                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            AddNewArtwork(myService);
                            break;

                        case "2":
                            ModifyArtwork(myService);
                            break;

                        case "3":
                            DeleteArtwork(myService);
                            break;

                        case "4":
                            MarkAsFavorite(myService);
                            break;

                        case "5":
                            UnmarkAsFavorite(myService);
                            break;

                        case "6":
                            DisplayFavorites(myService);
                            break;

                        case "7":
                            SearchForArtworks(myService);
                            break;

                        case "8":
                            FetchArtworkById(myService);
                            break;

                        case "9":
                            continueRunning = false;
                            Console.WriteLine("Closing Virtual Art Gallery. Program");
                            break;

                        default:
                            Console.WriteLine("Invalid option, please try again.");
                            break;
                    }
                }
                catch (ArtWorkNotFoundException ex)
                {
                    Console.WriteLine($"Artwork not found: {ex.Message}");
                }
                catch (UserNotFoundException ex)
                {
                    Console.WriteLine($"User not found: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                }

                if (continueRunning)
                {
                    Console.WriteLine("\nPress any key to return to the main menu...");
                    Console.ReadKey();
                }
            }
        }

        private static void ShowMainMenu()
        {
            Console.WriteLine("===== Virtual Art Gallery =====");
            Console.WriteLine("Select an option to continue:");
            Console.WriteLine("[1] Add New Artwork");
            Console.WriteLine("[2] Edit Existing Artwork");
            Console.WriteLine("[3] Delete an Artwork");
            Console.WriteLine("[4] Add Artwork to Favorites");
            Console.WriteLine("[5] Remove Artwork from Favorites");
            Console.WriteLine("[6] View Your Favorite Artworks");
            Console.WriteLine("[7] Search for Artworks");
            Console.WriteLine("[8] Find Artwork by ID");
            Console.WriteLine("[9] Exit Program");
            Console.WriteLine("------------------------------");
            Console.WriteLine("Enter the number of your choice:");
        }

        private static void AddNewArtwork(IVirtualArtGalleryImpl myService)
        {
            Console.WriteLine("\n--- Add a New Artwork ---");

            Console.Write("Enter Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter Description: ");
            string description = Console.ReadLine();

            Console.Write("Enter Creation Date (YYYY-MM-DD): ");
            DateTime creationDate;
            if (!DateTime.TryParse(Console.ReadLine(), out creationDate))
            {
                Console.WriteLine("Invalid date format. Operation canceled.");
                return;
            }

            Console.Write("Enter Medium (e.g., Digital, Oil): ");
            string medium = Console.ReadLine();

            Console.Write("Enter Image URL: ");
            string imageUrl = Console.ReadLine();

            Console.Write("Enter Artist ID: ");
            int artistID;
            if (!int.TryParse(Console.ReadLine(), out artistID))
            {
                Console.WriteLine("Invalid Artist ID.");
                return;
            }

            Artwork artwork = new Artwork
            {
                Title = title,
                Description = description,
                CreationDate = creationDate,
                Medium = medium,
                ImageURL = imageUrl,
                ArtistID = artistID
            };

            bool added = myService.AddArtwork(artwork);
            Console.WriteLine(added ? "Artwork added successfully!" : "Failed to add artwork.");
        }

        private static void ModifyArtwork(IVirtualArtGalleryImpl myService)
        {
            Console.WriteLine("\n--- Edit Artwork ---");

            Console.Write("Enter Artwork ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int artworkId))
            {
                Console.WriteLine("Invalid Artwork ID.");
                return;
            }

            Console.Write("Enter New Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter New Description: ");
            string description = Console.ReadLine();

            Console.Write("Enter New Creation Date (YYYY-MM-DD): ");
            DateTime creationDate;
            if (!DateTime.TryParse(Console.ReadLine(), out creationDate))
            {
                Console.WriteLine("Invalid date format.");
                return;
            }

            Console.Write("Enter New Medium: ");
            string medium = Console.ReadLine();

            Console.Write("Enter New Image URL: ");
            string imageUrl = Console.ReadLine();

            Artwork updatedArtwork = new Artwork
            {
                ArtworkID = artworkId,
                Title = title,
                Description = description,
                CreationDate = creationDate,
                Medium = medium,
                ImageURL = imageUrl
            };

            bool success = myService.UpdateArtwork(updatedArtwork);
            Console.WriteLine(success ? "Artwork updated!" : "Failed to update artwork.");
        }

        private static void DeleteArtwork(IVirtualArtGalleryImpl myService)
        {
            Console.WriteLine("\n--- Delete Artwork ---");

            Console.Write("Enter Artwork ID: ");
            if (!int.TryParse(Console.ReadLine(), out int artworkId))
            {
                Console.WriteLine("Invalid Artwork ID.");
                return;
            }

            bool deleted = myService.RemoveArtwork(artworkId);
            Console.WriteLine(deleted ? "Artwork successfully deleted." : "Error deleting artwork.");
        }

        private static void MarkAsFavorite(IVirtualArtGalleryImpl myService)
        {
            Console.WriteLine("\n--- Add Artwork to Favorites ---");

            Console.Write("Enter your User ID: ");
            if (!int.TryParse(Console.ReadLine(), out int userId))
            {
                Console.WriteLine("Invalid User ID.");
                return;
            }

            Console.Write("Enter Artwork ID to favorite: ");
            if (!int.TryParse(Console.ReadLine(), out int artworkId))
            {
                Console.WriteLine("Invalid Artwork ID.");
                return;
            }

            bool addedToFavorites = myService.AddArtworkToFavorite(userId, artworkId);
            Console.WriteLine(addedToFavorites ? "Artwork added to your favorites." : "Failed to add artwork to favorites.");
        }

        private static void UnmarkAsFavorite(IVirtualArtGalleryImpl myService)
        {
            Console.WriteLine("\n--- Remove Artwork from Favorites ---");

            Console.Write("Enter your User ID: ");
            if (!int.TryParse(Console.ReadLine(), out int userId))
            {
                Console.WriteLine("Invalid User ID.");
                return;
            }

            Console.Write("Enter Artwork ID to remove: ");
            if (!int.TryParse(Console.ReadLine(), out int artworkId))
            {
                Console.WriteLine("Invalid Artwork ID.");
                return;
            }

            bool removedFromFavorites = myService.RemoveArtworkFromFavorite(userId, artworkId);
            Console.WriteLine(removedFromFavorites ? "Artwork removed from your favorites." : "Failed to remove artwork from favorites.");
        }

        private static void DisplayFavorites(IVirtualArtGalleryImpl myService)
        {
            Console.WriteLine("\n--- Your Favorite Artworks ---");

            Console.Write("Enter your User ID: ");
            if (!int.TryParse(Console.ReadLine(), out int userId))
            {
                Console.WriteLine("Invalid User ID.");
                return;
            }

            List<Artwork> favoriteArtworks = myService.GetUserFavoriteArtworks(userId);

            if (favoriteArtworks.Count == 0)
            {
                Console.WriteLine("You have no favorite artworks.");
            }
            else
            {
                Console.WriteLine("Here are your favorite artworks:");
                foreach (var artwork in favoriteArtworks)
                {
                    Console.WriteLine($"Artwork ID: {artwork.ArtworkID}, Title: {artwork.Title}");
                }
            }
        }

        private static void SearchForArtworks(IVirtualArtGalleryImpl myService)
        {
            Console.WriteLine("\n--- Search for Artworks ---");

            Console.Write("Enter a keyword: ");
            string keyword = Console.ReadLine();

            List<Artwork> searchResults = myService.SearchArtworks(keyword);

            if (searchResults.Count == 0)
            {
                Console.WriteLine("No artworks matched your search.");
            }
            else
            {
                Console.WriteLine("Search Results:");
                foreach (var artwork in searchResults)
                {
                    Console.WriteLine($"Artwork ID: {artwork.ArtworkID}, Title: {artwork.Title}");
                }
            }
        }

        private static void FetchArtworkById(IVirtualArtGalleryImpl myService)
        {
            Console.WriteLine("\n--- Fetch Artwork by ID ---");

            Console.Write("Enter Artwork ID: ");
            if (!int.TryParse(Console.ReadLine(), out int artworkId))
            {
                Console.WriteLine("Invalid Artwork ID.");
                return;
            }

            Artwork artwork = myService.GetArtworkById(artworkId);

            if (artwork != null)
            {
                Console.WriteLine($"ID: {artwork.ArtworkID}");
                Console.WriteLine($"Title: {artwork.Title}");
                Console.WriteLine($"Description: {artwork.Description}");
                Console.WriteLine($"Created On: {artwork.CreationDate}");
                Console.WriteLine($"Medium: {artwork.Medium}");
                Console.WriteLine($"Image URL: {artwork.ImageURL}");
                Console.WriteLine($"Artist ID: {artwork.ArtistID}");
            }
            else
            {
                Console.WriteLine("Artwork not found.");
            }
        }
    }
}
