(function() {
    "use strict";

    function datacontext($http) {


        function getPeople() {
            var url = "api/person";

            return $http.get(url).then(function(response) {
                return response.data;
            });
        };

        function getPerson(personId) {
            var url = "api/person/" + personId;

            return $http.get(url).then(function(response) {
                return response.data;
            });
        };

        function updatePerson(person) {
            var url = "api/person/" + person.PersonId;

            return $http.put(url, person);
        }

        return {
            getPeople: getPeople,
            getPerson: getPerson,
            updatePerson: updatePerson
        };

    }

    var serviceId = "datacontext";
    angular.module("app").factory(serviceId, ["$http", datacontext]);

})();