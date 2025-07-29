CREATE TABLE [dbo].[Vehiculo]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [IdModelo] UNIQUEIDENTIFIER NOT NULL, 
    [Placa] VARCHAR(MAX) NOT NULL, 
    [Anio] INT NOT NULL, 
    [Color] VARCHAR(MAX) NOT NULL, 
    [Precio] DECIMAL NOT NULL, 
    [CorreoPropietario] VARCHAR(MAX) NOT NULL, 
    [TelefonoPropietario] VARCHAR(MAX) NOT NULL
)
