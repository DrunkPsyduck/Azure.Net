let url = "https://apidepartamentosmc.azurewebsites.net/";


function getTablaDepartamentosAsync(callback) {
    let request = 'api/departamento/';
    $.ajax({
        url: url + request,
        type: "GET",
        success: function (data) {
            let html = "";
            $.each(data, function (ind, dept) {
                html += "<tr>";
                html += "<td>" + dept.idDepartamento + "</td>";
                html += "<td>" + dept.nombre + "</td>";
                html += "<td>" + dept.localidad + "</td>";
                html += "</tr>";
            })
            callback(html);
        }
    })
}

function convertirDeptJson(id, nombre, localidad) {
    let departamento = new Object();
    departamento.idDepartamento = id;
    departamento.nombre = nombre;
    departamento.localidad = localidad;
    let json = JSON.stringify(departamento);
    return json;
}

function eliminarDepartamentoAsync(id, callback) {
    let request = "api/departamento/" + id;
    $.ajax({
        url: urlapi + request,
        type: "DELETE",
        success: function () {
            callback();
        }
    });
}

function insertarDepartamentoAsync(json, callback) {
    let request = "api/departamento"
    $.ajax({
        url: urlapi + request,
        type: "POST",
        data: json,
        contentType: "application/json",
        success: function () {
            callback();
        }
    })
}

function modificarDepartamentoAsync(json, callback) {
    let request = "api/departamento"
    $.ajax({
        url: urlapi + request,
        type: "PUT",
        data: json,
        contentType: "application/json",
        success: function () {
            callback();
        }
    })
}