-- Adds table to database and seeds it with 5 values
CREATE TABLE [dbo].[ServiceRequests]
(
	[Id] INT IDENTITY(0,1) NOT NULL,
	[FirstName] NVARCHAR(64) NOT NULL,
	[LastName] NVARCHAR(120) NOT NULL,
	[ApartmentName] NVARCHAR(40) NOT NULL,
	[UnitNumber] INT NOT NULL,
	[Phone] NVARCHAR(15) NOT NULL,
	[Comments] NVARCHAR(1000),
	[EnterForMaintenance] BIT NOT NULL,
	[Submitted] DateTime NOT NULL
	CONSTRAINT [PK_dbo.ServiceRequests] PRIMARY KEY CLUSTERED([ID] ASC)
);

INSERT INTO [dbo].[ServiceRequests] (FirstName, LastName, ApartmentName, UnitNumber, Phone, Comments, EnterForMaintenance, Submitted) VALUES
('James', 'Reed', 'Mountain View Apartments', '1', '987-324-0001', 'My water heater is not working.', '1', '2018-10-1 04:30:00'),
('Caroline', 'Beckers', 'Mountain View Apartments', '20', '503-334-8765', 'The air conditioning is constantly running and I can not shut it off!', '1', '2018-10-1 4:29:21'),
('Raymon', 'Cletus', 'Mountain View Apartments', '5', '876-990-9999', 'The kitchen sink is leaking.', '1', '2018-10-20 12:34:00'),
('Julie', 'Bishop', 'Mountain View Apartments', '12', '971-665-2023', 'One of my bedroom doors has fallen off of its hinges.', '0', '2018-09-29 16:45:46'),
('Randel', 'Wagner', 'Mountain View Apartments', '3', '541-667-2077', 'My internet is down and I keep hearing random static from my television', '0', '2018-10-22 20:00:00')
GO