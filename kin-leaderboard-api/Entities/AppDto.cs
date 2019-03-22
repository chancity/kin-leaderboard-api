using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using kin_leaderboard_api.Models;

namespace kin_leaderboard_api.Entities
{
    public class AppDto
    {
        public string AppId { get; set; }
        public string FriendlyName { get; set; }
        public long FirstSeen { get; set; }
        public long LastSeen { get; set; }
        public virtual AppInfoDto Info { get; set; }
        public virtual AppWalletDto Wallet { get; set; }

        public AppDto()
        {
            Info = new AppInfoDto();
        }
    }
}
