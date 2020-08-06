using System.Web;
using System.Web.Optimization;

namespace PM.LogAndAlert
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // jQuery
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery/dist/jquery.min.js"));

            // Bootstrap
            bundles.Add(new ScriptBundle("~/bundles/Bootstrap").Include("~/Scripts/bootstrap/dist/js/bootstrap.min.js"));

            // NProgress - Funcionalidades dos Menus
            bundles.Add(new ScriptBundle("~/bundles/NProgress").Include("~/Scripts/nprogress/nprogress.js"));

            // bootstrap - daterangepicker - Funcionalidades Data Picker
            bundles.Add(new ScriptBundle("~/bundles/bootstrap-daterangepicker").Include(
                                                                                          "~/Scripts/moment/min/moment.min.js"
                                                                                        , "~/Scripts/bootstrap-daterangepicker/daterangepicker.js"
                                                                                      ));

            // Flot 
            bundles.Add(new ScriptBundle("~/bundles/Grafico").Include(
                                                                      "~/Scripts/grafico/Flot/jquery.flot.js"                                   // Funcionalidades Graficas - Motor do Grafico
                                                                     , "~/Scripts/grafico/Flot/jquery.flot.pie.js"                              // Funcionalidades Graficas - Monta Grafico do tipo pizza
                                                                     , "~/Scripts/grafico/Flot/jquery.flot.time.js"                             // Funcionalidades Graficas - Monta Grafico do tipo linhas
                                                                     , "~/Scripts/grafico/Flot/jquery.flot.stack.js"                            // Funcionalidades Graficas - Monta Grafico do tipo linhas
                                                                     , "~/Scripts/grafico/Flot/jquery.flot.resize.js"                           // Funcionalidades Graficas - Ajusta grafico responsive
                                                                     , "~/Scripts/grafico/flot.orderbars/js/jquery.flot.orderBars.js"           // Funcionalidades Graficas - 
                                                                     , "~/Scripts/grafico/flot-spline/js/jquery.flot.spline.min.js"             // Funcionalidades Graficas - 
                                                                     , "~/Scripts/grafico/flot.curvedlines/curvedLines.js"                      // Funcionalidades Graficas - 
                                                                     , "~/Scripts/grafico/DateJS/build/date.js"                                 // Funcionalidades Graficas - Identifica Idioma do Grafico
                                                                     , "~/Scripts/grafico/Chart.js/dist/Chart.min.js"                           // Funcionalidades Graficas - Grafico de Pizza
                                                                     , "~/Scripts/grafico/jquery-sparkline/dist/jquery.sparkline.min.js"        // Funcionalidades Graficas - Grafico de Barra
                                                                     , "~/Scripts/grafico/bootstrap-progressbar/bootstrap-progressbar.min.js"   // Funcionalidades Graficas - Progress Bar
                                                                     , "~/Scripts/grafico/fastclick/lib/fastclick.js"                           // Funcionalidades Graficas - Correção de Erros do Navegador
                                                                     , "~/Scripts/grafico/morris.js/raphael/raphael.min.js"                     // Funcionalidades Graficas - Grafico de barras com legenda
                                                                     , "~/Scripts/grafico/morris.js/morris.min.js"                              // Funcionalidades Graficas - Grafico de barras com legenda
                                                                  ));
            // Funcionalidades DataTable
            bundles.Add(new ScriptBundle("~/bundles/Datatables").Include(
                                                                           "~/Scripts/datatables/datatables.net/js/jquery.dataTables.min.js"
                                                                         , "~/Scripts/datatables/datatables.net-bs/js/dataTables.bootstrap.min.js"
                                                                         , "~/Scripts/datatables/datatables.net-buttons/js/dataTables.buttons.min.js"
                                                                         , "~/Scripts/datatables/datatables.net-buttons-bs/js/buttons.bootstrap.min.js"
                                                                         , "~/Scripts/datatables/datatables.net-buttons/js/buttons.flash.min.js"
                                                                         , "~/Scripts/datatables/datatables.net-buttons/js/buttons.html5.min.js"
                                                                         , "~/Scripts/datatables/datatables.net-buttons/js/buttons.print.min.js"
                                                                         , "~/Scripts/datatables/datatables.net-fixedheader/js/dataTables.fixedHeader.min.js"
                                                                         , "~/Scripts/datatables/datatables.net-keytable/js/dataTables.keyTable.min.js"
                                                                         , "~/Scripts/datatables/datatables.net-responsive/js/dataTables.responsive.min.js"
                                                                         , "~/Scripts/datatables/datatables.net-responsive-bs/js/responsive.bootstrap.js"
                                                                         , "~/Scripts/datatables/datatables.net-scroller/js/dataTables.scroller.min.js"
                                                                        ));
            bundles.Add(new ScriptBundle("~/bundles/FormUI").Include(
                                                                           "~/Scripts/bootstrap-toggle/2.2.2/js/bootstrap-toggle.min.js"                    // CheckBox Animado
                                                                     ));

            // Custom Theme Scripts
            bundles.Add(new ScriptBundle("~/bundles/Custom").Include(
                                                                      //"~/Scripts/build/js/custom.js"
                                                                      "~/Scripts/build/js/menuprincipal.js"
                                                                    , "~/Scripts/build/js/graficos.js"
                                                                    , "~/Scripts/build/js/daterangepicker.js"
                                                                    , "~/Scripts/build/js/datatables.js"
                                                                    , "~/Scripts/build/js/vw_generico.js"

                                                                    ));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap/dist/css/bootstrap.min.css"                                          // CSS Default do framework Bootstrap
                                                                , "~/Content/bootstrap-toggle/2.2.2/css/bootstrap-toggle.min.css"                           // CheckBox Animado
                                                                , "~/Content/font-awesome/css/font-awesome.min.css"                                         // Configura Fontes da Aplicação
                                                                , "~/Content/build/css/custom.min.css"                                                      // CSS de Customização do Template Utilizado
                                                                , "~/Content/build/css/sitepm.css"                                                          // CSS Exclusivo do Metro
                                                                , "~/Content/datatables/datatables.net-bs/css/dataTables.bootstrap.min.css"                 // Funcionalidades DataTable
                                                                , "~/Content/datatables/datatables.net-responsive-bs/css/responsive.bootstrap.min.css"      // Funcionalidades DataTable Responsive
                                                                , "~/Content/datatables/datatables.net-scroller-bs/css/scroller.bootstrap.min.css"          // Funcionalidades Rolagem Tela BootStrap
                                                                , "~/Content/bootstrap-daterangepicker/daterangepicker.css"                                 // Funcionalidades Data Picker                                                                
                                                                , "~/Content/switchery/dist/switchery.min.css"
                                                               ));

            bundles.Add(new StyleBundle("~/bundles/ConsultaLog").Include("~/Scripts/build/js/vw_consultalog.js"));
            bundles.Add(new StyleBundle("~/bundles/Aplicacao").Include("~/Scripts/build/js/vw_aplicacao.js"));
        }
    }
}
