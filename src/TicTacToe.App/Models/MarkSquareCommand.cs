using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace TicTacToe.App.Models
{
    public class MarkSquareCommand : ICommand
    {
        private readonly TicTacToeViewModel _viewModel;

        public MarkSquareCommand(TicTacToeViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return parameter is Button button && string.IsNullOrWhiteSpace(button.Content?.ToString());
        }

        public void Execute(object? parameter)
        {
            if (parameter is Button button)
            {
                button.Content = _viewModel.ActivePlayer.Tag;
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler? CanExecuteChanged;
    }
}