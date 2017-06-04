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
            Map(x => x.Name).Not.Nullable().Length(255);
            Map(t => t.Surname).Not.Nullable().Length(255);
            Map(t => t.Password).Not.Nullable().Length(255);
            Map(t => t.Email).Not.Nullable().Length(255);
            Map(t => t.Role).Nullable().Length(100);
        }
    
    }
}
