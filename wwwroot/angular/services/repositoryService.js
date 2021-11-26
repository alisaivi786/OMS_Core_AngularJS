
app.service("repositoryService", function ($http) {

    this.get =(controller, action) => {
        return $http({
            url: "/" + controller + "/" + action,
            method: "POST"
        });
    };

    this.getAll = function(params,controller, action) {
        return $http({
            url: "/" + controller + "/" + action,
            method: "POST",
            data: { param: params }
        });
    };

    //this.getAll = (params, controller, action, filters)=> {
    //    return $http({
    //        url: "/" + controller + "/" + action,
    //        method: "POST",
    //        data: { param: params, filters: filters }
    //    });
    //};

    this.add  = function(params, controller, action) {
       
        return $http({
            url: "/" + controller + "/" + action,
            method: "POST",
            data: { param: params }
        });
    }

    this.getById =(id, controller, action) =>{
        return $http({
            url: "/" + controller + "/" + action,
            method: "POST",
            data: { Id: id }
        });
    }

    this.update = (params, controller, action)=> {
        return $http({
            url: "/" + controller + "/" + action,
            method: "POST",
            data: { param: params }
        });
    }

    this.delete = (id, controller, action) =>{
        return $http({
            url: "/" + controller + "/" + action,
            method: "POST",
            data: { Id: id }
        });
    }

    this.getByIds = (param, param2, controller, action)=> {
        return $http({
            url: "/" + controller + "/" + action,
            method: "POST",
            data: { param: param, param2: param2 }
        });
    }
});
