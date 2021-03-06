﻿using AccountSvc.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountSvc.Repositories
{
    public interface IAccountRepository
    {
        Task CreateAccount(CreateAccount account);
        Task UpdateAccount(UpdateAccount updAccount);
        Task UpdatePassword(UpdatePassword updPassword);
        Task<Account> GetAccountByEmail(string email);
        Task<Account> GetAccountById(string id);
        Task<Address> GetAddressById(string addrId);
        Task AddAddress(Address addr);
        Task UpdateAddress(Address addr);
        Task RemoveAddress(string addressId);
        Task<IList<Address>> GetAddressesByAccountId(string acctId);
        Task SetDefaultAddress(string acctId, int addressId);
        Task<PaymentInfo> GetPaymentInfoById(string pmtId);
        Task AddPaymentInfo(PaymentInfo pmtInfo);
        Task UpdatePaymentInfo(PaymentInfo pmtInfo);
        Task RemovePaymentInfo(string pmtId);
        Task<IList<PaymentInfo>> GetPaymentInfosByAccountId(string accountId);
        Task SetDefaultPaymentInfo(string accountId, int pmtId);
        Task<IList<AccountHistory>> GetAccountHistory(string acctId, int limit = 10);
        Task UpdateNewsletterSubscription(string email, bool subscribe = true);
        Task InsertLog(
            string accountId,
            EventType et,
            string requestedById = null,
            string refId = null,
            RefType? refType = null,
            string ip = null,
            string data = null);
    }
}