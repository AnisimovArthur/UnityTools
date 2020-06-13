using UnityEngine;

namespace UnityTools
{
    public static class CommonExtensions
    {
        /// <summary>
        /// Returns true if the layer in the mask.
        /// </summary>
        /// <param name="layerMask"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        public static bool ContainsLayer(this LayerMask layerMask, int layer)
        {
            return layerMask == (layerMask | (1 << layer));
        }

        /// <summary>
        /// Returns true if all specified layers are contained in the mask.
        /// </summary>
        /// <param name="layerMask"></param>
        /// <param name="layers"></param>
        /// <returns></returns>
        public static bool ContainsAllLayers(this LayerMask layerMask, int[] layers)
        {
            for (byte i = 0; i < layers.Length; i++)
            {
                if (!layerMask.ContainsLayer(layers[i]))
                    return false;
            }

            return true;
        }
    }
}
