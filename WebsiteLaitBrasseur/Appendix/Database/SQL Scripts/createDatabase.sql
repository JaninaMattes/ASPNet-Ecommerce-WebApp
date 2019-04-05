-- ================================================
-- SQL script defines the table structure of the
-- database system.
-- ================================================

-----------------------------------
--drop statement
DROP DATABASE beerAndCheeseOnlineStore
GO

-- create new database
CREATE DATABASE beerAndCheeseOnlineStore
GO

-- use database
USE beerAndCheeseOnlineStore
GO

-- create login table
CREATE TABLE dbo.Login(
loginID CHAR(8) PRIMARY KEY NOT NULL,
accountID CHAR(8) NULL,
email VARCHAR(25) NOT NULL DEFAULT '',
password VARCHAR(10) NOT NULL DEFAULT ''
)
GO 

-- create account table
CREATE TABLE dbo.Account(
accountID CHAR(8) PRIMARY KEY NOT NULL,
loginID CHAR(8) NOT NULL,
userName VARCHAR(25) NOT NULL UNIQUE DEFAULT '',
firstName VARCHAR(25) NOT NULL DEFAULT '',
lastName VARCHAR(25) NOT NULL DEFAULT '',
birthDate Date NOT NULL,
FOREIGN KEY(loginID ) REFERENCES Login(loginID)
)
GO 

-- create administrator table
CREATE TABLE dbo.Administrator(
accountID CHAR(8) NOT NULL REFERENCES Account(accountId) 
ON UPDATE CASCADE ON DELETE NO ACTION,
PRIMARY KEY(accountID),
businessName VARCHAR(255) NOT NULL DEFAULT '',
isAdmin TINYINT NOT NULL DEFAULT 0
)
GO

-- create customer table
CREATE TABLE dbo.Customer(
customerID CHAR(8) NOT NULL REFERENCES Account(accountId) 
ON UPDATE CASCADE ON DELETE NO ACTION,
PRIMARY KEY(customerID),
businessName VARCHAR(255) NOT NULL DEFAULT '',
isAdmin TINYINT NOT NULL DEFAULT 0
)
GO 

-- create invoice table
CREATE TABLE dbo.Invoice(
invoiceID CHAR(8) PRIMARY KEY NOT NULL,
quantity CHAR(8) NOT NULL,
shippingCost DECIMAL(10,4) NOT NULL DEFAULT 0.00,
totalAmount DECIMAL(10,4) NOT NULL DEFAULT 0.00, 
orderDate DATE NOT NULL,
paymentStatus TINYINT NOT NULL DEFAULT 0
)
GO 

-- create shipping table
CREATE TABLE dbo.Shipping(
shippingID CHAR(8) PRIMARY KEY NOT NULL,
sType VARCHAR(25) NOT NULL DEFAULT '',
arrival DATE NOT NULL,
postage DATE NOT NULL,
sCost DECIMAL(10,4) NOT NULL DEFAULT 0.00,
sCompany VARCHAR(25) NOT NULL DEFAULT ''
)
GO

-- create product table
CREATE TABLE dbo.Product(
productID CHAR(8) PRIMARY KEY NOT NULL,
accountID CHAR(8) NOT NULL,
invoiceID CHAR(8) NOT NULL,
shippingID CHAR(8) NOT NULL,
pName VARCHAR(25) NOT NULL DEFAULT '',
pCategory VARCHAR(25) NOT NULL DEFAULT '',
producer VARCHAR(25) NOT NULL DEFAULT '',
brand VARCHAR(25) NOT NULL DEFAULT '',
pType VARCHAR(25) NOT NULL DEFAULT '',
unitSize DECIMAL(10,4) NOT NULL DEFAULT 0.00,
unitPrice DECIMAL(10,4) NOT NULL DEFAULT 0.00,
pInfo VARCHAR(255) NOT NULL DEFAULT '',
imgPath VARCHAR(25) NOT NULL DEFAULT '',
inStock TINYINT NOT NULL DEFAULT 0,
pStatus TINYINT NOT NULL DEFAULT 0,
FOREIGN KEY(accountID ) REFERENCES Account(accountID),
FOREIGN KEY(invoiceID) REFERENCES Invoice(invoiceID),
FOREIGN KEY(shippingID) REFERENCES Shipping(shippingID)
)
GO 

