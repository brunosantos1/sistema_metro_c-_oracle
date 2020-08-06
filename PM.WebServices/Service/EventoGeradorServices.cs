using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class EventoGeradorServices
    {
        public IList<EventoGerador> GetAll()
        {
            return EventosGeradorExtensions.GetAll(Links.appN.EventosGerador);
        }

        public EventoGerador GetById(int id)
        {
            return EventosGeradorExtensions.GetById(Links.appN.EventosGerador, id);
        }

        public EventoGerador Add(EventoGerador _param)
        {
            return EventosGeradorExtensions.Add(Links.appN.EventosGerador, _param);
        }

        public EventoGerador Update(EventoGerador _param)
        {
            return EventosGeradorExtensions.Update(Links.appN.EventosGerador, _param);
        }
    }
}