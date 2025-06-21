using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DataAccess
{
    public class SpeakersDetailsRepo : ISpeakersDetailsRepo<SpeakersDetails>
    {
        public SpeakersDetails GetSpeakerById(int id)
        {
            using (var dbContext = new EventDbContext())
            {
                return dbContext.SpeakersDetails.FirstOrDefault(s => s.SpeakerId == id);
            }
        }


        public SpeakersDetails UpdateSpeaker(SpeakersDetails speakersDetails)
        {
            using (var dbContext = new EventDbContext())
            {
                var rowsAffected = dbContext.Database.ExecuteSqlRaw(
                    "EXEC sp_UpdateSpeaker @SpeakerId = {0}, @SpeakerName = {1}",
                    speakersDetails.SpeakerId,
                    speakersDetails.SpeakerName
                );

                return rowsAffected > 0 ? speakersDetails : null;
            }
        }

        public SpeakersDetails AddSpeaker(SpeakersDetails speakersDetails)
        {
            using (var dbContext = new EventDbContext())
            {
                var rowsAffected = dbContext.Database.ExecuteSqlRaw(
                    "EXEC sp_InsertSpeaker @SpeakerName = {0}",
                    speakersDetails.SpeakerName
                );

                return rowsAffected > 0 ? speakersDetails : null;
            }
        }

        public SpeakersDetails DeleteSpeaker(int speakerId)
        {
            using (var dbContext = new EventDbContext())
            {
                var rowsAffected = dbContext.Database.ExecuteSqlRaw(
                    "EXEC sp_DeleteSpeaker @SpeakerId = {0}",
                    speakerId
                );

                return rowsAffected > 0 ? new SpeakersDetails { SpeakerId = speakerId } : null;
            }
        }

        public List<SpeakersDetails> GetAllSpeakers()
        {
            using (var dbContext = new EventDbContext())
            {
                return dbContext.SpeakersDetails.ToList();
            }
        }
    }
}
