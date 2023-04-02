using PodelkaViewModel;
using PolzunkiModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PolzunkiViewModel
{
    public class VM : INotifyPropertyChanged
    {
        private ObservableCollection<ColorValue> _colorValues;
        private ColorValue _selectedColor;
        private bool _notExist;

        public event PropertyChangedEventHandler? PropertyChanged;
        public VM()
        {
            _colorValues = new ObservableCollection<ColorValue>() { new ColorValue()
            {
                ColorItem = "#FF820066"
            } };
            _colorValues.Add(new ColorValue() { ColorItem = "#FF384477" });
            _colorValues.Add(new ColorValue() { ColorItem = "#FF251532" });
            _notExist = true;
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public ObservableCollection<ColorValue> ColorValues
        {
            get { return _colorValues; }
            set
            {
                _colorValues = value;
                OnPropertyChanged("ColorValues");
            }
        }
        public ColorValue SelectedColor
        {
            get { return _selectedColor; }
            set
            {
                _selectedColor = value;
                OnPropertyChanged("SelectedColor");
            }
        }
        public bool NotExist
        {
            get { return _notExist; }
            set
            {
                _notExist = value;
                OnPropertyChanged("NotExist");
            }
        }
        RelayCommand _addColor;
        public RelayCommand AddColor
        {
            get
            {
                return _addColor ??
                  (_addColor = new RelayCommand((ob) =>
                  {
                      try
                      {
                          ColorValue newColor = new ColorValue()
                          {
                              ColorItem = (ob as SolidColorBrush).Color.ToString(),
                          };
                          ColorValues.Add(newColor);
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }
        RelayCommand _removeColor;
        public RelayCommand RemoveColor
        {
            get
            {
                return _removeColor ??
                  (_removeColor = new RelayCommand((ob) =>
                  {
                      try
                      {
                          ColorValues.Remove(SelectedColor);
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }));
            }
        }
    }
}
