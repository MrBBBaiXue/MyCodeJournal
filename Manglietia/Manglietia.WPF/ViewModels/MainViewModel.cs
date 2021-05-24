using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Stylet;
using c = System.Console;

namespace Manglietia.WPF.ViewModels
{
    public class MainViewModel
    {
        public bool IsDarkMode { get; set; } = false;
        public ObservableCollection<DLL.Class> Classes { get; set; } = new ObservableCollection<DLL.Class> { };

        public MainViewModel()
        {
            // Load File from Server directly
            var testEnglishScore = new DLL.Score
            {
                Subject = "English",
                Point = 150
            };
            var testMathScore = new DLL.Score
            {
                Subject = "Math",
                Point = 148
            };
            var student = new DLL.Student
            {
                Name = "Wang boyan",
                Sex = false,
                ID = "2020117103",
                Phone = "13456789233"
            };
            student.Scores.Add(testEnglishScore);
            student.Scores.Add(testMathScore);
            
            var testClass = new DLL.Class
            {
                Description = "电信二班"
            };
            testClass.Students.Add(student);
            Classes.Add(testClass);
            c.WriteLine();
            return;
        }

        public void ToggleDarkMode()
        {
            
            HandyControl.Themes.ThemeManager.Current.ApplicationTheme = 
                (IsDarkMode) ? HandyControl.Themes.ApplicationTheme.Dark : HandyControl.Themes.ApplicationTheme.Light;
            IsDarkMode = !IsDarkMode;
            return;
        }
    }
}
