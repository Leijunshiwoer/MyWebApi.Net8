using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyWpf.Net8.Models;
using MyWpf.Net8.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyWpf.Net8.ViewModels
{
   public partial class MainViewModel : ObservableObject
    {
        public MainViewModel(IDeepSeekService deepSeekService)
        {
            this.deepSeekService = deepSeekService;
            Messages = [];
        }
        [ObservableProperty]
        private string? responseText;
        [ObservableProperty]
        private string? requestText;
        [ObservableProperty]
        private bool isEnabled;
        [ObservableProperty]
        public ObservableCollection<MessageModel> messages;

        private readonly IDeepSeekService deepSeekService;

        [RelayCommand]
        private async Task SubmitAsync()
        {
            if (string.IsNullOrWhiteSpace(requestText))
            {
                MessageBox.Show("Please enter a message to send to DeepSeek.");
                return;
            }

            // Add user message to the list
            Messages.Add(new MessageModel { Content = requestText, IsSentByUser = true,Timestamp=DateTime.Now });

            var response = await deepSeekService.PostDeepSeekResAsync(requestText);
            if (response.Status)
            {
                ResponseText = response.Message;

                // Add response message to the list
                Messages.Add(new MessageModel { Content = response.Message, IsSentByUser = false ,Timestamp= DateTime.Now });
            }
            else
            {
                MessageBox.Show("Error calling DeepSeek API");
            }
        }
    }
}
