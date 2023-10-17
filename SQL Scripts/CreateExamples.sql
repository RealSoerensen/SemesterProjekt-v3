-- Insert data into the Address table
INSERT INTO [Address] ([zipCode], [houseNumber], [city], [street])
VALUES
    ('12345', '123 Main', 'Example City', 'Sample Street'),
    ('54321', '456 Elm', 'Another City', 'Test Avenue'),
    ('67890', '789 Oak', 'Newtown', 'Grove Road'),
    ('11111', '1001 Pi', 'Riverdale', 'Forest Lane'),
    ('22222', '456 Elm', 'Hometown', 'Meadow Drive'),
    ('33333', '789 Wil', 'Sunnyville', 'Sunset Blvd'),
    ('44444', '111 Bir', 'Beachville', 'Ocean Avenue'),
    ('55555', '987 Ced', 'Mountain View', 'Summit Road'),
    ('66666', '555 Red', 'Lake City', 'Lakefront Drive'),
    ('77777', '222 Elm', 'Springfield', 'Park Lane');

-- Insert data into the Customer table
INSERT INTO [Customer] ([firstName], [lastName], [addressID], [email], [phoneNo], [password], [registerDate])
VALUES
    ('John', 'Doe', 1, 'john.doe@example.com', '555-123-4567', 'password123', '2023-01-15 10:30:00'),
    ('Jane', 'Smith', 2, 'jane.smith@example.com', '555-987-6543', 'secretword', '2023-02-20 14:15:00'),
    ('Robert', 'Johnson', 3, 'robert.j@example.com', '555-111-2222', 'robertpass', '2023-03-10 08:45:00'),
    ('Lisa', 'Wilson', 4, 'lisa.w@example.com', '555-333-4444', 'lisapass', '2023-04-05 12:20:00'),
    ('Michael', 'Brown', 5, 'michael.b@example.com', '555-555-6666', 'michaelpass', '2023-05-15 16:10:00'),
    ('Sarah', 'Davis', 6, 'sarah.d@example.com', '555-777-8888', 'sarahpass', '2023-06-20 19:30:00'),
    ('David', 'Lee', 7, 'david.l@example.com', '555-999-1010', 'davidpass', '2023-07-25 22:15:00'),
    ('Emily', 'Evans', 8, 'emily.e@example.com', '555-121-1313', 'emilypass', '2023-08-30 10:00:00'),
    ('William', 'Taylor', 9, 'william.t@example.com', '555-141-1515', 'williampass', '2023-09-05 14:45:00'),
    ('Olivia', 'Harris', 10, 'olivia.h@example.com', '555-161-1717', 'oliviapass', '2023-10-10 18:55:00');

-- Insert data into the Order table
INSERT INTO [Order] ([date], [customerEmail], [totalPrice], [discount])
VALUES
    ('2023-01-16 11:15:00', 'john.doe@example.com', 150, 10),
    ('2023-02-21 15:30:00', 'jane.smith@example.com', 200, 15),
    ('2023-03-11 09:50:00', 'robert.j@example.com', 100, 5),
    ('2023-04-06 13:25:00', 'lisa.w@example.com', 250, 20),
    ('2023-05-16 17:20:00', 'michael.b@example.com', 180, 15),
    ('2023-06-21 19:45:00', 'sarah.d@example.com', 120, 10),
    ('2023-07-26 21:10:00', 'david.l@example.com', 300, 25),
    ('2023-08-31 10:55:00', 'emily.e@example.com', 90, 7),
    ('2023-09-06 14:35:00', 'william.t@example.com', 175, 12),
    ('2023-10-11 18:20:00', 'olivia.h@example.com', 220, 18);

	-- Insert data into the ProductDescription table
INSERT INTO [ProductDescription] ([description], [image], [price], [name], [stock])
VALUES
    ('Product A Description', NULL, 50.00, 'Product A', 100),
    ('Product B Description', NULL, 75.00, 'Product B', 50),
    ('Product C Description', NULL, 30.00, 'Product C', 200),
    ('Product D Description', NULL, 60.00, 'Product D', 75),
    ('Product E Description', NULL, 45.00, 'Product E', 120),
    ('Product F Description', NULL, 80.00, 'Product F', 30),
    ('Product G Description', NULL, 55.00, 'Product G', 90),
    ('Product H Description', NULL, 70.00, 'Product H', 60),
    ('Product I Description', NULL, 40.00, 'Product I', 150),
    ('Product J Description', NULL, 65.00, 'Product J', 40);

	-- Insert data into the Product table
INSERT INTO [Product] ([ProductDescriptionID])
VALUES
    (1),
    (2),
    (3),
    (4),
    (5),
    (6),
    (7),
    (8),
    (9),
    (10);

	-- Insert data into the Orderline table
INSERT INTO [Orderline] ([quantity], [productSN], [orderID])
VALUES
    (2, 1, 1),
    (3, 2, 1),
    (1, 3, 1),
    (2, 4, 2),
    (4, 5, 2),
    (1, 6, 2),
    (3, 7, 3),
    (2, 8, 3),
    (1, 9, 4),
    (4, 10, 4);
