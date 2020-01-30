USE Cotecna_Inspections
CREATE TABLE Inspector (
  Id    int IDENTITY(1,1) PRIMARY KEY, 
  InspectorName  varchar(50) NOT NULL
);

CREATE TABLE Inspection (
  [Id]   INTEGER IDENTITY(1,1) PRIMARY KEY, 
  [InspectionDate] [datetime] NOT NULL,
  [Customer] [varchar](50) NOT NULL,
  [Observations] [varchar](max),
  [Status] [int] NOT NULL,
  [InspectorId] [int],
  FOREIGN KEY(InspectorId) REFERENCES Inspector(Id)
);

INSERT INTO Inspector(InspectorName) VALUES ('Inspector Gadget');
INSERT INTO Inspector(InspectorName) VALUES ('Jimmy Hendrix');
INSERT INTO Inspector(InspectorName) VALUES ('Tony Stark');
INSERT INTO Inspector(InspectorName) VALUES ('Batman');

INSERT INTO Inspection(InspectionDate, Customer,Observations,Status,InspectorId)
VALUES ('20120618 10:34:09 AM','Aston Martin','All the specified parts are ok and in excelent conditions', 3, 4);

INSERT INTO Inspection(InspectionDate, Customer,Observations,Status,InspectorId)
VALUES ('20200131 12:30:10 AM','Plasma corp',NULL, 1, 3);

INSERT INTO Inspection(InspectionDate, Customer,Observations,Status,InspectorId)
VALUES ('20200130 11:44:00 AM','Fender','One of the Fender stratocasters is scratched',2, 2);
