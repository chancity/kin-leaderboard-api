using System.ComponentModel.DataAnnotations.Schema;

namespace kin_leaderboard_api.Entities
{
    public class AppInfoEntity
    {
        public string AppId { get; set; }
        public string GooglePlay { get; set; }
        public string AppStore { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        [ForeignKey(nameof(AppId))]
        public AppEntity AppEntity { get; set; }
    }
}