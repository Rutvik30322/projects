/// <summary>
/// System global variable / Constatnt / Enum
/// </summary>
namespace NConstant
{
    public class Constant
    {
        public enum GroupType : short
        {
            Event = 1,
            List = 2,
            Audit = 3,
        }

        public enum TypeOfCommunication
        {
            NONE = 0,
            Serial = 1,
            TCP = 2,
        }

        public enum ServiceConfig : short
        {
            BCUSequence = 13,
            CardReader = 12,
            BayQueueDisplay = 3,
            GateSequence = 4,
            SAPTAS = 5,
            DayEndSequence = 6,
            GSM = 7,
            WhatsApp = 8,
            EmailSequence = 2,
            NotificationSequence = 1
        }

        // GENERAL SETTINGS
        public enum GeneralSettingParamName : int
        {
            ProjectCustomer = 1,
            SiteName = 2,
            PrjCustAddress = 3,
            PrjState = 4
        }

        public enum YesNo : int
        {
            YES = 1,
            NO = 0
        }

        public enum QueryDataIndex : int
        {
            None = 0,
            Designation = 1,
        }

        public enum EmailTemplete : int
        {
            None = 0,
            PostJob1 = 1,
            //PostJob2 = 1,
            ApplyJob = 2,
            ShortListed1 = 3,
            //ShortListed2 = 3,
        }

        public enum ListId : int
        {
            Status = 1,
            DiscountType = 2,
            PaymentMode = 3,
            ReportType = 4,
            ReportCategory = 5,
            UOMType = 6,
            PaymentStatus = 7
        }
    }
}
