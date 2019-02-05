use FSPEngenharia

create table pedidomaterial
(
 idpedidomaterial int not null identity(1,1),
 datapedido datetime not null,
 nmsolitante varchar(100) not null,
 nmautorizado varchar(100) not null,
 vlvalorpedido decimal(18,2) not null,
 constraint pk_pedidomaterial primary key(idpedidomaterial)
)


create table detalhespedidomaterial
(
 iddetalhespedidomaterial int not null identity(1,1),
 idpedidomaterial int not null,
 idobra int not null,
 idservico int not null,
 constraint pk_detalhespedidomaterial primary key(iddetalhespedidomaterial),
 constraint fk_dpm_idobra foreign key(idobra) references obra(idobra),
 constraint fk_dpm_idservico foreign key(idservico) references servico(idservico)
)

