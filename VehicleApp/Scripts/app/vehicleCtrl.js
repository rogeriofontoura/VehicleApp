
(function () {
    'use strict';

    var app = angular.module('app', []);
    app.controller('vehicleController', ['$scope', '$http', vehicleController]);

    function vehicleController($scope, $http) {

        $scope.loading = true;
        $scope.addMode = false;
        $scope.editvehicle = {};

        $http({
            method: 'GET',
            url: '/api/Vehicle/'
        }).then(function successCallback(response) {
            $scope.vehicles = response.data;
            $scope.loading = false;

        }, function errorCallback(response) {
            $scope.error = "An Error has occured while loading posts!";
            $scope.loading = false;
        });

        //by pressing toggleEdit button ng-click in html, this method will be hit
        $scope.toggleEdit = function (vehicle) {
            $scope.addMode = !$scope.addMode;
            $scope.editvehicle = angular.copy(vehicle);
        };

        //by pressing toggleAdd button ng-click in html, this method will be hit
        $scope.toggleAdd = function () {
            $scope.addMode = !$scope.addMode;
            $scope.editvehicle = angular.copy({});
        };

        $scope.add = function () {
            $scope.loading = true;

            $http({
                method: 'POST',
                data: $scope.editvehicle,
                url: '/api/Vehicle/'
            }).then(function successCallback(response) {
                alert("Added Successfully!!");
                $scope.addMode = false;
                $scope.loading = false;
                $scope.vehicles.push(response.data);

            }, function errorCallback(response) {
                $scope.error = "An Error has occured while Adding Customer! " + data;
                $scope.loading = false;
            });
        };

        $scope.save = function () {
            $scope.loading = true;
            var Id = $scope.editvehicle.id;
            $http({
                method: 'PUT',
                data: $scope.editvehicle,
                url: '/api/Vehicle/' + Id
            }).then(function successCallback(response) {
                alert("Saved Successfully!!");
                $scope.addMode = false;
                $scope.loading = false;
                $.each($scope.vehicles, function (i) {
                    if ($scope.vehicles[i].id === response.data.id) {
                        $scope.vehicles[i].id = response.data.id;
                        $scope.vehicles[i].plate = response.data.plate;
                        $scope.vehicles[i].vehicles_document = response.data.vehicles_document;
                        $scope.vehicles[i].owner_name = response.data.owner_name;
                        $scope.vehicles[i].owner_document = response.data.owner_document;
                        $scope.vehicles[i].blocked = response.data.blocked;
                        return false;
                    }
                });

            }, function errorCallback(response) {
                $scope.error = "An Error has occured while Saving Customer! " + data;
                $scope.loading = false;
            });
        };

        $scope.deletecustomer = function (vehicle) {
            $scope.loading = true;
            var Id = vehicle.id;

            $http({
                method: 'DELETE',
                url: '/api/Vehicle/' + Id,
            }).then(function successCallback(response) {
                alert("Deleted Successfully!!");
                var index = $scope.vehicles.indexOf(vehicle);
                $scope.vehicles.splice(index, 1);
                $scope.loading = false;

            }, function errorCallback(response) {
                $scope.error = "An Error has occured while saving vehicle! " + response.data;
                $scope.loading = false;
            });
        };

    }
})();