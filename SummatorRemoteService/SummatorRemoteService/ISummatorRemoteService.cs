using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummatorRemoteService
{
    public interface ISummatorRemoteService
    {
        int GetSum(int x, int y);
    }
}
