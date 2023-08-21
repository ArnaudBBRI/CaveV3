using System.Collections.Generic;

namespace Buildwise.Core
{
    public abstract class UnitySerializedList<T> : List<T>
    {
        public List<T> nestedList = new List<T>();
    }
}