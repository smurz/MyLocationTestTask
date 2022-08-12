using System;
using System.IO;
using System.Threading.Tasks;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.Input;
using FlaUI.Core.WindowsAPI;
using FlaUI.UIA3;
using MyLocation.Services.Interfaces;

namespace MyLocation.Services
{
    internal class FlaUiFileOperationsService : IFileOperationsService
    {
        public void AddTimeToCountryFile(string countryName)
        {
            var filePath = GetFilePathForCountryName(countryName);

            if (!File.Exists(filePath))
                //dispose file stream after creation.
                File.Create(filePath).Dispose();

            //launch notepad with this file
            var launchArgs = $"/a \"{filePath}\"";

            var app = FlaUI.Core.Application.Launch("notepad.exe", launchArgs);
            using (var automation = new UIA3Automation())
            {
                var window = app.GetMainWindow(automation);
                window.Focus();

                var docChild = window.FindFirstChild(automation.ConditionFactory.ByControlType(ControlType.Document));
                docChild.Focus();

                Keyboard.Press(VirtualKeyShort.F5);
                Keyboard.Press(VirtualKeyShort.ENTER);
                Keyboard.TypeSimultaneously(VirtualKeyShort.CONTROL,VirtualKeyShort.KEY_S);

                //it was not asked for, but I just don't want to see this window hanging after task
                window.Close();
            }

        }

        private string GetFilePathForCountryName(string countryName)
        {
            var filename = $"{countryName}.txt";
            var desktopFolder = GetDesktopFolder();
            return Path.Combine(desktopFolder, filename);
        }

        private string GetDesktopFolder()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }
    }
}
