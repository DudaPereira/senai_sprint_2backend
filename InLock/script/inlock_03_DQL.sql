use inlock_games_tarde
go

select * from TipoUsuários
go

select * from Estúdios
go

select * from Jogos
go

--Listar todos os jogos e seus respectivos estúdios;
select nomeJogo, nomeEstudio from Jogos 
inner join Estúdios
on Jogos.idEstudio = Estúdios.idEstudio 
go

--Buscar e trazer na lista todos os estúdios com os respectivos jogos.
select Estúdios.nomeEstudio, nomeJogo from Estúdios
left join Jogos
on Estúdios.idEstudio = Jogos.idEstudio
go

--Buscar um usuário por e-mail e senha (login);
select idUsuario, email, senha from Usuário
where email = 'admin@admin.com' and senha = 'admin'
go

--Buscar um jogo por idJogo;
select idJogo, nomeJogo from Jogos 
where idJogo = 1
go

--Buscar um estúdio por idEstudio;
select idEstudio, nomeEstudio from Estúdios
where idEstudio = 3
go