CREATE PROCEDURE [dbo].[ObtenerMarca]
@Id UNIQUEIDENTIFIER

as
begin

	select * 
	from Marcas 
	where (Marcas.Id = @Id)

end