using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTestApp.Components
{
    [Table("DeliveryLog")]
    public class DeliveryLog
    {
        public int Id { get; set; }
        public string LogDateTime { get; set; }
        public string Description { get; set; }
    }
}
