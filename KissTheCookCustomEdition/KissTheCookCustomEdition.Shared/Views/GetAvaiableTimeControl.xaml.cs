using KissTheCookCustomEdition.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace KissTheCookCustomEdition.Views
{
    public sealed partial class GetAvaiableTimeControl : UserControl
    {
        public GetAvaiableTimeControl()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //int hours = 0;
            //int minutes = 0;
            //if(int.TryParse(this.availableHoursTextBox.Text, out hours) == false || int.TryParse(this.availableMinutesTextBox.Text, out minutes)== false)
            //{
            //    SendNotification("Invalid input", "No empty fields are", "possible", "Images/invalid-input.png");
            //}
                

            //if (hours > 23 || hours < 0)
            //{
            //    SendNotification("Invalid input", "Hours should be between ", "0 and 23", "Images/invalid-input.png");
            //    this.availableHoursTextBox.Text = "";
            //}
            //if (minutes < 0 || minutes > 59)
            //{
            //    SendNotification("Invalid input", "Minutes should be between ", "0 and 59", "Images/invalid-input.png");
            //    this.availableMinutesTextBox.Text = "";
            //}

            //int allMinutes = hours * 60 + minutes;
        }

        //private static void SendNotification(string mainMessage, string secondMessage, string thirdMessage, string imageSrc)
        //{
        //    var notificationXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText04);
        //    string toastXmlString = "<toast>"
        //                       + "<visual version='1'>"
        //                       + "<binding template='toastImageAndText04'>"
        //                       + "<text id='1'>" + mainMessage + "</text>"     //No internet connection!
        //                       + "<text id='2'>" + secondMessage + "</text>" //Turn it on to see 
        //                       + "<text id='3'>" + thirdMessage + "</text>"   //a list of restorants near you
        //                       + "<image id='1' src='" + imageSrc + "' alt='image placeholder'/>"
        //                       + "</binding>"
        //                       + "</visual>"
        //                       + "</toast>";
        //    notificationXml.LoadXml(toastXmlString);         //var toeastElement = notificationXml.GetElementsByTagName("text");
        //    //toeastElement[0].AppendChild(notificationXml.CreateTextNode("This is Notification Message"));
        //    var toastNotification = new ToastNotification(notificationXml);
        //    ToastNotificationManager.CreateToastNotifier().Show(toastNotification);
        //}

        //private static int ParseStringTime(string time)
        //{
        //    int minutes = 0;

        //    if(!time.Contains("час"))
        //    {
        //        string[] timeParts = time.Split(' ');
        //        minutes = int.Parse(timeParts[0]);
        //    } else if (!time.Contains("минути"))
        //    {
        //        string[] timeParts = time.Split(' ');
        //        minutes = int.Parse(timeParts[0]) * 60;
        //    } else
        //    {
        //        string[] timeParts = time.Split(' ');
        //        for(int i = 0; i < timeParts.Length; i++)
        //        {
        //            if(timeParts[i].Contains("час"))
        //            {
        //                minutes += int.Parse(timeParts[i - 1]) * 60;
        //            }
        //            if (timeParts[i].Contains("минути"))
        //            {
        //                minutes += int.Parse(timeParts[i - 1]);
        //                break;
        //            }
        //        }
        //    }

        //    return minutes;
        //}

        //public static async Task<List<Recipe>> GetAllRecepiesFromHttpRequest()
        //{
        //    List<Recipe> recipes = new List<Recipe>();
        //    string url = "http://www.bonapeti.bg/recepti/";

        //    var htmlDoc = new HtmlAgilityPack.HtmlDocument
        //    {
        //        OptionFixNestedTags = true,
        //        OptionAutoCloseOnEnd = true
        //    };

        //    var recHtmlDoc = new HtmlAgilityPack.HtmlDocument
        //    {
        //        OptionFixNestedTags = true,
        //        OptionAutoCloseOnEnd = true
        //    };

        //    for (int i = 1; i <= 114; i++)
        //    {
        //        string data = await GetResponseString(url + "?page=" + i);
        //        htmlDoc.LoadHtml(data);

        //        var titles = htmlDoc.DocumentNode.DescendantsAndSelf("a").Where(x => x.Attributes["title"] != null && x.ChildNodes.Count > 1 && x.Attributes["class"].Value.Contains("recipe_link"));

        //        var imageUrls = htmlDoc.DocumentNode.Descendants("div").Where(x => x.Attributes["class"] != null && (x.Attributes["class"].Value == "recipe_container" || x.Attributes["class"].Value == "user_recipe_container"));                   //("//*[contains(@class,'recipe_container')]");

        //        Recipe recipe = new Recipe();

        //        foreach (var imgUrl in imageUrls)
        //        {
        //            if (imgUrl.Attributes["style"] != null)
        //            {
        //                string value = imgUrl.Attributes["style"].Value;
        //                imageURLs.Add(value.Substring(value.IndexOf("'") + 1, value.LastIndexOf("'") - value.IndexOf("'") - 1));
        //            }
        //            else
        //            {
        //                imageURLs.Add("http://www.bonapeti.bg/images/user_nodish_big.jpg");
        //            }
        //        }

        //        foreach (var title in titles)
        //        {
        //            recipe = new Recipe();
        //            recipe.Title = title.Attributes["title"].Value;
        //            string recipeLink = title.Attributes["href"].Value;

        //            string recData = await GetResponseString(recipeLink);
        //            recHtmlDoc.LoadHtml(recData);
        //            var timeNode = recHtmlDoc.DocumentNode.Descendants("div").Where(x => x.Attributes["class"] != null && x.Attributes["class"].Value == "text");              //SelectSingleNode("//*[@id=\"printable_area\"]/div[4]/div[1]/div[2]");
        //            foreach (var time in timeNode)
        //            {
        //                recipe.Time = time.InnerText.Trim();
        //                break;
        //            }
        //            var ingredients = recHtmlDoc.DocumentNode.Descendants("table").Where(x => x.Attributes["class"] != null && x.Attributes["class"].Value == "tbl_products");           //("//*[contains(@class,'last')]");
        //            string ingredientsText = "";
        //            foreach (var ingr in ingredients)
        //            {
        //                ingredientsText += ingr.InnerHtml.Trim();
        //            }
        //            recipe.Ingredients = ingredientsText.Replace("&nbsp;", "\n").
        //                                    Replace("\t", "").
        //                                    Replace("\n", "").
        //                                    Replace("<tr>", "").
        //                                    Replace("</tr>", "").
        //                                    Replace("<td class=\"last\">", "").
        //                                    Replace("<td class=\"last\" colspan=\"1\">", "").
        //                                    Replace("<td class=\"last\" colspan=\"2\">", "").
        //                                    Replace("<td class=\"last\" colspan=\"3\">", "").
        //                                    Replace("<td>", "").
        //                                    Replace("</td>", "").
        //                                    Replace("<br>", "\n").
        //                                    Replace("<span itemprop=\"ingredients\">", "").
        //                                    Replace("</span>", "").
        //                                    Replace("<b>", "\n").
        //                                    Replace("</b>", "").
        //                                    Replace("\n ", "\n").
        //                                    TrimEnd().TrimStart(',');

        //            var preparations = recHtmlDoc.DocumentNode.Descendants("td").Where(x => x.Attributes["class"] != null && x.Attributes["class"].Value == "stepDescription");  //("//*[contains(@class,'stepDescription')]");
        //            StringBuilder prepWay = new StringBuilder();
        //            foreach (var prep in preparations)
        //            {
        //                prepWay.Append(prep.InnerText.Trim());
        //            }
        //            recipe.PreparationWay = prepWay.ToString();

        //            recipes.Add(recipe);
        //        }
        //        if (i != 114)
        //        {
        //            recipes.RemoveAt(recipes.Count - 1);
        //            recipes.RemoveAt(recipes.Count - 1);
        //        }
        //    }
        //    for (int i = 0; i < recipes.Count; i++)
        //    {
        //        recipes[i].ImageURL = imageURLs[i];
        //    }

        //    return recipes;
        //}
    }


}
