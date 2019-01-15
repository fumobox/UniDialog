using System;

namespace UniDialog.Domain
{
    public class ConfirmDialogButton : IDialogButton
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IDialog Owner { get; set; }

        public ConfirmDialogButton(string name) : this(Guid.NewGuid().ToString(), name)
        {
        }

        public ConfirmDialogButton(string id, string name)
        {
            Id = id;
            Name = name;
        }

    }

}
