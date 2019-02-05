namespace FSP.Engengaria.Core.Infra.Data.Repository.SQL
{
    public class ComandoSqlItenizacao
    {
        public static class Instrucao
        {
            public static string ObterProximoValorItemDoServico => @"select ISNULL(MAX(noordem),0) + 1 as NumeroOrdem from itenizacao i where i.idobra = @codigoObra and i.idservico = @codigoServico";
            public static string ObterItenizacaoDaObraEDoServicoParaPedidoMaterial => @"
            select it.iditenizacao as codigoitenizacao, it.noitem + ' - ' + it.dsitem as descricaoitem, it.dsunidade as descricaounidade, it.vlvalorunitario as valorunitario
            from itenizacao it
            where it.idobra = @codigoObra and it.idservico = @codigoServico";
        }
    }
}
