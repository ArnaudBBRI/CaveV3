using UnityEngine;

namespace Buildwise.BIM
{
    /// <summary>
    /// Interface for parsing BIM objects.
    /// Parsing means reading the BIM data from a GameObject, mapping it onto the internal BIM data structure, 
    /// and assigning it to each BIM Object in scene that needs to be considered as such.
    /// </summary>
    public interface IBIMObjectParser
    {
        /// <summary>
        /// Parse a (supposedly) BIM GameObject by reading its raw information, mapping it onto the internal BIM data structure, 
        /// and assigning it to the BIMObject component.
        /// </summary>
        /// <param name="go">The GameObject to parse</param>
        void Parse(GameObject go);
    }

}
