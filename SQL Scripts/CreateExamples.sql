-- Inserting Addresses
INSERT INTO [Address] ([zip], [houseNumber], [city], [street])
SELECT TOP 25
    'Zip' + CAST(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS VARCHAR(10)),
    'House ' + CAST(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS VARCHAR(10)),
    'City' + CAST(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS VARCHAR(10)),
    'Street' + CAST(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS VARCHAR(10))
FROM sys.objects;

-- Inserting Customers
INSERT INTO [Customer] ([firstName], [lastName], [addressID], [email], [phoneNo], [password], [registerDate])
SELECT TOP 25
    'First' + CAST(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS VARCHAR(10)),
    'Last' + CAST(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS VARCHAR(10)),
    ID,
    'email' + CAST(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS VARCHAR(10)) + '@example.com',
    '123-456-7890',
    'password' + CAST(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS VARCHAR(10)),
    GETDATE()
FROM [Address];

-- Inserting Products
INSERT INTO [Product] ([description], [image], [salePrice], [purchasePrice], [normalPrice], [name], [stock], [brand], [category])
SELECT TOP 50
    'Description' + CAST(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS VARCHAR(10)),
    'ImageURL' + CAST(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS VARCHAR(10)),
    CAST(10 + (ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) % 10) AS MONEY),
    CAST(5 + (ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) % 5) AS MONEY),
    CAST(10 + (ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) % 10) AS MONEY),
    'Product' + CAST(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS VARCHAR(10)),
    CAST(100 + (ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) % 50) AS BIGINT),
    'Brand' + CAST(ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS VARCHAR(10)),
    (ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) % 10) + 1
FROM sys.objects;

-- Inserting Orders and Orderlines
DECLARE @CustomerID BIGINT;
DECLARE @OrderID BIGINT;
DECLARE @ProductID BIGINT;

DECLARE @RandomOrderLineCount INT;
DECLARE @RandomProductCount INT;

DECLARE @OrderLineCounter INT;

SET @CustomerID = 1;
WHILE @CustomerID <= 25
BEGIN
    SET @OrderID = 1;
    WHILE @OrderID <= 5
    BEGIN
        -- Insert Orders
        INSERT INTO [Order] ([date], [customerID])
        VALUES (GETDATE(), @CustomerID);

        -- Generate a random number of orderlines (1-5) for each order
        SET @RandomOrderLineCount = (ABS(CHECKSUM(NEWID())) % 5) + 1;
        SET @OrderLineCounter = 1;

        WHILE @OrderLineCounter <= @RandomOrderLineCount
        BEGIN
            -- Insert Orderlines
            SET @RandomProductCount = (ABS(CHECKSUM(NEWID())) % 50) + 1;
            SET @ProductID = @RandomProductCount;
            
            INSERT INTO [Orderline] ([quantity], [priceAtTimeOfOrder], [productID], [orderID])
            VALUES (
                (ABS(CHECKSUM(NEWID())) % 5) + 1,
                (SELECT [purchasePrice] FROM [Product] WHERE [ID] = @ProductID),
                @ProductID,
                IDENT_CURRENT('[Order]')
            );
            
            SET @OrderLineCounter = @OrderLineCounter + 1;
        END

        SET @OrderID = @OrderID + 1;
    END

    SET @CustomerID = @CustomerID + 1;
END
