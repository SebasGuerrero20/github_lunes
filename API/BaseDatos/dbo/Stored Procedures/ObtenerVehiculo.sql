CREATE PROCEDURE [dbo].[ObtenerVehiculo]
	@Id UNIQUEIDENTIFIER

as
begin

set nocount on;

select 
	vehiculo.Id,
	IdModelo,
	Placa,
	Anio,
	Color,
	Precio,
	CorreoPropietario,
	TelefonoPropietario,
	Modelos.Nombre as Modelo,
	Marcas.Nombre as Marca

	from Vehiculo Inner Join 
		Modelos on Vehiculo.IdModelo = Modelos.Id
		Inner Join 
		Marcas on Modelos.IdMarca = Marcas.Id
	where vehiculo.Id = @Id
end