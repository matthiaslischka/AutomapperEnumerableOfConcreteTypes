using System.Collections.Generic;

namespace AutomapperEnumerableOfConcreteTypes
{
    public class FamilyModel
    {
        public IEnumerable<FamilyMemberModel> FamilyMembers { get; set; }
    }

    public class FamilyMemberModel
    {
        public string Name { get; set; }
    }

    public class FatherModel : FamilyMemberModel
    {
        public string PreferedBeer { get; set; }
    }

    public class MotherModel : FamilyMemberModel
    {
        public string PreferedSoap { get; set; }
    }

    public class ChildModel : FamilyMemberModel
    {
        public string PreferedToy { get; set; }
    }
}