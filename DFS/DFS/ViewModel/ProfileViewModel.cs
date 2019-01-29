using DFS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFS.ViewModel
{
    public class ProfileViewModel : BaseViewModel
    {
        private List<ProfileModel> _profileList = new List<ProfileModel>();

        public List<ProfileModel> ProfileList
        {
            get { return _profileList; }
            set
            {
                _profileList = value;
                OnPropertyChanged("ProfileList");

            }
        }

        public ProfileViewModel()

        {
            ProfileModel Profile = new ProfileModel();

            Profile.paramter = App.User.firstName + " " + App.User.lastName;
            Profile.ImageIcon = "ic_account_circle_black_24dp.png";
            Profile.Header = "Name :";
            
          
            ProfileModel MobileNumber = new ProfileModel() { ImageIcon = "ic_phone_black_24dp.png", Header = "Contact :", paramter = App.User.contact };
            ProfileModel Email = new ProfileModel() { ImageIcon = "ic_email_black_24dp.png", Header = "Email :", paramter = App.User.email };
            
            ProfileModel Address = new ProfileModel() { ImageIcon = "if_home_1372383.png", Header = "Address :", paramter = App.User.location };


            ProfileList.Add(Profile);           
            ProfileList.Add(MobileNumber);
            ProfileList.Add(Email);           
            ProfileList.Add(Address);

        }
    }
}
