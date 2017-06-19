namespace TaskConfigurator.Entity
{
    public class EnumAttributes
    {
        public enum TableName
        {
            tbl_task_configuration_desc,
            tbl_task_configuration_data,
            tbl_task_configuration_data_dropdown,
            tbl_task_configuration_cntrl,
            tbl_action_status_mapping_AIB,
            tbl_task_configuration_main,
            tbl_ukbs_Pcodes,
            tbl_AttributeNames,
            tbl_AttributeValues,
            tbl_aib_task_order_attribute_mapping
        }

        public enum MethodType
        {
            INSERT,
            UPDATE,
            DELETE,
            ROLLBACK,
            PATCH   
        }
    }
}
