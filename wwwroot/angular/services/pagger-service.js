app.service('paggerService', function () {

    this.setInitial = function ($scope) {
        $scope.sPageSize = {
            availableOptions: [
                { id: '1', name: '10' },
                { id: '2', name: '25' },
                { id: '3', name: '50' },
                { id: '4', name: '100' }
            ],
            selectedOption: { id: '1', name: '10' } //This sets the default value of the select in the ui
        };
    };

    //set pagging for second grid on the same page
    this.setInitial_2 = function ($scope) {
        $scope.sPageSize_2 = {
            availableOptions_2: [
                { id: '1', name: '10' },
                { id: '2', name: '25' },
                { id: '3', name: '50' },
                { id: '4', name: '100' }
            ],
            selectedOption_2: { id: '1', name: '10' } //This sets the default value of the select in the ui
        };
    };

    this.setInitial_3 = function ($scope) {
        $scope.sPageSize_3 = {
            availableOptions_3: [
                { id: '1', name: '10' },
                { id: '2', name: '25' },
                { id: '3', name: '50' },
                { id: '4', name: '100' }
            ],
            selectedOption_3: { id: '1', name: '10' } //This sets the default value of the select in the ui
        };
    };

    this.setInitial_4 = function ($scope) {
        $scope.sPageSize_4 = {
            availableOptions_4: [
                { id: '1', name: '10' },
                { id: '2', name: '25' },
                { id: '3', name: '50' },
                { id: '4', name: '100' }
            ],
            selectedOption_4: { id: '1', name: '10' } //This sets the default value of the select in the ui
        };
    };

    this.setInitial_5 = function ($scope) {
        $scope.sPageSize_5 = {
            availableOptions_5: [
                { id: '1', name: '10' },
                { id: '2', name: '25' },
                { id: '3', name: '50' },
                { id: '4', name: '100' }
            ],
            selectedOption_5: { id: '1', name: '10' } //This sets the default value of the select in the ui
        };
    };

    this.setPaggingTemplate = function ($scope) {
        $scope.PaggingTemplate = function (totalPage, currentPage, pageSize) {
            $scope.showForwardBtn = true;
            $scope.TotalPages = totalPage;
            $scope.CurrentPage = currentPage;
            $scope.PageSize = pageSize;
            $scope.PageNumberArray = Array();

            for (var i = 0; i < totalPage; i++) {
                $scope.PageNumberArray[i] = i + 1;
            };

            if (currentPage >= 1 && currentPage < 5)
                $scope.PageNumberArray = $scope.PageNumberArray.slice(0, 5);
            else
                $scope.PageNumberArray = $scope.PageNumberArray.slice(currentPage - 4, currentPage + 4);

            if (currentPage == 1) {
                $scope.isShowBackwardOne = false;
                $scope.isShowFirst = false;
            }
            else if (currentPage > 1) {
                $scope.isShowBackwardOne = true;
                $scope.isShowFirst = true;
            }
            if (currentPage == totalPage) {
                $scope.isShowForwardOne = false;
                $scope.isShowLast = false;
            }
            else if (currentPage < totalPage) {
                $scope.isShowForwardOne = true;
                $scope.isShowLast = true;
            }

            $scope.FirstPage = 1;
            $scope.LastPage = totalPage;
            if (totalPage != currentPage) {
                $scope.ForwardOne = currentPage + 1;
            }
            if (currentPage != 1) {
                $scope.BackwardOne = currentPage - 1;
            }

            if (totalPage == currentPage) {
                $scope.showForwardBtn = false;
            }

        };
    };

    //set pagging for second grid on same page
    this.setPaggingTemplate_2 = function ($scope) {
        $scope.PaggingTemplate_2 = function (totalPage, currentPage, pageSize) {
            $scope.showForwardBtn_2 = true;
            $scope.TotalPages_2 = totalPage;
            $scope.CurrentPage_2 = currentPage;
            $scope.PageSize_2 = pageSize;
            $scope.PageNumberArray_2 = Array();

            for (var i = 0; i < totalPage; i++) {
                $scope.PageNumberArray_2[i] = i + 1;
            };

            if (currentPage >= 1 && currentPage < 5)
                $scope.PageNumberArray_2 = $scope.PageNumberArray_2.slice(0, 5);
            else
                $scope.PageNumberArray_2 = $scope.PageNumberArray_2.slice(currentPage - 4, currentPage + 4);

            if (currentPage == 1) {
                $scope.isShowBackwardOne_2 = false;
                $scope.isShowFirst_2 = false;
            }
            else if (currentPage > 1) {
                $scope.isShowBackwardOne_2 = true;
                $scope.isShowFirst_2 = true;
            }
            if (currentPage == totalPage) {
                $scope.isShowForwardOne_2 = false;
                $scope.isShowLast_2 = false;
            }
            else if (currentPage < totalPage) {
                $scope.isShowForwardOne_2 = true;
                $scope.isShowLast_2 = true;
            }

            $scope.FirstPage_2 = 1;
            $scope.LastPage_2 = totalPage;
            if (totalPage != currentPage) {
                $scope.ForwardOne_2 = currentPage + 1;
            }
            if (currentPage != 1) {
                $scope.BackwardOne_2 = currentPage - 1;
            }

            if (totalPage == currentPage) {
                $scope.showForwardBtn_2 = false;
            }

        };
    };

    this.setPaggingTemplate_3 = function ($scope) {
        $scope.PaggingTemplate_3 = function (totalPage, currentPage, pageSize) {
            $scope.showForwardBtn_3 = true;
            $scope.TotalPages_3 = totalPage;
            $scope.CurrentPage_3 = currentPage;
            $scope.PageSize_3 = pageSize;
            $scope.PageNumberArray_3 = Array();

            for (var i = 0; i < totalPage; i++) {
                $scope.PageNumberArray_3[i] = i + 1;
            };

            if (currentPage >= 1 && currentPage < 5)
                $scope.PageNumberArray_3 = $scope.PageNumberArray_3.slice(0, 5);
            else
                $scope.PageNumberArray_3 = $scope.PageNumberArray_3.slice(currentPage - 4, currentPage + 4);

            if (currentPage == 1) {
                $scope.isShowBackwardOne_3 = false;
                $scope.isShowFirst_3 = false;
            }
            else if (currentPage > 1) {
                $scope.isShowBackwardOne_3 = true;
                $scope.isShowFirst_3 = true;
            }
            if (currentPage == totalPage) {
                $scope.isShowForwardOne_3 = false;
                $scope.isShowLast_3 = false;
            }
            else if (currentPage < totalPage) {
                $scope.isShowForwardOne_3 = true;
                $scope.isShowLast_3 = true;
            }

            $scope.FirstPage_3 = 1;
            $scope.LastPage_3 = totalPage;
            if (totalPage != currentPage) {
                $scope.ForwardOne_3 = currentPage + 1;
            }
            if (currentPage != 1) {
                $scope.BackwardOne_3 = currentPage - 1;
            }

            if (totalPage == currentPage) {
                $scope.showForwardBtn_3 = false;
            }

        };
    };

    this.setPaggingTemplate_4 = function ($scope) {
        $scope.PaggingTemplate_4 = function (totalPage, currentPage, pageSize) {
            $scope.showForwardBtn_4 = true;
            $scope.TotalPages_4 = totalPage;
            $scope.CurrentPage_4 = currentPage;
            $scope.PageSize_4 = pageSize;
            $scope.PageNumberArray_4 = Array();

            for (var i = 0; i < totalPage; i++) {
                $scope.PageNumberArray_4[i] = i + 1;
            };

            if (currentPage >= 1 && currentPage < 5)
                $scope.PageNumberArray_4 = $scope.PageNumberArray_4.slice(0, 5);
            else
                $scope.PageNumberArray_4 = $scope.PageNumberArray_4.slice(currentPage - 4, currentPage + 4);

            if (currentPage == 1) {
                $scope.isShowBackwardOne_4 = false;
                $scope.isShowFirst_4 = false;
            }
            else if (currentPage > 1) {
                $scope.isShowBackwardOne_4 = true;
                $scope.isShowFirst_4 = true;
            }
            if (currentPage == totalPage) {
                $scope.isShowForwardOne_4 = false;
                $scope.isShowLast_4 = false;
            }
            else if (currentPage < totalPage) {
                $scope.isShowForwardOne_4 = true;
                $scope.isShowLast_4 = true;
            }

            $scope.FirstPage_4 = 1;
            $scope.LastPage_4 = totalPage;
            if (totalPage != currentPage) {
                $scope.ForwardOne_4 = currentPage + 1;
            }
            if (currentPage != 1) {
                $scope.BackwardOne_4 = currentPage - 1;
            }

            if (totalPage == currentPage) {
                $scope.showForwardBtn_4 = false;
            }

        };
    };

    this.setPaggingTemplate_5 = function ($scope) {
        $scope.PaggingTemplate_5 = function (totalPage, currentPage, pageSize) {
            $scope.showForwardBtn_5 = true;
            $scope.TotalPages_5 = totalPage;
            $scope.CurrentPage_5 = currentPage;
            $scope.PageSize_5 = pageSize;
            $scope.PageNumberArray_5 = Array();

            for (var i = 0; i < totalPage; i++) {
                $scope.PageNumberArray_5[i] = i + 1;
            };

            if (currentPage >= 1 && currentPage < 5)
                $scope.PageNumberArray_5 = $scope.PageNumberArray_5.slice(0, 5);
            else
                $scope.PageNumberArray_5 = $scope.PageNumberArray_5.slice(currentPage - 4, currentPage + 4);

            if (currentPage == 1) {
                $scope.isShowBackwardOne_5 = false;
                $scope.isShowFirst_5 = false;
            }
            else if (currentPage > 1) {
                $scope.isShowBackwardOne_5 = true;
                $scope.isShowFirst_5 = true;
            }
            if (currentPage == totalPage) {
                $scope.isShowForwardOne_5 = false;
                $scope.isShowLast_5 = false;
            }
            else if (currentPage < totalPage) {
                $scope.isShowForwardOne_5 = true;
                $scope.isShowLast_5 = true;
            }

            $scope.FirstPage_5 = 1;
            $scope.LastPage_5 = totalPage;
            if (totalPage != currentPage) {
                $scope.ForwardOne_5 = currentPage + 1;
            }
            if (currentPage != 1) {
                $scope.BackwardOne_5 = currentPage - 1;
            }

            if (totalPage == currentPage) {
                $scope.showForwardBtn_5 = false;
            }

        };
    };

});