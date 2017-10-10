using System.Collections.Generic;

namespace AutomapperEnumerableOfConcreteTypes
{
    public class FamilyEntity
    {
        public IEnumerable<FamilyMemberEntity> FamilyMembers { get; set; }
    }

    public class FamilyMemberEntity
    {
        public string Name { get; set; }
    }

    public class FatherEntity : FamilyMemberEntity
    {
        public string PreferedBeer { get; set; }
    }

    public class MotherEntity : FamilyMemberEntity
    {
        public string PreferedSoap { get; set; }
    }

    public class ChildEntity : FamilyMemberEntity
    {
        public string PreferedToy { get; set; }
    }
}