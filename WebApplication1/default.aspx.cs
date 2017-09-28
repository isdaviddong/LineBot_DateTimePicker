using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        { 
            //建立Bot instance
            isRock.LineBot.Bot bot =
                new isRock.LineBot.Bot("!!!!!!!!!!請改用自己的Line bot Token!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");  //傳入Channel access token

            //建立actions，作為ButtonTemplate的用戶回覆行為
            var actions = new List<isRock.LineBot.TemplateActionBase>();
            actions.Add(new isRock.LineBot.DateTimePickerAction() {
                label = "測試-選取時間", mode = "time" });
            actions.Add(new isRock.LineBot.DateTimePickerAction() {
                label = "測試-選取日期", mode = "date" });
            actions.Add(new isRock.LineBot.DateTimePickerAction() {
                label = "測試-選取時間日期", mode = "datetime" });

            //單一Button Template Message
            var ButtonTemplate = new isRock.LineBot.ButtonsTemplate()
            {
                text = "這個範例測試使用Line新釋出的DateTime Action，讓用戶選擇時間日期並取得會傳值...",
                title = "ButtonsTemplate測試",
                //設定圖片
                thumbnailImageUrl = new Uri("https://arock.blob.core.windows.net/blogdata201706/22-124357-ad3c87d6-b9cc-488a-8150-1c2fe642d237.png"),
                actions = actions //設定回覆動作
            };
            //發送
            bot.PushMessage("!!!!!!!!!!請改用自己的Line bot Admin User ID!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!", ButtonTemplate);
        }
    }
}