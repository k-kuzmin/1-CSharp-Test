CREATE TABLE [Products] (
    [ID] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    [Name] NVARCHAR(100) NOT NULL
);


CREATE TABLE [Categories] (
    [ID] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    [Name] NVARCHAR(100) NOT NULL
);


CREATE TABLE [ProductCategories] (
    [ProductID] UNIQUEIDENTIFIER NOT NULL,
    [CategoryID] UNIQUEIDENTIFIER NOT NULL,
	CONSTRAINT [PK_ProductCategory] PRIMARY KEY ([ProductID], [CategoryID]),
    CONSTRAINT [FK_Product] FOREIGN KEY ([ProductID]) REFERENCES [Products]([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Category] FOREIGN KEY ([CategoryID]) REFERENCES [Categories]([ID]) ON DELETE CASCADE
);


INSERT INTO Products ([ID], [Name])
VALUES 
    (NEWID(), 'Laptop'),
    (NEWID(), 'Smartphone'),
    (NEWID(), 'Tablet');


INSERT INTO Categories ([ID], [Name])
VALUES 
    (NEWID(), 'Electronics'),
    (NEWID(), 'Gadgets'),
    (NEWID(), 'Accessories');


DECLARE @LaptopID UNIQUEIDENTIFIER = (SELECT [ID] FROM Products WHERE [Name] = 'Laptop');
DECLARE @SmartphoneID UNIQUEIDENTIFIER = (SELECT [ID] FROM Products WHERE [Name] = 'Smartphone');
-- DECLARE @TabletID UNIQUEIDENTIFIER = (SELECT [ID] FROM Products WHERE [Name] = 'Tablet');

DECLARE @ElectronicsID UNIQUEIDENTIFIER = (SELECT [ID] FROM Categories WHERE [Name] = 'Electronics');
DECLARE @GadgetsID UNIQUEIDENTIFIER = (SELECT [ID] FROM Categories WHERE [Name] = 'Gadgets');
DECLARE @AccessoriesID UNIQUEIDENTIFIER = (SELECT [ID] FROM Categories WHERE [Name] = 'Accessories');


INSERT INTO ProductCategories (ProductID, CategoryID)
VALUES
    (@LaptopID, @ElectronicsID),
    (@LaptopID, @GadgetsID),
    (@SmartphoneID, @ElectronicsID),
    (@SmartphoneID, @AccessoriesID);