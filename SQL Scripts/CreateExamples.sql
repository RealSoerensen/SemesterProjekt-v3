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
('78901', '2I', 'Denver', 'Spruce St');

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
('Sophia', 'Harris', 10, 'sophia.h@example.com', '555-321-6547', 'sophia789', '2023-10-26 19:45:32');

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
('2023-10-26 09:45:15', 'sophia.h@example.com');

-- Insert Example Records into Product Table
INSERT INTO [Product] ([description], [salePrice], [purchasePrice], [normalPrice], [name], [stock], [brand], [category]) VALUES
('Premium Padel Racket with Carbon Frame', 199.99, 159.99, 229.99, 'Carbon Racket', 30, 'Padel Pro', 1),
('Padel Shoes with Non-Marking Sole', 79.99, 64.99, 99.99, 'Padel Shoes', 100, 'Sporty Feet', 2),
('Padel Balls - Pack of 3', 14.99, 12.99, 19.99, 'Padel Balls', 500, 'BounceMaster', 3),
('Lightweight Padel Bag with Multiple Compartments', 49.99, 39.99, 59.99, 'Padel Bag', 50, 'GearMaster', 4),
('Padel Grip Overgrip Tape - Pack of 3', 9.99, 7.99, 12.99, 'Overgrip Tape', 200, 'GripPro', 5),
('Padel Court Net Set', 179.99, 149.99, 199.99, 'Court Net Set', 20, 'NetMaster', 6),
('Premium Padel Cap', 19.99, 16.99, 24.99, 'Padel Cap', 150, 'HeadSpin', 7),
('Padel Sunglasses with UV Protection', 39.99, 29.99, 49.99, 'Padel Sunglasses', 80, 'SunShield', 8),
('Padel Elbow Support Brace', 24.99, 19.99, 29.99, 'Elbow Brace', 100, 'JointGuard', 9),
('Padel Training Cones - Set of 10', 19.99, 15.99, 24.99, 'Training Cones', 75, 'SpeedPro', 10);

-- Insert Example Records into Orderline Table
INSERT INTO [Orderline] ([quantity], [priceAtTimeOfOrder], [productID], [orderID]) VALUES
(2, 199.99, 1, 1),
(1, 79.99, 2, 2),
(3, 14.99, 3, 3),
(2, 49.99, 4, 4),
(1, 9.99, 5, 5),
(1, 179.99, 6, 6),
(4, 19.99, 7, 7),
(2, 39.99, 8, 8),
(1, 24.99, 9, 9),
(2, 19.99, 10, 10);
