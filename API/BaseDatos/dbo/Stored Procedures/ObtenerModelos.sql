CREATE PROCEDURE [dbo].[ObtenerModelos]
@IdMarca uniqueidentifier

as
begin

set nocount on;
select
	Modelos.Id, Modelos.Nombre, Marcas.Nombre as Marca, Marcas.Id as IdMarca
	from Modelos Inner Join Marcas on Modelos.IdMarca = Marcas.Id	
	where Modelos.IdMarca = @IdMarca
end
