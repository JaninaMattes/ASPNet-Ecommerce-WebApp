using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace INFT3050.PaymentSystem
{
    /// <summary>
    /// A dummy account for INFT payment system
    /// </summary>
    public class DummyPaymentAccount
    {
        public DummyPaymentAccount(string name, string number, decimal accountValue, DateTime expiry, int cvc, TransactionResult defaultResult)
        {
            Name = name;
            Number = number;
            AccountValue = accountValue;
            Expiry = expiry;
            CVC = cvc;
            DefaultResult = defaultResult;
        }

        public string Name { get; set; }
        public string Number { get; set; }
        public decimal AccountValue { get; set; }
        public int CVC { get; set; }
        public DateTime Expiry { get; set; }
        public TransactionResult DefaultResult { get; set; }
    }

    /// <summary>
    /// A dummy payment system for INFT 3050
    /// </summary>
    public class PaymentSystem : IPaymentSystem
    {
        //
        // make a dummy payment based on the dummy accounts
        public Task<PaymentResult> MakePayment(PaymentRequest payment)
        {
            var task = Task<PaymentResult>.Factory.StartNew(() => {

                var receipt = new PaymentResult();
                var delay = new TimeSpan(m_rand.Next(50000000));
                Task delayTask = Task.Delay(delay);
                delayTask.Wait();

                // if payment name is 'timeout' then transaction will time out
                if (payment.CardName != "timeout")
                {
                    var account = FindValidCard(payment);

                    if (account != null)
                    {
                        // check for valid transaction
                        receipt.TransactionResult = CheckTransaction(account, payment);
                        if (receipt.TransactionResult == TransactionResult.Approved)
                        {
                            receipt.Amount = payment.Amount;
                            receipt.ReceiptId = m_rand.Next();
                            receipt.Description = payment.Description;
                        }

                    }
                    else
                    {
                        receipt.TransactionResult = TransactionResult.InvalidCard;
                    }

                }
                else
                {
                    receipt.TransactionResult = TransactionResult.ConnectionFailure;
                }
                return receipt;

            });

            return task;
        }

        // find a matching account for a given card
        private DummyPaymentAccount FindValidCard(PaymentRequest payment)
        {
            var account = Array.Find(m_dummyAccounts, (a) => { return a.Number == payment.CardNumber; });

            var name = payment.CardName.ToLower();
            if (account != null && account.CVC == payment.CVC && account.Expiry == payment.Expiry && account.Name == name)
            {
                return account;
            }
            return null;
        }

        // check the transaction results
        private TransactionResult CheckTransaction(DummyPaymentAccount account, PaymentRequest payment)
        {
            if (payment.Amount > account.AccountValue)
            {
                return TransactionResult.Declined;
            }
            var now = DateTime.Now;
            var firstOfMonth = new DateTime(now.Year, now.Month, 1);
            if (account.Expiry < firstOfMonth)
            {
                return TransactionResult.InvalidExpiry;
            }

            return account.DefaultResult;
        }

        // rng for results
        private Random m_rand = new Random();

        // dummy accounts associated with this payment system
        private DummyPaymentAccount[] m_dummyAccounts = new DummyPaymentAccount[] {
            new DummyPaymentAccount("arthur anderson", "4444333322221111",100000, new DateTime(2020, 11, 1), 123, TransactionResult.Approved),
            new DummyPaymentAccount("betty boo", "5105105105105100", 2000, new DateTime(2019, 05, 1), 123, TransactionResult.Approved),
            new DummyPaymentAccount("carol carver", "2223000048400011", 300, new DateTime(2018, 09, 1), 123, TransactionResult.Approved),
            new DummyPaymentAccount("don desilva","2223520043560014", 40, new DateTime(2020, 11, 1), 123, TransactionResult.Approved),
            new DummyPaymentAccount("emma edwards","378282246310005", 500, new DateTime(2020, 11, 1), 123, TransactionResult.Declined),
            new DummyPaymentAccount("timmy timeout","38520000023237", 500, new DateTime(2020, 11, 1), 123, TransactionResult.ConnectionFailure)
        };
    }


}