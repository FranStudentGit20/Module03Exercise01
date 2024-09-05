using Module02Exercise01.ViewModel;

namespace Module02Exercise01.View
{
    public partial class LoginPage : ContentPage
    {

        public LoginPage()
        {
            InitializeComponent();


        }

        private async void OnLogin(object sender, EventArgs e)
        {
            string username = userEntry.Text;
            string password = passEntry.Text;

            
            if (username == "admin" && password == "password")
            {
                
                await Navigation.PushAsync(new EmployeePage());
            }
            else
            {
                await DisplayAlert("Login Failed", "Incorrect username or password.", "OK");
            }
        }
    }
}