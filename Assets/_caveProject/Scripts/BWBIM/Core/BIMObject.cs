using UnityEngine;

namespace Buildwise.BIM
{
    [DisallowMultipleComponent]
    public class BIMObject : MonoBehaviour, IBIMObject
    {
        public BIMCategory Category { get; set; }
        public BIMFamily Family { get ; set ; }

        /// SRP: Single Responsibility Principle
        /// What is the responsibility of this class? What would be the single reason to modify this class?
        /// The responsibility of this class is to represent a BIM object and hold its properties/state.
        /// Does it mean we should have a class dedicated to performing modifications on a BIMObject?
        /// We could also say this class is responsible for doing that too (except maybe if the class becomes too large?).
        /// OCP: Open for extension, closed for modification.
        /// How do we ensure this here, for example?
        /// We don't want to have to modify this class every time we consider a new type of BIM object. And we don't want to change everywhere else in the code where we use this class.
        /// We could have a BIMObject interface, and then have a BIMWall, BIMDoor, BIMWindow, etc. classes that implement the interface.
        /// ISP: Interface Segregation Principle
        /// DI: Dependency Inversion Principle
        /// High level modules should not depend on low level modules. It should be the opposite. And both should depend on abstractions. And those abstractions should not depend on details.
        /// All depedencies (actual newing up things) should be in a single (if possible) place. Because at some point you do have to instantiate stuff. And you want to be able to change that easily.

    }
}