-- create administraion table
CREATE TABLE dbo.ProductAdministration(
accountID CHAR(8) NOT NULL,
productID CHAR(8) NOT NULL,
updateDate DATE NOT NULL,
PRIMARY KEY (accountID, productID),
FOREIGN KEY(accountID) REFERENCES Administrator(accountID)
ON UPDATE CASCADE ON DELETE NO ACTION,
FOREIGN KEY(productID) REFERENCES Product(productID)
ON UPDATE CASCADE ON DELETE NO ACTION
)
GO

-- create shopping table
CREATE TABLE dbo.ProductShopping(
accountID CHAR(8) NOT NULL,
productID CHAR(8) NOT NULL,
orderDate DATE NOT NULL,
PRIMARY KEY (accountID, productID),
FOREIGN KEY(accountID) REFERENCES Customer(customerID)
ON UPDATE CASCADE ON DELETE NO ACTION,
FOREIGN KEY(productID) REFERENCES Product(productID)
ON UPDATE CASCADE ON DELETE NO ACTION
)
GO  

-- create payment table
CREATE TABLE dbo.Payment(
paymentID CHAR(8) PRIMARY KEY NOT NULL,
invoiceID CHAR(8) NOT NULL,
customerID CHAR(8) NOT NULL,
amount DECIMAL(10,4) NOT NULL DEFAULT 0.00,
paymentDate DATE NOT NULL,
FOREIGN KEY(invoiceID) REFERENCES Invoice(invoiceID),
FOREIGN KEY(customerID) REFERENCES Customer(customerID)
)
GO

-- create card table
CREATE TABLE dbo.Card(
paymentID CHAR(8) NOT NULL REFERENCES Payment(paymentId) 
ON UPDATE CASCADE ON DELETE NO ACTION,
PRIMARY KEY(paymentId),
owner VARCHAR(25) NOT NULL DEFAULT '',
securityNo CHAR(8) NOT NULL DEFAULT 0.00,
bankName VARCHAR(255) NOT NULL DEFAULT '',
expiration DATE NOT NULL
)
GO

-- create paypal table
CREATE TABLE dbo.PayPal(
paymentID CHAR(8) NOT NULL REFERENCES Payment(paymentId) 
ON UPDATE CASCADE ON DELETE NO ACTION,
PRIMARY KEY(paymentId),
userName VARCHAR(25) NOT NULL DEFAULT '',
password VARCHAR(10) NOT NULL DEFAULT '',
expiration DATE NOT NULL
)
GO

-- create city table
CREATE TABLE dbo.City(
cityID CHAR(8) PRIMARY KEY NOT NULL,
zipCode CHAR(8) NOT NULL,
cityName VARCHAR(25) NOT NULL DEFAULT ''
)
GO

-- create postaddress
CREATE TABLE dbo.Address(
addressID CHAR(8) PRIMARY KEY NOT NULL,
shippingID CHAR(8) NOT NULL,
cityID CHAR(8) NOT NULL, 
streetName VARCHAR(25) NOT NULL DEFAULT '',
streetNo CHAR(8) NOT NULL DEFAULT '',
addressType VARCHAR(25) NOT NULL DEFAULT '', -- e.g. home, friend, business
FOREIGN KEY(shippingID) REFERENCES Shipping(shippingID),
FOREIGN KEY(cityID) REFERENCES City(cityID)
)
GO

-- create accound address table
CREATE TABLE dbo.AccountAddress(
addressID CHAR(8) NOT NULL,
accountID CHAR(8) NOT NULL,
PRIMARY KEY(addressID, accountID),
FOREIGN KEY(accountID ) REFERENCES Account(accountID)
ON UPDATE CASCADE ON DELETE NO ACTION,
FOREIGN KEY(addressID ) REFERENCES Address(addressID)
ON UPDATE CASCADE ON DELETE NO ACTION
)
GO