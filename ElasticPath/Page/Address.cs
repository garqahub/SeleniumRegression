using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeleniumRegression
{
    public class Address
    {
                    private Customer customer;
                    private string firstName;
            private string lastName;
        private string addressLine1;
         private string addressLine2;
        private string city;
        private string state;
        private string country;
        private string zip;
        private string phone;
        private bool preferredBillingAddress; 
        private string preferredBillingAddress_img;
        string[] customerName;

        public Address(Customer consumer)
        {
            customerName = new string[2];
            addressLine1 = "1200 E. 151st Street";           
            city = "Olathe";
            state = "Kansas";
            country = "United States";
            zip = "66062-3426";
            phone = "1234567890";
            preferredBillingAddress = false;
            preferredBillingAddress_img = "--";
             
		this.customer = consumer;
		customer.getName().Split(customerName,StringSplitOptions.RemoveEmptyEntries);
		this.firstName = customerName[0];
		this.lastName = customerName[1];
//		this.phone = customer.getPhone();
        }
    


            public string getFirstName()
            {
                return firstName;
            }

            public void setFirstName(String firstName)
            {
                this.firstName = firstName;
            }

            public void setLastName(String lname)
            {
                this.lastName = lname;
            }

            public String getLastName()
            {
                return lastName;
            }

            public String getAddressLine1()
            {
                return addressLine1;
            }

            public void setAddressLine1(String addressLine1)
            {
                this.addressLine1 = addressLine1;
            }

            public String getAddressLine2()
            {
                return addressLine2;
            }

            public void setAddressLine2(String addressLine2)
            {
                this.addressLine2 = addressLine2;
            }

            public String getCity()
            {
                return city;
            }

            public void setCity(String city)
            {
                this.city = city;
            }

            public String getState()
            {
                return state;
            }

            public void setState(String state)
            {
                this.state = state;
            }

            public String getCountry()
            {
                return country;
            }

            public void setCountry(String country)
            {
                this.country = country;
            }

            public String getZip()
            {
                return zip;
            }

            public void setZip(String zip)
            {
                this.zip = zip;
            }

            public void setPhone(String phone)
            {
                this.phone = phone;
            }

            public String getPhone()
            {
                return phone;
            }

            public String getPreferredBillingAddress_img()
            {
                return preferredBillingAddress_img;
            }

            public void setPreferredBillingAddress_img(String preferredBillingAddress_img)
            {
                this.preferredBillingAddress_img = preferredBillingAddress_img;
            }

            public bool isPreferredBillingAddress()
            {
                return preferredBillingAddress;
            }

            public void setPreferredBillingAddress(bool preferredBillingAddress)
            {
                this.preferredBillingAddress = preferredBillingAddress;
            }

    }
}
    

