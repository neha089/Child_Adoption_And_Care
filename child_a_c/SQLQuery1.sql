
CREATE TABLE Adopters (
    adopter_id INT PRIMARY KEY IDENTITY(1,1),
    first_name NVARCHAR(100) NOT NULL,
    last_name NVARCHAR(100) NOT NULL,
    password NVARCHAR(100) NOT NULL,
    date_of_birth DATE NOT NULL,
    address NVARCHAR(255) NOT NULL,
    phone_number NVARCHAR(20) NOT NULL,
    email NVARCHAR(100) NOT NULL,
    marital_status NVARCHAR(50) NOT NULL,
    occupation NVARCHAR(100) NULL,
    education_level NVARCHAR(100) NULL
);