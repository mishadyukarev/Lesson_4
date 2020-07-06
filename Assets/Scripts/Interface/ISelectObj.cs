using UnityEngine;

namespace Geekbrains
{
    public interface ISelectObj
    {
        string GetMessage();
        GameObject Instance { get; }
    }
}
