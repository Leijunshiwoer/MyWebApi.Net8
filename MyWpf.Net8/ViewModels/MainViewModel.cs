using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyWpf.Net8.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyWpf.Net8.ViewModels
{
   public partial class MainViewModel(IDeepSeekService deepSeekService) : ObservableObject
    {
        [ObservableProperty]
        private string? responseText;
        [ObservableProperty]
        private string? requestText;
        [ObservableProperty]
        private bool isEnabled;

        [RelayCommand]
        private async Task SubmitAsync()
        {
            if (string.IsNullOrWhiteSpace(requestText))
            {
                MessageBox.Show("Please enter a message to send to DeepSeek.");
                return;
            }
            var response = await deepSeekService.PostDeepSeekResAsync(requestText);
            if (response.Status)
            {
                ResponseText = response.Message;
            }
            else
            {
                MessageBox.Show("Error calling DeepSeek API");
            }
        }
    }
}
