using System;

namespace API_Users.Models
{
    public class Keep
    {
        public string Id {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public string userId {get; set;}
        public bool Public {get; set;} 
        public int Views {get; set;}
        public int Shares {get; set;}
        public int Saves {get; set;}
    }
}