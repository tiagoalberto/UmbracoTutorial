(function (){
    "use strict";

    function githubUserController($scope){
        
        if($scope.model.value === null || $scope.model.value === ""){
            $scope.model.value = {
                githubUserName: "",
                githubPreferredLanguage: ""
            }
        }
       
    }

    angular.module("umbraco").controller("githubUserController", githubUserController);
})();