namespace FSP.Engengaria.Core.Infra.Data.Repository.SQL
{
    public class ComandoSqlServico
    {
        public static class Instrucao
        {
            public static string ObterTodosServico => @"select s.idservico as codigoservico, convert(varchar,s.idservico) + '-' + s.dsservico as descricaoservico, s.percentual, s.valor from servico s";

            public static string ObterServicoDaObraRelacionadosNaItenizacao => @"
            select distinct i.idservico as codigoservico, s.dsservico as descricaoservico
            from itemservico i, servico s
            where s.idservico = i.idservico
            and i.idobra = @codigoObra";

        }
    }
}
