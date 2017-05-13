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
    
    }
}
