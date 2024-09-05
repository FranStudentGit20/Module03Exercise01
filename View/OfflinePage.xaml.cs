namespace Module02Exercise01.View;
using Module02Exercise01.ViewModel;
public partial class OfflinePage : ContentPage
{
	public OfflinePage()
	{
		InitializeComponent();
      
    }
    private void OnClickedAppClose(object sender, EventArgs e)
    {
        System.Diagnostics.Process.GetCurrentProcess().Kill();
    }
}