-- tables
-- Table: Car
CREATE TABLE Car (
    CarID int  NOT NULL,
    LicensePlate nvarchar(10)  NOT NULL,
    CategoryID int  NOT NULL,
    LocationID int  NOT NULL,
    Brand nvarchar(50)  NOT NULL,
    Model nvarchar(50)  NOT NULL,
    ProductionYear int  NOT NULL,
    KmClock int  NOT NULL,
    Fuel nvarchar(20)  NOT NULL,
    Color nvarchar(50)  NOT NULL,
    Seats int  NOT NULL,
    Gearbox nvarchar(20)  NOT NULL,
    Horsepower int  NOT NULL,
    Image nvarchar(max)  NOT NULL,
    CONSTRAINT Car_pk PRIMARY KEY  (CarID)
);

-- Table: CarCategory
CREATE TABLE CarCategory (
    CategoryID int  NOT NULL,
    CategoryName nvarchar(50)  NOT NULL,
    RentalPrice int  NOT NULL,
    CONSTRAINT CarCategory_pk PRIMARY KEY  (CategoryID)
);

-- Table: Client
CREATE TABLE Client (
    ClientID int  NOT NULL,
    IdCardNumber char(8)  NOT NULL,
    FullName nvarchar(50)  NOT NULL,
    Birthdate date  NOT NULL,
    ZipCode char(10)  NOT NULL,
    City nvarchar(30)  NOT NULL,
    Adress nvarchar(50)  NOT NULL,
    PhoneNumber char(12)  NOT NULL,
    LicenseNumber nvarchar(50)  NOT NULL,
    LicenseIssueDate date  NOT NULL,
    UserName nvarchar(50)  NOT NULL,
    PaswordHash binary(64)  NOT NULL,
    Salt uniqueidentifier  NOT NULL,
    EmailAdress nvarchar(50)  NOT NULL,
    CONSTRAINT Client_pk PRIMARY KEY  (ClientID)
);

-- Table: Employee
CREATE TABLE Employee (
    EmployeeID int  NOT NULL,
    FullName nvarchar(50)  NOT NULL,
    UserName nvarchar(50)  NOT NULL,
    PasswordHash binary(64)  NOT NULL,
    Salt uniqueidentifier  NOT NULL,
    PhoneNumber char(10)  NOT NULL,
    EmailAdress nvarchar(50)  NOT NULL,
    CONSTRAINT Employee_pk PRIMARY KEY  (EmployeeID)
);

-- Table: Location
CREATE TABLE Location (
    LocationID int  NOT NULL,
    ZipCode char(10)  NOT NULL,
    City nvarchar(30)  NOT NULL,
    Adress nvarchar(50)  NOT NULL,
    PhoneNumber char(12)  NOT NULL,
    CONSTRAINT Location_pk PRIMARY KEY  (LocationID)
);

-- Table: Rental
CREATE TABLE Rental (
    RentalID int  NOT NULL,
    EmployeeID int  NOT NULL,
    ReservationID int  NOT NULL,
    RentalDate date  NOT NULL,
    KmsDriven int  NOT NULL,
    Cost int  NOT NULL,
    Discount int  NOT NULL,
    Total int  NOT NULL,
    Advance int  NOT NULL,
    Balance int  NOT NULL,
    Status int  NOT NULL,
    CONSTRAINT Rental_pk PRIMARY KEY  (RentalID)
);

-- Table: Reservation
CREATE TABLE Reservation (
    ReservationID int  NOT NULL,
    ClientID int  NOT NULL,
    CarID int  NOT NULL,
    StartDate date  NOT NULL,
    EndDate date  NOT NULL,
    PickUpLocationID int  NOT NULL,
    DropOffLocationID int  NOT NULL,
    CONSTRAINT Reservation_pk PRIMARY KEY  (ReservationID)
);

-- foreign keys
-- Reference: Car_CarCategory (table: Car)
ALTER TABLE Car ADD CONSTRAINT Car_CarCategory
    FOREIGN KEY (CategoryID)
    REFERENCES CarCategory (CategoryID);

-- Reference: Car_Location (table: Car)
ALTER TABLE Car ADD CONSTRAINT Car_Location
    FOREIGN KEY (LocationID)
    REFERENCES Location (LocationID);

-- Reference: Rental_Employee (table: Rental)
ALTER TABLE Rental ADD CONSTRAINT Rental_Employee
    FOREIGN KEY (EmployeeID)
    REFERENCES Employee (EmployeeID);

-- Reference: Rental_Reservation (table: Rental)
ALTER TABLE Rental ADD CONSTRAINT Rental_Reservation
    FOREIGN KEY (ReservationID)
    REFERENCES Reservation (ReservationID);

-- Reference: Reservation_Car (table: Reservation)
ALTER TABLE Reservation ADD CONSTRAINT Reservation_Car
    FOREIGN KEY (CarID)
    REFERENCES Car (CarID);

-- Reference: Reservation_Client (table: Reservation)
ALTER TABLE Reservation ADD CONSTRAINT Reservation_Client
    FOREIGN KEY (ClientID)
    REFERENCES Client (ClientID);

-- Reference: Reservation_LocationD (table: Reservation)
ALTER TABLE Reservation ADD CONSTRAINT Reservation_LocationD
    FOREIGN KEY (DropOffLocationID)
    REFERENCES Location (LocationID);

-- Reference: Reservation_LocationP (table: Reservation)
ALTER TABLE Reservation ADD CONSTRAINT Reservation_LocationP
    FOREIGN KEY (PickUpLocationID)
    REFERENCES Location (LocationID);

-- End of file.

