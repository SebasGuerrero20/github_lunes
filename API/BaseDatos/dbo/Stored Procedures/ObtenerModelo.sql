CREATE PROCEDURE [dbo].[ObtenerModelo]
	@Id uniqueidentifier

as
begin

set nocount on;
	select
	Modelos.Id, Modelos.Nombre, Marcas.Nombre as Marca, Marcas.Id as IdMarca
	from Modelos Inner Join Marcas on Modelos.IdMarca = Marcas.Id	
	where Modelos.Id = @Id
end
