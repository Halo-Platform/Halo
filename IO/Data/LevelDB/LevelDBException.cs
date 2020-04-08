using System.Data.Common;

namespace Halo.IO.Data.LevelDB
{
    public class LevelDBException : DbException
    {
        internal LevelDBException(string message)
            : base(message)
        {
        }
    }
}
