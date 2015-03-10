// clock

(function() {

    "use strict";

    var id = "filters";

    var filters = angular.module(id, []);

    filters.filter("yesNo", function() {
        return function(input) {
            return input ? "Yes" : "No";
        };
    });

})();