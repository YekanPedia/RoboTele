namespace YekanPedia.ManagementSystem.Domain.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("User")]
    public  class User
    {
        public Guid UserId { get; set; }

        [StringLength(10)]
        public string BirthDate { get; set; }

        [StringLength(3)]
        public string Sex { get; set; }

        [Required]
        [StringLength(15)]
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public DateTime RegisterDate { get; set; }

        public DateTime LastLoginDate { get; set; }

        [Required]
        [StringLength(11)]
        public string Mobile { get; set; }

        [StringLength(20)]
        public string Latitude { get; set; }

        [StringLength(20)]
        public string Longitude { get; set; }

        [StringLength(90)]
        public string Twitter { get; set; }

        [StringLength(90)]
        public string Facebook { get; set; }

        public int Telegram { get; set; }

        [StringLength(200)]
        public string AboutMe { get; set; }

        public bool IsTeacher { get; set; }

        [Required]
        [StringLength(45)]
        public string FullName { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(150)]
        public string Picture { get; set; }

        public bool IsResetPassword { get; set; }
    }
}
