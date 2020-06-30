using RECODME.RD.Jade.Data.UserInfo;
using System;

namespace WebApi.Models.UserModelViews
{
    public class ClientViewModel
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public Guid RestaurantId { get; set; }
        public DateTime RegisterDate { get; set; }

        public ClientRecord ToClient()
        {
            return new ClientRecord(Id, DateTime.UtcNow, DateTime.UtcNow, false, RegisterDate, PersonId, RestaurantId);
        }

        public static ClientViewModel Parse(ClientRecord Client)
        {
            return new ClientViewModel()
            {
                Id = Client.Id,
                PersonId = Client.PersonId,
                RestaurantId = Client.RestaurantId,
                RegisterDate = Client.RegisterDate,

            };

        }

    }

}
