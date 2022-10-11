using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ViewModels.Commands;

namespace ViewModels
{
    public class HomeVM
    {
        public ICommand MouseDownCommands { get; set; }
        public HomeVM()
        {
            MouseDownCommands = new RelayCommands<Window>(
                p =>
                {
                    p.DragMove();
                });
        }
    }
}
