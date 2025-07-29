CREATE PROCEDURE [dbo].[EliminarVehiculo]
	@Id UNIQUEIDENTIFIER

as
begin

	set nocount on;
	delete from [dbo].[Vehiculo]
	where Id = @Id

end
