﻿using TeleBotDotNet.Http;
using TeleBotDotNet.Requests.Methods.Bases;
using TeleBotDotNet.Requests.Types;

namespace TeleBotDotNet.Requests.Methods
{
    public class SendPhotoRequest : BaseMethodRequest
    {
        public int ChatId { get; set; }
        public InputFileRequest Photo { get; set; }
        public string Caption { get; set; }
        public int ReplyToMessageId { get; set; }
        public ReplyMarkupRequest ReplyMarkup { get; set; }

        internal override string MethodName
        {
            get { return "sendPhoto"; }
        }

        internal override HttpData Parse()
        {
            var httpData = new HttpData
            {
                Parameters = new HttpParameterList
                {
                    {"chat_id", ChatId},
                    {"caption", Caption},
                    {"reply_to_message_id", ReplyToMessageId}
                }
            };

            if (Photo != null)
            {
                Photo.Parse(httpData, "photo");
            }
            if (ReplyMarkup != null)
            {
                ReplyMarkup.Parse(httpData, "reply_markup");
            }

            return httpData;
        }
    }
}