mergeInto(LibraryManager.library,
{
  StartGame: function (){
    YaGames.init().then(ysdk => {
        MyGameInstance.SendMessage('AwakeLoader', 'Loading');
    });
  },

  GetPlatform: function (){
    var deviceType = ysdk.deviceInfo.type;

    MyGameInstance.SendMessage("PlatformChecker", "SetPlatform", deviceType);
  },


  ShowAdv: function (){
    ysdk.adv.showFullscreenAdv({
      callbacks: {
        onError: function(error) {
            MyGameInstance.SendMessage('AdManager', 'StopAd');
            console.log("Err");
          },
          onClose: function(wasShown) {
            MyGameInstance.SendMessage('AdManager', 'StopAd');
            console.log("Good");
          }
      }
    })
  },

  GetLang: function () {
    if (ysdk.environment.i18n.lang == "en") {
      return 1
    } else {
      return 0
    }
  },

  AdCase: function (){
    ysdk.adv.showRewardedVideo({
      callbacks: {
          onOpen: () => {
            console.log('Video ad open.');
          },
          onRewarded: () => {
            MyGameInstance.SendMessage('AdCase', 'OnRewarded');
          },
          onClose: () => {
            MyGameInstance.SendMessage('AdCase', 'GetReward');
          }, 
          onError: (e) => {
            console.log('Error while open video ad:', e);
          }
     }
    })
  },

});