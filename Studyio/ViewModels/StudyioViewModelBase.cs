using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Studyio
{
    public abstract class StudyioViewModelBase : ViewModelBase
    {
        public bool Set<T>(T value, ref T field, [CallerMemberName] string propertyName = "")
        {
            Debug.WriteLine($"Set of {propertyName}");
            return Set(propertyName, ref field, value);
        }
    }
}
