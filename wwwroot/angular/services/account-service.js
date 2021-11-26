app.service("accountService", function ($http) {

    this.authorize = function (user) {
        return $http({
            url: "/Login/Authorize",
            method: "POST",
            data: { users: user }
        });
    };

    this.logout = function () {
        return $http({
            url: "/Account/LogOut",
            method: "POST"
        });
    };
});