
function DeleteUser(userId) {
    $.get("/Admin/Users/Delete/" + userId).done(function (res) {
        if (res.status === "Done") {
            location.reload();
        } else {
            alert(res.status);
        }
    });

};

function ReturnUser(userId) {
    $.get("/Admin/Users/Return/" + userId).done(function (res) {
        if (res.status === "Done") {
            location.reload();
        } else {
            alert(res.status);
        }
    });
};