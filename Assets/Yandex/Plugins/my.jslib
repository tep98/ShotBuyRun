mergeInto(LibraryManager.library, {

  AdRelive : function(){

    ysdk.adv.showRewardedVideo({
      callbacks: {
        onOpen: () => {
          console.log('Video ad open.');
        },
        onRewarded: () => {
          console.log('Rewarded!');
        },
        onClose: () => {
          console.log('Video ad closed.');
          myGameInstance.SendMessage("AdReliveManager", "RelivePlayer");
        }, 
        onError: (e) => {
          console.log('Error while open video ad:', e);
        }
      }
    })
  },

  RateGame : function(){

    ysdk.feedback.canReview()
    .then(({ value, reason }) => {
      if (value) {
        ysdk.feedback.requestReview()
                //сделать проверку feedbacksent, если true, то кнопка пропадет
        .then(({ feedbackSent }) => {
          console.log(feedbackSent);
        })
      } else {
        console.log(reason);
      }
    })
  },

  GetLang : function() {
    var lang = ysdk.environment.i18n.lang;
    var bufferSize = lengthBytesUTF8(lang) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(lang, buffer, bufferSize);
    return buffer;
  },


  StartAdBanner : function(){

    ysdk.adv.showFullscreenAdv({
      callbacks: {
        onClose: function(wasShown) {
          myGameInstance.SendMessage("basement(MCSpawnAnimation)_0", "OffPause");
          // some action after close
        },
        onError: function(error) {
          myGameInstance.SendMessage("basement(MCSpawnAnimation)_0", "OffPause");
          // some action on error
        }
      }
    })
  },

  DeathAdBanner : function(){

    ysdk.adv.showFullscreenAdv({
      callbacks: {
        onClose: function(wasShown) {
          myGameInstance.SendMessage("basement(MCSpawnAnimation)_0", "OffPause");
          // some action after close
        },
        onError: function(error) {
          myGameInstance.SendMessage("basement(MCSpawnAnimation)_0", "OffPause");
          // some action on error
        }
      }
    })
  },

  MobileCheck : function(){

    if (ysdk.deviceInfo.isMobile() || ysdk.deviceInfo.isTablet()) {
      myGameInstance.SendMessage("PLAYER", "EnableMobile");
    }
  },

  PlayerAuth : function(){
    auth();
  },

  StartGame : function(){
    initPlayer();
  },

  SaveExtern : function(date){
    var dateString = UTF8ToString(date);
    console.log(dateString);
    var myobj = JSON.parse(dateString);
    player.setData(myobj);
  },

  LoadExtern : function(){
    initPlayer();
    player.getData().then(_date => {
      const myJSON = JSON.stringify(_date);
      myGameInstance.SendMessage('Progress', 'SetPlayerInfo', myJSON);
    });
  },

  
});