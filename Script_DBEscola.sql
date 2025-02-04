create database DBEscola;

use DBEscola;

create table tblAlunos(
   id int not null primary key auto_increment,
   nome varchar(50) not null,
   idade int not null,
   unidade char(1) not null,
   serie int not null,
   turma char(1) not null
);

insert into tblAlunos values(null, 'Gustavo Lima', '16', 'f', '2', 'E');
insert into tblAlunos values(null, 'Bernardo Lopes', '16', 'f', '2', 'E');
insert into tblAlunos values(null, 'Guilherme Rocha', '17', 'f', '2', 'E');
insert into tblAlunos values(null, 'Arthur Leite', '17', 'f', '2', 'E');
insert into tblAlunos values(null, 'Laura ormy', '16', 'f', '2', 'E');

