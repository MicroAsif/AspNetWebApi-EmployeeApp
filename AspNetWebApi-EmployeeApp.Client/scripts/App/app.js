var baseUrl = "http://localhost:13968/api";

$(document).ready(function () {
    loadDepertment();

    loadEmployee();
});

function loadDepertment() {
    $.ajax({
        url: baseUrl + "/Deparment",
        type: "GET",
        success: function (data) {
            $.each(data, function (i, v) {
                $("#DeptTable tbody").append("<tr> <td>" + v.Id + "</td> <td>" +v.Name + "</td> <td> </td></tr>");
            })
        }
    })
}



function loadEmployee() {
    $.ajax({
        url: baseUrl + "/Employee",
        type: "GET",
        success: function (data) {
            $.each(data, function (i, v) {
                $("#EmpTable tbody").append("<tr> <td>" + v.Name + "</td> <td>" + v.Email + "</td> <td>" + v.Sallary + "</td> <td>" + v.Designation + "</td> </tr>");
            })
        }
    })
}
