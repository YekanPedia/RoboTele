namespace YekanPedia.RoboTele.Domain.Responses.Types
{
    using Json;
    public class UserResponse
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string UserName { get; private set; }

        public static UserResponse Parse(JsonData data)
        {
            if (data == null || !data.Has("id") || !data.Has("first_name"))
            {
                return null;
            }

            return new UserResponse
            {
                Id = data.Get<int>("id"),
                FirstName = data.Get<string>("first_name"),
                LastName = data.Get<string>("last_name"),
                UserName = data.Get<string>("username")
            };
        }
    }
}