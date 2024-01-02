using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JV_AppNotas.ViewModels
{

    internal class AboutViewModel_JV
    {
        public string Title => AppInfo.Name;
        public string Version => AppInfo.VersionString;
        public string MoreInfoUrl => "https://aka.ms/maui";
        public string Message => "This app is written in XAML and C# with .NET MAUI.";
        public ICommand ShowMoreInfoCommand_JV { get; }

        public AboutViewModel_JV()
        {
            ShowMoreInfoCommand_JV = new AsyncRelayCommand(ShowMoreInfo_JV);
        }

        async Task ShowMoreInfo_JV() =>
            await Launcher.Default.OpenAsync(MoreInfoUrl);
    }
}
