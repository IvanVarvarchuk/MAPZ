using System;
using System.Collections.Generic;
using System.Text;

namespace MPZ_Patterns.Command
{
    public class SavingServer
    {
        private ICommand _command;

        public void RegisterCommand(ICommand command)
        {
            _command = command;
        }

        public object RunCommand()
        {
            return _command.Execute();
        }
    }
  
}
