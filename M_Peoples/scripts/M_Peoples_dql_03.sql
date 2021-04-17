use M_Peoples;
go

-- exibi todas as informa��es de todos os funcion�rios
select * from Funcionarios;

-- exibi todos os funcion�rios 
select idFuncionario, nomeFuncio, sobrenomeFuncio
from Funcionarios;

-- exibe o funcion�rio com ID=1
select idFuncionario, nomeFuncio, sobrenomeFuncio
from Funcionarios 
where idFuncionario = 1;

-- exibe o funcion�rio que tenha o nome Tadeu
select idFuncionario, nomeFuncio, sobrenomeFuncio
from Funcionarios
where nomeFuncio = 'Tadeu';

-- exibe o nome completo dos funcion�rios 
select idFuncionario, concat (nomeFuncio, ' ', sobrenomeFuncio) As [Nome Completo],
dataNasci from Funcionarios;

--exibe  todos os funcion�rios de forma ordenada 
select idFuncionario, nomeFuncio, sobrenomeFuncio, dataNasci
from Funcionarios 
order by nomeFuncio desc;