using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Prueba.Model
{
    [DataContract]
    public class UsuarioModel
    {

        [DataMember(Name = "login")]
        private string login;
        public string Login
        {
            get
            {
                return this.login;
            }
            set
            {
                this.login = value;
            }
        }
        [DataMember(Name = "id")]
        private string id;
        public string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        [DataMember(Name = "avatar_url")]
        private string avatarurl;
        public string AvatarUrl
        {
            get
            {
                return this.avatarurl;
            }
            set
            {
                this.avatarurl = value;
            }
        }

        [DataMember(Name = "name")]
        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        [DataMember(Name = "company")]
        private string company;
        public string Company
        {
            get
            {
                return this.company;
            }
            set
            {
                this.company = value;
            }
        }

        [DataMember(Name = "location")]
        private string location;
        public string Location
        {
            get
            {
                return this.location;
            }
            set
            {
                this.location = value;
            }
        }


        [DataMember(Name = "email")]
        private string email;
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }
        //metodo si se nesecita insertar en un lisView
        public override string ToString()
        {
            return string.Format("[UsuarioModel: Login={0}, Id={1}, AvatarUrl={2}, Name={3}, Company={4}, Location={5}, Email={6}]", 
                                Login, Id, AvatarUrl, Name,Company,Location,Email);
        }

    }
}
