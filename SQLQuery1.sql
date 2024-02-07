CREATE TABLE CategoriesEntity (
  Id INT PRIMARY KEY,
  CategoryName NVARCHAR(MAX)
);

CREATE TABLE ReadersEntity (
  Id INT PRIMARY KEY,
  ReaderName NVARCHAR(MAX)
);

CREATE TABLE DirectionsEntity (
  Id INT PRIMARY KEY,
  StreetName NVARCHAR(MAX),
  PostalCode NVARCHAR(MAX),
  City NVARCHAR(MAX)
);

CREATE TABLE ClientsEntity (
  Id INT PRIMARY KEY,
  FirstName NVARCHAR(MAX),
  LastName NVARCHAR(MAX),
  ReaderId INT,
  DirectionId INT,
  FOREIGN KEY (ReaderId) REFERENCES ReadersEntity(Id),
  FOREIGN KEY (DirectionId) REFERENCES DirectionsEntity(Id)
);

CREATE TABLE ProductsEntity (
  Id INT PRIMARY KEY,
  ModelName NVARCHAR(MAX),
  Color NVARCHAR(MAX),
  CategoryId INT,
  FOREIGN KEY (CategoryId) REFERENCES CategoriesEntity(Id)
);
