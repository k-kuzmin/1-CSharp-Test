SELECT 
    p.[Name] as 'ProductName',
    ISNULL(c.[Name], 'No Category') as 'CategoryName'
FROM 
    [Products] p
LEFT JOIN 
    [ProductCategories] pc ON p.[ID] = pc.[ProductID]
LEFT JOIN 
    [Categories] c ON pc.[CategoryID] = c.[ID]
ORDER BY 
    p.[Name], c.[Name];