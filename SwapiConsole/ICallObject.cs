using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapiConsole
{
    internal interface ICallObject<TObject>
    {
        List<TObject> Get();
    }
}
