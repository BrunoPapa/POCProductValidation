using System.Collections.Generic;

namespace ProductValidation.IoC.Commom
{
    public class ActivityCode
    {
        public string id { get; set; }
    }

    public class AgreementLine
    {
        public string id { get; set; }
        public string label { get; set; }
        public string version { get; set; }
        public string parentId { get; set; }
        public List<Field> fields { get; set; }
    }

    public class Data
    {
        public string id { get; set; }
        public int version { get; set; }
        public string name { get; set; }
        public string shortDescription { get; set; }
        public string detailedDescription { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string channel { get; set; }
        public string brand { get; set; }
        public string coreProductId { get; set; }
        public int coreProductVersion { get; set; }
        public string configVersionId { get; set; }
        public string coreProductName { get; set; }
        public Extensions extensions { get; set; }
        public List<Field> fields { get; set; }
        public List<AgreementLine> agreementLines { get; set; }
        public List<Object> objects { get; set; }
        public List<Risk> risks { get; set; }
    }

    public class EntityInfo
    {
        public string id { get; set; }
        public string version { get; set; }
        public string parentId { get; set; }
        public string label { get; set; }
        public List<Field> fields { get; set; }
    }

    public class Extensions
    {
        public List<KilingQuestion> kilingQuestions { get; set; }
        public List<ActivityCode> activityCode { get; set; }
        public string turnoverMin { get; set; }
        public string turnoverMax { get; set; }
        public string additionalDetailsUri { get; set; }
        public bool isMarketable { get; set; }
        public string productFamily { get; set; }
    }

    public class Field
    {
        public string value { get; set; }
        public string key { get; set; }
        public Metadata metadata { get; set; }
    }

    public class KilingQuestion
    {
        public string questionText { get; set; }
        public string questionNumber { get; set; }
    }

    public class Lov
    {
        public string lovId { get; set; }
        public List<LovOption> lovOptions { get; set; }
    }

    public class LovOption
    {
        public string value { get; set; }
        public string key { get; set; }
    }

    public class Metadata
    {
        public string defaultValue { get; set; }
        public string itemName { get; set; }
        public string dataType { get; set; }
        public string label { get; set; }
        public bool isEditable { get; set; }
        public bool isMandatory { get; set; }
        public Lov lov { get; set; }
        public string id { get; set; }
    }

    public class Object
    {
        public string id { get; set; }
        public string version { get; set; }
        public string parentId { get; set; }
        public string label { get; set; }
        public List<Field> fields { get; set; }
    }

    public class Risk
    {
        public string riskNumber { get; set; }
        public string riskGroupNumber { get; set; }
        public string riskType { get; set; }
        public string sortNumber { get; set; }
        public bool isVisible { get; set; }
        public bool isPreselected { get; set; }
        public EntityInfo entityInfo { get; set; }
    }

    public class Root
    {
        public Data data { get; set; }
    }
}
