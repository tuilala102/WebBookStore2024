using System.Web;
using System.Web.Optimization;

namespace WebBookStore
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/LTE211CSS").Include(
                     "~/Assets/Template/Admin/LTE/211/bootstrap/css/bootstrap.min.css",
                     "~/Assets/Template/Admin/LTE/211/font-awesome/4.3.0/css/font-awesome.min.css",
                     "~/Assets/Template/Admin/LTE/211/ionicons/2.0.1/css/ionicons.min.css",
                     "~/Assets/Template/Admin/LTE/211/dist/css/AdminLTE.min.css",
                     "~/Assets/Template/Admin/LTE/211/dist/css/skins/_all-skins.min.css",
                     "~/Assets/Template/Admin/LTE/211/plugins/iCheck/flat/blue.css",
                     "~/Assets/Template/Admin/LTE/211/plugins/morris/morris.css",
                     "~/Assets/Template/Admin/LTE/211/plugins/jvectormap/jquery-jvectormap-1.2.2.css",
                     "~/Assets/Template/Admin/LTE/211/plugins/datepicker/datepicker3.css",
                     "~/Assets/Template/Admin/LTE/211/plugins/daterangepicker/daterangepicker-bs3.css",
                     "~/Assets/Template/Admin/LTE/211/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css",
                     "~/Assets/Template/Admin/LTE/211/plugins/iCheck/square/blue.css",
                     "~/Assets/Content/AdminSite.css"
                      ));
            bundles.Add(new StyleBundle("~/bundles/contentCSS").Include(
                     "~/Assets/Content/bootstrap.css",
                     "~/Assets/Content/site.css"
                      ));
            bundles.Add(new StyleBundle("~/bundles/JTableCSS").Include(
                     "~/Assets/Scripts/DataTable/media/css/jquery.dataTables.min.css",
                     "~/Assets/Scripts/DataTable/extensions/colvis/css/dataTables.colvis.jqueryui.css",
                     "~/Assets/Scripts/DataTable/extensions/colvis/css/dataTables.colVis.min.css",
                     "~/Assets/Scripts/DataTable/extensions/ColReorder/css/dataTables.colReorder.min.css",
                     "~/Assets/Scripts/DataTable/extensions/TableTools/css/dataTables.tableTools.min.css"
                      ));
            bundles.Add(new StyleBundle("~/bundles/UnicaseCSS").Include(
                     "~/Assets/Template/User/Unicase/assets/css/bootstrap.min.css",
                     "~/Assets/Template/User/Unicase/assets/css/btn_top.css",
                     "~/Assets/Template/User/Unicase/assets/css/main.css",
                     "~/Assets/Template/User/Unicase/assets/css/owl.carousel.css",
                     "~/Assets/Template/User/Unicase/assets/css/owl.transitions.css",
                     "~/Assets/Template/User/Unicase/assets/css/lightbox.css",
                     "~/Assets/Template/User/Unicase/assets/css/animate.min.css",
                     "~/Assets/Template/User/Unicase/assets/css/bootstrap-select.min.css",
                     "~/Assets/Template/User/Unicase/assets/css/config.css",
                     "~/Assets/Content/Site.css",
                     "~/Assets/Template/User/Unicase/assets/css/font-awesome.min.css"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/LTE211JS").Include(
                     "~/Assets/Template/Admin/LTE/211/plugins/jQuery/jQuery-2.1.4.min.js",
                     "~/Assets/Template/Admin/LTE/211/jQueryUI/1.11.2/jquery-ui.min.js",
                     "~/Assets/Template/Admin/LTE/211/bootstrap/js/bootstrap.min.js",
                     "~/Assets/Template/Admin/LTE/211/raphael/2.1.0/raphael-min.js",
                     "~/Assets/Template/Admin/LTE/211/plugins/morris/morris.min.js",
                     "~/Assets/Template/Admin/LTE/211/plugins/sparkline/jquery.sparkline.min.js",
                     "~/Assets/Template/Admin/LTE/211/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js",
                     "~/Assets/Template/Admin/LTE/211/plugins/jvectormap/jquery-jvectormap-world-mill-en.js",
                     "~/Assets/Template/Admin/LTE/211/plugins/knob/jquery.knob.js",
                     "~/Assets/Template/Admin/LTE/211/moment/2.10.0/moment.min.js",
                     "~/Assets/Template/Admin/LTE/211/plugins/daterangepicker/daterangepicker.js",
                     "~/Assets/Template/Admin/LTE/211/plugins/datepicker/bootstrap-datepicker.js",
                     "~/Assets/Template/Admin/LTE/211/plugins/slimScroll/jquery.slimscroll.min.js",
                     "~/Assets/Template/Admin/LTE/211/dist/js/app.min.js",
                     "~/Assets/Scripts/ckeditor/ckeditor.js",
                     "~/Assets/Scripts/NumberJS/numeral.min.js",
                     "~/Assets/Template/Admin/LTE/211/plugins/iCheck/icheck.min.js",
                     "~/Assets/Template/Admin/LTE/211/dist/js/demo.js",
                     "~/Assets/Scripts/setup_format_number.js",
                     "~/Assets/Template/Admin/LTE/211/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js",
                     "~/Assets/Template/Admin/LTE/211/dist/js/pages/dashboard.js",
                     "~/Assets/Scripts/LoadDataTable.js",
                     "~/Assets/Scripts/ModelPopup.js"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/Modernizr").Include(
                     "~/Assets/Scripts/modernizr-2.6.2.js"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/BSValidJS").Include(
                     "~/Assets/Scripts/BootstrapValidator/js/bootstrapValidator.min.js"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/JTableJS").Include(
                     "~/Assets/Scripts/DataTable/media/js/jquery.dataTables.min.js"
                  //   "~/Assets/Scripts/DataTable/extensions/colvis/js/dataTables.colVis.min.js",
                  //   "~/Assets/Scripts/DataTable/extensions/ColReorder/js/dataTables.colReorder.min.js",
                  //   "~/Assets/Scripts/DataTable/extensions/TableTools/js/dataTables.tableTools.min.js"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/UnicaseJS").Include(
                     "~/Assets/Template/User/Unicase/assets/js/jquery-1.11.1.min.js",
                     "~/Assets/Template/User/Unicase/assets/js/btn_top.js",
                     "~/Assets/Template/User/Unicase/assets/js/bootstrap.min.js",
                     "~/Assets/Template/User/Unicase/assets/js/bootstrap-hover-dropdown.min.js",
                     "~/Assets/Template/User/Unicase/assets/js/owl.carousel.min.js",
                     "~/Assets/Template/User/Unicase/assets/js/echo.min.js",
                     "~/Assets/Template/User/Unicase/assets/js/jquery.easing-1.3.min.js",
                     "~/Assets/Template/User/Unicase/assets/js/bootstrap-slider.min.js",
                     "~/Assets/Template/User/Unicase/assets/js/bootstrap-select.min.js",
                     "~/Assets/Template/User/Unicase/assets/js/scripts.js",
                     "~/Assets/Scripts/NumberJS/numeral.min.js",
                     "~/Assets/Scripts/LoadCart.js",                   
                     "~/Assets/Scripts/FlyingCart.js",
                     "~/Assets/Scripts/RemoveCartAjax.js",
                     "~/Assets/Scripts/Dropdown.js",
                     "~/Assets/Scripts/Paging.js",
                     "~/Assets/Scripts/process_box_chat.js",
                     "~/Assets/Scripts/setup_format_number.js"
                      ));
        }
    }
}
