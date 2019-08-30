using System.ComponentModel.DataAnnotations;

namespace iRender.iDrive.Authorization.Accounts.Dto
{
    public class SendEmailActivationLinkInput
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}