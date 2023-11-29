﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShitChat
{
    public class Message
    {
        public string MessageString { get; set; }
        public User Writer {  get; set; }
        public User Reciever { get; set; }


        public Message(string messageString, User writer, User reciever)
        {
            this.MessageString = messageString;
            this.Writer = writer;   
            this.Reciever = reciever;
        }
    }
}
