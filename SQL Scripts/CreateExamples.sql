-- Insert Example Records into Address Table
INSERT INTO [Address] ([zip], [houseNumber], [city], [street]) VALUES
('12345', '10A', 'New York', 'Main St'),
('54321', '5B', 'Los Angeles', 'Elm St'),
('98765', '22', 'Chicago', 'Oak St'),
('43210', '15C', 'San Francisco', 'Market St'),
('56789', '8D', 'Miami', 'Ocean Ave'),
('34567', '3E', 'Houston', 'Maple St'),
('87654', '7F', 'Seattle', 'Pine St'),
('23456', '14G', 'Boston', 'Cedar St'),
('65432', '11H', 'Dallas', 'Cherry Ave'),
('78901', '2I', 'Denver', 'Spruce St'),
('11223', '9J', 'Austin', 'Palm Ave');

-- Insert Example Records into Customer Table
INSERT INTO [Customer] ([firstName], [lastName], [addressID], [email], [phoneNo], [password], [registerDate]) VALUES
('John', 'Doe', 1, 'john.doe@email.com', '555-123-4567', 'password123', '2023-10-25 12:34:56'),
('Jane', 'Smith', 2, 'jane.smith@email.com', '555-987-6543', 'securepass', '2023-10-25 13:45:32'),
('Michael', 'Johnson', 3, 'michael.j@example.com', '555-456-7890', 'mikepass', '2023-10-26 09:12:34'),
('Emily', 'Brown', 4, 'emily.b@example.com', '555-876-5432', 'pass1234', '2023-10-26 10:23:45'),
('David', 'Wilson', 5, 'david.w@email.com', '555-234-5678', 'davidpass', '2023-10-26 11:34:56'),
('Lisa', 'Lee', 6, 'lisa.l@email.com', '555-765-4321', 'lisa123', '2023-10-26 14:45:32'),
('Robert', 'Martinez', 7, 'robert.m@email.com', '555-123-9876', 'robpass', '2023-10-25 15:12:34'),
('Olivia', 'Garcia', 8, 'olivia.g@example.com', '555-654-3210', 'olivia456', '2023-10-25 16:23:45'),
('William', 'Taylor', 9, 'william.t@example.com', '555-987-1234', 'willpass', '2023-10-26 18:34:56'),
('Sophia', 'Harris', 10, 'sophia.h@example.com', '555-321-6547', 'sophia789', '2023-10-26 19:45:32'),
('Daniel', 'Clark', 11, 'daniel.c@example.com', '555-789-3210', 'danielpass', '2023-10-25 20:56:43');

-- Insert Example Records into Order Table
INSERT INTO [Order] ([date], [customerEmail]) VALUES
('2023-10-25 09:30:15', 'john.doe@email.com'),
('2023-10-25 10:45:30', 'jane.smith@email.com'),
('2023-10-25 12:15:45', 'michael.j@example.com'),
('2023-10-25 14:20:00', 'emily.b@example.com'),
('2023-10-26 08:45:30', 'david.w@email.com'),
('2023-10-26 10:00:15', 'lisa.l@email.com'),
('2023-10-26 11:30:45', 'robert.m@email.com'),
('2023-10-25 15:00:00', 'olivia.g@example.com'),
('2023-10-26 08:15:30', 'william.t@example.com'),
('2023-10-26 09:45:15', 'sophia.h@example.com'),
('2023-10-25 17:30:30', 'daniel.c@example.com');

-- Insert Example Records into Product Table
INSERT INTO [Product] ([description], [salePrice], [purchasePrice], [normalPrice], [name], [stock], [brand]) VALUES
('Laptop computer with 15-inch screen', 899.99, 799.99, 999.99, 'Laptop 15', 50, 'Brand X'),
('Smartphone with 6.2-inch display', 499.99, 399.99, 599.99, 'Phone 6.2', 100, 'Brand Y'),
('Wireless Bluetooth headphones', 79.99, 59.99, 99.99, 'Headphones', 200, 'Brand Z'),
('55-inch 4K Ultra HD Smart TV', 799.99, 699.99, 899.99, 'TV 55', 30, 'Brand X'),
('Digital camera with 24MP sensor', 349.99, 299.99, 399.99, 'Camera 24MP', 75, 'Brand Y'),
('Coffee maker with timer function', 49.99, 39.99, 59.99, 'Coffee Maker', 150, 'Brand A'),
('Stainless steel refrigerator', 999.99, 899.99, 1099.99, 'Fridge SS', 25, 'Brand B'),
('Gaming console with 1TB storage', 399.99, 349.99, 449.99, 'Console 1TB', 40, 'Brand C'),
('Cordless vacuum cleaner', 129.99, 109.99, 149.99, 'Vacuum Cleaner', 60, 'Brand D'),
('Microwave oven with convection', 149.99, 129.99, 169.99, 'Microwave', 55, 'Brand E');

-- Insert Example Records into Orderline Table
INSERT INTO [Orderline] ([quantity], [priceAtTimeOfOrder], [productID], [orderID]) VALUES
(2, 499.99, 1, 1),
(1, 79.99, 3, 2),
(3, 799.99, 4, 3),
(2, 349.99, 5, 4),
(1, 49.99, 6, 5),
(1, 999.99, 7, 6),
(4, 399.99, 8, 7),
(2, 129.99, 9, 8),
(1, 149.99, 10, 9),
(2, 899.99, 1, 10);
