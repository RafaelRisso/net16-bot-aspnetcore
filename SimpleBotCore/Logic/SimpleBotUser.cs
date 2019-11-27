using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBotCore.Logic
{
    public class SimpleBotUser
    {
        static MongoClient cliente;
        static IMongoDatabase db;
        static IMongoCollection<BsonDocument> col;

        public SimpleBotUser()
        {
            cliente = new MongoClient("mongodb://localhost:27017");
            db = cliente.GetDatabase("net16");
            col = db.GetCollection<BsonDocument>("col02");
        }

        public string Reply(SimpleMessage message)
        {
            Insere(message.User, message.Text);

            return $"{message.User} disse '{message.Text}'";

        }

        public void Insere(String User, String text)
        {

            var doc = new BsonDocument()
            {
                {"nome",User },
                {"text", text }

            };
            col.InsertOne(doc);
        }

        public string RetornoMensagem()
        {
            return "";
        }
    }
}