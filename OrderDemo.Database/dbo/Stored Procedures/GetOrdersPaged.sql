CREATE PROCEDURE GetOrdersPaged
    @Filter NVARCHAR(100),
    @Offset INT,
    @PageSize INT,
    @SortColumn NVARCHAR(50),
    @SortDirection NVARCHAR(4)
AS
BEGIN
    SELECT o.Id, o.ClientId, o.CreatedAt, o.ModifiedAt
    FROM Orders o
    INNER JOIN Clients c ON o.ClientId = c.Id
    WHERE (@Filter IS NULL OR c.Name LIKE '%' + @Filter + '%')
    ORDER BY
        CASE WHEN @SortColumn = 'Id' AND @SortDirection = 'ASC' THEN o.Id END ASC,
        CASE WHEN @SortColumn = 'Id' AND @SortDirection = 'DESC' THEN o.Id END DESC,
        CASE WHEN @SortColumn = 'ClientId' AND @SortDirection = 'ASC' THEN o.ClientId END ASC,
        CASE WHEN @SortColumn = 'ClientId' AND @SortDirection = 'DESC' THEN o.ClientId END DESC,
        CASE WHEN @SortColumn = 'CreatedAt' AND @SortDirection = 'ASC' THEN o.CreatedAt END ASC,
        CASE WHEN @SortColumn = 'CreatedAt' AND @SortDirection = 'DESC' THEN o.CreatedAt END DESC,
        CASE WHEN @SortColumn = 'ModifiedAt' AND @SortDirection = 'ASC' THEN o.ModifiedAt END ASC,
        CASE WHEN @SortColumn = 'ModifiedAt' AND @SortDirection = 'DESC' THEN o.ModifiedAt END DESC,
        o.Id ASC -- Fallback, damit Reihenfolge immer eindeutig ist
    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;

    SELECT COUNT(*)
    FROM Orders o
    INNER JOIN Clients c ON o.ClientId = c.Id
    WHERE (@Filter IS NULL OR c.Name LIKE '%' + @Filter + '%');
END