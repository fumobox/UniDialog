using UnityEngine;
using UniRx;
using UniDialog.Domain;

namespace UniDialog.Presentation
{
    public class MenuDialogContentPresenter : DialogContentPresenter
    {
        [SerializeField]
        GameObject _container;

        [SerializeField]
        MenuDialogItemPresenter _menuDialogItemPrefab;

        MenuDialogContentModel _model;

        public override void Initialize(IDialogContent argument)
        {
            _model = (MenuDialogContentModel)argument;

            foreach (var item in _model.MenuItems)
            {
                var m = item;
                m.Owner = _model.Owner;
                var p = Instantiate(_menuDialogItemPrefab, _container.transform);
                p.OnClickAsObservable().Subscribe(_ =>
                {
                    _model.Owner.Click(m);
                }).AddTo(this);
                p.Initialize(m);
            }
        }

    }
}
