CREATE PROCEDURE [dbo].[AgregarVehiculo]
	@IdModelo UNIQUEIDENTIFIER,
	@Placa VARCHAR(MAX),
	@Anio INT,
	@Color VARCHAR(MAX),
	@Precio decimal(18,0),
	@CorreoPropietario VARCHAR(MAX),
	@TelefonoPropietario VARCHAR(MAX)

as
begin

	set nocount on;

	declare @Id as uniqueidentifier = newid();

	insert into [dbo].[Vehiculo]
	(
		Id,
		IdModelo,
		Placa,
		Anio,
		Color,
		Precio,
		CorreoPropietario,
		TelefonoPropietario
	)
	values 
	(
		@Id,
		@IdModelo,
		@Placa,
		@Anio,
		@Color,
		@Precio,
		@CorreoPropietario,
		@TelefonoPropietario
	)

	select @Id

end