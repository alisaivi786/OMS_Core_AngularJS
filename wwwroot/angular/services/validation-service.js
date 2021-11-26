app.service("validationService", function ($http) {

    this.validation = function ($scope) {
        $scope.hasError = function (field, validation) {
            if (validation) {
                return ($scope.frm[field].$dirty && $scope.frm[field].$error[validation] && $scope.submitted) || ($scope.submitted && $scope.frm[field].$error[validation]);
            }
            return ($scope.frm[field].$dirty && $scope.frm[field].$invalid && $scope.submitted) || ($scope.submitted && $scope.frm[field].$invalid);
        };
    };

});