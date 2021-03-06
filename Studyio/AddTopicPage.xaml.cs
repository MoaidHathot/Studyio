﻿using Studyio.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Studyio
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddTopicPage : Page
    {
        private IAddTopicViewModel AddTopicDataContext { get { return DataContext as IAddTopicViewModel; } }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var topic = e.Parameter as Topic;

            if (null != topic)
            {
                AddTopicDataContext.CurrentTopic = topic;
            }
        }

        public AddTopicPage()
        {
            this.InitializeComponent();

            this.Loaded += AddTopicPage_Loaded;
        }

        private void AddTopicPage_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void AppBarButton_Click_Accept(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void AppBarButton_Click_Cancel(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void priorityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            AddTopicDataContext.EvaluateSaveTopicCommand();
        }
    }
}
