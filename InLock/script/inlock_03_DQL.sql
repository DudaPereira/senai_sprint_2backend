use inlock_games_tarde
go

select * from TipoUsu�rios
go

select * from Est�dios
go

select * from Jogos
go

--Listar todos os jogos e seus respectivos est�dios;
select nomeJogo, nomeEstudio from Jogos 
inner join Est�dios
on Jogos.idEstudio = Est�dios.idEstudio 
go

--Buscar e trazer na lista todos os est�dios com os respectivos jogos.
select Est�dios.nomeEstudio, nomeJogo from Est�dios
left join Jogos
on Est�dios.idEstudio = Jogos.idEstudio
go

--Buscar um usu�rio por e-mail e senha (login);
select idUsuario, email, senha from Usu�rio
where email = 'admin@admin.com' and senha = 'admin'
go

--Buscar um jogo por idJogo;
select idJogo, nomeJogo from Jogos 
where idJogo = 1
go

--Buscar um est�dio por idEstudio;
select idEstudio, nomeEstudio from Est�dios
where idEstudio = 3
go