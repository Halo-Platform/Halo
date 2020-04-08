using Halo.SmartContract.Enumerators;
using Neo.VM;

namespace Halo.SmartContract.Iterators
{
    internal interface IIterator : IEnumerator
    {
        StackItem Key();
    }
}
