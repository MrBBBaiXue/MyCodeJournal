using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace PokerDealer.WPF
{
    public class DelegateCommand : ICommand
        {
            public bool CanExecute(object parameter)
            {
                if (CanExecuteFunc == null)
                {
                    return true;
                }

                return CanExecuteFunc(parameter);
            }
            public event EventHandler CanExecuteChanged;
            public void Execute(object parameter)
            {
                if (ExecuteAction == null)
                {
                    return;
                }
                ExecuteAction(parameter);
            }
            public Action<object> ExecuteAction { get; set; }
            public Func<object, bool> CanExecuteFunc { get; set; }

            public DelegateCommand(Action<object> action)
            {
                ExecuteAction = action;
            }
        }
}
