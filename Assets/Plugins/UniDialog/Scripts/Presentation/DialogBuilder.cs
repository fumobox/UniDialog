using UnityEngine;
using UniDialog.Domain;

namespace UniDialog.Presentation
{

    public static class DialogBuilder
    {

        public static DialogQueueModel CreateQueue(Transform parent)
        {
            var resource = Resources.Load("DialogQueuePrefab");
            var gameObject = Object.Instantiate(resource) as GameObject;
            var instance = gameObject.GetComponent<DialogQueuePresenter>();
            var model = new DialogQueueModel();
            instance.Initialize(model);
            instance.transform.SetParent(parent, false);
            return model;
        }

    }

}