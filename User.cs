/*
User.cs A class to generate different things
*/
using System;

namespace ATM
{
    internal class User
    {
        #region Members
        
        public string Name = string.Empty;
        public int Balance = 0;
        public int Wallet = 0;

        #endregion /Members

        #region Public methods
        
        /// <summary>
        /// Generates a password
        /// </summary>
        /// <returns></returns>
        public int PassGenerator()
        {
            try
            {
                Random rand = new Random();
                return rand.Next(1000, 9999);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Generate a balance
        /// </summary>
        /// <returns></returns>
        public int BalanceGen()
        {
            try
            {
                Random rand = new Random();
                return rand.Next(1000, 9999);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Generate a wallet
        /// </summary>
        /// <returns></returns>
        //public int WalletGen()
        //{
        //    try
        //    {
        //        Random rand = new Random();
        //        return rand.Next(0, 250);
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        #endregion /Public methods
    }
}
