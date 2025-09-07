using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.GrantSupport {
    public class GrantSupportDto : FixDto {
        public Guid GrantSupportCategoryId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? Image { get; set; }
    }
}
