using System.Data;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Taschenrechner2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
          
        }
        string currentCal = "";

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            currentCal += (sender as Button).Content; ;
            textBox.Text = currentCal;
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            currentCal = "";
            textBox.Text = currentCal;
        }

        private void BtnEqual_Click(object sender, RoutedEventArgs e)
        {
            if (currentCal.Contains("/0"))
            {

            }
            //Berchnet und zeig die Gleichung an.
            try
            {
                textBox.Text = new DataTable().Compute(currentCal, null).ToString();

                currentCal = textBox.Text;


            }
            catch (Exception ex)
            {
                textBox.Text = "Error";
                currentCal = "";
                Console.WriteLine(ex);             
            }
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

    }
    public class EnableDragHelper
    {
        public static readonly DependencyProperty EnableDragProperty = DependencyProperty.RegisterAttached(
            "EnableDrag",
            typeof(bool),
            typeof(EnableDragHelper),
            new PropertyMetadata(default(bool), OnLoaded));

        private static void OnLoaded(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var uiElement = dependencyObject as UIElement;
            if (uiElement == null || (dependencyPropertyChangedEventArgs.NewValue is bool) == false)
            {
                return;
            }
            if ((bool)dependencyPropertyChangedEventArgs.NewValue == true)
            {
                uiElement.MouseMove += UIElementOnMouseMove;
            }
            else
            {
                uiElement.MouseMove -= UIElementOnMouseMove;
            }

        }
        // Aktiviert das bewegen von Fenster
        private static void UIElementOnMouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            var uiElement = sender as UIElement;
            if (uiElement != null)
            {
                if (mouseEventArgs.LeftButton == MouseButtonState.Pressed)
                {
                    DependencyObject parent = uiElement;
                    int avoidInfiniteLoop = 0;
                    // Search up the visual tree to find the first parent window.
                    while ((parent is Window) == false)
                    {
                        parent = VisualTreeHelper.GetParent(parent);
                        avoidInfiniteLoop++;
                        if (avoidInfiniteLoop == 1000)
                        {
                            // Something is wrong - we could not find the parent window.
                            return;
                        }
                    }
                    var window = parent as Window;
                    window.DragMove();
                }
            }
        }

        public static void SetEnableDrag(DependencyObject element, bool value)
        {
            element.SetValue(EnableDragProperty, value);
        }

        public static bool GetEnableDrag(DependencyObject element)
        {
            return (bool)element.GetValue(EnableDragProperty);
        }
    }

}
