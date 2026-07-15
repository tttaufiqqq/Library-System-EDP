SELECT Book_Title, Author, COUNT(*) as cnt
FROM Books
GROUP BY Book_Title, Author
HAVING COUNT(*) > 1;