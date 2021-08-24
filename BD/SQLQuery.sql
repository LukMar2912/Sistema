CREATE DATABASE DB_SISTEMA

USE DB_SISTEMA;
GO

CREATE TABLE clientes(
	codigo varchar(5),
	nombre varchar(50),
	edad int,
	telefono int
);
GO

CREATE PROC sp_listar_clientes
AS
SELECT * FROM clientes order by codigo
GO


CREATE PROC sp_buscar_clientes_nombre
@nombre varchar(50)
AS
SELECT * FROM clientes WHERE nombre like @nombre + '%'
GO

CREATE PROC sp_buscar_clientes_codigo
@codigo varchar(55)
AS
SELECT * FROM clientes WHERE codigo like @codigo + '%'
GO

CREATE PROC sp_mantenimiento_clientes
@codigo varchar(5),
@nombre varchar(50),
@edad int,
@telefono int,
@accion varchar(50) output
AS
IF(@accion='1')
begin
	declare @codnuevo varchar(5), @codmax varchar(5)
	set @codmax = (select max(codigo) from clientes)
	set @codmax = isnull(@codmax,'A0000')
	set @codnuevo = 'A'+RIGHT(RIGHT(@codmax,4)+1001,4)
	insert into clientes(codigo,nombre,edad,telefono)
	values(@codnuevo,@nombre,@edad,@telefono)
	set @accion='Se genero el codigo: '+@codnuevo
end
else if(@accion='2')
begin
	update clientes set nombre=@nombre,edad=@edad, telefono=@telefono where codigo=@codigo
	set @accion='Se modifico el codigo: '+@codigo
end
else if(@accion='3')
begin
	delete from clientes where codigo=@codigo
	set @accion='Se borro el codigo: '+@codigo
end
