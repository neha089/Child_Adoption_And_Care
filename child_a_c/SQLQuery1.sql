CREATE TABLE Donors (
    donor_id INT IDENTITY(1,1) PRIMARY KEY,    -- Auto-incrementing primary key
    donor_name NVARCHAR(100) NOT NULL,         -- Name of the donor
    phone_number NVARCHAR(15) NOT NULL,        -- Phone number
    email NVARCHAR(100) NOT NULL,              -- Email address
    password NVARCHAR(255) NOT NULL,           -- Password (encrypted/hashed in practice)
    created_at DATETIME DEFAULT GETDATE()      -- Date when the donor signed up
);