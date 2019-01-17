using System.Collections.Generic;

namespace UniDialog.Domain
{

    public class MenuDialogContentModel: IDialogContent
    {
        public string Text { get; set;}

        public IDialog Owner { get; set; }

        public List<MenuDialogItemModel> MenuItems { get; private set;}

        public MenuDialogContentModel()
        {
            MenuItems = new List<MenuDialogItemModel>();
        }
    }

}
