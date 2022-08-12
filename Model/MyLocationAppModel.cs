using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MyLocation.Model.Interfaces;
using MyLocation.Services;
using MyLocation.Services.Interfaces;

namespace MyLocation.Model
{
    public class MyLocationAppModel : IAppModel
    {
        private readonly IVoiceRecognitionService _recognitionService;
        private readonly IFileOperationsService _fileOperationsService;
        private readonly ILocationService _locationService;

        public MyLocationAppModel(
            IVoiceRecognitionService recognitionService,
            IFileOperationsService fileOperationsService,
            ILocationService locationService)
        {
            _recognitionService = recognitionService ?? throw new ArgumentNullException(nameof(recognitionService));
            _fileOperationsService = fileOperationsService ?? throw new ArgumentNullException(nameof(fileOperationsService));
            _locationService = locationService ?? throw new ArgumentNullException(nameof(locationService));

            _recognitionService.VoiceCommandReceived += VoiceRecognitionServiceOnVoiceCommandReceived;
        }

        public void Start()
        {
            
            _recognitionService.StartListening();
        }

        public void Stop()
        {
            _recognitionService.StopListening();
        }

        //async void is a bad practice and should be avoided. It is here just to keep this Test Task as minimal as possible.
        //And to not introduce additional dependencies to the project.
        //In production version this algorithm should be reworked into Reactive Extensions pipeline for example.
        private async void VoiceRecognitionServiceOnVoiceCommandReceived(object? sender, EventArgs e)
        {
            try
            {
                var countryName = await _locationService.GetCurrentLocationAsync();
                if (countryName != null)
                    _fileOperationsService.AddTimeToCountryFile(countryName);
            }
            catch(Exception ex)
            {
                #if DEBUG
                    MessageBox.Show(ex.Message);
                #endif
                //log exceptions
            }
        }
    }
}
