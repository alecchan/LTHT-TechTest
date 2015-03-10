(function() {
    "use strict";

    function person($location, $routeParams, datacontext) {

        var vm = this;

        var onGetPersonSuccess = function(data) {
            vm.person = data;
        };

        vm.submitChanges = function(data) {
            if (data) {
                datacontext.updatePerson(data)
                    .then(function() {
                        $location.path("/");
                    });
            }
        };

        var activate = function() {

            var personId = $routeParams.personId;

            if (personId) {
                datacontext.getPerson(personId).then(onGetPersonSuccess);
            } else {
                $location.path("/");
            }
        };

        activate();
    }

    var controllerId = "person";
    angular.module("app").controller(controllerId, ["$location", "$routeParams", "datacontext", person]);
})();