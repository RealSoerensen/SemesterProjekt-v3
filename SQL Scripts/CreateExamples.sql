-- Insert into [Address] table
INSERT INTO [Address] ([zip], [houseNumber], [city], [street])
VALUES
    ('12345', '123', 'New York', 'Main Street'),
    ('54321', '456', 'Los Angeles', 'Broadway'),
    ('98765', '789', 'Chicago', 'Elm Street'),
    ('45678', '101', 'San Francisco', 'Market Street'),
    ('23456', '202', 'Houston', 'Oak Avenue'),
    ('78901', '303', 'Miami', 'Ocean Drive'),
    ('34567', '404', 'Dallas', 'Pine Street'),
    ('87654', '505', 'Seattle', 'Lake Avenue'),
    ('65432', '606', 'Boston', 'Harbor Road'),
    ('21098', '707', 'Austin', 'Sunset Boulevard');

-- Insert into [Customer] table
INSERT INTO [Customer] ([firstName], [lastName], [addressID], [email], [phoneNo], [password], [registerDate])
VALUES
    ('John', 'Doe', 1, 'johndoe@email.com', '123-456-7890', 'password123', '2023-10-26 12:00:00'),
    ('Jane', 'Smith', 2, 'janesmith@email.com', '987-654-3210', 'securepass', '2023-10-26 13:30:00'),
    ('Mike', 'Johnson', 3, 'mike@email.com', '111-222-3333', 'mikepass', '2023-10-26 14:45:00'),
    ('Emily', 'Wilson', 4, 'emily@email.com', '444-555-6666', 'emilypass', '2023-10-26 16:20:00'),
    ('David', 'Lee', 5, 'david@email.com', '777-888-9999', 'davidpass', '2023-10-26 18:10:00'),
    ('Sarah', 'Adams', 6, 'sarah@email.com', '123-987-4567', 'sarahpass', '2023-10-26 19:55:00'),
    ('Chris', 'Brown', 7, 'chris@email.com', '555-444-3333', 'chrispass', '2023-10-26 21:30:00'),
    ('Linda', 'Taylor', 8, 'linda@email.com', '999-888-7777', 'lindapass', '2023-10-26 23:15:00'),
    ('Ryan', 'Miller', 9, 'ryan@email.com', '111-555-9999', 'ryanpass', '2023-10-27 01:00:00'),
    ('Olivia', 'Martinez', 10, 'olivia@email.com', '111-333-7777', 'oliviapass', '2023-10-27 03:45:00');

-- Insert into [Order] table
INSERT INTO [Order] ([date], [customerID])
VALUES
    ('2023-10-26 14:30:00', 1),
    ('2023-10-26 15:15:00', 2),
    ('2023-10-26 17:00:00', 3),
    ('2023-10-26 18:45:00', 4),
    ('2023-10-26 20:30:00', 5),
    ('2023-10-26 22:15:00', 6),
    ('2023-10-26 23:59:59', 7),
    ('2023-10-27 01:45:00', 8),
    ('2023-10-27 03:30:00', 9),
    ('2023-10-27 05:15:00', 10);

-- Insert into [Product] table with NULL image and realistic-sounding names and brands
INSERT INTO [Product] ([description], [image], [salePrice], [purchasePrice], [normalPrice], [name], [stock], [brand], [category])
VALUES
    ('ProLine Carbon Padel Racket', NULL, 189.99, 130.00, 209.99, 'ProLine Carbon Padel Racket', 50, 'Wilson', 0), -- Category: Bats
    ('Elite Padel Bat II', NULL, 159.99, 120.00, 179.99, 'Elite Padel Bat II', 45, 'Head', 0), -- Category: Bats
    ('Adidas Padel Pro Shoes', NULL, 79.99, 50.00, 89.99, 'Adidas Padel Pro Shoes', 80, 'Adidas', 1), -- Category: Shoes
    ('Asics Padel X-Tech Shoes', NULL, 89.99, 60.00, 99.99, 'Asics Padel X-Tech Shoes', 75, 'Asics', 1), -- Category: Shoes
    ('Padel Balls (Pack of 3)', NULL, 14.99, 9.00, 17.99, 'Padel Balls (Pack of 3)', 200, 'Penn', 2), -- Category: Balls
    ('Padel Performance Outfit', NULL, 59.99, 40.00, 69.99, 'Padel Performance Outfit', 100, 'Nike', 3), -- Category: Clothes
    ('Babolat Padel Bag', NULL, 49.99, 35.00, 59.99, 'Babolat Padel Bag', 120, 'Babolat', 4), -- Category: Bags
    ('Padel Accessories Bundle', NULL, 29.99, 20.00, 34.99, 'Padel Accessories Bundle', 150, 'Gamma', 5); -- Category: Accessories


-- Insert into [Orderline] table
INSERT INTO [Orderline] ([quantity], [priceAtTimeOfOrder], [productID], [orderID])
VALUES
    (3, 59.97, 1, 1),
    (2, 59.98, 2, 2),
    (5, 74.95, 3, 3),
    (1, 39.99, 4, 4),
    (4, 199.96, 5, 5),
    (2, 19.98, 6, 6),
    (3, 179.97, 7, 7),
    (2, 49.98, 8, 8);
