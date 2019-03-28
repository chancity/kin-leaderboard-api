using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace kin_leaderboard_api.Entities
{
    public class PagingTokenEntity
    {
        public long Value { get; set; }
        public string Cursor { get; set; }
    }
}
