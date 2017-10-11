using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonClientTypes
{
    /// <summary>
    /// Connector to GnuClay server.
    /// </summary>
    public interface IGnuClayServerConnection: IDisposable
    {
        /// <summary>
        /// Gets instance of the NPC with the name.
        /// If the NPC does not exist yet then the NPC with the name will be created and returned.
        /// </summary>
        /// <param name="npcName">The name of the target NPC.</param>
        /// <returns>Reference to the entity with the name.</returns>
        IGnuClayNPCConnection ConnectToNPC(string npcName);

        /// <summary>
        /// Creates a new empty NPC with a random name (Guid) and returns the instance of the NPC.
        /// </summary>
        /// <returns>Reference to the created NPC.</returns>
        IGnuClayNPCConnection CreateNPC();

        /// <summary>
        /// Creates a new NPC (with a random name (Guid)) by a byte array of the target image and returns the instance of the NPC.
        /// </summary>
        /// <param name="data">The byte array of the target image.</param>
        /// <returns>Reference to the created NPC.</returns>
        IGnuClayNPCConnection CreateNPC(byte[] data);

        /// <summary>
        /// Destroys the target NPC by its name.
        /// </summary>
        /// <param name="npcName">The name of the target NPC.</param>
        void DestroyNPC(string npcName);

        /// <summary>
        /// Checks containing the NPC with such name on the server.
        /// Returns true if he NPC with such name contains on the server.
        /// Otherwise returns false.
        /// </summary>
        /// <param name="npcName">The name of target NPC.</param>
        /// <returns>Result of checking.</returns>
        bool ContainsNPC(string npcName);

        /// <summary>
        /// Returns array of names of all NPCes which contained on the server.
        /// </summary>
        string[] NPCesNames { get; }

        /// <summary>
        /// Suspend all GnuClay NPCes which contain on the server.
        /// </summary>
        void Suspend();

        /// <summary>
        /// Resume all GnuClay NPCes which contain on the server.
        /// </summary>
        void Resume();

        /// <summary>
        /// Returns true if this instance is active. Otherwise returns false.
        /// </summary>
        bool IsRunning { get; }

        /// <summary>
        /// Loads all GnuClay NPCes from files of target directory activates them next.
        /// All previous information will be removed.
        /// </summary>
        /// <param name="directoryName">The target directory.</param>
        void Load(string directoryName);

        /// <summary>
        /// Saves all GnuClay NPCes to their files of target directory.
        /// After saving running continues if the NPC was activity before saving.
        /// </summary>
        /// <param name="directoryName">The target directory.</param>
        void Save(string directoryName);

        /// <summary>
        /// Clears all of internal resources of each of the NPCes in the instace. And continues working without them. 
        /// </summary>
        void Clear();

        /// <summary>
        /// Returns true if this instance is destryed. Otherwise returns false. 
        /// </summary>
        bool IsDestroyed { get; }

        /// <summary>
        /// Stops and free all of internal resources.
        /// </summary>
        void Destroy();
    }
}
