angular.module('app', ['app.controllers']).filter('ItemStatus', function () {
    return function (input) {
        return input ? 'Poprawny' : 'Wadliwy';
    };
});