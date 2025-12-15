CREATE PROCEDURE GetOrdersPaged
    @Filter NVARCHAR(100),
    @Offset INT,
    @PageSize INT
AS
BEGIN
    SELECT o.Id, o.ClientId, o.CreatedAt, o.ModifiedAt
    FROM Orders o
    INNER JOIN Clients c ON o.ClientId = c.Id
    WHERE (@Filter IS NULL OR c.Name LIKE '%' + @Filter + '%')
    ORDER BY o.Id
    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;

    SELECT COUNT(*)
    FROM Orders o
    INNER JOIN Clients c ON o.ClientId = c.Id
    WHERE (@Filter IS NULL OR c.Name LIKE '%' + @Filter + '%');
END