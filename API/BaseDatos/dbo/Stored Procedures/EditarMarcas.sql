CREATE PROCEDURE [dbo].[EditarMarcas]
@Id UNIQUEIDENTIFIER,
@Nombre VARCHAR(MAX)

as
begin

set nocount on;
	update [dbo].[Marcas]
	set 
		Nombre = @Nombre
	where Id = @Id
	select @Id
end
