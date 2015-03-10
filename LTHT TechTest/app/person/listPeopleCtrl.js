(function() {
    "use strict";

    function person($location, datacontext) {

        var vm = this;

        var onGetPeopleSuccess = function(data) {
            vm.people = data;
        };

        vm.editPerson = function(personId) {
            $location.path("/person/" + personId);
        };

        var activate = function() {
            datacontext.getPeople().then(onGetPeopleSuccess);
        };

        activate();
    }

    var controllerId = "listPeople";
    angular.module("app").controller(controllerId, ["$location", "datacontext", person]);
})();