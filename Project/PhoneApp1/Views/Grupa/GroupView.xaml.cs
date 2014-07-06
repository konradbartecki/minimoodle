using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace PhoneApp1
{
    public partial class GroupView : PhoneApplicationPage
    {
        public GroupView()
        {
            InitializeComponent();
        }

        private void Panorama_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
        	switch (((Panorama)sender).SelectedIndex)
        	{
            	default:
					ApplicationBar = null;
               	 	break;

            	case 2:
                	ApplicationBar = ((ApplicationBar)Application.Current.Resources["AppBar1"]);
                	break;
    		}
        }

        private void LongListSelector_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
        	NavigationService.Navigate(new Uri("/Views/Grupa/MaterialView.xaml", UriKind.Relative));
        }

        private void LongListSelectorEgzaminy_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
        	NavigationService.Navigate(new Uri("/Views/Grupa/EgzaminView.xaml", UriKind.Relative));
        }
    }
}