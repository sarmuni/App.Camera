using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using APP.Camera.Application;
using APP.Camera.Domain;
using APP.Framework;
using APP.Framework.Infrastructure;
using Newtonsoft.Json;

namespace APP.Camera.Api.Controllers
{    
    public class CaptureController : ApiController
    {
        private CaptureMobileAppService captureMobileAppService;

        UserProfile usr = new UserProfile
        {
            GlobalID = "System",
            ApplicationMode = Enumeration.ApplicationMode.Production,
            IPAddress = "127.0.0.1"
        };

        //[HttpGet]
        //public String Get()
        //{

        //    return test;
        //}

        [HttpPost]
        public ResultCapture Post()
        {
            ResultCapture result = new ResultCapture();

            String userid, foto, dirname;
            var httpRequest = HttpContext.Current.Request;
            foto = httpRequest["foto"] == null ? "" : httpRequest["foto"].Trim();
            userid = httpRequest["userid"] == null ? "" : httpRequest["userid"].Trim();
            dirname = httpRequest["dirname"] == null ? "" : httpRequest["dirname"].Trim();

            usr.GlobalID = userid;
            //Singleton.Instance.userProfile = usr;
            captureMobileAppService = new CaptureMobileAppService(usr);

            //var myParam = JsonConvert.DeserializeObject<JsonCapture>(myJSON);// parse json string to object.
            //if (myParam != null)
            //{
            //    userid = myParam.userid;
            //    foto = myParam.foto;
            //    dirname = myParam.dirname;

            //}
            //else
            //{
            //    result.success = false;
            //    result.code = 200;
            //    result.message = "Invalid JSON Format";

            //    return result;
            //}
            try
            {
                //uploadImage
                String dirImage = "", dirSave = "";
                if (!String.IsNullOrEmpty(foto))
                {
                    //klo data image ada
                    dirImage = @"E:\Userfiles\cameraapp.userfiles\" + userid + @"\" + dirname + @"\";

                    bool exists = System.IO.Directory.Exists(dirImage);

                    if (!exists)
                        System.IO.Directory.CreateDirectory(dirImage);

                    dirImage = dirImage + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                    dirSave = "./foto/" + userid + "/" + dirname + "/" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                    //img.Save(dirImage);

                    byte[] bytes = Convert.FromBase64String(foto);

                    Image image;
                    using (MemoryStream ms = new MemoryStream(bytes))
                    {
                        image = Image.FromStream(ms);

                        image.Save(dirImage);
                    }

                    CaptureMobile capture = new CaptureMobile();
                    capture.DirName = dirname;
                    capture.CaptureFile = dirSave;

                    TransactionResult res;
                    res = captureMobileAppService.Update(ref capture);

                    if (res.Result == 1)
                    {
                        result.success = true;
                        result.code = 200;
                        result.message = "Insert data successfully";
                    }
                    else
                    {
                        result.success = false;
                        result.code = 200;
                        result.message = "Insert data failed";
                    }
                }
            }catch(Exception ex)
            {
                result.success = false;
                result.code = 200;
                result.message = ex.Message.ToString();
            }
            return result;
        }

    }
}
