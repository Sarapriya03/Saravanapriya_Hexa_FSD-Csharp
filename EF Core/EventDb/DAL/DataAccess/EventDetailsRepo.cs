using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DataAccess
{
    public class EventDetailsRepo : IEventDetailsRepo<EventDetails>
    {
        public List<EventDetails> GetEventsByCategory(string category)
        {
            using (var dbContext = new EventDbContext())
            {
                return dbContext.Events.Where(event => event.EventCategory.Equals(category)).ToList();
            }
        }

        public EventDetails UpdateEvent(EventDetails eventDetails)
        {
            using (var dbContext = new EventDbContext())
            {
                var existingEvent = dbContext.EventDetails.Where(e => e.EventId == eventDetails.EventId).FirstOrDefault();
                if (existingEvent != null)
                {
                    existingEvent.EventName = eventDetails.EventName;
                    existingEvent.EventCategory = eventDetails.EventCategory;
                    existingEvent.EventDate = eventDetails.EventDate;
                    existingEvent.Description = eventDetails.Description;
                    existingEvent.Status = eventDetails.Status;
                    dbContext.SaveChanges();
                    return existingEvent;
                }
                return null;
            }
        }

        public EventDetails AddEvent(EventDetails eventDetails)
        {
            using (var dbContext = new EventDbContext())
            {
                dbContext.Events.Add(eventDetails);
                dbContext.SaveChanges();
                return eventDetails;
            }
        }

        public EventDetails DeleteEvent(int eventName)
        {
            using (var dbContext = new EventDbContext())
            {
                var existingEvent = dbContext.Events.Where(e => e.EventName.Equals(eventName)).FirstOrDefault();
                if (existingEvent != null)
                {
                    dbContext.Events.Remove(existingEvent);
                    dbContext.SaveChanges();
                    return existingEvent;
                }
                return null;
            }
        }

        public List<EventDetails> GetAllEvents()
        {
            using (var dbContext = new EventDbContext())
            {
                return dbContext.Events.ToList();
            }
        }
    }
}