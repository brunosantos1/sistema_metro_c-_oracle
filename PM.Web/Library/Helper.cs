using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Collections.Generic;

namespace PM.Web.Library
{
    public class Helper
    {

        public static string ExportCSV(Object ValorOrigem)
        {   
            System.Text.StringBuilder oStringBuilderHeader = new System.Text.StringBuilder();
            System.Text.StringBuilder oStringBuilderData   = new System.Text.StringBuilder();
            System.Text.StringBuilder oStringBuilderSaida  = new System.Text.StringBuilder();

            try
            {
                if (ValorOrigem != null)
                {
                    var objOrigem = ValorOrigem.GetType();

                    string ValorDeOrigem = "";
                    string NomeAmigavelPropriedade;
                    string NomePropriedade;
                    System.Collections.IList lstOrigem;
                    foreach (var propOrigem in objOrigem.GetProperties().Where(c => c.Name.ToUpper().Equals("ITEM")))
                    {   
                        lstOrigem = (System.Collections.IList)propOrigem.GetValue(ValorOrigem);
                        oStringBuilderSaida.AppendFormat("{0}\r\n", oStringBuilderHeader.ToString());
                        oStringBuilderSaida.AppendFormat("{0}\r\n", oStringBuilderData.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
                throw new Exception("Erro ao gerar arquivo .csv");
            }
            finally
            {
                oStringBuilderHeader = null;
                oStringBuilderData = null;
            }
            return oStringBuilderSaida.ToString();
        }

        public static string MakeFisicalFile(string Body, string FileName)
        {
            string _retorno = "";
            try
            {
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                using (System.IO.StreamWriter outputFile = new System.IO.StreamWriter(System.IO.Path.Combine(docPath, FileName)))
                {   
                        outputFile.WriteLine(Body.ToString());
                }
                _retorno = System.IO.Path.Combine(docPath, FileName);
            }
            catch(Exception ex)
            {
                Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
                throw new Exception("Erro ao salvar arquivo .csv");
            }
            return _retorno;
        }
    }
}