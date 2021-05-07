use projeto_medicals;

select * from tipoUsuario;
select * from usuario;
select * from especialidade;
select * from clinica;
select * from medico;
select * from paciente;
select * from situacao;
select * from consulta;

--O administrador poder� cadastrar qualquer tipo de usu�rio (administrador, paciente ou m�dico)
select idUsuario, tituloTipoUsuario, email from Usuario
inner join tipoUsuario
on Usuario.idTipoUsuario = tipoUsuario.idTipoUsuario;

--O administrador poder� agendar uma consulta, onde ser� informado o paciente, data do agendamento e qual m�dico ir� atender a consulta (o m�dico possuir� sua determinada especialidade)
select idConsulta, nomePaciente, dataConsulta, nomeMedico from consulta 
inner join medico
on medico.idMedico = consulta.idConsulta
inner join paciente
on paciente.idPaciente = consulta.idPaciente; 

--O administrador poder� cancelar o agendamento
select tituloTipoUsuario[situacao], email from Usuario
inner join tipoUsuario
on usuario.idTipoUsuario = tipoUsuario.idTipoUsuario
where email = 'adm@adm.com';

--O administrador dever� informar os dados da cl�nica (como endere�o, hor�rio de funcionamento, CNPJ, nome fantasia e raz�o social)
select idClinica, endereco, CNPJ, nomeFantasia, razaoSocial from clinica;

--O m�dico poder� ver os agendamentos (consultas) associados a ele
select nomeMedico, nomePaciente, dataConsulta, descricao from consulta 
inner join  medico
on medico.idMedico = consulta.idMedico
inner join paciente
on paciente.idPaciente = consulta.idMedico
WHERE medico.idMedico = 1;

--O m�dico poder� incluir a descri��o da consulta que estar� vinculada ao paciente (prontu�rio)
select nomePaciente, descricao from paciente 
left join consulta
on consulta.idConsulta = paciente.idPaciente;


--O paciente poder� visualizar suas pr�prias consultas
select nomePaciente, dataConsulta, nomeMedico, descricao from paciente
inner join consulta 
on consulta.idConsulta = paciente.idPaciente
inner join medico 
on medico.idMedico = paciente.idPaciente;

--Converteu a data de nascimento do usu�rio para o formato (mm-dd-yyyy) na exibi��o
SELECT nomePaciente AS Nome, CONVERT (VARCHAR, dataNascimento, 101) AS DataNascimento FROM paciente;

--aqui mostra a quantidade de usu�rios cadastrados;
SELECT COUNT (Usuario.idUsuario) AS QuantidadeDeUsuarios  FROM Usuario;


