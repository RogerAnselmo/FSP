namespace FSP.Engengaria.Core.Infra.Data.Repository.SQL
{
    public class ComandoSqlObra
    {
        public static class Instrucao
        {
            public static string ObterObraPorDescricao => @"
            select 
	            idobra as CodigoObra, 
	            dsobjeto as DescricaoObjeto,
	            nmobra as NomeObra,
	            dsendreco as Endereco,
	            dsbairro as Bairro,
	            dscidade as Cidade,
	            dsuf as uf,
	            nocep as cep,
	            dsstatus as status,
                datainicio,
	            datafim
            from obra where lower(nmobra) like lower(@NomeObra)";
        }
    }
}
