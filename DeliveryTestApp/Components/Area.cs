using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTestApp.Components
{
    [Table("Area")]
    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<SelectionResult> SelectionResult { get; set; }

        public DateTime FirstDeliveryTime
        {
            get
            {
                return Order.OrderBy(x => x.DeliveryDateTime).FirstOrDefault().DeliveryDateTime;
            }
        }
    }
}
