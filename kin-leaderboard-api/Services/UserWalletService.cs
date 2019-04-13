﻿using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using kin_leaderboard_api.Entities;
using kin_leaderboard_api.Exceptions;
using kin_leaderboard_api.Helper;
using kin_leaderboard_api.Services.Abstract;
using kin_leaderboard_frontend.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace kin_leaderboard_api.Services
{
    public class UserWalletService : AbstractService<UserWalletEntity, UserWallet, string>
    {
        public UserWalletService(ILoggerFactory loggerFactory, ApplicationContext context, IMapper mapper)
            : base(loggerFactory, context, mapper) { }


        public async Task<PaginatedList<AppPayment>> GetPayments(string id, string address, int pageIndex = 1)
        {
            UserWalletEntity dbEntityWallet =
                await Repo.GetContext.UserWallets.FindAsync(id, address).ConfigureAwait(false);

            if (dbEntityWallet == null)
            {
                throw new NotFoundApiException($"{GetType().Name} id '{id}' not found");
            }

            return await Repo
                .GetContext
                .Payments
                .AsNoTracking()
                .Where(w => w.AppId.Equals(id) && w.Recipient.Equals(address) || w.Sender.Equals(address))
                .OrderByDescending(w => w.EpochTime).CreateAsync<AppPaymentEntity, AppPayment>(Mapper, pageIndex, 25);
        }

        public async Task<int> UpdateFriendlyName(string id, string address, string value)
        {
            UserWalletEntity dbEntityWallet =
                await Repo.GetContext.UserWallets.FindAsync(id, address).ConfigureAwait(false);

            if (dbEntityWallet == null)
            {
                throw new NotFoundApiException($"{GetType().Name} id '{id}' not found");
            }


            dbEntityWallet.FriendlyName = value;
            return await Repo.SaveChanges().ConfigureAwait(false);
        }
    }
}