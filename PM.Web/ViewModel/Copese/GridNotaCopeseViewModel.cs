using System;

namespace PM.Web.ViewModel.Copese
{
    public class GridNotaCopeseViewModel : BaseViewModel
    {
        public GridNotaCopeseViewModel()
        {

        }

        public string nr_copese { get; set; }
        public string nr_nota_ref { get; set; }
        public string nr_notificador { get; set; }
        public string nr_lc_inst { get; set; }
        public string ds_nota { get; set; }
        public string ds_lc_inst { get; set; }
        public string ds_ct_trabalho { get; set; }
        public string ds_sintoma { get; set; }
        public DateTime dt_abertura_nota_ref { get; set; }
        public DateTime dt_abertura_nota_copese { get; set; }
        public string ds_st_copese { get; set; }
        public string id_copese { get; set; }
    }
}