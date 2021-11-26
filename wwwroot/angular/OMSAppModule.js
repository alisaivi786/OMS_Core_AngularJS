var app = angular.module("OMSApplication", ['toaster']);


app.config(function ($httpProvider) {
    $httpProvider.defaults.transformRequest = function (data) {
        if (data === undefined) {
            return data;
        }
        return $.param(data);
    }


    $httpProvider.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded; charset=UTF-8';

});

//app.config(function ($httpProvider) {


//    angular.lowercase = angular.$$lowercase;

//    //$translateProvider.useStaticFilesLoader({
//    //    prefix: 'http://localhost:7421/Scripts/app/resource_files/lang_',
//    //    suffix: '.json'
//    //}).preferredLanguage('en').useMissingTranslationHandlerLog();

//    $httpProvider.defaults.headers.common["X-Requested-With"] = 'XMLHttpRequest';

//    //$httpProvider.interceptors.push('jsonRefResolver');

//    /*$translateProvider.translations('en', {
//        TITLE: 'Hello',
//        WELCOME_MESSAGE1: 'My name is {{name}}',
//        WELCOME_MESSAGE2: 'And my name is {{name}}. I\'m {{age}} years old',
//        BUTTON_LANG_EN: 'english',
//        BUTTON_LANG_FR: 'french',
//        BUTTON_LANG_ESP: 'espagnol'
//    });
//    $translateProvider.translations('fr', {
//        TITLE: 'Bonjour.',
//        WELCOME_MESSAGE1: 'Mon nom est {{name}}',
//        WELCOME_MESSAGE2: 'Et mon nom est {{name}}. J\'ai {{age}} ans',
//        BUTTON_LANG_EN: 'anglais',
//        BUTTON_LANG_FR: 'français',
//        BUTTON_LANG_ESP: 'espagnol'
//    });
//    $translateProvider.translations('esp', {
//        TITLE: 'hola.',
//        WELCOME_MESSAGE1: 'Mi nombre es {{name}}',
//        WELCOME_MESSAGE2: ' Y mi nombre es Javier {{name}}. años de edad {{age}} ans',
//        BUTTON_LANG_EN: 'anglais',
//        BUTTON_LANG_FR: 'français',
//        BUTTON_LANG_ESP: 'espagnol'
//    });
//    $translateProvider.preferredLanguage('en');*/

//    //BEGIN: Cache
//    //initialize get if not there
//    if (!$httpProvider.defaults.headers.get) {
//        $httpProvider.defaults.headers.get = {};
//    }

//    // Answer edited to include suggestions from comments
//    // because previous version of code introduced browser-related errors

//    //disable IE ajax request caching
//    $httpProvider.defaults.headers.get['If-Modified-Since'] = 'Mon, 26 Jul 1997 05:00:00 GMT';
//    // extra
//    $httpProvider.defaults.headers.get['Cache-Control'] = 'no-cache';
//    $httpProvider.defaults.headers.get['Pragma'] = 'no-cache';
//    //END: Cache

   


//});

app.controller('layout_controller', function ($scope) {

    $scope.name = "mohsin mushtaq";
    //$scope.$on('IdleTimeout', function () {
    //    // the user has timed out (meaning idleDuration + timeout has passed without any activity).
    //    // this is where you'd log them.
    //    window.location.href = "/Account/Login";
    //});

    //$scope.Reset = function () {
    //    //Redirect to refresh Session.
    //    window.location = window.location.href;
    //}
    //$scope.SignOut = function () {
    //    accountService.logout();
    //    window.location.href = "/Account/Login";
    //}
    //$scope.$watch('idle', function (value) {
    //    if (value !== null) {
    //        Idle.setIdle(value);
    //    }
    //});
    //$scope.$watch('timeout', function (value) {
    //    if (value !== null) {
    //        Idle.setTimeout(value);
    //    }
    //});

});

app.directive("w3TestDirective", () => {
    return {
        template: "<h1>Hello Mohsin </h1>"
    };
});