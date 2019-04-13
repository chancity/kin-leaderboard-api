﻿namespace kin_leaderboard_frontend.Shared.Models
{
    public class UserWallet
    {
        public string Address { get; set; }
        public string AppId { get; set; }
        public string FriendlyName { get; set; }
        public long TxCount { get; set; }
        public long TxVolume { get; set; }
        public long FirstSeen { get; set; }
        public long LastSeen { get; set; }
    }
}