using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace VideoServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerSession)]
    public class VideoConferenceService : IVideoConferenceService
    {
        private ReaderWriterLockSlim subscribersLock = new ReaderWriterLockSlim();
        private static List<IVideoConferenceServiceCallback> subscribers = new List<IVideoConferenceServiceCallback>();

        public void Subscribe()
        {
            try
            {
                subscribersLock.EnterWriteLock();
                subscribers.Add(OperationContext.Current.GetCallbackChannel<IVideoConferenceServiceCallback>());
            }
            finally
            {
                subscribersLock.ExitWriteLock();
            }
        }
        public string PublishText(string data)
        {
            try
            {
                subscribersLock.EnterReadLock();
                foreach (var subscriber in subscribers)
                {
                    subscriber.OnTextSend(data);
                }
            }
            finally
            {
                subscribersLock.ExitReadLock();
            }
            return "Passed" + data;
        }
        public void PublishVideo(byte[] data)
        {
            try
            {
                subscribersLock.EnterReadLock();
                foreach (var subscriber in subscribers)
                {
                    subscriber.OnVideoSend(data);
                }
            }
            finally
            {
                subscribersLock.ExitReadLock();
            }
        }

        public void PublishVoice(byte[] data)
        {
            try
            {
                subscribersLock.EnterReadLock();
                foreach (var subscriber in subscribers)
                {
                    subscriber.OnVoiceSend(data);
                }
            }
            finally
            {
                subscribersLock.ExitReadLock();
            }
        }
    }
}
