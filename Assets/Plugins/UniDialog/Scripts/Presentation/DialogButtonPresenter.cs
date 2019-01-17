using UnityEngine;
using UniDialog.Domain;

namespace UniDialog.Presentation
{
    public abstract class DialogButtonPresenter : MonoBehaviour
    {
        public virtual void Initialize(IDialogButton argument)
        {
        }
    }
}
