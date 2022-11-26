using Snag_That_Table.Models.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snag_That_Table.Services.MessageServices
{
    public interface IMessageServices
    {
        bool CreateMessages(MessagesCreate model);
        IEnumerable<MessagesListItem> GetMessagesForUser();
        IEnumerable<MessagesListItem> GetMessagesForRestaurantUser();
        bool DeleteMessage(int messagesId, Guid userId);
        void SetUserId(Guid userId);

    }
}
