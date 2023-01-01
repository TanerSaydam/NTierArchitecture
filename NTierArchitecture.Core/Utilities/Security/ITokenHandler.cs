using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Core.Utilities.Security
{
    public interface ITokenHandler
    {
        string CreateToken();
    }
}
