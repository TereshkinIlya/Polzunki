using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PolzunkiViewModel;

namespace Polzunki
{
    /// <summary>
    /// Логика взаимодействия для ColorsWindow.xaml
    /// </summary>
    public partial class ColorsWindow : Window
    {
        public ColorsWindow()
        {
            InitializeComponent();
            DataContext = new VM();
        }
    }
    public class IntToColorConverter : IMultiValueConverter
    {
        #region IMultiValueConverter Members
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new SolidColorBrush(Color.FromArgb(
                (byte)(double)values[0],
                (byte)(double)values[1],
                (byte)(double)values[2],
                (byte)(double)values[3]));
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
