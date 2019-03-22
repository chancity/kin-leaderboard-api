using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kin_leaderboard_api.Entities
{
    public class AppWallet
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public string AppId { get; set; }
        [ForeignKey(nameof(AppId))]
        public App App { get; set; }
        public string Address { get; set; }
        public long Balance { get; set; }

    }
}
