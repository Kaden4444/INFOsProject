-- Create the Clients table
CREATE TABLE Clients (
    ClientID INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(255) NOT NULL,
    Address VARCHAR(255),
    Area VARCHAR(255),
    Town VARCHAR(255),
    PostalCode VARCHAR(10),
    Reservation INT,
    FOREIGN KEY (Reservation) REFERENCES Reservations(ReservationID)
);

-- Create the Rooms table
CREATE TABLE Rooms (
    RoomID INT PRIMARY KEY AUTO_INCREMENT,
    Price DECIMAL(10, 2) NOT NULL
);

-- Create the Reservations table
CREATE TABLE Reservations (
    ReservationID INT PRIMARY KEY AUTO_INCREMENT,
    Guest VARCHAR(255) NOT NULL,
    Room INT,
    Total DECIMAL(10, 2),
    FOREIGN KEY (Room) REFERENCES Rooms(RoomID)
);


