use FSPEngenharia


create table itenizacao
(
 iditenizacao int not null identity(1,1),
 idobra int not null,
 idservico int not null,
 noitem varchar(20) not null,
 dsitem varchar(200) not null,
 dsunidade varchar(10) not null,
 vlvalorunitario varchar(10) not null,
 noordem int null,
 constraint pk_itenizacao primary key(iditenizacao),
 constraint fk_pm_idobra foreign key(idobra) references obra(idobra),
 constraint fk_pm_idservico foreign key(idservico) references servico(idservico)
)

alter table itenizacao add constraint pk_itenizacao primary key(iditenizacao) 




