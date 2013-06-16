using System;
using System.Collections.Generic;
using System.ComponentModel;
using BlacksmithPress.Diabetes.Core.Values;
using BlacksmithPress.Diabetes.WinRT.ViewModels;
using Microsoft.Practices.Prism.StoreApps;
using Microsoft.Practices.Prism.StoreApps.Interfaces;
using Windows.UI.Xaml;

namespace BlacksmithPress.Diabetes.WinRT.DesignTime
{
    public class DailyTileViewModel : ViewModel, IDailyTileViewModel
    {
        public DailyTileViewModel(string title)
        {
            Title = title;

            var meals = new List<MealCarbohydrates>();
            var randomizer = new Random(DateTime.Now.Millisecond);

            if (randomizer.Next(0,100) < 75)
                meals.Add(new MealCarbohydrates()
                    {
                        Grams = randomizer.Next(75, 200),
                        Name = "Breakfast"
                    });

            if (randomizer.Next(0, 100) < 5)
                meals.Add(new MealCarbohydrates()
                {
                    Grams = randomizer.Next(25, 100),
                    Name = "Mid-morning Snack"
                });

            if (randomizer.Next(0, 100) < 75)
                meals.Add(new MealCarbohydrates()
                {
                    Grams = randomizer.Next(75, 200),
                    Name = "Lunch"
                });

            if (randomizer.Next(0, 100) < 15)
                meals.Add(new MealCarbohydrates()
                {
                    Grams = randomizer.Next(25, 200),
                    Name = "Afternoon Snack"
                });

            if (randomizer.Next(0, 100) < 95)
                meals.Add(new MealCarbohydrates()
                {
                    Grams = randomizer.Next(75, 200),
                    Name = "Supper"
                });

            if (randomizer.Next(0, 100) < 25)
                meals.Add(new MealCarbohydrates()
                {
                    Grams = randomizer.Next(25, 200),
                    Name = "Evening Snack"
                });

            Meals = meals;
        }

        private string _title = string.Empty;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private IEnumerable<MealCarbohydrates> _meals = default(IEnumerable<MealCarbohydrates>);
        public IEnumerable<MealCarbohydrates> Meals
        {
            get { return _meals; }
            set { SetProperty(ref _meals, value); }
        }

    }
}
