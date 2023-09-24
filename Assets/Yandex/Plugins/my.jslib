mergeInto(LibraryManager.library, {

  AdRelive : function(value){
    ysdk.adv.showRewardedVideo({
      callbacks: {
        onOpen: () => {
          console.log('Video ad open.');
        },
        onRewarded: () => {
          console.log('Rewarded!');
          myGameInstance.SendMessage("AdReliveManager", "RelivePlayer");
        },
        onClose: () => {
          console.log('Video ad closed.');
        }, 
        onError: (e) => {
          console.log('Error while open video ad:', e);
        }
      }
    })
  },


});