using System;

namespace NavTech.Configuration.DataAccess.Models
{
    public class EntityConfiguration
    {
        public int EntityConfigurationID { get; set; }
        public string EntityName { get; set; }
        public string FieldName { get; set; }
        public bool IsRequired { get; set; }
        public string FieldSource { get; set; }
        public int MaxLength { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime ModifiedTime { get; set; }
    }
}
