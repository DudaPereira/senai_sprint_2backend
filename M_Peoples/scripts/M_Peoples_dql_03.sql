use M_Peoples;
go

-- exibi todas as informações de todos os funcionários
select * from Funcionarios;

-- exibi todos os funcionários 
select idFuncionario, nomeFuncio, sobrenomeFuncio
from Funcionarios;

-- exibe o funcionário com ID=1
select idFuncionario, nomeFuncio, sobrenomeFuncio
from Funcionarios 
where idFuncionario = 1;

-- exibe o funcionário que tenha o nome Tadeu
select idFuncionario, nomeFuncio, sobrenomeFuncio
from Funcionarios
where nomeFuncio = 'Tadeu';

-- exibe o nome completo dos funcionários 
select idFuncionario, concat (nomeFuncio, ' ', sobrenomeFuncio) As [Nome Completo],
dataNasci from Funcionarios;

--exibe  todos os funcionários de forma ordenada 
select idFuncionario, nomeFuncio, sobrenomeFuncio, dataNasci
from Funcionarios 
order by nomeFuncio desc;