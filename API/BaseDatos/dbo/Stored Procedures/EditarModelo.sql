CREATE PROCEDURE [dbo].[EditarModelo]
	@Id uniqueidentifier,
	@Nombre varchar(max)

as
begin

	set nocount on;
	begin transaction
	update Modelos

	set Nombre = @Nombre
	where Id = @Id

	--Revision del editado

	if @@ROWCOUNT = 0
	begin
	rollback transaction;
		throw 50000, 'No se encontro el modelo o se realizaron cambios', 1
	end

	commit transaction

	select @Id;
end