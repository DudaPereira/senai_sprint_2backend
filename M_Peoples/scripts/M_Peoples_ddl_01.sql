create database M_Peoples;
go 

use M_Peoples;
go

create table Funcionarios
(
  idFuncionario int primary key identity
  ,nomeFuncio varchar (100) not null
  , sobrenomeFuncio varchar (100) not null
  ,dataNasci date not null 
);
go
