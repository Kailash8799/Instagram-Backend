using Instagram.Service.NotificationAPI.Model.Dto;

namespace Instagram.Service.NotificationAPI.Service.IService {
    public interface IEmailService {
        void SendFollowEmail(EmailDTO emailDTO);
        void SendNewPostEmail(EmailDTO emailDTO);
    }
}
