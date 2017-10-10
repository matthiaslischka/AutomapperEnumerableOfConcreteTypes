using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using Xunit;

namespace AutomapperEnumerableOfConcreteTypes
{
    public class EnumerableMappingTests
    {
        [Fact]
        public void MapEnumerable_FromBaseClass_ToConcreteClasses()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<FamilyEntity, FamilyModel>();

                cfg.CreateMap<FamilyMemberEntity, FamilyMemberModel>()
                    .Include<FatherEntity, FatherModel>()
                    .Include<MotherEntity, MotherModel>()
                    .Include<ChildEntity, ChildModel>();

                cfg.CreateMap<FatherEntity, FatherModel>();
                cfg.CreateMap<MotherEntity, MotherModel>();
                cfg.CreateMap<ChildEntity, ChildModel>();
            });

            var familyEntity = new FamilyEntity();

            familyEntity.FamilyMembers = new List<FamilyMemberEntity>
            {
                new FatherEntity {Name = "Peter", PreferedBeer = "Stiegel"},
                new MotherEntity {Name = "Johanna", PreferedSoap = "Desperate Housewives"},
                new ChildEntity {Name = "Susi", PreferedToy = "Power Ranger"},
                new ChildEntity {Name = "Tommy", PreferedToy = "Spongebob"}
            };

            var familyModel = Mapper.Map<FamilyModel>(familyEntity);

            familyModel.FamilyMembers.OfType<FatherModel>().Should().HaveCount(1);
            familyModel.FamilyMembers.OfType<MotherModel>().Should().HaveCount(1);
            familyModel.FamilyMembers.OfType<ChildModel>().Should().HaveCount(2);
        }
    }
}