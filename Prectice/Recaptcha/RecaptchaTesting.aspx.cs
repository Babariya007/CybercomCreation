using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Recaptcha
{
    public partial class Recaptcha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnClick_Click(object sender, EventArgs e)
        {
            if (!IsReCaptchaValid())
            {
                Response.Write(txtName.Text);
            }
            else 
            {
                Response.Write("Please fill Captcha");
            }
        }

        public class WebResponseCaptch
        {
            public bool Success { get; set; }
            public string Challenge_TS { get; set; }
            public string HostName { get; set; }
            public string Error_Codes { get; set; }
        }

        public bool IsReCaptchaValid()
        {
            var result = false;
            var captchaResponse = Request.Form["g-recaptcha-response"];
            var secretKey = "";
            var apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
            var requestUrl = string.Format(apiUrl, secretKey, captchaResponse);
            var request = (HttpWebRequest)WebRequest.Create(requestUrl);

            using (WebResponse res = request.GetResponse())
            {
                using (StreamReader sr = new StreamReader(res.GetResponseStream()))
                {
                    JavaScriptSerializer java = new JavaScriptSerializer();
                    WebResponseCaptch response = java.Deserialize<WebResponseCaptch>(sr.ReadToEnd());
                    result = response.Success;
                }
            }
            return result;
        }
    }
}