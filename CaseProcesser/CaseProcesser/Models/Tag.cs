using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Media;
using CaseProcesser.Common;

namespace CaseProcesser.Models
{
    [ComplexType]
    public class Tag : ModelBase
    {
        private string _value;
        private TagColorType _color;

        public string Value
        {
            get { return _value; }
            set
            {
                if (value == _value) return;
                _value = value;
                NotifyOfPropertyChange(() => Value);
            }
        }

        public TagColorType Color
        {
            get { return _color; }
            set
            {
                if (value == _color) return;
                _color = value;
                NotifyOfPropertyChange(() => Color);
            }
        }
    }

    public static class TagExtensions
    {
        public static SolidColorBrush GetColor(this TagColorType type)
        {
            switch (type)
            {
                case TagColorType.Red:
                    return new SolidColorBrush(Colors.Red);
                case TagColorType.Yellow:
                    return new SolidColorBrush(Colors.Yellow);
                case TagColorType.Blue:
                    return new SolidColorBrush(Colors.Blue);
                case TagColorType.Orange:
                    return new SolidColorBrush(Colors.Orange);
                case TagColorType.Green:
                    return new SolidColorBrush(Colors.Green);
                case TagColorType.Black:
                    return new SolidColorBrush(Colors.Black);
                case TagColorType.White:
                    return new SolidColorBrush(Colors.White);
                default:
                    return new SolidColorBrush(Colors.Transparent);

            }
        }
    }

    public enum TagColorType
    {
        White, Red, Yellow, Blue, Orange, Green, Black
    }

}