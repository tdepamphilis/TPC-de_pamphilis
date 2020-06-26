use depamphilis_db
go


create procedure SP_AltaUsuario(
@Codigo varchar(5),
@Nombre varchar (50),
@Apellido varchar (50),
@DNI int,
@Correo varchar (100),
@Password varchar (50),
@Direccion varchar (50),
@zona int
)
as
if (select COUNT(*) from usuarios where Correo = @Correo) = 0 
begin
insert into usuarios values (@Codigo, @Nombre, @Apellido, @DNI, @Correo, @Password, @Direccion, @zona)
end 
go
exec SP_AltaUsuario '32d1a','Agustin','DP', 41655477,'agusdp@gmail.com','cac3','falsa332',2
go



create procedure SP_CargaFactura(
@Codigo varchar(15),
@Usuario varchar(5),
@fecha datetime,
@estado bit,
@modo varchar (1),
@monto money,
@dir varchar (50)
)
as 
if (select count(*) from facturas where Codigo = @Codigo) = 0
begin
insert into facturas values (@Codigo, @Usuario, @fecha, @estado, @modo, @monto, @dir)
end





































