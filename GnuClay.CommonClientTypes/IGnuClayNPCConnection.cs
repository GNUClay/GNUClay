using GnuClay.CommonClientTypes.CommonData;
using System;
using System.Collections.Generic;

namespace GnuClay.CommonClientTypes
{
    /// <summary>
    /// Connector to NPC that is an instance of the GnuClay engine.
    /// </summary>
    public interface IGnuClayNPCConnection: IReadOnlyStorageDataDictionary, IDisposable
    {
        /// <summary>
        /// Returns the name of the GnuClay NPC.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Suspends the instance.
        /// </summary>
        void Suspend();

        /// <summary>
        /// Resumes the instance.
        /// </summary>
        void Resume();

        /// <summary>
        /// Returns true if this instance is active. Otherwise returns false.
        /// </summary>
        bool IsRunning { get; }

        /// <summary>
        /// Executes query from text and returns result of the executing.
        /// </summary>
        /// <param name="text">The text with the query.</param>
        /// <returns>The result of the executing</returns>
        SelectResult Query(string text);

        /// <summary>
        /// Loads image of GnuClay NPC form file and activates it next.
        /// All previous information will be removed.
        /// </summary>
        /// <param name="fileName">The name of the file which contains the image of GnuClay NPC.</param>
        void Load(string fileName);

        /// <summary>
        /// Loads image of GnuClay NPC form array of bytes and activates it next.
        /// All previous information will be removed.
        /// </summary>
        /// <param name="data">Reference to the array of bytes.</param>
        void Load(byte[] data);

        /// <summary>
        /// Saves image of GnuClay NPC to a file. After saving running continues if the NPC was activity before saving.
        /// </summary>
        /// <param name="fileName">The name of the file which will contain the image of GnuClay NPC.</param>
        void Save(string fileName);

        /// <summary>
        /// Saves image of GnuClay NPC to a byte array. After saving running continues if the NPC was activity before saving.
        /// </summary>
        /// <returns>Returns target byte array which contains the image of GnuClay NPC.</returns>
        byte[] Save();

        /// <summary>
        /// Removes all of internal resources and continues working without them.
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


        ulong GetKey(string val);

        void SetInheritance(ulong subKey, ulong superKey, double rank);
        List<InheritanceItem> LoadListOfSuperClasses(ulong targetKey);
        double GetInheritanceRank(ulong subKey, ulong superKey);
        List<InheritanceItem> LoadListOfSubClasses(ulong targetKey);
        List<InheritanceItem> LoadAllInheritanceItems();

        ulong AddLogHandler(Action<IExternalValue> handler);
        void RemoveLogHandler(ulong descriptor);
    }
}
