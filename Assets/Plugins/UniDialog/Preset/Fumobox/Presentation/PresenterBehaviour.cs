using UnityEngine;
using System.Collections;

namespace Fumobox.Presenter
{
    public class PresenterBehaviourBase: MonoBehaviour
    {
    }

    public class PresenterBehaviour<T> : PresenterBehaviourBase
    {

        public virtual void Initialize(T argument)
        {
        }
    }

    public class PresenterBehaviour : PresenterBehaviourBase
    {

        public virtual void Initialize()
        {
        }

    }

}