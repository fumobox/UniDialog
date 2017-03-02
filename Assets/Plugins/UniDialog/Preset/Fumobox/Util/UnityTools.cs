using System.Collections;
using UnityEngine;

namespace Fumobox.Util
{

    public static class UnityTools
    {

        public static T Instantiate<T>(GameObject subject, Transform parent) where T: MonoBehaviour
        {
            var o = Object.Instantiate(subject).GetComponent<T>();
            o.transform.SetParent(parent, false);
            return o;
        }

        public static T Instantiate<T>(string path, Transform parent) where T : MonoBehaviour
        {
            var res = Resources.Load(path);
            var go = Object.Instantiate(res) as GameObject;
            go.transform.SetParent(parent, false);
            return go.GetComponent<T>();
        }

    }

}
