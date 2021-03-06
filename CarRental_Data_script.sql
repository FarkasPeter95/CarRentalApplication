USE [CarRental2]
GO
SET IDENTITY_INSERT [Client] ON 

INSERT [Client] ([Id], [IdCardNumber], [FirstName], [SurName], [Birthdate], [ZipCode], [City], [AdressLine1], [AdressLine2], [PhoneNumber], [LicenseNumber], [LicenseIssueDate], [UserName], [PasswordHash], [Salt], [EmailAdress]) VALUES (2, N'RH456875', N'Ferenc', N'Nagy', CAST(N'1985-05-25' AS Date), N'9700', N'Szombathely', N'Király u. 52', N'', N'+36204587854', N'4654658', CAST(N'2005-08-11' AS Date), NULL, NULL, NULL, NULL)
INSERT [Client] ([Id], [IdCardNumber], [FirstName], [SurName], [Birthdate], [ZipCode], [City], [AdressLine1], [AdressLine2], [PhoneNumber], [LicenseNumber], [LicenseIssueDate], [UserName], [PasswordHash], [Salt], [EmailAdress]) VALUES (3, N'JK754852', N'Sándor', N'Kovács', CAST(N'1999-02-11' AS Date), N'9875', N'Miskolc', N'Kossuth u.', N'78./B', N'+36702254685', N'6545789', CAST(N'2019-06-01' AS Date), NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [Client] OFF
SET IDENTITY_INSERT [Location] ON 

INSERT [Location] ([Id], [LocationName], [ZipCode], [City], [AdressLine1], [AdressLine2], [PhoneNumber]) VALUES (1, N'CarRental Vasi Telephely', N'9700', N'Szombathely', N'Petőfi Sándor u. 6.', NULL, N'+3620455577')
INSERT [Location] ([Id], [LocationName], [ZipCode], [City], [AdressLine1], [AdressLine2], [PhoneNumber]) VALUES (2, N'CarRental Baranya Telephely', N'3500', N'Miskolc', N'Akácfa u.', N'25.', N'+3620455777')
INSERT [Location] ([Id], [LocationName], [ZipCode], [City], [AdressLine1], [AdressLine2], [PhoneNumber]) VALUES (3, N'CarRental Pest Telephely', N'1121', N'Budapest', N'Bartók Béla u.', N'79.', N'+3620457777')
SET IDENTITY_INSERT [Location] OFF
SET IDENTITY_INSERT [CarCategory] ON 

INSERT [CarCategory] ([Id], [CategoryName], [CategoryDescription], [RentalPrice]) VALUES (1, N'Közép', NULL, CAST(30000.00 AS Decimal(18, 2)))
INSERT [CarCategory] ([Id], [CategoryName], [CategoryDescription], [RentalPrice]) VALUES (2, N'SUV', NULL, CAST(50000.00 AS Decimal(18, 2)))
INSERT [CarCategory] ([Id], [CategoryName], [CategoryDescription], [RentalPrice]) VALUES (3, N'Luxus', NULL, CAST(75000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [CarCategory] OFF
SET IDENTITY_INSERT [Car] ON 

INSERT [Car] ([Id], [LicensePlate], [CategoryId], [LocationId], [Brand], [Model], [ProductionYear], [KmClock], [Fuel], [Color], [Seats], [Gearbox], [Horsepower], [Image], [Remark]) VALUES (1, N'JHK-456', 1, 1, N'Toyota', N'Yaris', 2016, 12554, N'Benzin', N'kék', 5, N'manuális', 103, NULL, NULL)
INSERT [Car] ([Id], [LicensePlate], [CategoryId], [LocationId], [Brand], [Model], [ProductionYear], [KmClock], [Fuel], [Color], [Seats], [Gearbox], [Horsepower], [Image], [Remark]) VALUES (2, N'KLT-751', 1, 2, N'Ford', N'Mondeo', 2018, 6575, N'Diesel', N'fekete', 5, N'automata', 150, N'nincs', NULL)
INSERT [Car] ([Id], [LicensePlate], [CategoryId], [LocationId], [Brand], [Model], [ProductionYear], [KmClock], [Fuel], [Color], [Seats], [Gearbox], [Horsepower], [Image], [Remark]) VALUES (9, N'RHG-854', 1, 3, N'Opel', N'Corsa', 2015, 78575, N'Benzin', N'piros', 4, N'manuális', 98, NULL, NULL)
INSERT [Car] ([Id], [LicensePlate], [CategoryId], [LocationId], [Brand], [Model], [ProductionYear], [KmClock], [Fuel], [Color], [Seats], [Gearbox], [Horsepower], [Image], [Remark]) VALUES (10, N'KCL-665', 2, 1, N'Suzuki', N'Vitara', 2012, 168750, N'Benzin', N'szürke', 5, N'automata', 148, NULL, NULL)
SET IDENTITY_INSERT [Car] OFF
SET IDENTITY_INSERT [Employee] ON 

INSERT [Employee] ([Id], [FirstName], [SurName], [UserName], [PasswordHash], [Salt], [PhoneNumber], [EmailAdress], [AdminStatus]) VALUES (1, N'Gábor', N'Kiss', N'kissg', NULL, NULL, N'+36305875241', NULL, 1)
INSERT [Employee] ([Id], [FirstName], [SurName], [UserName], [PasswordHash], [Salt], [PhoneNumber], [EmailAdress], [AdminStatus]) VALUES (2, N'Márk', N'Pungor', N'pungorm', NULL, NULL, N'+36204568975', NULL, NULL)
SET IDENTITY_INSERT [Employee] OFF
