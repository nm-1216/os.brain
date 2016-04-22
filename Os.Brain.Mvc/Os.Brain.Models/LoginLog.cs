namespace Os.Brain.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class LoginLog<TKey> where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }

        public TKey UserId { get; set; }

        public DateTime AddTime { get; set; }

        [MaxLength(64)]
        public string IP { get; set; }

        public string Description { get; set; }
    }
}
