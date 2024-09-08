using Ion.Server.RequestEntities.TripRecord;
using Ion.Server.RequestEntities.User;

namespace Ion.RazorPages.Models
{
    public class UserModel
    {
        public UserToGet UserToGet { get; set; }
        public IEnumerable<TripRecordToGet> TripRecords { get; set; }
    }
}
