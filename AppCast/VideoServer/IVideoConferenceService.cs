using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace VideoServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IVideoConferenceServiceCallback), SessionMode = SessionMode.Allowed)]
    public interface IVideoConferenceService
    {
        [OperationContract]
        void Subscribe();

        [OperationContract]
        void PublishVideo(byte[] data);

        [OperationContract]
        void PublishVoice(byte[] data);

        [OperationContract]
        string PublishText(string data);
        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "VideoServer.ContractType".
    public interface IVideoConferenceServiceCallback
    {
        [OperationContract]
        void OnVideoSend(byte[] data);

        [OperationContract]
        void OnVoiceSend(byte[] data);

        [OperationContract]
        void OnTextSend(string data);

    }
}
