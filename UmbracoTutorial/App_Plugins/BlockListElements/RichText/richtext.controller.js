(function (){
    "use strict";

    function bleRichtextController($scope){
      var vm = this;
      
      vm.richTextContent = $scope.block.data.richText;
      
      //vm.settings = $scope.block?.settingsData;
      
      vm.backgroundColor = $scope.block?.settingsData?.backgroundColor?.value; 
      console.log($scope.block?.settingsData);
      $scope.$watch('block.data', function (){
          vm.richTextContent = $scope.block.data.richText;
      }, true);
      $scope.$watch('block.settingsData', function (){
          vm.backgroundColor = $scope.block?.settingsData?.backgroundColor?.value;
      }, true);
      
    }

    angular.module("umbraco").controller("bleRichtextController", bleRichtextController);
})();