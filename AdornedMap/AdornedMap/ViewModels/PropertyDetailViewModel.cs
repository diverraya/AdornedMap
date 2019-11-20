using System;
using System.Collections.Generic;
using System.Windows.Input;
using AdornedMap.Models;
using AdornedMap.Views;
using Xamarin.Forms;

namespace AdornedMap.ViewModels
{
    public class PropertyDetailViewModel : BaseViewModel  
    {
          public Property Property { get; set; }
          public IList<Property> PropertyList { get; set; }
          public ICommand CancelCommand => new Command(CancelAsync);
          public bool IsNewProperty { get; set; }

          public PropertyDetailViewModel()
          {
              Property = new Property{Id = "Test Id", Address = "VM Test Address", City = "VM Test City", 
                  State = "VM Test State", Zip = "VM Test Zip", Latitude = 100.2, Longitude = 22.5};
          }

          public PropertyDetailViewModel(Property property = null)
          {
              IsNewProperty = property == null;

              Title = IsNewProperty ? "Add property" : "Edit Property";
              InitializePropertyList();
              Property = property ?? new Property();
          }

          async void InitializePropertyList()
          {
              PropertyList = await AdornedMapDataStore.GetPropertiesAsync();
          }
          
          private void CancelAsync()
          {
               throw new NotImplementedException();
          }
    }
}