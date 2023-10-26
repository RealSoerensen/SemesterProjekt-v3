CREATE TABLE [Address] (
	[ID] bigint PRIMARY KEY IDENTITY(1, 1),
	[zip] varchar(50),
	[houseNumber] varchar(10),
	[city] varchar(50),
	[street] varchar(50)
);

CREATE TABLE [Customer] (
	[ID] bigint PRIMARY KEY IDENTITY(1,1),
	[firstName] varchar(50),
	[lastName] varchar(50),
	[addressID] bigint FOREIGN KEY REFERENCES [Address](ID),
	[email] varchar(50),
	[phoneNo] varchar(50),
	[password] varchar(30),
	[registerDate] datetime2,
);

CREATE TABLE [Order] (
	[date] datetime,
	[ID] bigint PRIMARY KEY IDENTITY(1, 1),
	[customerEmail] varchar(50),
);

CREATE TABLE [Product] (
	[ID] bigint PRIMARY KEY IDENTITY(1,1),
	[description] varchar(1000),
	[image] NVARCHAR(MAX),
	[salePrice] money,
	[purchasePrice] money,
	[normalPrice] money,
	[name] varchar(50),
	[stock] bigint,
	[brand] varchar(100),
	[category] int,
);

CREATE TABLE [Orderline] (
	[quantity] int,
	[priceAtTimeOfOrder] money,
	[productID] bigint FOREIGN KEY REFERENCES [Product](ID),
	[orderID] bigint FOREIGN KEY REFERENCES [Order](ID),

	PRIMARY KEY([productID], [orderID]),
);

GO
