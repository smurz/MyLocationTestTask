using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MyLocation.Model;
using MyLocation.Model.Interfaces;
using MyLocation.Services;
using MyLocation.Services.Interfaces;
using MyLocation.ViewModel;
using MyLocation.ViewModel.Interfaces;

namespace MyLocation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string IpApiUrl = "http://ip-api.com/json/";
        private const string WhereAmIPhrase = "Where am I";

        private readonly IListenerButtonViewModel _viewModel;
        private readonly IAppModel _appModel;


        public MainWindow()
        {
            InitializeComponent();

            ISpeechRecognizerFactory recognizerFactory = new OnePhraseSpeechRecognizerFactory(WhereAmIPhrase);
            _appModel = new MyLocationAppModel(
                new SimpleVoiceRecognitionService(recognizerFactory), 
                new FlaUiFileOperationsService(),
                new IpApiLocationService(IpApiUrl));

            _viewModel = new ListenerButtonViewModel(_appModel);

            LayoutRoot.DataContext = _viewModel;
        }
    }
}
