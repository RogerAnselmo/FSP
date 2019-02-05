use FSPEngenharia

create table itemservico
(
 iditemservico int not null identity(1,1),
 idobra int not null,
 idservico int not null,
 noitem varchar(20) not null,
 dsitem varchar(200) not null,
 dsunidade varchar(10) not null,
 vlvalorunitario decimal(18,2) not null,
 noordem int null,
 constraint pk_iditemservico primary key(iditemservico),
 constraint fk_its_idobra foreign key(idobra) references obra(idobra),
 constraint fk_its_idservico foreign key(idservico) references servico(idservico)
)




select * from itemservico