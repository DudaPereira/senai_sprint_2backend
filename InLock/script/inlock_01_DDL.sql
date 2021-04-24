create database inlock_games_tarde
go 

use inlock_games_tarde
go 

create table Estudios 
(
   idEstudio    int primary key identity, 
   nomeEstudio  varchar(100) not null
)
go

create table Jogos 
(
   idJogo          int primary key identity, 
   idEstudio       int foreign key references Estudios(idEstudio),
   nomeJogo        varchar(200) not null, 
   descricao       varchar(250) not null,
   dataLancamento  date not null, 
   valor           smallmoney not null 
)
go

create table TipoUsuarios 
(
  idTipoUsuario  int primary key identity, 
  titulo         varchar(200) not null
)
go

create table Usuario 
(
  idUsuario int primary key identity,
  idTipoUsuario int foreign key references TipoUsuarios(idTipoUsuario),
  email     varchar(100) unique not null, 
  senha     varchar(50) not null 
)
go