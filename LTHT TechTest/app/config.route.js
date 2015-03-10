(function () {

    'use strict';
    
    // Collect the routes
    function getRoutes() {
        return [
            {
                url: '/',
                config: {
                    templateUrl: 'app/person/listPeople.html',
                    caseInsensitiveMatch: true,
                    title: 'people'
                }
            },
             {
                 url: '/person/:personId',
                 config: {
                     templateUrl: 'app/person/person.html',
                     caseInsensitiveMatch: true,
                     title: 'Modify Person'
                 }
             }
        ];
    }

    // Configure the routes and route resolvers
    function routeConfigurator($routeProvider, $locationProvider, routes) {

        routes.forEach(function (r) {
            $routeProvider.when(r.url, r.config);
        });
        $routeProvider.otherwise({ redirectTo: '/' });

      //  $locationProvider.html5Mode(true);

    }

    var app = angular.module('app');
    app.config(['$routeProvider','$locationProvider', 'routes', routeConfigurator]); // Define the routes 
    app.constant('routes', getRoutes());

})();