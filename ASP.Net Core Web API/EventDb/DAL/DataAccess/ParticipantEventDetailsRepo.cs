using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DataAccess
{
    public class ParticipantEventDetailsRepo : IParticipantEventDetailsRepo<ParticipantEventDetails>
    {
        public ParticipantEventDetails GetParticipantEventDetailsById(int id)
        {
            using (var dbContext = new EventDbContext())
            {
                return dbContext.ParticipantEventDetails.FirstOrDefault(p => p.ParticipantId == id);
            }
        }

        public ParticipantEventDetails AddParticipantEventDetails(ParticipantEventDetails participantEventDetails)
        {
            using (var dbContext = new EventDbContext())
            {
                var rowsAffected = dbContext.Database.ExecuteSqlRaw(
                    "EXEC sp_InsertParticipantEvent @ParticipantEmailId = {0}, @EventId = {1}, @isAttended = {2}",
                    participantEventDetails.ParticipantEmailId,
                    participantEventDetails.EventId,
                    participantEventDetails.isAttended
                );

                return rowsAffected > 0 ? participantEventDetails : null;
            }
        }

        public ParticipantEventDetails UpdateParticipantEventDetails(ParticipantEventDetails participantEventDetails)
        {
            using (var dbContext = new EventDbContext())
            {
                var rowsAffected = dbContext.Database.ExecuteSqlRaw(
                    "EXEC sp_UpdateParticipantEvent @Id = {0}, @ParticipantEmailId = {1}, @EventId = {2}, @isAttended = {3}",
                    participantEventDetails.ParticipantId,
                    participantEventDetails.ParticipantEmailId,
                    participantEventDetails.EventId,
                    participantEventDetails.isAttended
                );

                return rowsAffected > 0 ? participantEventDetails : null;
            }
        }

        public ParticipantEventDetails DeleteParticipantEventDetails(int id)
        {
            using (var dbContext = new EventDbContext())
            {
                var rowsAffected = dbContext.Database.ExecuteSqlRaw(
                    "EXEC sp_DeleteParticipantEvent @Id = {0}",
                    id
                );

                return rowsAffected > 0 ? new ParticipantEventDetails { ParticipantId = id } : null;
            }
        }

        public List<ParticipantEventDetails> GetAllParticipantEventDetails()
        {
            using (var dbContext = new EventDbContext())
            {
                return dbContext.ParticipantEventDetails.ToList();
            }
        }
    }
}
