function contactRequestsResource($http, umbRequestHelper){
    return{
        getTotalNumber: function (){
            return umbRequestHelper.resourcePromise(
                $http.get("/umbraco/backoffice/api/ContactRequestsApi/GetTotalNumber"),
                "Failed to retrieve the total number"
            );
        },
        getAll: function (){
            return umbRequestHelper.resourcePromise(
                $http.get("/umbraco/backoffice/api/ContactRequestsApi/GetAll"),
                "Failed to retrieve the contact's requests"
            );
        },
    }
}

angular.module("umbraco.services").factory("contactRequestsResource",contactRequestsResource);