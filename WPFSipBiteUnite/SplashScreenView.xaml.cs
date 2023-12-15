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
using System.Windows.Shapes;
using System.Threading;
using System.ComponentModel;
using System.Windows.Media.Animation;

namespace WPFSipBiteUnite
{
    /// <summary>
    /// Interaction logic for SplashScreenView.xaml
    /// </summary>
    public partial class SplashScreenView : Window
    {
        public SplashScreenView()
        {
            InitializeComponent();
            StartAnimation();
        }

        private void StartAnimation()
        {
            Storyboard animateGlass = (Storyboard)FindResource("AnimateGlass");
            animateGlass.Begin();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerAsync();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(100);
            }
        }


        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MyProgressBar.Value = e.ProgressPercentage;
            UpdateCircularProgress(MyProgressBar, e.ProgressPercentage);

            if (MyProgressBar.Value == 100)
            {
                LoginView mainWindow = new LoginView();
                Close();
                mainWindow.Show();
            }
        }

        private void UpdateCircularProgress(ProgressBar progressBar, int progress)
        {
            if (progressBar.Template.FindName("PART_Indicator", progressBar) is Path indicatorPath &&
                indicatorPath.Data is PathGeometry geometry &&
                geometry.Figures.FirstOrDefault() is PathFigure figure &&
                figure.Segments.FirstOrDefault() is ArcSegment arcSegment)
            {
                var endPoint = ComputeCartesianCoordinate(progress, 18);
                endPoint.Offset(20, 20);

                arcSegment.Point = endPoint;
                arcSegment.Size = new Size(18, 18);
                arcSegment.IsLargeArc = progress > 50;
            }
        }

        private Point ComputeCartesianCoordinate(double progress, double radius)
        {
            double angle = (progress / 100 * 360) - 90;
            double angleRad = (Math.PI / 180.0) * angle;

            double x = radius * Math.Cos(angleRad);
            double y = radius * Math.Sin(angleRad);

            return new Point(x, y);
        }
    }
}
