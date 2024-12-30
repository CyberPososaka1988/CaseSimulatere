using UnityEngine;

namespace CaseSimulator.Gameplay.InventorySystem
{
    public class Interactor : MonoBehaviour
    {
        [SerializeField] private string _itemsSaveTag;
        [SerializeField] private InventoryData _inventoryData;
        [SerializeField] private ItemInfo[] _allItems;

        public InventoryData InventoryData => _inventoryData;

        /*private void Awake()
        {
            List<string> names = new List<string>();
            foreach (ItemInfo item in _allItems)
            {
                names.Append(item.ItemName);
            }

            foreach (ItemInfo item in _allItems)
            {
                int c = 0;
                foreach (string name in names)
                {
                    if (name == item.ItemName)
                    {
                        c++;
                    }
                }

                if (c > 1)
                {
                    print(item.ItemName);
                }
                else
                    print("zebis");
            }
        }*/

        private void Awake()
        {
            _inventoryData.ItemInfos.Clear();
            Load();
        }

        public void AddItem(ItemInfo itemInfo)
        {
            _inventoryData.ItemInfos.Add(itemInfo);
            Save();
        }

        public void RemoveItem(ItemInfo itemInfo)
        {
            if (_inventoryData.ItemInfos.Contains(itemInfo))
            {
                _inventoryData.ItemInfos.Remove(itemInfo);
            }
            Save();
        }

        private void Load()
        {
            string saveStr = PlayerPrefs.GetString(_itemsSaveTag);
            string[] names = saveStr.Split(',');
            foreach (string name in names)
            {
                foreach (ItemInfo itemInfo in _allItems)
                {
                    if (name == itemInfo.ItemName)
                    {
                        _inventoryData.ItemInfos.Add(itemInfo);
                    }
                }
            }

        }

        private void Save()
        {
            string saveStr = string.Empty;

            foreach (ItemInfo item in _inventoryData.ItemInfos)
            {
                saveStr += $"{item.ItemName},";
            }

            PlayerPrefs.SetString(_itemsSaveTag, saveStr);
        }
    }
}