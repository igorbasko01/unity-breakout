using System;

namespace Common
{
    public interface IStickable
    {
        bool IsSticky { get; }
        /// <summary>
        /// Event that is triggered when the sticky state changes.
        /// The parameter is the new sticky state.
        /// True means the object is sticky, false means it is not.
        /// </summary>
        event Action<bool> OnStickyChanged;
    }
}