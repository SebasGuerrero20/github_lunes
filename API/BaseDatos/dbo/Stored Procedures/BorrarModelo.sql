CREATE PROCEDURE [dbo].[BorrarModelo]
	@Id uniqueidentifier

as
begin

set nocount on;
	begin transaction

	delete from Modelos
	where Id = @Id

	select @Id

	-- Revision del borrado

	if @@ROWCOUNT = 0
		throw 50000, 'No se encontro el modelo', 1
	commit transaction
end
