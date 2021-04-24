use inlock_games_tarde
go

select * from TipoUsuarios
go

select * from Estudios
go

select * from Jogos
go

--Listar todos os jogos e seus respectivos est�dios;
select nomeJogo, nomeEstudio from Jogos 
inner join Estudios
on Jogos.idEstudio = Estudios.idEstudio 
go

--Buscar e trazer na lista todos os est�dios com os respectivos jogos.
select Estudios.nomeEstudio, nomeJogo from Estudios
left join Jogos
on Estudios.idEstudio = Jogos.idEstudio
go

--Buscar um usu�rio por e-mail e senha (login);
select idUsuario, email, senha from Usuario
where email = 'admin@admin.com' and senha = 'admin'
go

--Buscar um jogo por idJogo;
select idJogo, nomeJogo from Jogos 
where idJogo = 1
go

--Buscar um est�dio por idEstudio;
select idEstudio, nomeEstudio from Estudios
where idEstudio = 3
go