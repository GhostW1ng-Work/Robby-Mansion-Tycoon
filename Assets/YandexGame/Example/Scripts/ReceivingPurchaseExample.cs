using StarterAssets;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Windows;

namespace YG.Example
{
    [HelpURL("https://www.notion.so/PluginYG-d457b23eee604b7aa6076116aab647ed#10e7dfffefdc42ec93b39be0c78e77cb")]
    public class ReceivingPurchaseExample : MonoBehaviour
    {
        [SerializeField] private PlayerWallet _wallet;
        [SerializeField] private RewardBoosters _rewardBoosters;
        [SerializeField] private MoneyEarner _moneyEarner;
        [SerializeField] private StarterAssetsInputs _input;
        [SerializeField] UnityEvent successPurchased;
        [SerializeField] UnityEvent failedPurchased;

        private void Start()
        {
            if(YandexGame.SDKEnabled)
            {
                YandexGame.PurchaseSuccessEvent += SuccessPurchased;
                YandexGame.PurchaseFailedEvent += FailedPurchased;
            }
        }

        void SuccessPurchased(string id)
        {
            successPurchased?.Invoke();
         /*   Debug.Log(id + " попытка купить");
            switch (id)
            {
                case "buy250k":
                    _wallet.AddMoney(1000);
                    break;
                case "buy633k":
                    _wallet.AddMoney(3500);
                    break;
                case "buy1dot9M":
                    _wallet.AddMoney(7000);
                    break;
                case "buy2dot5M":
                    _wallet.AddMoney(25000);
                    break;
                case "buy6dot3M":
                    _wallet.AddMoney(55000);
                    break;
                case "buy12dot6M":
                    _wallet.AddMoney(72000);
                    break;
                case "buy25dot3M":
                    _wallet.AddMoney(87000);
                    break;
                case "buy54dot3M":
                    _wallet.AddMoney(100000);
                    break;
                case "magnet":
                    _moneyEarner.SetHasMagnet();
                    _rewardBoosters.DeleteBooster(1);
                    break;
                case "x2money":
                    _moneyEarner.DoubleMultiplier();
                    _rewardBoosters.DeleteBooster(2);
                    break;
                case "speedBoost":
                    _input.SetSprint();
                    _rewardBoosters.DeleteBooster(0);
                    break;
                case "superman":
                    YandexGame.savesData.supermanSkinIsBuyed = true;
                    YandexGame.SaveProgress();
                    break;
                case "robot":
                    YandexGame.savesData.robotSkinIsBuyed = true;
                    YandexGame.SaveProgress();
                    break;
            }
*/
            // Ваш код для обработки покупки. Например:
            //if (id == "50")
            //    YandexGame.savesData.money += 50;
            //else if (id == "250")
            //    YandexGame.savesData.money += 250;
            //else if (id == "1500")
            //    YandexGame.savesData.money += 1500;
            //YandexGame.SaveProgress();
        }

        void FailedPurchased(string id)
        {
            Debug.Log(id + " попытка провалилась");
            failedPurchased?.Invoke();
        }
    }
}