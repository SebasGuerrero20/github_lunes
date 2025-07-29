CREATE PROCEDURE [dbo].[ObtenerMarcas]

as
begin

	set nocount on;

	select *
	from Marcas;

end
