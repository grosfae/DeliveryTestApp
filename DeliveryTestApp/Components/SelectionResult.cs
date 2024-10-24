using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTestApp.Components
{
    [Table("SelectionResult")]
    public class SelectionResult
    {
        public int Id { get; set; }
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeEnd { get; set; }
        public int AreaId { get; set; }
        public virtual Area Area { get; set; }
        public virtual ICollection<SelectionResultOrder> SelectionResultOrder { get; set; }
    }
}
