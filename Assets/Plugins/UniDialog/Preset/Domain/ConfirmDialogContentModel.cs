using System.Collections;
using UnityEngine;
using UniDialog.Domain;

namespace UniDialog.Preset.Confirm.Domain
{

    public class ConfirmDialogContentModel: IDialogContent
    {

        public string PresenterPath
        {
            get
            {
                return "ConfirmDialogContentPrefab";
            }
        }

        public string Text { get; set;}

    }

}
