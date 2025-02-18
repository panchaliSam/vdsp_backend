create database vdsp;

use vdsp;

-- Creating the Role Table
CREATE TABLE Role (
    role_id INT PRIMARY KEY AUTO_INCREMENT,
    role_name VARCHAR(255) NOT NULL
);

-- Creating the Team Table
CREATE TABLE Team (
    team_id INT PRIMARY KEY AUTO_INCREMENT,
    team_name VARCHAR(100) NOT NULL
);

-- Crate the Package table
CREATE TABLE Package(
	package_id INT PRIMARY KEY AUTO_INCREMENT,
    package_name VARCHAR(100) NOT NULL,
    package_price DECIMAL(10,2) NOT NULL,
    no_of_photos INT NOT NULL
);

-- Creating the User Table
CREATE TABLE User (
    user_id INT PRIMARY KEY AUTO_INCREMENT,
    email VARCHAR(255) UNIQUE NOT NULL,
    user_token VARCHAR(2000)
);

-- Creating the Customer Table with Foreign Key to User
CREATE TABLE Customer (
    cus_id INT PRIMARY KEY AUTO_INCREMENT,
    cus_first_name VARCHAR(255) NOT NULL,
    cus_last_name VARCHAR(255) NOT NULL,
    phone VARCHAR(15),
	email VARCHAR(255) UNIQUE NOT NULL,
    user_id INT,
    FOREIGN KEY (user_id) REFERENCES User(user_id)
);

-- Creating the Staff Table with Foreign Key to Role
CREATE TABLE Staff (
    staff_id INT PRIMARY KEY AUTO_INCREMENT,
    staff_first_name VARCHAR(255) NOT NULL,
    staff_last_name VARCHAR(255) NOT NULL,
    role_id INT,
    user_id INT,
	team_id INT,
    FOREIGN KEY (role_id) REFERENCES Role(role_id),
    FOREIGN KEY (user_id) REFERENCES User(user_id),
    FOREIGN KEY (team_id) REFERENCES Team(team_id)
);

-- Creating the Payment Table
CREATE TABLE Payment (
    payment_id INT PRIMARY KEY AUTO_INCREMENT,
    cus_id INT NOT NULL,
    payment_method ENUM('card', 'online_transfer', 'cash_deposit') NOT NULL,
    total_amount DECIMAL(10, 2) NOT NULL,
    installment_id INT NOT NULL
);

-- Creating the Installment Table
CREATE TABLE Installment (
    installment_id INT PRIMARY KEY AUTO_INCREMENT,
    payment_id INT NOT NULL,
    phase ENUM('phase1', 'phase2', 'phase3') NOT NULL,
    amount_paid DECIMAL(10, 2) NOT NULL,
    payment_date DATE NOT NULL,
    next_payment_date DATE NOT NULL,
    is_complete BOOLEAN DEFAULT 0
);

ALTER TABLE Payment
ADD COLUMN transaction_id VARCHAR(255),
ADD COLUMN payment_status ENUM('Pending', 'Completed', 'Failed', 'Cancelled') DEFAULT 'Pending';


-- Adding Foreign Key for cus_id in Payment Table (references Customer table)
ALTER TABLE Payment
ADD CONSTRAINT FK_Payment_Customer
FOREIGN KEY (cus_id) REFERENCES Customer(cus_id);

-- Adding Foreign Key for installment_id in Payment Table (references Installment table)
ALTER TABLE Payment
ADD CONSTRAINT FK_Payment_Installment
FOREIGN KEY (installment_id) REFERENCES Installment(installment_id);

-- Adding Foreign Key for payment_id in Installment Table (references Payment table)
ALTER TABLE Installment
ADD CONSTRAINT FK_Installment_Payment
FOREIGN KEY (payment_id) REFERENCES Payment(payment_id);

ALTER TABLE Installment
ADD COLUMN payment_status ENUM('Pending', 'Paid', 'Failed') DEFAULT 'Pending';

-- Creating the Reservation Table with Foreign Key to Customer
CREATE TABLE Reservation (
    reservation_id INT PRIMARY KEY AUTO_INCREMENT,
	event_type VARCHAR(100) NOT NULL,
    event_date DATE NOT NULL,
    event_location VARCHAR(500) NOT NULL,
    cus_id INT,
    package_id INT,
    payment_id INT NOT NULL,
    FOREIGN KEY (cus_id) REFERENCES Customer(cus_id),
    FOREIGN KEY (package_id) REFERENCES Package(package_id),
    FOREIGN KEY (payment_id) REFERENCES Payment(payment_id)
);

