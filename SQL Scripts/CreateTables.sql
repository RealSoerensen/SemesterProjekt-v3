CREATE TABLE [Address] (
	[ID] bigint PRIMARY KEY IDENTITY(1, 1),
	[zipCode] varchar(50),
	[houseNumber] varchar(10),
	[city] varchar(50),
	[street] varchar(50)
);

CREATE TABLE [Customer] (
	[firstName] varchar(50),
	[lastName] varchar(50),
	[addressID] bigint FOREIGN KEY REFERENCES [Address](ID),
	[email] varchar(50) PRIMARY KEY,
	[phoneNo] varchar(50),
	[password] varchar(30),
	[registerDate] datetime2,
);

CREATE TABLE [Order] (
	[date] datetime,
	[ID] bigint PRIMARY KEY IDENTITY(1, 1),
	[customerEmail] varchar(50),
	[totalPrice] money,
	[discount] int,
);

CREATE TABLE [ProductDescription] (
	[ID] bigint PRIMARY KEY IDENTITY(1, 1),
	[description] varchar(1000),
	[image] image,
	[price] money,
	[name] varchar(50),
	[stock] bigint,

);

CREATE TABLE [Product] (
	[ProductDescriptionID] bigint FOREIGN KEY REFERENCES [ProductDescription](ID),
	[productSN] bigint PRIMARY KEY IDENTITY(1, 1),
);

CREATE TABLE [Orderline] (
	[quantity] int,
	[productSN] bigint FOREIGN KEY REFERENCES [Product](productSN),
	[orderID] bigint FOREIGN KEY REFERENCES [Order](ID),
	PRIMARY KEY([productSN], [orderID]),
);

GO
