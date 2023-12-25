using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ShitChat
{
    public class MessageManager
    {
        public User currentUser;
        public static string path = "Conversation";

        public void SetUser(User user)
        {
            this.currentUser = user;
        }


        public void CreateNewMessage(string message, User writer, User reciever)
        {
            writer.conversations.Add(new Conversation(reciever));
            reciever.conversations.Add(new Conversation(writer));
            Message newMessage = new Message(message, writer.UserName.ToString(), reciever.UserName.ToString());
        }



        public void ReplyToConversation(string message, User writer, User reciever)
        {
            Message newMessage = new Message(message, writer.UserName.ToString(), reciever.UserName.ToString());
            foreach (Conversation con in writer.conversations)
            {
                if (con.Friend.UserName == reciever.UserName.ToString())
                {
                    con.messages.Add(newMessage);
                }
                else
                {
                    CreateNewMessage(message, writer, reciever);
                }
            }
        }


        public void ExportToJson(string fileName, string location)
        {
            string file = System.IO.Path.Combine(location, fileName);
            try
            {
                System.IO.File.Create(file).Close();
                using (StreamWriter sw = new StreamWriter(file))
                {
                    foreach (Conversation conversation in currentUser.conversations)
                    {
                        sw.WriteLine(conversation.GetJson());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
