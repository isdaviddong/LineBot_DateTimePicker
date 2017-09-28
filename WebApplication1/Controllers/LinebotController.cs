using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class LinebotController : ApiController
    { 
        [HttpPost]
        public IHttpActionResult POST()
        {
            string ChannelAccessToken = "!!!!!!!!!!請改用自己的Line bot Token!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!";

            try
            {
                //取得 http Post RawData(should be JSON)
                string postData = Request.Content.ReadAsStringAsync().Result;
                //剖析JSON
                var ReceivedMessage = isRock.LineBot.Utility.Parsing(postData);
                //回覆訊息
                string Message = "";
                if (ReceivedMessage.events[0].message != null && !string.IsNullOrEmpty(ReceivedMessage.events[0].message.text))
                    Message = "你說了:" + ReceivedMessage.events[0].message.text;

                if (ReceivedMessage.events[0].postback != null)
                {
                    Message += "收到 postback data " + ReceivedMessage.events[0].postback.data;
                    Message += "\n postback params(datetime) " + 
                        ReceivedMessage.events[0].postback.Params.datetime;
                    Message += "\n postback params(date) " +
                        ReceivedMessage.events[0].postback.Params.date;
                    Message += "\n postback params(time) " + 
                        ReceivedMessage.events[0].postback.Params.time;
                }
                //回覆用戶
                isRock.LineBot.Utility.ReplyMessage(
                    ReceivedMessage.events[0].replyToken, Message, ChannelAccessToken);

                //回覆API OK
                return Ok();
            }
            catch (Exception ex)
            {
                //請自行handle Exception
                return Ok();
            }
        }
    }
}
