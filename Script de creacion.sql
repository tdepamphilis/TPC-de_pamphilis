use master

go

drop database depamphilis_db
go

create database depamphilis_db
go
use depamphilis_db

create table categorias
(
[Id][int] IDENTITY (1,1) primary key not null,
[Nombre][varchar](50) unique not null
)


go

create table marcas(
[Id] [int] IDENTITY(1,1) primary key not null,
[Nombre][varchar] (50) unique not null,
[Active] [bit] not null
)

go

create table articulos
(
	
	[Codigo] [varchar](5) primary key not NULL,
	[Nombre] [varchar](50) not NULL,
	[Descripcion] [varchar](150) not NULL,
	[IdMarca] [int]  foreign key references marcas(id),
	[ImagenUrl] [varchar](1000)  not NULL,
	[MargenGanancia] [int] not null,
	[Active] [bit]  not null 
)

create table stock
(

	[CodigoArticulo] [varchar] (5) foreign key references articulos(Codigo) primary key,
	[Cantidad] [int] not null,
	[PrecioDistribuidor] [money] not null,
	
)
go


create table categoriaxarticulo(
[IdRegistro] [int] primary key identity(1,1), 
[CodigoArticulo] [varchar] (5) foreign key references articulos(Codigo) ,
[Idcategoria] [int] foreign key references categorias(id),
)
go
alter table categoriaxarticulo 
add constraint categoriaxarticuloun UNIQUE (CodigoArticulo, Idcategoria)
go
create table zonas(
[Id] [int] identity (1,1) primary key,
[Nombre] [varchar] (15) not null
)
go
create table usuarios(
[Codigo] [varchar] (5) primary key,
[Nombre] [varchar] (50) not null,
[Apellido] [varchar] (50) not null,
[DNI] [int] not null,
[Correo] [varchar] (100) unique not null,
[Password] [varchar] (50) not null,
[Dirrecion] [varchar] (50) not null,
[IdZona] [int] foreign key references zonas(id)
)
go
create table admins(
[Codigo] [varchar] (5) primary key,
[Correo] [varchar] (50) not null,
[Password] [varchar] (50) not null,
[Nombre] [varchar] (50) not null
)
go
create table facturas(
[Codigo] [varchar] (15) primary key not null,
[CodigoUsuario] [varchar] (5) foreign key references usuarios(Codigo),
[Fecha] [datetime] not null,
[Estado] [bit] not null,
[ModoDePago] [varchar] (1) not null,
[Monto] [money] not null,
[Direccion] [varchar] (50) not null
)
go
create table itemsxfactura(
[Id] [int] primary key identity(1,1),
[CodigoArticulo] [varchar] (5) foreign key references articulos(Codigo),
[CodigoFactura] [varchar] (15) foreign key references facturas(Codigo),
[Precio] [money] not null,
[Cantidad] [int] not null
)
go
alter table itemsxfactura
add constraint itemsxfacuraun unique(CodigoArticulo, CodigoFactura)
go
create table favoritosxusuario(
[Id] [int] primary key identity (1,1),
[Usuario] [varchar] (5) foreign key references usuarios(Codigo),
[Articulo] [varchar] (5) foreign key references articulos(Codigo)
)
go
alter table favoritosxusuario
add constraint favoritosxusuarioun unique (Usuario,Articulo)
go
create view [vw_articulos] 
as
select a.Codigo, a.Nombre, a.Descripcion, a.MargenGanancia, a.ImagenUrl, a.IdMarca, m.Nombre as Marca, s.Cantidad as stock, s.PrecioDistribuidor as 'precio distribuidor'  from articulos as a 
inner join marcas as m on a.IdMarca = m.id
inner join stock as s on s.CodigoArticulo = a.Codigo
where a.Active = '1'
go
create view [vw_articulosxcategoria] 
as
select a.Codigo, a.Nombre, a.Descripcion, a.MargenGanancia, a.ImagenUrl,  a.IdMarca , a.Marca , c.id as IdCategoria, c.nombre as categoria, s.Cantidad as stock, s.PrecioDistribuidor as 'precio distribuidor'   from vw_articulos as a 
inner join categoriaxarticulo as cxa on a.Codigo = cxa.CodigoArticulo
inner join categorias as c on cxa.Idcategoria = c.id
inner join stock as s on s.CodigoArticulo = a.Codigo

go

