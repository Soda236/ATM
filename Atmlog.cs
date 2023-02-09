using System;

namespace ATM
{
    internal class Atmlog
    {
        #region Members
        
        private bool IsCorrect = false;
        private string result = String.Empty;
        private bool IsEnough = false;
        public bool IsLogged = false;

        #endregion /Members

        #region Public methods

        public string Separator(int money)
        {
                int[] banknotes = { 200, 100, 50, 20, 10, 5 };

                foreach (int note in banknotes)
                {
                    int notesToWithdraw = money / note;
                    if (notesToWithdraw > 0)
                    {
                        result += notesToWithdraw + " notes of " + note + "€" + "\n";
                        money = money % note;
                    }
                }          
            return result;
        }
        public bool NumCheck(string number)
        {
            if (number != "" & number != "0")
            {
                string CorNum = number.Remove(0, number.Length - 1);

                if (CorNum == "0" || CorNum == "5")
                {
                    IsCorrect = true;
                }
                else IsCorrect = false;
            }
            else IsCorrect = false;

            return IsCorrect;
        }

        public bool BalanceCheck(int balance, int money)
        {
            if (money < balance)
            {
                IsEnough = true;
            }
            else IsEnough = false;

            return IsEnough;
        }

        public bool PinCheck(string userpass, string pass)
        {
            if (userpass == pass)
            {
                IsLogged = true;
            }

            return IsLogged;
        }

        public int History(int money, string TextBlock)
        {
            return 1;
        }

        #endregion /Public methods
    }
}
