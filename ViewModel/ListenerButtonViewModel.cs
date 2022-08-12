using System;
using System.Windows;
using MyLocation.Model.Interfaces;
using MyLocation.ViewModel.Interfaces;

namespace MyLocation.ViewModel
{
    internal class ListenerButtonViewModel : DependencyObject, IListenerButtonViewModel
    {
        private readonly IAppModel _appModel;

        public static readonly DependencyProperty IsListeningProperty =
            DependencyProperty.Register(
                "IsListening",
                typeof(bool),
                typeof(ListenerButtonViewModel),
                new PropertyMetadata(OnIsListeningChanged));

        private static void OnIsListeningChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null) return;
            if (!(d is ListenerButtonViewModel viewModel)) return;

            var value = (bool)e.NewValue;
            viewModel.HandleIsListeningChanged(value);
        }

        public ListenerButtonViewModel(IAppModel appModel)
        {
            _appModel = appModel ?? throw new ArgumentNullException(nameof(appModel));
        }

        public bool IsListening
        {
            get => (bool)GetValue(IsListeningProperty);
            set => SetValue(IsListeningProperty, value);
        }

        private void HandleIsListeningChanged(bool value)
        {
            try
            {
                if (value)
                {
                    _appModel.Start();
                }
                else
                {
                    _appModel.Stop();
                }
            }
            catch (Exception ex)
            {
                #if DEBUG
                    MessageBox.Show(ex.Message);
                #endif
                //log exceptions
            }
        }
    }
}
