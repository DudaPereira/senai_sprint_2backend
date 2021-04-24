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
values            (1, 'Diablo 3', '� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�', '15/05/2012', 99.00),
                  (2, 'Red Dead Redemption II', 'jogo eletr�nico de a��o-aventura western', '26/10/2018', 120.00)
go
