using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM.WebServices;
using PM.WebServices.Models;

namespace PM.WebServices.Service
{
    public class LocalInstalacaoServices
    {
        public IList<LocalInstalacao> GetAll()
        {
            return LocaisInstalacaoExtensions.GetAll(Links.appN.LocaisInstalacao);
        }

        public IList<LocalInstalacao> Search(int idFrota, int idTrem, int idCarro)
        {
            try
            {
                return LocaisInstalacaoExtensions.Search(Links.appN.LocaisInstalacao, idFrota, idTrem, idCarro);
            }
            catch (Exception e)
            {
                return new List<LocalInstalacao>();
            }
        }


        public IList<LocalInstalacao> SearchMS(int idFrota, int idTrem, int idCarro, int idSistema, int? idComplemento = null, int? idPosicao = null)
        {
            try
            {
                return LocaisInstalacaoExtensions.SearchMS(Links.appN.LocaisInstalacao, idFrota, idTrem, idCarro, idSistema, idComplemento, idPosicao);
            }
            catch (Exception e)
            {
                return new List<LocalInstalacao>();
            }
        }

        public IList<LocalInstalacao> Search1(int idFrota, int idTrem, int idCarro, int idLinha)
        {
            try
            {
                return LocaisInstalacaoExtensions.Search1(Links.appN.LocaisInstalacao, idFrota, idTrem, idCarro, idLinha);
            }
            catch (Exception e)
            {
                return new List<LocalInstalacao>();
            }
        }

        public IList<LocalInstalacao> Search3(int idFrota, int idTrem, int idCarro, int idLinha, int idSistema, int idComplemento, int idPosicao)
        {
            try
            {
                return LocaisInstalacaoExtensions.Search3(Links.appN.LocaisInstalacao, idFrota, idTrem, idCarro, idLinha, idSistema, idComplemento, idPosicao);
            }
            catch (Exception e)
            {
                return new List<LocalInstalacao>();
            }
        }

        public IList<LocalInstalacao> Search4(int idFrota, int idTrem, int idCarro, int idSistema, int idComplemento, int idPosicao)
        {
            try
            {
                return LocaisInstalacaoExtensions.Search4(Links.appN.LocaisInstalacao, idFrota, idTrem, idCarro, idSistema, idComplemento, idPosicao);
            }
            catch (Exception e)
            {
                return new List<LocalInstalacao>();
            }
        }

        public LocalInstalacao GetById(int id)
        {
            return LocaisInstalacaoExtensions.GetById(Links.appN.LocaisInstalacao, id);
        }

        public LocalInstalacao Add(LocalInstalacao _param)
        {
            return LocaisInstalacaoExtensions.Add(Links.appN.LocaisInstalacao, _param);
        }


        public IList<LocalInstalacao> ConsultarLCParametros(LocalInstalacao localInstalacao)
        {
            return LocaisInstalacaoExtensions.ConsultarLCParametros(Links.appN.LocaisInstalacao, localInstalacao);
        }

        /*public Sistema Update(Sistema _param)
        {
            return SistemasExtensions.Update(Links.appN.Sistemas, _param);
        }*/
    }
}