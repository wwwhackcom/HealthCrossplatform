using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCrossplatform.Core.Extensions;
using HealthCrossplatform.Core.Models;
using HealthCrossplatform.Core.Services.Interface;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace HealthCrossplatform.Core.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private string _nextPage;

        public DashboardViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            DashboardItems = new MvxObservableCollection<IDashboardItem>();

            //DashboardItemSelectedCommand = new MvxAsyncCommand<IDashboardItem>(DashboardItemSelected);
            FetchItemsCommand = new MvxCommand(
                () =>
            {
                FetchItemsTask = MvxNotifyTask.Create(LoadItems);
                RaisePropertyChanged(() => FetchItemsTask);
            });
            RefreshItemsCommand = new MvxCommand(RefreshItems);
        }

        // MvvmCross Lifecycle
        public override Task Initialize()
        {
            LoadItemsTask = MvxNotifyTask.Create(LoadItems);

            return Task.FromResult(0);
        }

        // MVVM Properties
        public MvxNotifyTask LoadItemsTask { get; private set; }

        public MvxNotifyTask FetchItemsTask { get; private set; }

        private MvxObservableCollection<IDashboardItem> _dashboardItems;
        public MvxObservableCollection<IDashboardItem> DashboardItems
        {
            get
            {
                return _dashboardItems;
            }
            set
            {
                _dashboardItems = value;
                RaisePropertyChanged(() => DashboardItems);
            }
        }

        // MVVM Commands
        //public IMvxCommand<IRecipe> DashboardItemSelectedCommand { get; private set; }

        public IMvxCommand FetchItemsCommand { get; private set; }

        public IMvxCommand RefreshItemsCommand { get; private set; }

        // Private methods
        private Task LoadItems()
        {
            var result = getItems();

            List<IDashboardItem> itemsToAdd = new List<IDashboardItem>();
            for (int i = 0; i < result.Results.Count(); i++)
            {
                if (i % 2 == 0)
                {
                    itemsToAdd.Add(result.Results.ElementAt(i).ToItem());
                }
                else
                {
                    itemsToAdd.Add(result.Results.ElementAt(i).ToItem2());
                }
            }

            if (string.IsNullOrEmpty(_nextPage))
            {
                DashboardItems.Clear();
            }
            DashboardItems.AddRange(itemsToAdd);

            _nextPage = result.Next;

            return Task.FromResult(0);
        }

        private void RefreshItems()
        {
            LoadItemsTask = MvxNotifyTask.Create(LoadItems);
            RaisePropertyChanged(() => LoadItemsTask);
        }

        private PagedResult<BaseDashboardItem> getItems()
        {
            return new PagedResult<BaseDashboardItem>()
            {
                Count = 3,
                Next = string.Empty,
                Previous = string.Empty,
                Results = new List<BaseDashboardItem>
                {
                    new DashboardItem
                    {
                        Name = "Your Workout Programs",
                        Status = "In Progressing",
                        Description = "Do X number of reps at the top of each minute (or work for a certain number of seconds), rest the remainder of the minute, and repeat for Y minutes. ",
                        Recommendation = "DIRECTIONS: Perform four rounds of the following triset, for a total of 12 minutes.",
                    },
                    new DashboardItem2
                    {
                        Name = "Your Meal Plans",
                        Status = "Weekly meal plans",
                        Description = "Enjoy a varied meal plan with your favorite dishes, from pizzas and pastas to salads and steaks, all with less than 500 calories per serving.",
                        Recommendation = "DIRECTIONS: Low-glycemic ingredients and plenty of protein provide balance and variety for the whole family.",
                    },
                    new DashboardItem
                    {
                        Name = "Your Progress",
                        Status = "Lightly Active",
                        Description = "22 days streak, 2kg lost, lose 0.6kg per week",
                        Recommendation = "DIRECTIONS: Measure your waist, hips, biceps, triceps, thighs & calves.Often you will notice changes in inches lost or gained, depending on your goal, before you see a change in the scale.",
                    },
                    new DashboardItem2
                    {
                        Name = "Your Calories",
                        Status = "Not Bad! You burned 2650 calories today",
                        Description = "You have to burn 3000 calories to lose today, Diet and exercise, both are important.",
                        Recommendation = "DIRECTIONS: Reduce the number of calories they consume and increase their physical activity, you need to reduce your daily calories by 500 to 750 calories.",
                    }
                }
            };
        }
    }
}
