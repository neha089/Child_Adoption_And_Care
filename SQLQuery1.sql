CREATE TABLE Adopters (
    adopter_id INT PRIMARY KEY IDENTITY(1,1),
    first_name NVARCHAR(100) NOT NULL,
    last_name NVARCHAR(100) NOT NULL,
    date_of_birth DATE NOT NULL,
    address NVARCHAR(255) NOT NULL,
    phone_number NVARCHAR(20) NOT NULL,
    email NVARCHAR(100) NOT NULL,
    marital_status NVARCHAR(50) NOT NULL,
    occupation NVARCHAR(100) NULL,
    education_level NVARCHAR(100) NULL
);

CREATE TABLE Orphanages (
    orphanage_id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(100) NOT NULL,
    address NVARCHAR(255) NOT NULL,
    phone_number NVARCHAR(20) NOT NULL,
    email NVARCHAR(100) NOT NULL,
    contact_person NVARCHAR(100) NOT NULL,
    capacity INT NOT NULL,
    number_of_children INT NOT NULL,
    license_number NVARCHAR(50) NOT NULL
);

CREATE TABLE Children (
    child_id INT PRIMARY KEY IDENTITY(1,1),
    first_name NVARCHAR(100) NOT NULL,
    last_name NVARCHAR(100) NOT NULL,
    date_of_birth DATE NOT NULL,
    gender NVARCHAR(10) NOT NULL,
    orphanage_id INT NOT NULL,
    adopter_id INT NULL,
    date_of_adoption DATE NULL,
    medical_history NVARCHAR(MAX) NULL,
    education_level NVARCHAR(100) NULL,
    special_needs NVARCHAR(MAX) NULL,
    profile_image NVARCHAR(255) NULL,
    FOREIGN KEY (orphanage_id) REFERENCES Orphanages(orphanage_id),
    FOREIGN KEY (adopter_id) REFERENCES Adopters(adopter_id)
);


CREATE TABLE Admins (
    admin_id INT PRIMARY KEY IDENTITY(1,1),
    username NVARCHAR(50) NOT NULL,
    password NVARCHAR(255) NOT NULL,
    first_name NVARCHAR(100) NOT NULL,
    last_name NVARCHAR(100) NOT NULL,
    email NVARCHAR(100) NOT NULL,
    phone_number NVARCHAR(20) NOT NULL,
    role NVARCHAR(50) NOT NULL,
    last_login DATETIME NULL,
    status NVARCHAR(20) NOT NULL
);

CREATE TABLE ChildDocuments (
    document_id INT PRIMARY KEY IDENTITY(1,1),
    child_id INT NOT NULL,
    document_type NVARCHAR(100) NOT NULL,
    document_name NVARCHAR(255) NOT NULL,
    document_url NVARCHAR(255) NOT NULL,
    upload_date DATETIME NOT NULL,
    FOREIGN KEY (child_id) REFERENCES Children(child_id)
);

CREATE TABLE AdopterDocuments (
    document_id INT PRIMARY KEY IDENTITY(1,1),
    adopter_id INT NOT NULL,
    document_type NVARCHAR(100) NOT NULL,
    document_name NVARCHAR(255) NOT NULL,
    document_url NVARCHAR(255) NOT NULL,
    upload_date DATETIME NOT NULL,
    FOREIGN KEY (adopter_id) REFERENCES Adopters(adopter_id)
);


CREATE TABLE OrphanageDocuments (
    document_id INT PRIMARY KEY IDENTITY(1,1),
    orphanage_id INT NOT NULL,
    document_type NVARCHAR(100) NOT NULL,
    document_name NVARCHAR(255) NOT NULL,
    document_url NVARCHAR(255) NOT NULL,
    upload_date DATETIME NOT NULL,
    FOREIGN KEY (orphanage_id) REFERENCES Orphanages(orphanage_id)
);


CREATE TABLE ApplicationRecords (
    application_id INT PRIMARY KEY IDENTITY(1,1),
    adopter_id INT NOT NULL,
    orphanage_id INT NOT NULL,
    child_id INT NULL,
    application_date DATETIME NOT NULL,
    status NVARCHAR(50) NOT NULL,
    review_date DATETIME NULL,
    notes NVARCHAR(MAX) NULL,
    FOREIGN KEY (adopter_id) REFERENCES Adopters(adopter_id),
    FOREIGN KEY (orphanage_id) REFERENCES Orphanages(orphanage_id),
    FOREIGN KEY (child_id) REFERENCES Children(child_id)
);

CREATE TABLE AdoptionRecords (
    adoption_id INT PRIMARY KEY IDENTITY(1,1),
    adopter_id INT NOT NULL,
    child_id INT NOT NULL,
    adoption_date DATETIME NOT NULL,
    finalization_date DATETIME NULL,
    adoption_status NVARCHAR(50) NOT NULL,
    legal_documents NVARCHAR(255) NULL,
    notes NVARCHAR(MAX) NULL,
    FOREIGN KEY (adopter_id) REFERENCES Adopters(adopter_id),
    FOREIGN KEY (child_id) REFERENCES Children(child_id)
);

CREATE TABLE HomeStudies (
    home_study_id INT PRIMARY KEY IDENTITY(1,1),
    adopter_id INT NOT NULL,
    child_id INT NOT NULL,
    date_of_study DATETIME NOT NULL,
    home_study_report_url NVARCHAR(255) NOT NULL,
    status NVARCHAR(50) NOT NULL,
    social_worker_name NVARCHAR(100) NOT NULL,
    comments NVARCHAR(MAX) NULL,
    FOREIGN KEY (adopter_id) REFERENCES Adopters(adopter_id),
    FOREIGN KEY (child_id) REFERENCES Children(child_id)
);

CREATE TABLE Donations (
    donation_id INT PRIMARY KEY IDENTITY(1,1),
    donor_name NVARCHAR(100) NOT NULL,
    amount DECIMAL(10, 2) NOT NULL,
    date DATETIME NOT NULL,
    donation_type NVARCHAR(50) NOT NULL,
    purpose NVARCHAR(255) NOT NULL,
    receipt_url NVARCHAR(255) NULL,
    orphanage_id INT NULL,
    FOREIGN KEY (orphanage_id) REFERENCES Orphanages(orphanage_id)
);

CREATE TABLE Images (
    image_id INT PRIMARY KEY IDENTITY(1,1),
    image_url NVARCHAR(255) NOT NULL,
    description NVARCHAR(255) NOT NULL,
    uploaded_date DATETIME NOT NULL,
    related_child_id INT NULL,
    related_adopter_id INT NULL,
    related_orphanage_id INT NULL,
    FOREIGN KEY (related_child_id) REFERENCES Children(child_id),
    FOREIGN KEY (related_adopter_id) REFERENCES Adopters(adopter_id),
    FOREIGN KEY (related_orphanage_id) REFERENCES Orphanages(orphanage_id)
);