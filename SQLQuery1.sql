
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
[Nombre][varchar] (50) unique not null
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
	[CodigoArticulo] [varchar] (5) foreign key references articulos(Codigo),
	[Cantidad] [int] not null,
	[PrecioDistribuidor] [money] not null,
	
)

go

create table categoriaxarticulo(
[CodigoArticulo] [varchar] (5) foreign key references articulos(Codigo) ,
[Idcategoria] [int] foreign key references categorias(id),

)
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
[Correo] [varchar] (100) not null,
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
[Monto] [money] not null
)
go
create table itemsxfactura(
[CodigoArticulo] [varchar] (5) foreign key references articulos(Codigo),
[CodigoFactura] [varchar] (15) foreign key references facturas(Codigo),
[Precio] [money] not null,
[Cantidad] [int] not null
)
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
group by m.Nombre, m.Id
go
create view [vw_usuarios]
as
select u.codigo, u.Nombre,u.Apellido,u.DNI,u.Correo,u.Password, u.Dirrecion, z.Id as idzona, z.Nombre as zona from usuarios as u
inner join zonas as z on z.Id = u.IdZona
go
insert into marcas values ('arcor'),('la campagnola'),('Magistral'),('la serenisima'),('sancor')
insert into categorias values ('cocina'),('almacen'),('bebidas'),('lacteos'),('limpieza'),('golosinas')
insert into articulos values ('asasd','mermelada de naranja', 'caja 24 unidades', 2,'https://walmartar.vteximg.com.br/arquivos/ids/829225-1000-1000/Mermelada-Naranja-La-Campagnola-454-Gr-1-17738.jpg?v=636685104012570000', 100,1),
('qwere','Detergente Magistral', 'caja 24 unidades',3 ,'https://www.ofiflex.com.ar/wp-content/uploads/578_13.jpg', 25,1),
('qwdas','Bombones surtidos', 'caja 12 unidades', 1,'https://ardiaqa.vteximg.com.br/arquivos/ids/213174-1000-1000/SURTIDO-CHOCOLATE-ARCOR-266GR.jpg?v=636977361302600000', 25,1),
('asdqw','Leche largavida', 'pack 8 unidades', 4,'https://statics.dinoonline.com.ar/imagenes/full_600x600_ma/3262754_f.jpg', 25,1)
go
insert into categoriaxarticulo values ('asasd',2),('qwere',1),('qwere',5),('qwdas',6),('asdqw',4),('asdqw',2)
go
insert into stock values ('asasd', 0,500),('qwere', 300,200),('qwdas', 100,700),('asdqw', 300,500)
go
insert into zonas values ('CABA'), ('Norte'), ('Sur')
go
insert into usuarios values ('abcdf' ,'Tomas', 'De Pamphilis', 41067359, 'tomdp@gmail.com','hola123','calle falsa 123',2)
go
insert into admins values ('abcde','admin@correo','adminpass','tomas')

select * from  vw_usuarios

select * from admins
/*
as a
inner join categoriaxarticulo as cxa on a.Codigo = cxa.CodigoArticulo
inner join categorias as c on cxa.Idcategoria = c.id
*/

select Count(*) from usuarios where Codigo = '3321d'