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
	[Id] [int] IDENTITY(1,1) primary key NOT NULL,
	[Codigo] [varchar](5) unique NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](150) NULL,
	[IdMarca] [int]  foreign key references marcas(id),
	[ImagenUrl] [varchar](1000) NULL,
	[MargenGanancia] [int] not null
)

create table stock
(
	[CodigoProducto] [varchar] (50) unique not null,
	[Cantidad] [int] not null,
	[PrecioDistribuidor] [money] not null
)

go

create table categoriaxarticulo(
[CodigoArticulo] [varchar] (5),
[Idcategoria] [int] foreign key references categorias(id),
)
go

create view [vw_articulos] 
as
select a.Codigo, a.Nombre, a.Descripcion, a.IdMarca, m.Nombre as marca   from articulos as a 
inner join marcas as m on a.IdMarca = m.id


go

insert into marcas values ('arcor'),('la campagnola'),('Magistral'),('la serenisima'),('sancor')
insert into categorias values ('cocina'),('almacen'),('bebidas'),('lacteos'),('limpieza'),('golosinas')
insert into articulos values ('asasd','mermelada de naranja', 'caja 24 unidades', 2,'https://walmartar.vteximg.com.br/arquivos/ids/829225-1000-1000/Mermelada-Naranja-La-Campagnola-454-Gr-1-17738.jpg?v=636685104012570000', 25),
('qwere','Detergente Magistral', 'caja 24 unidades',3 ,'https://pbs.twimg.com/media/ETFuP6OWkAAiPt4.jpg', 25),
('qwdas','Bombones surtidos', 'caja 12 unidades', 1,'https://ardiaqa.vteximg.com.br/arquivos/ids/213174-1000-1000/SURTIDO-CHOCOLATE-ARCOR-266GR.jpg?v=636977361302600000', 25),
('asdqw','Leche largavida', 'pack 8 unidades', 4,'https://statics.dinoonline.com.ar/imagenes/full_600x600_ma/3262754_f.jpg', 25)
go
insert into categoriaxarticulo values ('asasd',2),('qwere',1),('qwere',5),('qwdas',6),('asdqw',4),('asdqw',2)
go
select * from vw_articulos as a
inner join categoriaxarticulo as cxa on a.Codigo = cxa.CodigoArticulo
inner join categorias as c on cxa.Idcategoria = c.id


