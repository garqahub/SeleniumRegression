using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumRegression
{
    public class Customer
    {

        private string name;
        private string userName;
        private string phone;
        private string password;
        private string confirmPassword;
        private string emailAddress; 
        private bool subscription; 
        private List<Address> addressList;
  

        public Customer()
        {
            name = "Joe Smith";
            //	private String lastName = "Smith";
            phone = "913-397-800";
            password = "test1!";
            confirmPassword = "test1!";
            userName = "test_" + System.DateTime.Now.TimeOfDay.TotalMinutes;          
            
            emailAddress = userName + "@epgarmintest.com";
            subscription = false;
            addressList = new List<Address>();
        }

        public string getName()
        {
            return name;
        }
        public void setName(string name)
        {
            this.name = name;
        }

        //	public String getLastName() {
        //		return lastName;
        //	}
        //	
        //	public void setLastName(String lname) {
        //		this.lastName = lname;
        //	}

        public string getEmailAddress()
        {
            return emailAddress;
        }

        public void setEmailAddress(string emailAddress)
        {
            this.emailAddress = emailAddress;
        }

        public string getUserName()
        {
            return userName;
        }

        public void setUserName(string userName)
        {
            this.userName = userName;
            this.emailAddress = userName + "@epgarmintest.com";
        }

        public string getPhone()
        {
            return phone;
        }

        public void setPhone(string phone)
        {
            this.phone = phone;
        }

        public String getPassword()
        {
            return password;
        }

        public void setPassword(string password)
        {
            this.password = password;
        }

        public String getConfirmPassword()
        {
            return confirmPassword;
        }

        public void setConfirmPassword(string confirmPassword)
        {
            this.confirmPassword = confirmPassword;
        }

        public bool isSubscription()
        {
            return subscription;
        }

        public void setSubscription(bool subscription)
        {
            this.subscription = subscription;
        }

        public void setAddress(Address address)
        {
            this.addressList.Add(address);
        }

        public List<Address> getAddressList()
        {
            return addressList;
        }
    }
}
