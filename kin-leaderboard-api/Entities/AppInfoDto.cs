using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace kin_leaderboard_api.Entities
{
    public class AppInfoDto
    {
        public string AppId { get; set; }
        public string GooglePlay { get; set; }
        public string AppStore { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        [ForeignKey(nameof(AppId))]
        public AppDto AppDto { get; set; }
    }
}
