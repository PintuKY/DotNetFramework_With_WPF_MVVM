using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using log4net;

namespace SELF_KBM_DESIGN.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private bool isClosingApplication = false;
        private Action yesActionToPerform;
        private DispatcherTimer _timer;
        private string[] _imagePaths;
        private int _currentImageIndex;
        public MainWindow()
        {
            InitializeComponent();
            log.Info("Main window Initialized");
            Loaded += MainWindow_Loaded;
            Deactivated += MainWindow_Deactivated;
            //Unloaded += MainWindow_Unloaded;
            Height = SystemParameters.WorkArea.Height;
            Width = SystemParameters.WorkArea.Width;
            DataContext = this;
           // LoadImagesFromFolder();
           // StartSlider();
        }


        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            log.Info("MainWindow loaded.");
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        }


        private void MainWindow_Deactivated(object sender, EventArgs e)
        {

        }


        private void MainWindow_Unloaded(object sender, RoutedEventArgs e)
        {
            log.Info("MainWindow Unloaded event triggered.");
            if (_timer != null)
            {
                _timer.Stop();
                _timer = null;
            }
        }

        public class Dot : INotifyPropertyChanged
        {
            private bool _selected;
            private Brush _color;

            public int Index { get; set; }

            public bool Selected
            {
                get { return _selected; }
                set
                {
                    _selected = value;
                    OnPropertyChanged(nameof(Selected));
                }
            }

            public Brush Color
            {
                get { return _color; }
                set
                {
                    _color = value;
                    OnPropertyChanged(nameof(Color));
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }





        public ObservableCollection<Dot> Dots { get; set; } = new ObservableCollection<Dot>();


        private void LoadImagesFromFolder()
        {
            log.Info("Loading Slider images in Mainwindow");
            //string folderPath = "pack://siteoforigin:,,,/Res/Slider";
            string folderPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Res", "Slider");

            if (Directory.Exists(folderPath))
            {
                _imagePaths = Directory.GetFiles(folderPath, "*.png", SearchOption.TopDirectoryOnly)
                                       .Concat(Directory.GetFiles(folderPath, "*.jpg", SearchOption.TopDirectoryOnly))
                                       .ToArray();

                if (_imagePaths.Length > 0)
                {
                    Dots = new ObservableCollection<Dot>();

                    // Initialize dots with their corresponding index
                    for (int i = 0; i < _imagePaths.Length; i++)
                    {
                        Dots.Add(new Dot { Index = i, Color = Brushes.White });
                    }

                    _currentImageIndex = 0;
                    UpdateImage();
                }
            }

        }



        private void StartSlider()
        {
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(3)
            };
            _timer.Tick += (s, e) =>
            {
                _currentImageIndex = (_currentImageIndex + 1) % _imagePaths.Length;
                UpdateImage();
            };
            _timer.Start();

        }


        private void UpdateImage()
        {
            if (_imagePaths.Length > 0)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(_imagePaths[_currentImageIndex], UriKind.Absolute));
                SliderImage.Source = bitmap;
                UpdateDots();
            }
        }




        private void Dot_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle clickedRectangle = (Rectangle)sender;
            Dot clickedDot = (Dot)clickedRectangle.DataContext;
            _currentImageIndex = clickedDot.Index;
            UpdateImage();
            UpdateDots();
        }

        private void UpdateDots()
        {
            foreach (var dot in Dots)
            {
                dot.Selected = (dot.Index == _currentImageIndex);
                dot.Color = dot.Selected ? Brushes.White : Brushes.White;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Normal;
            WindowState = WindowState.Maximized;
        }

        private void MouseDownHandler(object sender, MouseButtonEventArgs e)
        {
            var maximizeButton = this.FindName("MaximizeButtonControl") as Button;
            var image = maximizeButton?.Content as Image;

            if (e.ClickCount == 2 && e.ChangedButton == MouseButton.Left)
            {
                if (WindowState == WindowState.Normal)
                {
                    WindowState = WindowState.Maximized;
                    MaxHeight = SystemParameters.WorkArea.Height + 10;
                    MaxWidth = SystemParameters.WorkArea.Width + 10;

                    // Change the icon to the restore down icon when window is maximized
                    if (image != null)
                    {
                        image.Source = new BitmapImage(new Uri("pack://application:,,,/Res/iconMaximize.png"));
                    }
                }
                else
                {
                    WindowState = WindowState.Normal;
                    Width = 1280;
                    Height = 720;

                    // Change the icon to the maximize icon when window is in normal state
                    if (image != null)
                    {
                        image.Source = new BitmapImage(new Uri("pack://application:,,,/Res/iconRestoreDown.png"));
                    }
                }
            }
            else if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            var maximizeButton = sender as Button;
            var image = maximizeButton?.Content as Image;

            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                Width = 1280;
                Height = 720;

                // Change the icon to the maximize icon when window is in normal state
                if (image != null)
                {
                    image.Source = new BitmapImage(new Uri("pack://application:,,,/Res/iconRestoreDown.png"));
                }
            }
            else
            {
                this.WindowState = WindowState.Maximized;
                MaxHeight = SystemParameters.WorkArea.Height + 10;
                MaxWidth = SystemParameters.WorkArea.Width + 10;

                // Change the icon to the restore down icon when window is maximized
                if (image != null)
                {
                    image.Source = new BitmapImage(new Uri("pack://application:,,,/Res/iconMaximize.png"));
                }
            }
        }
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void HideLogoutControl()

        {

            //logoutControl.Visibility = Visibility.Collapsed;

            overlay.Visibility = Visibility.Collapsed;

            //isClosingApplication = false;

        }
        private void CloseApplicationAction()

        {

            if (isClosingApplication)

            {

                Application.Current.Shutdown();

            }

        }
       
        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                MaxHeight = SystemParameters.WorkArea.Height + 10;
                MaxWidth = SystemParameters.WorkArea.Width + 10;
            }

            InvalidateVisual();
            UpdateLayout();
            UpdateDefinitions();
        }
        private void UpdateDefinitions()
        {
            if (this.WindowState == WindowState.Maximized)
            {
                MainGrid.ColumnDefinitions.Clear();
                MainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(6, GridUnitType.Star) });
                MainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(4, GridUnitType.Star) });

                BannerGrid.ColumnDefinitions.Clear();
                BannerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(7, GridUnitType.Star) });
                BannerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) });

                SliderGrid.ColumnDefinitions.Clear();
                SliderGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(7, GridUnitType.Star) });
                SliderGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) });

                //logoutControl.Margin


            }
            else
            {
                MainGrid.ColumnDefinitions.Clear();
                MainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                MainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                BannerGrid.ColumnDefinitions.Clear();
                BannerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                BannerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                SliderGrid.ColumnDefinitions.Clear();
                SliderGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                SliderGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });


            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)

        {
            log.Info("MainWindow Close button Clicked.");
            isClosingApplication = true;

            //ShowLogoutControl("Are you sure you want to close the application?", CloseApplicationAction);

        }
    }
}