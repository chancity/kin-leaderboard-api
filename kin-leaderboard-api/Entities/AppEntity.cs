using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using kin_leaderboard_api.Models;

namespace kin_leaderboard_api.Entities
{
    public class AppEntity
    {
        public string AppId { get; set; }
        public string FriendlyName { get; set; }
        public long FirstSeen { get; set; }
        public long LastSeen { get; set; }
        public virtual AppInfoEntity Info { get; set; }
        public virtual AppWalletEntity Wallet { get; set; }

        public AppEntity()
        {
            Info = new AppInfoEntity();
        }
    }
}
