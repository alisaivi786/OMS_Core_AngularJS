app.controller("accountCtrl", ['$scope', 'validationService', 'accountService', '$window',

    function ($scope, validationService, accountService, $window) {

        //initial settings
        var init = function () {
            $scope.submitted = false;
        };
        init();

        $scope.authorize = function (form) {

            $scope.submitted = true;

            if (!form.$valid) {
                $scope.error = "is-invalid";
                //toaster.pop({
                //    type: 'error',
                //    title: 'Login Failed!',
                //    body: 'Please provide required information.',
                //    timeout: 3000
                //});

                alert("invalid forms");
                notification("error", "Please provide required information.");
            }
            else {
                $scope.error = "";
                var user = {};
                user.UserName = $scope.UserName;
                user.Password = $scope.Password;
                var response = accountService.authorize(user);
                response.then(function (data) {
                    data = angular.fromJson(data.data);

                    if (data[1] == "success") {

                        notification(data[1], data[0]);
                        $window.location.href = "/Dashboard/Index";
                    }
                    else {

                        notification(data[1], data[0]);
                    }
                }, function () { });
            }
        };


        //validation
        validationService.validation($scope);


    }]);