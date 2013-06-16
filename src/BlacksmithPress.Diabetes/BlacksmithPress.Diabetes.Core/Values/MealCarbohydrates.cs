using BlacksmithPress.Diabetes.Core.Common;

namespace BlacksmithPress.Diabetes.Core.Values
{
    public class MealCarbohydrates : ValueTypeBase
    {
        private string _name = default(string);
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private int _grams = default(int);
        public int Grams
        {
            get { return _grams; }
            set { SetProperty(ref _grams, value); }
        }
    }
}
