using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.DTO.User {
    public class DtoUserToken {
        public string? Email { get; set; }
        public IEnumerable<string>? Roles { get; set; }
        public string? Token { get; set; }
    }
}
