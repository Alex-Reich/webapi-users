using System;

namespace API_Users.Models
{
    public class Vault
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
    }
    public class VaultKeep
    {
        public int Id { get; set; }
        public int VaultId { get; set; }
        public int KeepId { get; set; }
        public string UserId { get; set; }
    }
}