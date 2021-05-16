using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Manglietia.DLL
{
    class Class
    {
        public ObservableCollection<Student> Students { get; set; }
        public string Description { get; set; }
        
        public readonly string GUID;

        public Class()
        {
            GUID = System.Guid.NewGuid().ToString();
        }
    }
}
