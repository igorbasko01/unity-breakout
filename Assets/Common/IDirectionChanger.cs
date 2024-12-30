using UnityEngine;

namespace Common
{
    public interface IDirectionChanger
    {
        Vector3 CalculateNewDirection(Vector3 originalPosition, Vector3 originalDirection);
    }
}
