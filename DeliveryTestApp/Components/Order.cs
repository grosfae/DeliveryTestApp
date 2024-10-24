using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTestApp.Components
{
    [Table("Order")]
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double OrderWeight { get; set; }
        public DateTime DeliveryDateTime { get; set; }
        public int AreaId { get; set; }
        public virtual Area Area { get; set; }
        public virtual ICollection<SelectionResultOrder> SelectionResultOrder { get; set; }
    }
}
