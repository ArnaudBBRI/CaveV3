using UnityEngine;

namespace Buildwise.BIM
{
    /// <summary>
    /// Interface for parsing BIM objects.
    /// Parsing means reading the BIM data from a GameObject, mapping it onto the internal BIM data structure, 
    /// and assigning it to each BIM Object in scene that needs to be considered as such.
    /// </summary>
    public interface IBIMModelParser
    {
        /// <summary>
        /// Parses the whole BIM model so that it is compatible within the 'Buildwise BIM' way of work.
        /// </summary>
        /// <param name="root">The root GameObject. All children of this objects will be parsed.</param>
        void ParseBIMModel(GameObject root);

        /// <summary>
        /// Parse a (supposedly) BIM GameObject by reading its raw information, mapping it onto the internal BIM data structure, 
        /// and assigning it to the BIMObject component.
        /// </summary>
        /// <param name="go">The GameObject to parse</param>
        /// <param name="usingMazeFlystick">Specifies wether or not the VRMaze flystick event listener is to be used or not</param>
        void Parse(GameObject go, bool usingMazeFlystick);
    }

}
