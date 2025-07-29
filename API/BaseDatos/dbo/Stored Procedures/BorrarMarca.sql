CREATE PROCEDURE [dbo].[BorrarMarca]


@Id UNIQUEIDENTIFIER

as
begin

set nocount on;
	delete from [dbo].[Marcas]
	where Id = @Id
	select @Id
end
