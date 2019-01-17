using UnityEngine;
using UniDialog.Domain;

namespace UniDialog.Presentation
{
    public abstract class DialogContentPresenter : MonoBehaviour
    {
        public virtual void Initialize(IDialogContent argument)
        {
        }
    }
}
