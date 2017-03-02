using System.Collections;
using UnityEngine;
using UniDialog.Domain;

namespace UniDialog.Preset.Confirm.Domain
{

    public class ConfirmDialogFrameModel: IDialogFrame
    {
        public string PresenterPath
        {
            get
            {
                return "ConfirmDialogFramePrefab";
            }
        }

        public string Title { get; set;}

        public ConfirmDialogSize Size { get; set;}

    }

}
