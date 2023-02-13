using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOs.AppUserDTOs
{
    public class AppUserRegisterDTO
    {
            public string NameSurname { get; set; }
            public string UserName { get; set; }
            public string Mail { get; set; }
            public string Password { get; set; }
            public string ComfirmPassword { get; set; }
    }
}
