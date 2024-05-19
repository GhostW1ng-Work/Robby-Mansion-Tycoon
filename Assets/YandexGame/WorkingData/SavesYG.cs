
using System.Collections.Generic;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)
        public int money = 1;                       // Можно задать полям значения по умолчанию
        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[3];

        // Ваши сохранения
        public int earnedMoney = 0;
        public int buildingLevel = 0;
        public int playerMoney = 0;
        public int currentMultiplier = 1;
        public int earnPerSecond = 0;
        public int moneyReceiverCount = 0;
        public bool isSprint = false;
        public bool hasMagnet = false;
        public bool speedBoostBuyed = false;
        public bool magnetBoostBuyed = false;
        public bool doubleMoneyBoostBuyed = false;

        //Комнаты
        public int livingRoomLevel = 0;
        public int bedroomLevel = 0;
        public int bathroomLevel = 0;
        public int kitchenLevel = 0;
        public int arcadeLevel = 0;
        public int gymLevel = 0;
        public int musicLevel = 0;
        public int libraryLevel = 0;

        //Скины
        public bool robotSkinIsBuyed = false;
        public bool supermanSkinIsBuyed = false;
        public Skins skin = Skins.Standart;
        // ...

        // Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны


        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива

            openLevels[1] = true;
        }
    }
}
