app.controller("role-controller", ['$scope', 'repositoryService', 'validationService', 'toaster', '$filter', 'paggerService',
    function ($scope, repositoryService, validationService, toaster, $filter, paggerService) {


        paggerService.setInitial($scope);
        $scope.divList = true;
        $scope.CrudForm = false;


        $scope.getDataList = (pageNum, action = 'page') => {

            $scope.PageIndex = pageNum;
            var pageInfo = {
                PageNum: pageNum,
                PageSize: $scope.sPageSize.selectedOption.name,
                SearchTerm: $scope.searchTerm,
                SortColumn: $scope.SortColumn,
                SortDirection: $scope.SortDirection
            };

            if (action == 'page')
                $scope.isLoaded = false;


            var data = repositoryService.getAll(pageInfo,"Configuration", "GetRoleList");
            data.then(function (response) {

                $scope.PaggingTemplate(angular.fromJson(response.data).TotalPages, angular.fromJson(response.data).CurrentPage, angular.fromJson(response.data).PageSize);
                $scope.Items = angular.fromJson(response.data).Data;

                console.log(angular.fromJson(response.data).Data);
                $scope.isLoaded = true;

            }, function (error) {
                console.log(error);
            });
        }


        var init = function () {
            $scope.getDataList(1);
        };

        init();


        $scope.addNew = function () {
            $scope.submitted = false;
            $scope.divList = false;
            $scope.CrudForm = true;
            $scope.RoleId = "0";
            $scope.action = "Add";
            clearAllFields();

        };

        $scope.addUpdateRole = function (form) {

            $scope.submitted = true;

            if (!form.$valid) {
                $scope.error = "is-invalid";
                //toaster.pop({
                //    type: 'error',
                //    title: 'Submit Failed!',
                //    body: 'Please provide required information.',
                //    timeout: 3000
                //});

                notification("error", "Please provide required information.");
            }
            else {
                $scope.error = "";

                var role = {};
                role.RoleId = $scope.RoleId;
                role.RoleName = $scope.RoleName;
                role.Description = $scope.Description;
                role.IsDeleted = false;
                role.IsActive = true;
                role.AddDate = new Date();


                if ($scope.action == "Add") {

                    var response = repositoryService.add(role, "Configuration", "Save");
                    response.then(function (data) {
                        data = angular.fromJson(data.data);

                        if (data[1] == "success") {

                            notification(data[1], data[0]);

                            $scope.divList = true;
                            $scope.CrudForm = false;
                            $scope.getDataList(1);
                        }
                        else {

                            notification(data[1], data[0]);
                        }

                    }, function () { });
                }
                else {
                    var response = repositoryService.update(role, "Configuration", "Save");
                    response.then(function (data) {
                        data = angular.fromJson(data.data);
                        if (data[1] == "success") {

                            notification(data[1], data[0]);

                            $scope.divList = true;
                            $scope.CrudForm = false;
                            $scope.getDataList(1);
                        }
                        else {

                            notification(data[1], data[0]);
                        }

                    }, function () { });
                }
            }
        };

        $scope.edit = function (item) {
            $scope.submitted = false;
            var response = repositoryService.getById(item.RoleId, "Configuration", "GetRoleById");
            response.then(function (data) {

                $scope.RoleId = angular.fromJson(data.data).RoleId;
                $scope.RoleName = angular.fromJson(data.data).RoleName;
                $scope.Description = angular.fromJson(data.data).Description;

                //$scope.firstName = (!angular.fromJson(data.data).User.FirstName ? "" : angular.fromJson(data.data).User.FirstName.trim());


                /*$scope.dob = new Date(!angular.fromJson(data.data).User.DOB ? "22/2/2020" : angular.fromJson(data.data).User.DOB.trim());*/
                //var _dob = new Date(!angular.fromJson(data.data).User.DOB ? "22/2/2020" : angular.fromJson(data.data).User.DOB.trim());
                //$scope.dob = $filter('date')(_dob, "MM/dd/yyyy");


                $scope.divList = false;
                $scope.CrudForm = true;
                $scope.action = "Update";

            }, function (error) {
                console.log(error);
            });

        };

        $scope.setDeleteId = function (item) {

            swal({
                title: 'Are you sure?',
                text: '',
                icon: 'warning',
                buttons: true,
                dangerMode: true,
                closeOnClickOutside: false,
            })
                .then((willDelete) => {
                    if (willDelete) {
                        var data = repositoryService.delete(item.RoleId, "Configuration", "Delete");
                        data.then(function (data) {
                            data = angular.fromJson(data.data);
                            if (data[1] == "success") {

                                notification(data[1], data[0]);
                                $scope.getDataList(1);
                            }
                            else {

                                notification(data[1], data[0]);
                            }

                        }, function () { });

                    } else {
                        //swal('Your imaginary file is safe!');
                    }
                });
        };



        $scope.cancel = () => {
            $scope.divList = true;
            $scope.CrudForm = false;
            $scope.getDataList(1);
            clearAllFields();
        };



        var clearAllFields = () => {
            $scope.RoleId = "0";
            $scope.RoleName = "";
            $scope.Description = "";
            $scope.error = "";
        };

        validationService.validation($scope);

        paggerService.setPaggingTemplate($scope);

    }]);