using System;

namespace Remote
{
    public interface SharedTypeInterface
    {
        string GetRemoteStatus(string stringToPrint);
    }

    public class SharedType : MarshalByRefObject, SharedTypeInterface
    {
        public string GetRemoteStatus(string stringToPrint)
        {
            string returnStatus = "Ticket Confirmed";
            Console.WriteLine("Enquiry for {0}", stringToPrint);
            Console.WriteLine("Sending back status: {0}", returnStatus);

            return returnStatus;
        }
    }
}
