using BiGitServer.Data.Models;
using NHibernate.Mapping.ByCode.Conformist;
using FluentNHibernate.Mapping;

namespace BiGitServer.Data.Mapping
{
    public class ProjectMap:ClassMap<Project>
    {
        public ProjectMap()
        {
            Table("Project");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Not.Nullable().Length(255);
            Map(x => x.Description).Nullable().Length(255);
        }
    }
}
