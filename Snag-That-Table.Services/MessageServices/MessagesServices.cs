using Microsoft.AspNetCore.Identity;
using Snag_That_Table.Data;
using Snag_That_Table.Models.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Snag_That_Table.Services.MessageServices
{
    public class MessagesServices : IMessageServices
    {
        private Guid _userId;
        private readonly ApplicationDbContext _context;

        public MessagesServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SetUserId(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateMessages(MessagesCreate model)
        { 
                var contactEntity = new Contact()
                {
                    RestaurantId = model.RestaurantId,
                    Content = model.Content,
                    DateSent = DateTime.Now,
                };
                _context.Contacts.Add(contactEntity);
                return _context.SaveChanges() == 1;
            

        }

        public IEnumerable<MessagesListItem> GetMessagesForUser()
        {
                var query =
                    _context
                        .Contacts
                        .Where(m => m.UserId == _userId)
                        .Select(
                            m =>
                                new MessagesListItem
                                {
                                    Content = m.Content,
                                    DateSent = m.DateSent,
                                }
                        );

                return query.ToList();
        }
        public IEnumerable<MessagesListItem> GetMessagesForRestaurantUser()
        {
                var query =
                    _context
                        .Contacts
                        .Where(m => m.RestaurantId == _userId)
                        .Select(
                            m =>
                                new MessagesListItem
                                {
                                    Content = m.Content,
                                    DateSent = m.DateSent,
                                }
                        );

                return query.ToList();
        }

        public bool DeleteMessage(int messagesId, Guid userId)
        {
                var entity =
                    _context
                    .Contacts
                    .Single(m => m.MessagesId == messagesId && m.UserId == _userId);
                _context.Contacts.Remove(entity);

                return _context.SaveChanges() == 1;
        }


    }
}
