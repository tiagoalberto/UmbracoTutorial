(function (){
    "use strict";
    
    function contactRequestsController($scope, contactRequestsService){
        var vm = this;
        vm.contactRequestsNumber = 0;
        vm.contactRequests = [];
        $scope.model.badge = { count: 0 };
        
        getTotalNumber();
        getContactRequests();
        
        function getTotalNumber(){
            contactRequestsService.getTotalNumber().then((number)=>{
               vm.contactRequestsNumber = number;
               $scope.model.badge = { count: number };
            });
        }

        function getContactRequests(){
            contactRequestsService.getAll().then((data)=>{
                vm.contactRequests = data;
            });
        }
    }
    
    angular.module("umbraco").controller("contactRequestsController", contactRequestsController);
})();