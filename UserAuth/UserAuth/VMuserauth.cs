using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace UserAuth
{
    class VMuserauth : INotifyPropertyChanged
    {
        modelUserAuth gameModel;
        public event PropertyChangedEventHandler PropertyChanged;
        public VMuserauth()
        {
            gameModel = new modelUserAuth();
            checkPasswordCommand = new CommandHandler(checkPassword, CanExecute);
            SuggestPasswordCommand = new CommandHandler(SuggestPassword, CanExecute);
        }

        private string _passwordInsert;
        public string passwordInsert
        {
            get
            {
                return _passwordInsert;
            }
            set
            {
                _passwordInsert = value;
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public string passwordInfoText { get; set; }
        public string passwordLenghtText { get; set; }
        public string passwordSuggestionv1 { get; set; }
        public string passwordSuggestionv2 { get; set; }

        public ICommand checkPasswordCommand { get; set; }
        public ICommand SuggestPasswordCommand { get; set; }

        public void checkPassword()
        {
            gameModel.password = passwordInsert;
            //passwordInfoText=gameModel.checkPasswordLenght();
            //passwordInfoText = gameModel.PasswordLow();
            //passwordInfoText = gameModel.PasswordUpp();
            passwordInfoText = gameModel.EvaluatePasswordStrenght();
            OnPropertyChange(nameof(passwordInfoText));
        }

        public void SuggestPassword()
        {
            gameModel.password=passwordInsert;
            passwordSuggestionv1 = gameModel.SugestPasswordV1();
            passwordSuggestionv2 = gameModel.SugestPasswordV2();
            OnPropertyChange(nameof(passwordSuggestionv1));
            OnPropertyChange(nameof(passwordSuggestionv2));
        }

        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public bool CanExecute()
        {
            if (string.IsNullOrWhiteSpace(passwordInsert))
            {
                return false;
            }
            else
            {
                gameModel.password = passwordInsert;
                var lenghtCheck = gameModel.checkPasswordLenght();

                if (lenghtCheck == "password is too short")
                {
                    passwordLenghtText = "password is too short";
                    OnPropertyChange(nameof(passwordLenghtText));
                    return false;
                }

                if (lenghtCheck == "password is too long")
                {
                    passwordLenghtText = "password is too long";
                    OnPropertyChange(nameof(passwordLenghtText));
                    return false;
                }


                passwordLenghtText = "password lenght ok";
                OnPropertyChange(nameof(passwordLenghtText));
                return true;
            }
        }
    }
}
