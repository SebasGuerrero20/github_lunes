CREATE PROCEDURE [dbo].[AgregarMarca]
@Nombre VARCHAR(MAX)

as
begin

set nocount on;
	declare @Id as uniqueidentifier = newid();
	insert into [dbo].[Marcas]
	(
		Id,
		Nombre
	)
	values 
	(
		@Id,
		@Nombre
	)
	select @Id
end