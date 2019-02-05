use FSPEngenharia

create table servico(
 idservico int not null identity(1,1),
 dsservico varchar(200)  not null,
 percentual decimal(18,2) not null,
 valor decimal(18,2) not null,
 constraint pk_servico primary key(idservico)
) 

select * from servico