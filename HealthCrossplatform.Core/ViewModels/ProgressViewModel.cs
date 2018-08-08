using System.Windows.Input;
using HealthCrossplatform.Core.Resources;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace HealthCrossplatform.Core.ViewModels
{
    public class ProgressViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public ProgressViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            CloseCommand = new MvxAsyncCommand(async () => await _navigationService.Close(this));
        }

        // MvvmCross Lifecycle

        // MVVM Properties
        public PlotModel PlotModel => GeneratePlotModel();

        // MVVM Commands
        public ICommand CloseCommand { get; private set; }

        // Private methods
        private PlotModel GeneratePlotModel()
        {
            var model = new PlotModel
            {
                PlotAreaBorderColor = OxyColors.LightGray,
                LegendTextColor = OxyColors.LightGray,
                LegendTitleColor = OxyColors.LightGray,
                TextColor = OxyColors.White
            };
            model.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = Strings.Date,
                TitleColor = OxyColors.White,
                AxislineColor = OxyColors.LightGray,
                TicklineColor = OxyColors.LightGray
            });
            model.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Maximum = 400,
                Minimum = 0,
                Title = Strings.Weight,
                TitleColor = OxyColors.White,
                AxislineColor = OxyColors.LightGray,
                TicklineColor = OxyColors.LightGray
            });

            var series1 = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.Red,
                Color = OxyColors.Red
            };

            series1.Points.Add(new DataPoint(0.0, 160.0));
            series1.Points.Add(new DataPoint(1.0, 159.1));
            series1.Points.Add(new DataPoint(2.0, 158.2));
            series1.Points.Add(new DataPoint(3.0, 157.3));
            series1.Points.Add(new DataPoint(4.0, 155.4));
            series1.Points.Add(new DataPoint(5.0, 146.2));
            series1.Points.Add(new DataPoint(6.0, 141.7));
            series1.Points.Add(new DataPoint(7.0, 138.9));
            series1.Points.Add(new DataPoint(8.0, 137.9));
            series1.Points.Add(new DataPoint(9.0, 136.9));
            series1.Points.Add(new DataPoint(10.0, 135.9));

            model.Series.Add(series1);

            return model;
        }
    }
}
