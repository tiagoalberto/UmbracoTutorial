(function () {
    "use strict";

    function peopleListViewController($scope, $location, listViewHelper) {

        $scope.toggleItem = (item) => {
            if (item.selected) {
                listViewHelper.deselectItem(item, $scope.selection);
            } else {
                listViewHelper.selectItem(item, $scope.selection);
            }
        }

        $scope.gotoItem = (item) => {
            $location.url(item.editPath);
        }

    }

    angular.module("umbraco").controller("peopleListViewController", peopleListViewController);
})();