using System;
using System.Windows.Input;

namespace TicTacToe.App.Models
{
    public class AdvancePlayerCommand : ICommand
    {
        private readonly TicTacToeViewModel _viewModel;

        public AdvancePlayerCommand(TicTacToeViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _viewModel.ActivePlayer = _viewModel.ActivePlayer == _viewModel.PlayerOne
                ? _viewModel.PlayerTwo
                : _viewModel.PlayerOne;
        }

        public event EventHandler? CanExecuteChanged;
    }
}