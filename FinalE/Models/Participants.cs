using System.ComponentModel.DataAnnotations;
namespace FinalE.Models
{
    public class Participants
    {
        [Key]
        public int ParticipantId {get;set;}
        public int UserId {get;set;}
        public int ActivityId {get;set;}

        public Activities Activity {get;set;}
        public User User {get;set;}
    }
}