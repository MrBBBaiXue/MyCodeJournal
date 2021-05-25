using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using d = System.Diagnostics.Debug;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Documents;
using Manglietia.DLL;
using MessageBox = HandyControl.Controls.MessageBox;

namespace Manglietia.WPF.ViewModels
{
    public class MainViewModel
    {
        public bool IsDarkMode { get; set; } = false;
        public ObservableCollection<DLL.Class> Classes { get; set; } = new ObservableCollection<DLL.Class> { };
        public int SelectedIndex { get; set; } = 0;
        public Class SelectedClass => Classes[SelectedIndex];
        public ObservableCollection<Student> SelectedStudents => SelectedClass.Students;
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
            var studentA = new DLL.Student
            {
                Name = "Wang boyan",
                Sex = false,
                ID = "2020117103",
                Phone = "13456789233"
            };
            studentA.Scores.Add(testEnglishScore);
            studentA.Scores.Add(testMathScore);

            testEnglishScore.Point = 100;
            testMathScore.Point = 120;

            var studentB = new DLL.Student
            {
                Name = "Zhang wenle",
                Sex = true,
                ID = "2020117151",
                Phone = "13860378752"
            };

            studentB.Scores.Add(testEnglishScore);
            studentB.Scores.Add(testMathScore);
            var testClass = new DLL.Class
            {
                Description = "电信二班"
            };
            testClass.Students.Add(studentA);
            testClass.Students.Add(studentB);
            Classes.Add(testClass);
            d.WriteLine(testClass);
            return;
        }

        public void ToggleDarkMode()
        {
            HandyControl.Themes.ThemeManager.Current.ApplicationTheme = 
                (IsDarkMode) ? HandyControl.Themes.ApplicationTheme.Dark : HandyControl.Themes.ApplicationTheme.Light;
            IsDarkMode = !IsDarkMode;
            return;
        }

        public void NewFile()
        {
            while (Classes.Count > 0)
            {
                Classes.RemoveAt(0);
            }
        }

        public void OpenFile()
        {
            string path;
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                InitialDirectory = Environment.CurrentDirectory
            };
            if ((bool)dialog.ShowDialog())
            {
                // Clean up files
                while (Classes.Count > 0)
                {
                    Classes.RemoveAt(0);
                }
                path = dialog.FileName;
                var classesData = new ClassesData(path);
                // List to ObservableCollection
                foreach (var classData in classesData.Read())
                {
                    Classes.Add(classData);
                }
            }
        }

        public void SaveFile()
        {
            string path;
            var dialog = new Microsoft.Win32.SaveFileDialog
            {
                InitialDirectory = Environment.CurrentDirectory
            };
            if ((bool)dialog.ShowDialog())
            {
                path = dialog.FileName;
                var classesData = new ClassesData(path);
                classesData.Write(Classes);
            }
        }

        public void AddClass()
        {
            var newClass = new Class
            {
                Description = "2333"
            };
            Classes.Add(newClass);
            d.WriteLine(SelectedIndex);
        }

        public void RemoveClass()
        {
            if (MessageBox.Show($"确认移除班级 \"{SelectedClass.Description}\" 吗?",
                "确认删除",
                MessageBoxButton.YesNo
            ) == MessageBoxResult.Yes)
            {
                Classes.RemoveAt(SelectedIndex);
            }
        }

        public void DataAnalysis()
        {
            foreach (var selectedStudent in SelectedStudents)
            {
                d.WriteLine($"{selectedStudent.IsSelected} {selectedStudent.Name} {selectedStudent.ScoreText}");
            }
        }

        public void AddStudent()
        {
            var student = new Student { };
            
        }

        public void EditStudent()
        {
            // create Window popup
        }

        public void RemoveStudent()
        {
            if (MessageBox.Show($"确认移除这些学生吗?",
                "确认删除",
                MessageBoxButton.YesNo
            ) != MessageBoxResult.Yes) return;

            for(int i = 0; i <= SelectedStudents.Count; i++)
            {
                if (SelectedStudents[i].IsSelected)
                {
                    // remove
                }
            }
        }

    }
}
