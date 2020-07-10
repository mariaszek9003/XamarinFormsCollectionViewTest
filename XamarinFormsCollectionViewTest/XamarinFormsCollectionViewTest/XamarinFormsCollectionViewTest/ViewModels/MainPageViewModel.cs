using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using XamarinFormsCollectionViewTest.Models;
using XamarinFormsCollectionViewTest.Services;

namespace XamarinFormsCollectionViewTest.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private StuffService _stuffService;
        private ObservableCollection<StuffModel> _stuff;
        private int _pageNumber;
        private bool _isBusy;
        private int _itemThreshold = -1;

        public ObservableCollection<StuffModel> Stuff
        {
            get => _stuff;
            set => SetProperty(ref _stuff, value);
        }

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public int ItemThreshold
        {
            get => _itemThreshold;
            set => SetProperty(ref _itemThreshold, value);
        }

        public DelegateCommand GenerateRandomStuffCommand { get; private set; }
        public DelegateCommand GenerateGoodStuffCommand { get; private set; }
        public DelegateCommand GenerateBetterStuffCommand { get; private set; }
        public DelegateCommand LoadMoreStuffCommand { get; private set; }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Stuff Page";
            _stuffService = new StuffService();
            Stuff = new ObservableCollection<StuffModel>();

            GenerateRandomStuffCommand = new DelegateCommand(async () =>
            {
                await GetRandomStuff();
            });

            GenerateGoodStuffCommand = new DelegateCommand(() =>
            {
                GetStuff(false);
            });

            GenerateBetterStuffCommand = new DelegateCommand(() =>
            {
                GetStuff(true);
            });

            LoadMoreStuffCommand = new DelegateCommand(async () =>
            {
                await GetStuffAsync();
            });
        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            await GetStuffAsync();
        }

        private async Task GetStuffAsync()
        {
            IsBusy = true;
            ItemThreshold = -1;

            var newStuff = await _stuffService.GetHugeStuffAsync(_pageNumber, 20);

            foreach (var item in newStuff)
            {
                Stuff.Add(item);
            }

            _pageNumber++;

            IsBusy = false;
            ItemThreshold = 1;
        }

        private async Task GetRandomStuff()
        {
            IsBusy = true;
            ItemThreshold = -1;

            var newItem = await _stuffService.AddSingleStuffAsync();
            Stuff.Insert(0, newItem);

            IsBusy = false;
            ItemThreshold = 1;
        }

        private void GetStuff(bool shouldBeBetter)
        {
            IsBusy = true;
            ItemThreshold = -1;

            var newItem = _stuffService.GenerateStuff(shouldBeBetter, "Good stuff");
            Stuff.Insert(0, newItem);

            IsBusy = false;
            ItemThreshold = 1;
        }
    }
}
