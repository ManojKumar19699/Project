using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AgriFarmProj.Models.ViewModel
{
    [DataContract]
    public class Email
    {
        [DataMember]
        public string To { get; set; }
        [DataMember]
        public string From { get; set; }
        [DataMember]
        public string Subject { get; set; }
        [DataMember]
        public string Body { get; set; }
    }
}