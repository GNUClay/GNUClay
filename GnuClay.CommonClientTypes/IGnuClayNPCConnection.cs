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
        ISelectResult Query(string text);

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

        /// <summary>
        /// Returns the key of the string value from its internal data dictionary.
        /// </summary>
        /// <param name="val">The target string value</param>
        /// <returns>The key of the string value.</returns>
        ulong GetKey(string val);

        /// <summary>
        /// Set relationship of inheritance between two entities.
        /// </summary>
        /// <param name="subKey">The key of type of the subclass.</param>
        /// <param name="superKey">The key of type of the superclass.</param>
        /// <param name="rank">The rank of the inheritance from 0 to 1 inclusively.</param>
        void SetInheritance(ulong subKey, ulong superKey, double rank);

        /// <summary>
        /// Loads a list of the superclasses for the target entity.
        /// </summary>
        /// <param name="targetKey">The key of type of the target entity.</param>
        /// <returns>The list of the superclasses for the target entity.</returns>
        List<InheritanceItem> LoadListOfSuperClasses(ulong targetKey);

        /// <summary>
        /// Gets rank of relationship of inheritance between two entities.
        /// </summary>
        /// <param name="subKey">The key of type of the subclass.</param>
        /// <param name="superKey">The key of type of the superclass.</param>
        /// <returns>The rank of the inheritance from 0 to 1 inclusively.</returns>
        double GetInheritanceRank(ulong subKey, ulong superKey);

        /// <summary>
        /// Loads a list of the subclasses for the target entity.
        /// </summary>
        /// <param name="targetKey">The key of type of the target entity.</param>
        /// <returns>The list of the subclasses for the target entity.</returns>
        List<InheritanceItem> LoadListOfSubClasses(ulong targetKey);

        /// <summary>
        /// Loads all items of relationship of inheritance.
        /// </summary>
        /// <returns>The list of all items of relationship of inheritance.</returns>
        List<InheritanceItem> LoadAllInheritanceItems();

        /// <summary>
        /// Adds remote function.
        /// </summary>
        /// <param name="filter">The filter which describes the signature and handler of the function.</param>
        /// <returns>The descriptor of the function.</returns>
        ulong AddRemoteFunction(IExternalCommandFilter filter);

        /// <summary>
        /// Removes remote function by its descriptor.
        /// </summary>
        /// <param name="descriptor">The descriptor of the removed function.</param>
        void RemoveRemoteFunction(ulong descriptor);

        /// <summary>
        /// Adds a handler for receiving log messages.
        /// Returns the descriptor of the added handler.
        /// </summary>
        /// <param name="handler">The reference to the handler.</param>
        /// <returns>The descriptor of the added handler.</returns>
        ulong AddLogHandler(Action<IExternalValue> handler);

        /// <summary>
        /// Removes a handler of log messages by its descriptor.
        /// </summary>
        /// <param name="descriptor">The descriptor of the removed handler.</param>
        void RemoveLogHandler(ulong descriptor);
    }
}
