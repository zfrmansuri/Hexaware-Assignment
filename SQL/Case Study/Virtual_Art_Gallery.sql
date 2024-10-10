CREATE DATABASE VirtualArtGalleryDB;USE VirtualArtGalleryDB;

CREATE TABLE Artwork (
    ArtworkID INT PRIMARY KEY IDENTITY(1,1),
    Title VARCHAR(255) NOT NULL,
    Description VARCHAR(255),
    CreationDate DATE,
    Medium VARCHAR(100),
    ImageURL VARCHAR(255),
    ArtistID INT,
    FOREIGN KEY (ArtistID) REFERENCES Artist(ArtistID)
);

CREATE TABLE Artist (
    ArtistID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(255) NOT NULL,
    Biography VARCHAR(255),
    BirthDate DATE,
    Nationality VARCHAR(100),
    Website VARCHAR(255),
    ContactInformation VARCHAR(255)
);

CREATE TABLE [User] (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(50) UNIQUE NOT NULL,
    Password VARCHAR(255) NOT NULL,
    Email VARCHAR(255) UNIQUE NOT NULL,
    FirstName VARCHAR(100),
    LastName VARCHAR(100),
    DateOfBirth DATE,
    ProfilePicture VARCHAR(255)
);

CREATE TABLE Gallery (
    GalleryID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(255) NOT NULL,
    Description VARCHAR(255),
    Location VARCHAR(255),
    Curator INT,
    OpeningHours VARCHAR(100),
    FOREIGN KEY (Curator) REFERENCES Artist(ArtistID) 
);

CREATE TABLE User_Favorite_Artwork (
    UserID INT,
    ArtworkID INT,
    PRIMARY KEY (UserID, ArtworkID),
    FOREIGN KEY (UserID) REFERENCES [User](UserID) ,
    FOREIGN KEY (ArtworkID) REFERENCES Artwork(ArtworkID) 
);

CREATE TABLE Artwork_Gallery (
    ArtworkID INT,
    GalleryID INT,
    PRIMARY KEY (ArtworkID, GalleryID),
    FOREIGN KEY (ArtworkID) REFERENCES Artwork(ArtworkID) ,
    FOREIGN KEY (GalleryID) REFERENCES Gallery(GalleryID) 
);


--Populating Artist Table
INSERT INTO Artist (Name, Biography, BirthDate, Nationality, Website, ContactInformation)
VALUES 
('Ravi Kumar', 'Contemporary Indian painter', '1980-07-10', 'Indian', 'https://ravikumarart.com', 'ravi@ravikumarart.com'),
('Priya Mehta', 'Modern abstract artist from India', '1985-03-22', 'Indian', 'https://priyamehtaart.com', 'priya@mehtaart.com'),
('Sanjay Patel', 'Landscape painter with a focus on Indian scenery', '1975-09-12', 'Indian', 'https://sanjaypatelart.com', 'sanjay@patelart.com'),
('Anjali Rao', 'Renowned for traditional Indian art', '1990-11-01', 'Indian', 'https://anjaliraoart.com', 'anjali@raoart.com'),
('Rakesh Singh', 'Digital artist creating futuristic designs', '1992-05-17', 'Indian', 'https://rakeshsinghart.com', 'rakesh@singhart.com');


--Populating Artwork Table
INSERT INTO Artwork (Title, Description, CreationDate, Medium, ImageURL, ArtistID)
VALUES 
('Sunset in Kerala', 'A vibrant landscape painting of a Kerala sunset', '2020-05-15', 'Oil on Canvas', 'https://imageurl.com/sunsetkerala', 3),
('Abstract Dreams', 'Modern abstract painting by Priya Mehta', '2019-08-30', 'Acrylic on Canvas', 'https://imageurl.com/abstractdreams', 2),
('City Lights', 'Digital representation of a futuristic city', '2022-01-10', 'Digital', 'https://imageurl.com/citylights', 5),
('Peacock Dance', 'Traditional Indian painting of a dancing peacock', '2018-03-15', 'Watercolor', 'https://imageurl.com/peacockdance', 4),
('Golden Temple', 'Depiction of the Golden Temple at sunset', '2021-07-05', 'Oil on Canvas', 'https://imageurl.com/goldentemple', 1);


--Populating User Table
INSERT INTO [User] (Username, Password, Email, FirstName, LastName, DateOfBirth, ProfilePicture)
VALUES 
('vishal_patel', 'pass123', 'vishal.patel@example.com', 'Vishal', 'Patel', '1992-12-05', 'https://profilepic.com/vishal'),
('meera_verma', 'pass456', 'meera.verma@example.com', 'Meera', 'Verma', '1988-04-10', 'https://profilepic.com/meera'),
('rahul_gupta', 'pass789', 'rahul.gupta@example.com', 'Rahul', 'Gupta', '1990-09-22', 'https://profilepic.com/rahul'),
('deepa_kapoor', 'pass987', 'deepa.kapoor@example.com', 'Deepa', 'Kapoor', '1995-06-18', 'https://profilepic.com/deepa'),
('anil_singh', 'pass654', 'anil.singh@example.com', 'Anil', 'Singh', '1985-01-30', 'https://profilepic.com/anil');


--Populating Gallery Table
INSERT INTO Gallery (Name, Description, Location, Curator, OpeningHours)
VALUES 
('Art House', 'Simple gallery showcasing modern works', 'Mumbai', 1, '10:00 AM - 5:00 PM'),
('Color Palette', 'Gallery with vibrant contemporary paintings', 'Delhi', 2, '9:00 AM - 6:00 PM'),
('Urban Arts', 'Digital art collection from various artists', 'Bangalore', 5, '11:00 AM - 4:00 PM'),
('Nature Arts', 'Focused on nature-themed art', 'Chennai', 3, '10:00 AM - 4:00 PM'),
('Cultural Heritage', 'Gallery featuring traditional Indian art', 'Kolkata', 4, '9:00 AM - 3:00 PM');


--Populating User_Favorite_Artwork Table
INSERT INTO User_Favorite_Artwork (UserID, ArtworkID)
VALUES 
(1, 3), -- Vishal Patel likes City Lights
(2, 1), -- Meera Verma likes Sunset in Kerala
(3, 5), -- Rahul Gupta likes Golden Temple
(4, 4), -- Deepa Kapoor likes Peacock Dance
(5, 2); -- Anil Singh likes Abstract Dreams


--Polulating Artwork_Gallery Table
INSERT INTO Artwork_Gallery (ArtworkID, GalleryID)
VALUES 
(1, 4), -- Sunset in Kerala in Nature Arts
(2, 2), -- Abstract Dreams in Color Palette
(3, 3), -- City Lights in Urban Arts
(4, 5), -- Peacock Dance in Cultural Heritage
(5, 1); -- Golden Temple in Art House


--View Artist Table
SELECT * FROM Artist;

--View Artwork Table
SELECT * FROM Artwork;

--View User Table
SELECT * FROM [User];

--View Gallery Table
SELECT * FROM Gallery;

--View User_Favorite_Artwork Table
SELECT * FROM User_Favorite_Artwork;

--View  Artwork_Gallery Table
SELECT * FROM Artwork_Gallery;





