using System.ComponentModel.DataAnnotations.Schema;
using NHibernate.Mapping.ByCode;
using BiGitServer.Data.Models;
using NHibernate.Mapping.ByCode.Conformist;
using FluentNHibernate.Mapping;

namespace BiGitServer.Data.Mapping
{
    public class UserMap: ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Table("User");
            Map(x => x.Name);
            Map(t => t.Surname);
            Map(t => t.Username);
            Map(t => t.Password);
           
            Map(t => t.Email);
        }
        //public UserMap()
        //{
        //    ToTable("User");
        //    HasKey(t => t.Id);
        //    Property(t => t.Id).HasColumnName("Id");
        //    Property(t => t.Name).HasColumnName("Name");
        //    Property(t => t.Surname).HasColumnName("Surname");
        //    Property(t => t.Username).HasColumnName("Username");
        //    Property(t => t.Password).HasColumnName("Password");
        //    Property(t => t.PasswordSalt).HasColumnName("PasswordSalt");
        //    Property(t => t.Email).HasColumnName("Email");

        //    SetProperties();
        //}
        //private void SetProperties()
        //{
        //    Property(t => t.Name)
        //        .IsRequired()
        //        .HasMaxLength(255);

        //    Property(t => t.Surname)
        //        .IsRequired()
        //        .HasMaxLength(255);

        //    Property(t => t.Username)
        //        .IsRequired()
        //        .HasMaxLength(255);

        //    Property(t => t.Password)
        //        .IsRequired()
        //        .HasMaxLength(255);

        //    Property(t => t.Email)
        //        .IsRequired()
        //        .HasMaxLength(255);
        //}
    }
}
