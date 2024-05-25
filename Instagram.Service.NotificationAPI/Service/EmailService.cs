using Instagram.Service.NotificationAPI.Model.Dto;
using Instagram.Service.NotificationAPI.Service.IService;
using Instagram.Service.NotificationAPI.Utils;

namespace Instagram.Service.NotificationAPI.Service {
    public class EmailService : IEmailService {
        public void SendFollowEmail(EmailDTO emailDTO) {
            SmtpClientService.SendMail("Instagram","kailashrajput8799@gmail.com","May Be","Hey");
            throw new NotImplementedException();
        }
        public void SendNewPostEmail(EmailDTO emailDTO) {
            throw new NotImplementedException();
        }
    }
}
