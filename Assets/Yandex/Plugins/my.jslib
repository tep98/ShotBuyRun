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

});