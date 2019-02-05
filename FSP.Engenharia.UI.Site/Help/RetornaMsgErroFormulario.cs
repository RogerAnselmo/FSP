using System.Web.Mvc;

namespace FSP.Engenharia.UI.Site.Help
{
    public class RetornaMsgErroFormulario : Controller
    {
        public static string RetornaMsgErro(ModelStateDictionary model)
        {
            string retorno = string.Empty;

            foreach (var obj in model.Values)
            {
                foreach (var error in obj.Errors)
                {
                    if (!string.IsNullOrEmpty(error.ErrorMessage))
                        retorno += error.ErrorMessage + "\n";
                }
            }

            return retorno;
        }
    }
}