-- This is a comment

SELECT Band.name, Album.title, Album.release_date 
FROM Album
INNER JOIN Band ON Band.id = Album.band
WHERE Album.title LIKE '%up%';

SELECT Band.name, Album.title, Album.release_date 
FROM Album
INNER JOIN Band ON Band.id = Album.band
WHERE Band.name = 'NOFX';