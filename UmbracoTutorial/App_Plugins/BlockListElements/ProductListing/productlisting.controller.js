(function () {
    "use strict";

    function bleProductListingController($scope, productListingService) {
        var vm = this;

        vm.title = $scope.block.data.title;
        vm.numberOfProducts = $scope.block?.settingsData?.numberOfProducts;

        vm.products = [];

        getAllProducts();
        
        $scope.$watch('block.data', function () {
            vm.title = $scope.block.data.title;
            
            getAllProducts();
            
        }, true);

        $scope.$watch('block.settingsData', function () {
            
            vm.numberOfProducts = $scope.block?.settingsData?.numberOfProducts;
            
            getAllProducts();
            
        }, true);

        function getAllProducts() {
            productListingService.getProducts(vm.numberOfProducts)
                .then(
                    (response) => {
                        console.log(response);
                        vm.products = response;
                    }, (error) => {
                        console.log(error);
                    });
        }

    }

    angular.module("umbraco").controller("bleProductListingController", bleProductListingController);
})();