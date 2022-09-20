using System;
using System.Collections.Generic;
using System.Text;

namespace SylerBackend.Domain.ResponseModel
{
    public class MultiLevelResponseModel
    {
        public int id { get; set; }

        public string name { get; set; }

        public string fk_id { get; set; }

        public string type_level_id { get; set; }

        public List<MultiLevelResponseModel> childrens { get; set; }

        public MultiLevelResponseModel()
        {
            this.childrens = new List<MultiLevelResponseModel>();
        }
    }

    
}
