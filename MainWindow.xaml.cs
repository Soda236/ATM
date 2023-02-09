using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ATM
{

    public partial class MainWindow : Window
    {
        #region Members

        private int pass;
        private bool Welcome = true;
        private bool WithdrawBool = false;
        private bool DepositBool = false;
        private bool ButtonON = false;
        private int CurrentBalance;
        #endregion / Members

        public MainWindow()
        {
            try
            {
                InitializeComponent();

                User user = new User();
                user.Name = " Nikita Kravtsov";
                user.Balance = user.BalanceGen();
                CurrentBalance = user.Balance;
                //user.Wallet = user.WalletGen();
                pass = user.PassGenerator();

                name.Text += user.Name;
                password.Text += pass.ToString();
                balance.Text += user.Balance.ToString() + "€";
               // wallet.Text += user.Wallet.ToString() + "€";

                ButtonON = false;
                ButtonON = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }     

        //All digits buttons click handler
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NumBox.Text.Length != 4)
                {
                    Button button = (Button)sender;
                    string content = button.Content.ToString();

                    NumBox.Text += content;
                    Console.Beep();
                }
                else Console.Beep(100, 60);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
         
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            NumBox.Text = "";
            Console.Beep();
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            if (NumBox.Text.Length > 0)
            {
                NumBox.Text = NumBox.Text.Substring(0, NumBox.Text.Length - 1);
            }
            Console.Beep();
        }

        private void Enter(object sender, RoutedEventArgs e)
        {
            if (Welcome)
            {
                Atmlog atm = new Atmlog();
                if (atm.PinCheck(NumBox.Text, pass.ToString()))
                {
                    Title.Content = "Welocme";
                    AtmConsole.Text = "Select withdraw to continue";
                    NumBox.Text = "";

                    withdraw.Content = "-";
                    //deposit.Content = "+";
                    Welcome = false;
                    ButtonON = true;
                    Console.Beep();
                }
                else
                {
                    AtmConsole.Text = "Pass is incorrect";
                    Console.Beep(100, 60);
                    NumBox.Text = "";
                }      
            }

            if (WithdrawBool)
            {
                Atmlog atm = new Atmlog();
                if (atm.NumCheck(NumBox.Text) && atm.BalanceCheck(CurrentBalance, int.Parse(NumBox.Text)))
                {

                    if (atm.NumCheck(NumBox.Text))
                    {
                        int money = int.Parse(NumBox.Text);
                        AtmConsole.Text = atm.Separator(money);
                        int NewBalance = CurrentBalance - int.Parse(NumBox.Text);
                        balance.Text = "Balance: " + NewBalance.ToString() + "€";
                        CurrentBalance = NewBalance;

                        //Console.WriteLine(atm.Separator(money));
                        Console.Beep();
                        NumBox.Text = "";
                    }
                    else
                    {
                        AtmConsole.Text = "Number is written incorecctly";
                        Console.Beep(100, 60);
                        NumBox.Text = "";
                    }
                }
                else
                {
                    AtmConsole.Text = "You don't have enough money";
                    Console.Beep(100, 60);
                    NumBox.Text = "";
                }
            }
        }

        private void Withdraw(object sender, RoutedEventArgs e)
        {
            if (ButtonON)
            {
                Title.Content = "Withdraw";
                Console.Beep();
                WithdrawBool = true;
            }
            else Console.Beep(100, 60);
        }
        
        private void Deposit(object sender, RoutedEventArgs e)
        {
            /*
            if (ButtonON)
            {

                Title.Content = "Deposit";
                Console.Beep();
            }
            else Console.Beep(100, 60);
            */
        }
       
    }
}

