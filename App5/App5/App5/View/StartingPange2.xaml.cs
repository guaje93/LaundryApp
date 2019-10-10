using App5.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartingPange2 : ContentPage
    {
        public StartingPange2()
        {
            InitializeComponent();
            BindingContext = new StartPageViewModel();

        }
    }
}