using DFS.Services;
using DFS.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DFS.ViewModel
{
    public class AddCardViewModel : BaseViewModel
    {
        private string userName=App.User.firstName+" "+App.User.lastName;

        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;

                OnPropertyChanged("UserName");
            }
        }

        private string email=App.User.email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;

                OnPropertyChanged("Email");
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

        private List<string> processSteps;

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
            }
        }


        private async void LoadProcessSteps()
        {
            IGetProcessSteps processStepService = new CreateCardService();
            var deptId = deptResult.Where(x => x.departmentName.Equals(SelectedDepartment)).Select(x => x.departmentId).FirstOrDefault();
            var processStepResult = await processStepService.GetProcessStep(GetLocationId().FirstOrDefault(), GetFlowId(), deptId);
            ProcessSteps = processStepResult.Select(x => x.processName).ToList();

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

            IGetProcessSteps process = new CreateCardService();
          


            Locations = locationResult.Select(x => x.clientLocationName).ToList();
        }
    }
}
