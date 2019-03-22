using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kin_leaderboard_api.Entities
{
    public class AppWalletDto
    {
        public string Address { get; set; }
         [ForeignKey(nameof(AppId))]
        public string AppId { get; set; }
       
        public AppDto AppDto { get; set; }
        public long Balance { get; set; }

    }
}
