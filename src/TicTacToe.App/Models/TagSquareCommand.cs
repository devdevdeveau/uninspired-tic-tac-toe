using System;
using System.Linq;
using System.Windows.Input;

namespace TicTacToe.App.Models
{
    public class TagSquareCommand : ICommand
    {
        private readonly ICommand[] _commands;
        
        public TagSquareCommand(params ICommand[] commands)
        {
            _commands = commands;
        }

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            foreach (var command in _commands.Where(c=>c.CanExecute(parameter)))
            {
                command.Execute(parameter);
            }
        }

        public event EventHandler? CanExecuteChanged;
    }
}