go
create view [vw_categorias]
as
select c.Id, c.Nombre, COUNT(cxa.CodigoArticulo) as articulos from categorias as c
left join  categoriaxarticulo as cxa on c.Id = cxa.Idcategoria
group by c.Nombre, c.Id
go
create view [vw_marcas]
as
select m.Id, m.Nombre, COUNT(a.Codigo) as articulos from marcas as m
left join articulos as a on a.IdMarca = m.Id
where m.active = 1
group by m.Nombre, m.Id
go
create view [vw_usuarios]
as
select u.codigo, u.Nombre,u.Apellido,u.DNI,u.Correo,u.Password, u.Dirrecion, z.Id as idzona, z.Nombre as zona from usuarios as u
inner join zonas as z on z.Id = u.IdZona
go
create view [vw_facturas]
as
select f.Codigo, f.CodigoUsuario, f.Fecha, f.Estado, f.ModoDePago ,f.Monto, f.Direccion, (u.Apellido + ' ' + u.Nombre) as ApellidoNombre from facturas as f
inner join usuarios as u on u.Codigo = f.CodigoUsuario
where f.Estado = 1
go
create view [vw_itemFactura]
as
select i.CodigoFactura, i.CodigoArticulo, a.Nombre , i.Cantidad, i.Precio from itemsxfactura as i
inner join articulos as a on a.Codigo = i.CodigoArticulo
go
create view [vw_favoritos]
as
select Usuario, Articulo from favoritosxusuario
go

go
insert into marcas values ('arcor',1),('la campagnola',1),('Magistral',1),('la serenisima',1),('sancor',1),('Coca cola',1),('Pepsico',1)
go
insert into categorias values ('cocina'),('almacen'),('bebidas'),('lacteos'),('limpieza'),('golosinas')
go
insert into articulos values 
('asasd','mermelada de naranja', 'caja 24 unidades', 2,'https://walmartar.vteximg.com.br/arquivos/ids/829225-1000-1000/Mermelada-Naranja-La-Campagnola-454-Gr-1-17738.jpg?v=636685104012570000', 100,1),
('qwere','Detergente Magistral', 'caja 24 unidades',3 ,'https://www.ofiflex.com.ar/wp-content/uploads/578_13.jpg', 25,1),
('qwdas','Bombones surtidos', 'caja 12 unidades', 1,'https://ardiaqa.vteximg.com.br/arquivos/ids/213174-1000-1000/SURTIDO-CHOCOLATE-ARCOR-266GR.jpg?v=636977361302600000', 25,1),
('asdqw','Leche largavida', 'pack 8 unidades', 4,'https://statics.dinoonline.com.ar/imagenes/full_600x600_ma/3262754_f.jpg', 25,1),
('qwert','Pepsi 2.5l', 'pack 8 unidades', 7,'https://lacolonia.vteximg.com.br/arquivos/ids/184532-500-500/360-Bebidas-y-Jugos-Refrescos-Refrescos-de-Cola_7421601101614_1.jpg?v=637117565841900000', 25,1),
('fkhop','Coca cola 2.5l', 'pack 8 unidades', 6,'https://infonegocios.info/uploads/old_site/Coca.jpg', 25,1),
('mngop','manteca', 'caja 24 unidades', 4,'https://statics.dinoonline.com.ar/imagenes/full_600x600_ma/3260038_f.jpg', 25,1),
('progf','yogurt firme', 'caja 24 unidades', 5,'https://ardiaqa.vteximg.com.br/arquivos/ids/223212-1000-1000/Yogur-Entero-Firme-Sancor-Vainilla-190-Gr-_1.jpg?v=637194325015700000', 25,1),
('ckxa2','Polenta', 'caja 10 unidades', 1,'https://mandamosfruta.com.ar/wp-content/uploads/2020/06/difTKLCb5y_1024x.jpg', 25,1),
('sd340','Atun', 'pack 8 unidades', 4,'https://ardiaqa.vteximg.com.br/arquivos/ids/190076-1000-1000/ATUN-EN-ACEITE---LA-CAMPAGNOLA-170GR.jpg?v=636838250372330000', 25,1)
go
insert into categoriaxarticulo values ('asasd',2),('qwere',1),('qwere',5),('qwdas',6),('asdqw',4),('asdqw',2),
('qwert',3),('fkhop',3),('mngop',4),('progf',4),('ckxa2',2),('sd340',2)
go
insert into stock values ('asasd', 2,3),('qwere', 300,200),('qwdas', 100,700),('asdqw', 300,500),
('qwert', 300,350),('fkhop', 300,500),('mngop', 300,500),('progf', 300,500),('ckxa2', 300,500),('sd340', 300,500)
go
insert into zonas values ('CABA'), ('Norte'), ('Sur')
go
insert into usuarios values 
('abcdf' ,'Tomas', 'De Pamphilis', 41067359, 'tomdp@gmail.com','hola123','calle falsa 123',2),
('abder' ,'Juan', 'Moreno', 17895644, 'jmoreno@gmail.com','hola123','Cabildo 500',2),
('abess' ,'Matias', 'lizi', 74115895, 'mlizi@gmail.com','hola123','Del arca 214',1),
('abdww' ,'Tomas', 'Ponce', 74015878, 'tponce@gmail.com','hola123','monroe',3),
('aba23' ,'Roman', 'de veneto', 18569148, 'rveneto@gmail.com','hola123','calle falsa 123',1),
('abcde' ,'Camila', 'lizi', 35487010, 'clizi@gmail.com','hola123','calle falsa 123',2),
('abxmv' ,'Mariana', 'lopez', 38256658, 'mlopez@gmail.com','hola123','calle falsa 123',3),
('ab123' ,'Sol', 'somer', 38458899, 'solsomer@gmail.com','hola123','calle falsa 123',1)
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
insert into facturas values ('AHFNCPERTGSFCDW','abder','2014-11-03', 1, 'E', 1000, 'cabildo 500'),
('AHFNCPERT32FCDW','abder','2014-10-03', 1, 'E', 1000, 'cabildo 500'),
('AHFNCPERT22FCDW','abder','2014-09-03', 1, 'T', 1000, 'cabildo 500'),
('AHFNC22dRTGSCDW','abder','2014-08-03', 1, 'E', 1000, 'cabildo 500'),
('AHFNCPBDTGSFCDW','abder','2014-07-03', 1, 'T', 1000, 'cabildo 500'),
('AHFN4PERTGSFCDW','abder','2014-07-08', 1, 'E', 1000, 'cabildo 500'),
('AHFN234PEGSFCDW','abder','2014-04-03', 1, 'E', 1000, 'cabildo 500'),
('AHFNCPERT44FCDW','abder','2014-02-03', 1, 'E', 1000, 'cabildo 500'),
('AHFNCPER289FCDW','abder','2014-01-03', 1, 'E', 1000, 'cabildo 500'),
('AHFNCPERCBGFCDW','abder','2014-01-03', 1, 'E', 1000, 'cabildo 500')
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
go


