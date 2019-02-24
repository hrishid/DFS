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



        private string cardTitle;

        public string CardTitle
        {
            get { return cardTitle; }
            set
            {
                cardTitle = value;
                OnPropertyChanged("CardTitle");
                card.cardTitle = CardTitle;
            }
        }


        private string descriptionText;

        public string DescriptionText
        {
            get { return descriptionText; }
            set
            {
                descriptionText = value;
                OnPropertyChanged("RootCause");
                card.description = descriptionText;
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
            card.cardTitle = cardTitle;
            card.descriptionImage = Base64Image; /*"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";*/



            card.clientId = App.User.clientId;
            card.auditUserId = App.User.id;
            cardService.PostCard(card);

            CallBack();

        }

        private string selectedBucket;

        public string SelectedBucket
        {
            get { return selectedBucket; }
            set
            {
                selectedBucket = value;
                OnPropertyChanged("SelectedBucket");

                card.bucketId = bucketListResult.Where(x => x.bucketName.Equals(SelectedBucket)).Select(x => x.bucketId).FirstOrDefault();
            }
        }


        private List<string> ciBucketList;
        private List<BucketModel> bucketListResult;

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
            bucketListResult = await bucketList.GetBucketList();
            CIBucketList = bucketListResult.Select(x => x.bucketName).ToList();
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
        private Action CallBack;

        public AddCardViewModel(Action callBack)
        {
            this.CallBack = callBack;
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
