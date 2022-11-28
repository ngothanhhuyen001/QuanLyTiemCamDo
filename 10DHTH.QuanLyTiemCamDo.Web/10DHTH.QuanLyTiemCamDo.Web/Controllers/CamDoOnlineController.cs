using Microsoft.AspNetCore.Mvc;

namespace _10DHTH.QuanLyTiemCamDo.Web.Controllers
{

    //[Route("api/[controller]")]
    public class CamDoOnlineController : Controller
	{
        public CamDoOnlineController() { }
        /// <summary>
        /// Main View
        /// </summary>
        /// <returns></returns>
        [Route("~/main")]
        [HttpGet]
        public IActionResult Main()
        {
            return View();
        }
        /// <summary>
        /// _Step1_PV (Step 1)
        /// </summary>
        /// <param name="data"></param>
        /// <param name="buttonType"></param>
        /// <param name="stepName"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult _ThietLapKhoanVay(string data, string buttonType, string stepName)
        {
          
            if (data != null && buttonType == "next")
            {
                return PartialView("~/Views/CamDoOnline/PartialViews/_ThongTinKH.cshtml", data); //Step 2
            }

            else if (buttonType == "prev")
            {
                return PartialView("~/Views/CamDoOnline/PartialViews/_ThietLapKhoanVay.cshtml"); //Step 1
            }

            if (buttonType == "selected")
            {
                return PartialView($"~/Views/CamDoOnline/PartialViews/{stepName}.cshtml", data); // step selected
            }

            return Json("Fail");
        }

        /// <summary>
        /// _Step2_PV (Step 2)
        /// </summary>
        /// <param name="data"></param>
        /// <param name="buttonType"></param>
        /// <param name="stepName"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult _ThongTinKH(string data, string buttonType, string stepName)
        {
           
            if (data != null && buttonType == "next")
            {
                return PartialView("~/Views/CamDoOnline/PartialViews/_HoanTat.cshtml", data); //Step 3
            }
            else if (buttonType == "prev")
            {
                return PartialView("~/Views/CamDoOnline/PartialViews/_ThietLapKhoanVay.cshtml", data); //Step 1 
            }

            if (buttonType == "selected")
            {
                return PartialView($"~/Views/CamDoOnline/PartialViews/{stepName}.cshtml", data); // step selected
            }

            return Json("Fail");
        }


        /// <summary>
        /// _Step3_PV (Step 3)
        /// </summary>
        /// <param name="data"></param>
        /// <param name="buttonType"></param>
        /// <param name="stepName"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult _HoanTat(string data, string buttonType, string stepName)
        {

            if (buttonType == "prev")
            {
                return PartialView("~/Views/CamDoOnline/PartialViews/_ThongTinKH.cshtml", data); //Step 2
            }

            if (buttonType == "selected")
            {
                return PartialView($"~/Views/CamDoOnliner/PartialViews/{stepName}.cshtml", data); // step selected
            }

            return Json("Fail");

        }

    }
}
