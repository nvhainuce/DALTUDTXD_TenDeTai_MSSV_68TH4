using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
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
using OxyPlot.Legends;


namespace DALTUDTXD_TenDeTai_MSSV_68TH4.Views
{
    /// <summary>
    /// Interaction logic for BieuDoMomentView.xaml
    /// </summary>
    public partial class BieuDoMomentView : Window
    {
        public BieuDoMomentView()
        {
            InitializeComponent();

            OxyPlotView.Model = TwoColorAreaSeries();
        }


        public static PlotModel TwoColorAreaSeries()
        {
            var plotModel1 = new PlotModel();
            plotModel1.Title = "TwoColorAreaSeries";
            var linearAxis1 = new LinearAxis();
            linearAxis1.Title = "Temperature";
            linearAxis1.Unit = "°C";
            linearAxis1.ExtraGridlines = new Double[1];
            linearAxis1.ExtraGridlines[0] = 0;
            plotModel1.Axes.Add(linearAxis1);
            var linearAxis2 = new LinearAxis();
            linearAxis2.Position = AxisPosition.Bottom;
            linearAxis2.Title = "Date";
            plotModel1.Axes.Add(linearAxis2);
            var twoColorAreaSeries1 = new TwoColorAreaSeries();
            twoColorAreaSeries1.Fill2 = OxyColors.LightBlue;
            twoColorAreaSeries1.MarkerFill2 = OxyColors.Blue;
            twoColorAreaSeries1.MarkerStroke2 = OxyColors.Black;
            twoColorAreaSeries1.Color2 = OxyColors.Brown;
            twoColorAreaSeries1.Fill = OxyColors.Tomato;
            twoColorAreaSeries1.Color = OxyColors.Black;
            twoColorAreaSeries1.MarkerFill = OxyColors.Red;
            twoColorAreaSeries1.MarkerSize = 1;
            twoColorAreaSeries1.MarkerStroke = OxyColors.Brown;
            twoColorAreaSeries1.MarkerType = MarkerType.Circle;
            twoColorAreaSeries1.StrokeThickness = 1;
            twoColorAreaSeries1.Title = "Temperature at Eidesmoen, December 1986.";
            twoColorAreaSeries1.TrackerFormatString = "December {2:0}: {4:0.0} °C";
            twoColorAreaSeries1.Points.Add(new DataPoint(1, 5));
            twoColorAreaSeries1.Points.Add(new DataPoint(2, 0));
            twoColorAreaSeries1.Points.Add(new DataPoint(3, 7));
            twoColorAreaSeries1.Points.Add(new DataPoint(4, 7));
            twoColorAreaSeries1.Points.Add(new DataPoint(5, 4));
            twoColorAreaSeries1.Points.Add(new DataPoint(6, 3));
            twoColorAreaSeries1.Points.Add(new DataPoint(7, 5));
            twoColorAreaSeries1.Points.Add(new DataPoint(8, 5));
            twoColorAreaSeries1.Points.Add(new DataPoint(9, 11));
            twoColorAreaSeries1.Points.Add(new DataPoint(10, 4));
            twoColorAreaSeries1.Points.Add(new DataPoint(11, 2));
            twoColorAreaSeries1.Points.Add(new DataPoint(12, 3));
            twoColorAreaSeries1.Points.Add(new DataPoint(13, 2));
            twoColorAreaSeries1.Points.Add(new DataPoint(14, 1));
            twoColorAreaSeries1.Points.Add(new DataPoint(15, 0));
            twoColorAreaSeries1.Points.Add(new DataPoint(16, 2));
            twoColorAreaSeries1.Points.Add(new DataPoint(17, -1));
            twoColorAreaSeries1.Points.Add(new DataPoint(18, 0));
            twoColorAreaSeries1.Points.Add(new DataPoint(19, 0));
            twoColorAreaSeries1.Points.Add(new DataPoint(20, -3));
            twoColorAreaSeries1.Points.Add(new DataPoint(21, -6));
            twoColorAreaSeries1.Points.Add(new DataPoint(22, -13));
            twoColorAreaSeries1.Points.Add(new DataPoint(23, -10));
            twoColorAreaSeries1.Points.Add(new DataPoint(24, -10));
            twoColorAreaSeries1.Points.Add(new DataPoint(25, 0));
            twoColorAreaSeries1.Points.Add(new DataPoint(26, -4));
            twoColorAreaSeries1.Points.Add(new DataPoint(27, -5));
            twoColorAreaSeries1.Points.Add(new DataPoint(28, -4));
            twoColorAreaSeries1.Points.Add(new DataPoint(29, 3));
            twoColorAreaSeries1.Points.Add(new DataPoint(30, 0));
            twoColorAreaSeries1.Points.Add(new DataPoint(31, -5));
            plotModel1.Series.Add(twoColorAreaSeries1);
            var legend1 = new Legend();
            legend1.LegendSymbolLength = 24;
            plotModel1.Legends.Add(legend1);
            return plotModel1;
        }

    }
}
