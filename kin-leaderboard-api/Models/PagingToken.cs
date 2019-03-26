using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kin_leaderboard_api.Models.ApiResponse;

namespace kin_leaderboard_api.Models
{
    public class PagingToken
    {
        public long Value { get; set; }
        public string Cursor { get; set; }
    }
}
