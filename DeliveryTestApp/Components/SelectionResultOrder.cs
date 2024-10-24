using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTestApp.Components
{
    [Table("SelectionResultOrder")]
    public class SelectionResultOrder
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int SelectionResultId { get; set; }
        public virtual Order Order { get; set; }
        public virtual SelectionResult SelectionResult { get; set; }
    }
}
