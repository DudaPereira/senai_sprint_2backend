use inlock_games_tarde
go

insert into TipoUsuarios (titulo)
values                   ('administrador'),
                         ('cliente')
go

insert into Usuario (idTipoUsuario, email, senha)
values              (1, 'admin@admin.com', 'admin'),
                    (2, 'cliente@cliente.com', 'cliente')
go


insert into Estudios (nomeEstudio)
values               ('Blizzard'),   
                     ('Rockstar Studios'),
					 ('Square Enix')
go

insert into Jogos (idEstudio, nomeJogo, descricao, dataLancamento, valor)
values            (1, 'Diablo 3', 'é um jogo que contém bastante ação e é viciante, seja você um novato ou um fã', '15/05/2012', 99.00),
                  (2, 'Red Dead Redemption II', 'jogo eletrônico de ação-aventura western', '26/10/2018', 120.00)
go
