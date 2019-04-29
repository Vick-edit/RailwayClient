using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using RailwayClient.DataAccess.Commands;
using RailwayClient.DataAccess.Entities;
using RailwayClient.DataAccess.Queries;
using RailwayClient.DataAccess.SettingsEF;
using RailwayClient.Domain;
using RailwayClient.WpfUtilities.Commands;

namespace RailwayClient.ViewModel
{
    /// <summary>
    ///     VM основного и единственного окна
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        private const int TOP_ELEMENTS_NUMBER = 100;
        private readonly IQueryBuilder _queryBuilder;
        private readonly ICatalogueUpdater _catalogueUpdater;
        private readonly IExcelReporter _excelReporter;

        public string RailwayHeader => $"Cправочник ж/д дорог : первые {TOP_ELEMENTS_NUMBER} записей";
        public ObservableCollection<Railway> Railways { get; set; }

        public string StationHeader => $"Cправочник ж/д станций : первые {TOP_ELEMENTS_NUMBER} записей";
        public ObservableCollection<Station> Stations { get; set; }


        public bool IsInProcess
        {
            get => Get<bool>();
            set => Set(value);
        }


        public MainWindowViewModel(IQueryBuilder queryBuilder, ICatalogueUpdater catalogueUpdater, IExcelReporter excelReporter)
        {
            _queryBuilder = queryBuilder;
            _catalogueUpdater = catalogueUpdater;
            _excelReporter = excelReporter;

            Railways = new ObservableCollection<Railway> { new Railway() };
            Stations = new ObservableCollection<Station> { new Station() };
        }


        [MapCommand(nameof(UpdateСatalogue))]
        public ICommand UpdateСatalogueCommand { get; private set; }
        private async void UpdateСatalogue()
        {
            IsInProcess = true;
            List<Railway> railways = new List<Railway>();
            List<Station> stations = new List<Station>();

            await Task.Run(() =>
            {
                _catalogueUpdater.UpdateCatalogue();
                railways = _queryBuilder.For<List<Railway>>().With(new GetAllCriterion());
                stations = _queryBuilder.For<List<Station>>().With(new GetAllCriterion());
            });
            IsInProcess = false;

            Railways.Clear();
            railways.Take(TOP_ELEMENTS_NUMBER).ToList().ForEach(Railways.Add);

            Stations.Clear();
            stations.Take(TOP_ELEMENTS_NUMBER).ToList().ForEach(Stations.Add);
        }


        [MapCommand(nameof(BuildExcelFile))]
        public ICommand BuildExcelCommand { get; private set; }
        private async void BuildExcelFile()
        {
            IsInProcess = true;

            await Task.Run(() =>
            {
                _excelReporter.Buildreport();
            });

            IsInProcess = false;
        }
    }
}