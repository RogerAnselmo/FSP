namespace FSP.Engengaria.Core.Infra.Data.Repository.SQL
{
    public class ComandoSqlItemServico
    {
        public static class Instrucao
        {
            public static string ObterProximoValorItemDoServico => @"select ISNULL(MAX(noordem),0) + 1 as NumeroOrdem from itemservico i where i.idobra = @codigoObra and i.idservico = @codigoServico";
            public static string ObterItemServicoDaObraEDoServicoParaPedidoMaterial => @"
            select it.iditemservico as codigoitemservico, it.noitem + ' - ' + it.dsitem as descricaoitem, it.dsunidade as descricaounidade, it.vlvalorunitario as valorunitario
            from itemservico it
            where it.idobra = @codigoObra and it.idservico = @codigoServico";
        }
    }
}
