using KissTheCookCustomEdition.Common;
using KissTheCookCustomEdition.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.Storage;
using Windows.UI.Notifications;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace KissTheCookCustomEdition.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FoundRecipesByTime : Page
    {
        public static List<string> imageURLs = new List<string>();

        private const string dbName = "food.db";

        public List<Recipe> recipes { get; set; }

        public ViewModel viewModel { get; set; }

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public FoundRecipesByTime()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;

            viewModel = new ViewModel();

            this.DataContext = viewModel;

            LoadTheRecipes();
        }

        /// <summary>
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// Gets the view model for this <see cref="Page"/>.
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            int allMinutes = (int)e.NavigationParameter;

            List<Recipe> appropriateRecipes = new List<Recipe>();

            foreach (var recipe in viewModel.Recipes)
            {
                if (ParseStringTime(recipe.Time) <= allMinutes)
                {
                    appropriateRecipes.Add(recipe);
                }
            }
            this.listView.ItemsSource = appropriateRecipes;
        }

        private static void SendNotification(string mainMessage, string secondMessage, string thirdMessage, string imageSrc)
        {
            var notificationXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText04);
            string toastXmlString = "<toast>"
                               + "<visual version='1'>"
                               + "<binding template='toastImageAndText04'>"
                               + "<text id='1'>" + mainMessage + "</text>"     //No internet connection!
                               + "<text id='2'>" + secondMessage + "</text>" //Turn it on to see 
                               + "<text id='3'>" + thirdMessage + "</text>"   //a list of restorants near you
                               + "<image id='1' src='" + imageSrc + "' alt='image placeholder'/>"
                               + "</binding>"
                               + "</visual>"
                               + "</toast>";
            notificationXml.LoadXml(toastXmlString);         //var toeastElement = notificationXml.GetElementsByTagName("text");
            //toeastElement[0].AppendChild(notificationXml.CreateTextNode("This is Notification Message"));
            var toastNotification = new ToastNotification(notificationXml);
            ToastNotificationManager.CreateToastNotifier().Show(toastNotification);
        }

        private static int ParseStringTime(string time)
        {
            int minutes = 0;

            if (!time.Contains("час"))
            {
                string[] timeParts = time.Split(' ');
                if (timeParts[0].Contains("-"))
                {
                    string[] splitedNumbers = timeParts[0].Split('-');
                    minutes = int.Parse(splitedNumbers[1]);
                }
                else
                {
                    minutes = int.Parse(timeParts[0]);
                }
            }
            else if (!time.Contains("минути"))
            {
                string[] timeParts = time.Split(' ');
                minutes = int.Parse(timeParts[0]) * 60;
            }
            else
            {
                string[] timeParts = time.Split(' ');
                for (int i = 0; i < timeParts.Length; i++)
                {
                    if (timeParts[i].Contains("час"))
                    {
                        minutes += int.Parse(timeParts[i - 1]) * 60;
                    }
                    if (timeParts[i].Contains("минути"))
                    {
                        minutes += int.Parse(timeParts[i - 1]);
                        break;
                    }
                }
            }

            return minutes;
        }

        public static async Task<List<Recipe>> GetAllRecepiesFromHttpRequest()
        {
            List<Recipe> recipes = new List<Recipe>();
            string url = "http://www.bonapeti.bg/recepti/";

            var htmlDoc = new HtmlAgilityPack.HtmlDocument
            {
                OptionFixNestedTags = true,
                OptionAutoCloseOnEnd = true
            };

            var recHtmlDoc = new HtmlAgilityPack.HtmlDocument
            {
                OptionFixNestedTags = true,
                OptionAutoCloseOnEnd = true
            };

            for (int i = 1; i <= 1; i++)   //114
            {
                string data = await GetResponseString(url + "?page=" + i);
                htmlDoc.LoadHtml(data);

                var titles = htmlDoc.DocumentNode.DescendantsAndSelf("a").Where(x => x.Attributes["title"] != null && x.ChildNodes.Count > 1 && x.Attributes["class"].Value.Contains("recipe_link"));

                var imageUrls = htmlDoc.DocumentNode.Descendants("div").Where(x => x.Attributes["class"] != null && (x.Attributes["class"].Value == "recipe_container" || x.Attributes["class"].Value == "user_recipe_container"));                   //("//*[contains(@class,'recipe_container')]");

                Recipe recipe = new Recipe();

                foreach (var imgUrl in imageUrls)
                {
                    if (imgUrl.Attributes["style"] != null)
                    {
                        string value = imgUrl.Attributes["style"].Value;
                        imageURLs.Add(value.Substring(value.IndexOf("'") + 1, value.LastIndexOf("'") - value.IndexOf("'") - 1));
                    }
                    else
                    {
                        imageURLs.Add("http://www.bonapeti.bg/images/user_nodish_big.jpg");
                    }
                }

                foreach (var title in titles)
                {
                    recipe = new Recipe();
                    recipe.Title = title.Attributes["title"].Value;
                    string recipeLink = title.Attributes["href"].Value;

                    string recData = await GetResponseString(recipeLink);
                    recHtmlDoc.LoadHtml(recData);
                    var timeNode = recHtmlDoc.DocumentNode.Descendants("div").Where(x => x.Attributes["class"] != null && x.Attributes["class"].Value == "text");              //SelectSingleNode("//*[@id=\"printable_area\"]/div[4]/div[1]/div[2]");
                    foreach (var time in timeNode)
                    {
                        recipe.Time = time.InnerText.Trim();
                        break;
                    }
                    var ingredients = recHtmlDoc.DocumentNode.Descendants("table").Where(x => x.Attributes["class"] != null && x.Attributes["class"].Value == "tbl_products");           //("//*[contains(@class,'last')]");
                    string ingredientsText = "";
                    foreach (var ingr in ingredients)
                    {
                        ingredientsText += ingr.InnerHtml.Trim();
                    }
                    recipe.Ingredients = ingredientsText.Replace("&nbsp;", "\n").
                                            Replace("\t", "").
                                            Replace("\n", "").
                                            Replace("<tr>", "").
                                            Replace("</tr>", "").
                                            Replace("<td class=\"last\">", "").
                                            Replace("<td class=\"last\" colspan=\"1\">", "").
                                            Replace("<td class=\"last\" colspan=\"2\">", "").
                                            Replace("<td class=\"last\" colspan=\"3\">", "").
                                            Replace("<td>", "").
                                            Replace("</td>", "").
                                            Replace("<br>", "\n").
                                            Replace("<span itemprop=\"ingredients\">", "").
                                            Replace("</span>", "").
                                            Replace("<b>", "\n").
                                            Replace("</b>", "").
                                            Replace("\n ", "\n").
                                            TrimEnd().TrimStart(',');

                    var preparations = recHtmlDoc.DocumentNode.Descendants("td").Where(x => x.Attributes["class"] != null && x.Attributes["class"].Value == "stepDescription");  //("//*[contains(@class,'stepDescription')]");
                    StringBuilder prepWay = new StringBuilder();
                    foreach (var prep in preparations)
                    {
                        prepWay.Append(prep.InnerText.Trim());
                    }
                    recipe.PreparationWay = prepWay.ToString();

                    recipes.Add(recipe);
                }
                if (i != 114)
                {
                    recipes.RemoveAt(recipes.Count - 1);
                    recipes.RemoveAt(recipes.Count - 1);
                }
            }
            for (int i = 0; i < recipes.Count; i++)
            {
                recipes[i].ImageURL = imageURLs[i];
            }

            return recipes;
        }

        public static async Task<string> GetResponseString(string url)
        {
            string recieved = "";

            if (!IsConnectedToNetwork())
            {
                SendNotification("No internet connection!", "Turn it on to see", "a list of restorants near you", "/Images/connection.png");
            }
            else
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                using (var response = (HttpWebResponse)(await Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, null)))
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        Encoding eCofidication = Encoding.UTF8;
                        using (var sr = new StreamReader(responseStream, eCofidication))
                        {
                            recieved = await sr.ReadToEndAsync();
                        }
                    }
                }
            }
            return recieved;
        }

        private async void LoadTheRecipes()
        {
            bool dbExists = await CheckDbAsync(dbName);
            if (!dbExists)
            {
                await CreateDataBaseAsync();
                await AddRecipesAsync();
            }

            SQLiteAsyncConnection dbCon = new SQLiteAsyncConnection(dbName);
            var query = dbCon.Table<Recipe>();
            recipes = await query.ToListAsync();

            viewModel.Recipes = recipes;

            
            //this.listView.ItemsSource = viewModel.Recipes;
        }

        public static bool IsConnectedToNetwork()
        {
            bool hasConnection = true;
            hasConnection = NetworkInterface.GetIsNetworkAvailable();
            return hasConnection;
        }

        private async Task AddRecipesAsync()
        {
            var list = await GetAllRecepiesFromHttpRequest();

            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
            await conn.InsertAllAsync(list);
        }

        private async Task CreateDataBaseAsync()
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
            await conn.CreateTableAsync<Recipe>();
        }

        private async Task<bool> CheckDbAsync(string dbName)
        {
            bool dbExists = true;

            try
            {
                StorageFile sf = await ApplicationData.Current.LocalFolder.GetFileAsync(dbName);
            }
            catch (Exception)
            {
                dbExists = false;
            }

            return dbExists;
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// <summary>
        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// <para>
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="NavigationHelper.LoadState"/>
        /// and <see cref="NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        /// </para>
        /// </summary>
        /// <param name="e">Provides data for navigation methods and event
        /// handlers that cannot cancel the navigation request.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void listView_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(Pages.RecipeDetailsPage));
        }
    }
}
