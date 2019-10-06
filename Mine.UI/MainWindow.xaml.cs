using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mine.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            for (var i = 0; i < 10; i++)
            { 
                for (var j = 0; j < 10; j++)
                {
                    var butt = new Button();
                    butt.Content = $"{i},{j}";
                    butt.FontSize = 12;
                    butt.HorizontalAlignment = HorizontalAlignment.Stretch;
                    butt.VerticalAlignment = VerticalAlignment.Stretch;
                    var rowDef = new RowDefinition();
                    var colDef = new ColumnDefinition();
                    Grid.SetColumn(butt, i);
                    Grid.SetRow(butt, j);
                    Grid.SetColumnSpan(butt, 1);
                    Grid.SetRowSpan(butt, 1);
                    MainGrid.Children.Add(butt); 
                    MainGrid.RowDefinitions.Add(rowDef);
                    MainGrid.ColumnDefinitions.Add(colDef);
                }
            }
        }
    }
}