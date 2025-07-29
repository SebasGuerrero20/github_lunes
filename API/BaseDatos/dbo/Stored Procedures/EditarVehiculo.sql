CREATE PROCEDURE [dbo].[EditarVehiculo]
	@Id UNIQUEIDENTIFIER,
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

	update [dbo].[Vehiculo]
	set 
		IdModelo = @IdModelo,
		Placa = @Placa,
		Anio = @Anio,
		Color = @Color,
		Precio = @Precio,
		CorreoPropietario = @CorreoPropietario,
		TelefonoPropietario = @TelefonoPropietario
	where Id = @Id
	select @Id
end