-- Creating the Schedules Table
CREATE TABLE Schedule (
    schedule_id INT PRIMARY KEY AUTO_INCREMENT,
    date DATE NOT NULL,
    reservation_id INT,
    team_id INT,
    FOREIGN KEY (reservation_id) REFERENCES Reservation(reservation_id),
    FOREIGN KEY (team_id) REFERENCES Team(team_id)
);

-- Creating the Event Table with Foreign Key to Schedules
CREATE TABLE Event (
    event_id INT PRIMARY KEY AUTO_INCREMENT,
    event_date ENUM('In progress', 'Completed'),
    album_status ENUM('In progress', 'Completed'),
    schedule_id INT,
    FOREIGN KEY (schedule_id) REFERENCES Schedule(schedule_id)
);

-- Constarints
ALTER TABLE Customer
ADD CONSTRAINT unique_user_id UNIQUE (user_id);

ALTER TABLE Staff
ADD CONSTRAINT unique_user_id UNIQUE (user_id);

ALTER TABLE Role
ADD CONSTRAINT unique_role_name UNIQUE(role_name);

ALTER TABLE Team
ADD CONSTRAINT unique_team_name UNIQUE(team_name);

ALTER TABLE Package
ADD CONSTRAINT unique_package_name UNIQUE(package_name);

-- Trigger for preventing duplicate user_id in Customer table if it exists in Staff table
DELIMITER $$

CREATE TRIGGER prevent_duplicate_user_id_in_customer
BEFORE INSERT ON Customer
FOR EACH ROW
BEGIN
    DECLARE user_count INT;
    -- Check if the user_id is already in Staff
    SELECT COUNT(*) INTO user_count FROM Staff WHERE user_id = NEW.user_id;
    IF user_count > 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'User ID is already associated with a staff member.';
    END IF;
END $$

DELIMITER ;

-- Trigger for preventing duplicate user_id in Staff table if it exists in Customer table
DELIMITER $$

CREATE TRIGGER prevent_duplicate_user_id_in_staff
BEFORE INSERT ON Staff
FOR EACH ROW
BEGIN
    DECLARE user_count INT;
    -- Check if the user_id is already in Customer
    SELECT COUNT(*) INTO user_count FROM Customer WHERE user_id = NEW.user_id;
    IF user_count > 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'User ID is already associated with a customer.';
    END IF;
END $$

DELIMITER ;

SHOW TRIGGERS;


-- Inserting data into the User table
INSERT INTO User (email, user_token) 
VALUES ('john.doe@example.com', 'token_123456');
INSERT INTO User (email, user_token) 
VALUES ('jane.smith@example.com', 'token_345628');

-- Inserting data into the Customer table
INSERT INTO Customer (cus_first_name, cus_last_name, phone, email, user_id) 
VALUES ('John', 'Doe', '1234567890', 'john.doe@example.com', 1);

INSERT INTO Role (role_name) VALUES
('Photographer'),
('Assistant'),
('Editor'),
('Manager'),
('Customer Service'),
('Marketing Specialist');

INSERT INTO Team (team_name) VALUES
('Team A'),
('Team B');

INSERT INTO Package (package_name, package_price, no_of_photos) 
VALUES 
    ('Wedding Package - Basic', 75000.00, 200),
    ('Wedding Package - Premium', 120000.00, 350),
    ('Engagement Package', 35000.00, 100),
    ('Pre-Shoot Package', 45000.00, 150),
    ('Birthday Party Package', 25000.00, 80),
    ('Corporate Event Package', 60000.00, 200),
    ('Graduation Package', 30000.00, 120),
    ('Anniversary Package', 40000.00, 150),
    ('Family Photoshoot Package', 20000.00, 50),
    ('Newborn Photoshoot Package', 15000.00, 30);
    
-- Inserting data into the Staff table with Sri Lankan names
INSERT INTO Staff (staff_first_name, staff_last_name, role_id, user_id, team_id) 
VALUES 
    ('Amal', 'Perera', 1, 2, 1);

