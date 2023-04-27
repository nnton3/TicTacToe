using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Store
{
    public class ArtifactItemView : ItemView
    {
        [SerializeField] private GameObject _statInfoPref;
        [SerializeField] private Transform _statInfoParent;
        [SerializeField] private TMP_Text _artifactName;
        [SerializeField] private Image _img;

        public override void Init(ItemModel data)
        {
            var specialData = data as ArtifactItem;
            _price.text = specialData.price.ToString();
            _currency.text = specialData.currency.ToString();
            _artifactName.text = specialData.key;
            _img.sprite = Resources.Load<Sprite>(data.key);
            _key = data.key;

            foreach (var stat in specialData.stats)
            {
                var instance = Instantiate(_statInfoPref, _statInfoParent);
                instance.GetComponent<TMP_Text>().text = $"{stat.Key}: {stat.Value}";
            }
        }
    }
}
