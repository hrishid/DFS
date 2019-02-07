using DFS.Models;
using DFS.Services;
using DFS.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DFS.ViewModel
{
    public class AddCardViewModel : BaseViewModel
    {
        private ICommand submitCommand;

        public ICommand SubmitCommand
        {
            get { return submitCommand; }
            set
            {
                submitCommand = value;
                OnPropertyChanged("SubmitCommand");
            }
        }

        CICardModel card = new CICardModel();


        private string userName = App.User.firstName + " " + App.User.lastName;

        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;

                OnPropertyChanged("UserName");
            }
        }

        private string email = App.User.email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;

                OnPropertyChanged("Email");
            }
        }


        private string rootCause;

        public string RootCause
        {
            get { return rootCause; }
            set
            {
                rootCause = value;
                OnPropertyChanged("RootCause");
                card.businessValue = RootCause;
            }
        }


        private List<string> locations;

        public List<string> Locations
        {
            get { return locations; }
            set
            {
                locations = value;

                OnPropertyChanged("Locations");
            }
        }


        private string selectedDepartment;

        public string SelectedDepartment
        {
            get { return selectedDepartment; }
            set
            {
                selectedDepartment = value;
                OnPropertyChanged("SelectedDepartment");
                LoadBucketList();
                LoadProcessSteps();
            }
        }

        public string Base64Image { get; set; }

        private List<string> processSteps;
        private List<ProcessStepModel> processStepResult;

        public List<string> ProcessSteps
        {
            get { return processSteps; }
            set
            {
                processSteps = value;
                OnPropertyChanged("ProcessSteps");
            }
        }

        private string selectedProcessStep;

        public string SelectedProcessStep
        {
            get { return selectedProcessStep; }
            set
            {
                selectedProcessStep = value;

                OnPropertyChanged("SelectedProcessStep");
                card.processId = GetProcessId();
            }
        }

        private int GetProcessId()
        {
            return processStepResult.Where(x => x.processName.Equals(selectedProcessStep)).Select(x => x.processId).FirstOrDefault();
        }

        private async void LoadProcessSteps()
        {
            IGetProcessSteps processStepService = new CreateCardService();
            var deptId = deptResult.Where(x => x.departmentName.Equals(SelectedDepartment)).Select(x => x.departmentId).FirstOrDefault();
            card.departmentId = deptId;
            var flowId = GetFlowId();
            card.dynamicFlowId = flowId;
            processStepResult = await processStepService.GetProcessStep(GetLocationId().FirstOrDefault(), flowId, deptId);
            ProcessSteps = processStepResult.Select(x => x.processName).ToList();
            SubmitCommand = new Command(InvokeSubmitCommand);
        }

        private void InvokeSubmitCommand(object obj)
        {
            IPostCardService cardService = new CreateCardService();
            card.cardTitle = Title;
            card.descriptionImage = Base64Image;
            card.clientId = App.User.;
            card.auditUserId = App.User.cclientIdlientId;
            cardService.PostCard(card);

        }

        private string selectedBucket;

        public string SelectedBucket
        {
            get { return selectedBucket; }
            set
            {
                selectedBucket = value;
                OnPropertyChanged("SelectedBucket");
            }
        }


        private List<string> ciBucketList;

        public List<string> CIBucketList
        {
            get { return ciBucketList; }
            set
            {
                ciBucketList = value;
                OnPropertyChanged("CIBucketList");
            }
        }


        private async void LoadBucketList()
        {
            IGetBucketList bucketList = new CreateCardService();
            var result = await bucketList.GetBucketList();
            CIBucketList = result.Select(x => x.bucketName).ToList();
        }

        private List<string> departMents;

        public List<DepartmentModel> deptResult { get; private set; }

        public List<string> Departments
        {
            get { return departMents; }
            set
            {
                departMents = value;
                OnPropertyChanged("Departments");
            }
        }


        private string selectedLocation;

        public string SelectedLocation
        {
            get { return selectedLocation; }
            set
            {
                selectedLocation = value;

                OnPropertyChanged("SelectedLocation");

                LoadDynamicFlows();
            }
        }

        private async void LoadDynamicFlows()
        {
            IGetDynamicFlow GetFlow = new CreateCardService();
            IEnumerable<int> locationId = GetLocationId();
            flowResult = await GetFlow.GetDynamicFlow(locationId.FirstOrDefault());
            card.clientLocationId = locationId.FirstOrDefault();
            DynamicFlows = flowResult.Select(x => x.dynamicFlowName).ToList();

        }

        private IEnumerable<int> GetLocationId()
        {
            return locationResult.Where(x => x.clientLocationName.Equals(selectedLocation)).Select(x => x.clientLocationId);
        }

        private string selectedFlow;

        public string SelectedFlow
        {
            get { return selectedFlow; }
            set
            {
                selectedFlow = value;
                OnPropertyChanged("SelectedFlow");
                LoadDepartments();
            }
        }

        private async void LoadDepartments()
        {
            IGetDepartments getDeptService = new CreateCardService();
            IEnumerable<int> locationId = GetLocationId();
            int flowId = GetFlowId();
            card.dynamicFlowId = flowId;
            deptResult = await getDeptService.GetDepartments(locationId.FirstOrDefault(), flowId);

            Departments = deptResult.Select(x => x.departmentName).ToList();
        }

        private int GetFlowId()
        {
            return flowResult.Where(x => x.dynamicFlowName == selectedFlow).Select(x => x.dynamicFlowId).FirstOrDefault();
        }

        private List<string> dynamicFlows;

        public List<DynamicFlow> flowResult { get; private set; }

        public List<string> DynamicFlows
        {
            get { return dynamicFlows; }
            set
            {
                dynamicFlows = value;

                OnPropertyChanged("DynamicFlows");
            }
        }

        List<LocationModel> locationResult;
        public AddCardViewModel()
        {
            GetLocations();

        }

        private async void GetLocations()
        {
            ICreateCardService service = new CreateCardService();

            locationResult = await service.GetLocations();

            Locations = locationResult.Select(x => x.clientLocationName).ToList();
        }
    }
}
