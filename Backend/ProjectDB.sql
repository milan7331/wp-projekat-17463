INSERT INTO [UserAccount] (ID, FirstName, LastName, City, Address, PostalCode, PhoneNumber, MailAddress) VALUES
(1, 'Milan', 'Stojanovski' 'Grad', 'Adresa' 12345, 123456789, 'milan@email.com'),
(3, 'Milan2', 'Stojanovski2', 'Niš', 'Ulica u Nišu', 20000, 1324354657, 'milan2@email.com');

INSERT INTO [PCPart] (ID, SerialNumber, ProductName, ProductCategory, Price) VALUES
(1, 1, 'NVIDIA RTX 3060', 'Grafička kartica', 600),
(2, 2, 'NVIDIA RTX 3070', 'Grafička kartica', 700),
(3, 3, 'NVIDIA RTX 3080', 'Grafička kartica', 800),
(4, 4, 'NVIDIA RTX 3090', 'Grafička kartica', 900),
(5, 5, 'Intel i7-12700K', 'Procesor', 500), 
(6, 6, 'AMD Ryzen 7 5800X', 'Procesor', 600),
(7, 7, 'AMD Radeon RX 6800 XT', 'Gračička kartica', 700), 
(8, 8, 'Kingston Fury 8GB DDR4 3733MHz', 'RAM memorija', 80),
(9, 9, 'Kingston 4GB DDR3 1600MHz', 'RAM memorija', 30);

INSERT INTO [Stores] (ID, Name, StorePhoneNumber, StoreLocation, StoreMailAdress) VALUES
(1, 'Prodajno mesto 1', 123456789, 'Niš', 'prod1@gmail.com'),
(2, 'Prodajno mesto 2', 987654321, 'Beograd', 'prod2@gmail.com'), 
(3, 'Prodajno mesto 3', 112233442, 'Novi Sad', 'prodavnica3@example.com');

INSERT INTO [Orders] (ID, Quantity, Price, BuyerID, PartID, FromStoreID) VALUES
(9, 4, 2800, 1, 2, 1),
(10, 5, 3000, 1, 6, 1);