using System.Collections.Generic;
using System.Xml.Serialization;

namespace TaskConfigurator.Entity
{
    public class ColumnAttributes
    {
        public string AttributeName { get; set; }
        public string ColumnType { get; set; }
    }

    [XmlRoot("Columns")]
    public class Columns
    {
        [XmlElement("InformationSchemaColumns")]
        public List<InformationSchemaColumns> Items { get; set; }

    }

    public class InformationSchemaColumns
    {
        [XmlElement("TABLE_CATALOG")]
        public string TABLE_CATALOG { get; set; }
        [XmlElement("TABLE_SCHEMA")]
        public string TABLE_SCHEMA { get; set; }
        [XmlElement("TABLE_NAME")]
        public string TABLE_NAME { get; set; }
        [XmlElement("COLUMN_NAME")]
        public string COLUMN_NAME { get; set; }
        [XmlElement("ORDINAL_POSITION")]
        public int ORDINAL_POSITION { get; set; }
        [XmlElement("COLUMN_DEFAULT")]
        public string COLUMN_DEFAULT { get; set; }
        [XmlElement("IS_NULLABLE")]
        public string IS_NULLABLE { get; set; }
        [XmlElement("DATA_TYPE")]
        public string DATA_TYPE { get; set; }
        [XmlElement("CHARACTER_MAXIMUM_LENGTH")]
        public string CHARACTER_MAXIMUM_LENGTH { get; set; }
        [XmlElement("CHARACTER_OCTET_LENGTH")]
        public string CHARACTER_OCTET_LENGTH { get; set; }
        [XmlElement("NUMERIC_PRECISION")]
        public string NUMERIC_PRECISION { get; set; }
        [XmlElement("NUMERIC_PRECISION_RADIX")]
        public string NUMERIC_PRECISION_RADIX { get; set; }
        [XmlElement("NUMERIC_SCALE")]
        public string NUMERIC_SCALE { get; set; }
        [XmlElement("DATETIME_PRECISION")]
        public string DATETIME_PRECISION { get; set; }
        [XmlElement("CHARACTER_SET_CATALOG")]
        public string CHARACTER_SET_CATALOG { get; set; }
        [XmlElement("CHARACTER_SET_SCHEMA")]
        public string CHARACTER_SET_SCHEMA { get; set; }
        [XmlElement("CHARACTER_SET_NAME")]
        public string CHARACTER_SET_NAME { get; set; }
        [XmlElement("COLLATION_CATALOG")]
        public string COLLATION_CATALOG { get; set; }
    }
}
