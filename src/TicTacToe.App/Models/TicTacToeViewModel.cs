using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TicTacToe.App.Annotations;

namespace TicTacToe.App.Models
{
    public class TicTacToeViewModel : INotifyPropertyChanged
    {
        private Player _activePlayer;
        public event PropertyChangedEventHandler PropertyChanged;

        public Player PlayerOne { get; }
        public Player PlayerTwo { get; }

        public ICommand TagCommand { get; }

        public Player ActivePlayer
        {
            get => _activePlayer;
            set
            {
                _activePlayer = value;
                OnPropertyChanged(nameof(ActivePlayer));
            }
        }

        public TicTacToeViewModel()
        {
            PlayerOne = new Player {Name = nameof(PlayerOne), Tag = PlayerTags.X};
            PlayerTwo = new Player {Name = nameof(PlayerTwo), Tag = PlayerTags.O};
            ActivePlayer = PlayerOne;
            TagCommand = new TagSquareCommand(new MarkSquareCommand(this), new AdvancePlayerCommand(this));
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}