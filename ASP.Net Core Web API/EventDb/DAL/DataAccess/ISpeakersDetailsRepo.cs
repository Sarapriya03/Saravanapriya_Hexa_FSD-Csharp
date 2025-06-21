using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public interface ISpeakersDetailsRepo<T>
    {
        T GetSpeakerById(int speakerId);
        T UpdateSpeaker(T speakersDetails);
        T AddSpeaker(T speakersDetails);
        T DeleteSpeaker(int speakerId);
        List<T> GetAllSpeakers();
    }
}