create procedure SP_DevolucionItem(
@Codigo varchar(5),
@cantidad int 
)
as
begin
Update stock set Cantidad = Cantidad + @cantidad where CodigoArticulo = @Codigo
end
go

create procedure SP_DevolucionFactura(
@Factura varchar(15)
)
as
begin
Declare @CodigoArticulo varchar(5);
Declare @cantidad int;
Declare @lastArt varchar (5);
Declare cursorTabla CURSOR
FOR SELECT CodigoArticulo, Cantidad FROM itemsxfactura
WHERE CodigoFactura = @Factura;
OPEN cursorTabla;
FETCH NEXT FROM cursorTabla
        INTO
        @CodigoArticulo, @Cantidad       
	   
	   set @lastArt = @CodigoArticulo
		exec SP_DevolucionItem @CodigoArticulo, @cantidad

		
WHILE @@FETCH_STATUS = 0 
    BEGIN
        FETCH NEXT FROM cursorTabla
        INTO
        @CodigoArticulo, @Cantidad
        if @lastArt != @CodigoArticulo or @lastArt is null
		begin
			
			set @lastArt = @CodigoArticulo
			exec SP_DevolucionItem @CodigoArticulo, @cantidad
		end
	END
deallocate cursorTabla
end


go
create trigger tr_ventaStock
on itemsxfactura
after insert
as
begin
	declare @cant int
	declare @prod varchar (5)
	select @cant = Cantidad, @prod = CodigoArticulo from inserted
	update stock set Cantidad = Cantidad - @cant where CodigoArticulo = @prod


end

go
insert into favoritosxusuario values ('32d1a','qwdas'), ('32d1a','asasd')
go
insert into admins values ('abcde','admin@correo','adminpass','tomas')
go
insert into itemsxfactura values ('asasd','AHFNC22dRTGSCDW',14,2),('ckxa2','AHFNC22dRTGSCDW',14,2)
go
select * from itemsxfactura
go
use master
go
use depamphilis_db
go



select * from stock