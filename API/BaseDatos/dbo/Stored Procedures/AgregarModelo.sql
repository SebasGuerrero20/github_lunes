CREATE PROCEDURE [dbo].[AgregarModelo]
	@IdMarca uniqueidentifier,
	@Nombre varchar(max)

as
begin

	set nocount on;
	begin transaction
	declare @IdModelo as uniqueidentifier = NewId()

		insert into Modelos (Id, IdMarca, Nombre)
		values (@IdModelo, @IdMarca, @Nombre)

	select @IdModelo as IdModelo
	commit transaction
end
