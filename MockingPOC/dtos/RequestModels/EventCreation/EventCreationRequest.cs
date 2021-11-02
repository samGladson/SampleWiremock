using System;

namespace MockingPOC.dtos.RequestModels.EventCreation
{
    public class EventCreationRequest
    {
        public string eventId { get; set; }
        public string eventGbsCode { get; set; }
        public string businessUnitId { get; set; }
        public Boolean supportedInPlatform { get; set; }
        public multilingual multilingual { get; set; }
        public Boolean gbsEnabled { get; set; }
        public Boolean isECommerceEnabled { get; set; }
        public Boolean isParticipationEvent { get; set; }
        public Boolean isGbsRegistrationEnabled { get; set; }
        public Boolean isGbsSalesEnabled { get; set; }
        public Boolean isAnonymousRegistrationEnabled { get; set; }
    }
}