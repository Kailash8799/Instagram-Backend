namespace Instagram.Service.NotificationAPI.Model.Dto {

    public enum SendType {
        POST,
        FOLLOW
    }

    public class EmailDTO {
        public required string UserId { get; set; }
        public string FollowerId { get; set; }
        public  SendType Type { get; set; }
    }
}
