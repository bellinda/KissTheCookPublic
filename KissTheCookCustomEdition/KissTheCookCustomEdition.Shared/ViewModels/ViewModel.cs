using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace KissTheCookCustomEdition.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }


    public class ViewModel : ViewModelBase
    {
        private const string dbName = "food.db";

        public List<Recipe> Recipes { get; set; }

        public List<FavouriteRecipe> FavouriteRecipes { get; set; }

        public List<Recipe> MyRecipes { get; set; }

        public List<Restaurant> Restaurants { get; set; }

        public ViewModel()
        {
            this.OnPropertyChanged("Recipes");
        }

        public static async Task<Recipe> GetRecipeByTitle(string title)
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbName);
            var query = await conn.Table<Recipe>().Where(x => x.Title == title).FirstAsync();
            return query;
        }
    }
}
