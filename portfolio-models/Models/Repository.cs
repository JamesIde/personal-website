using System.Collections.Generic;

namespace portfolio_models.Models
{
    public class Repository
    {
        public User User { get; set; }
    }
    public class User
    {
        public PinnedItems PinnedItems { get; set; }
    }
    public class PinnedItems
    {
        public Nodes[] Nodes { get; set; }
    }
    public class Nodes
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public DateTime CreatedAt { get; set; }
        public PrimaryLanguage PrimaryLanguage { get; set; }
    }
    public class PrimaryLanguage
    {
        public string name { get; set; }
    }
    
}
