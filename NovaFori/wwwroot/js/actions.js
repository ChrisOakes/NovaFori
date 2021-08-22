


function toggleButton(i) {
    if (i == "" || i == null) {
        $('#addButton').prop('disabled', true);
    } else {
        $('#addButton').prop('disabled', false);
    }
}


function addItem() {
    const newItem = $('#newItem').val();

    $.ajax({
        type: 'post',
        url: '?handler=AddNewListItem&description=' + newItem,
        data: {
            existing_list: list_of_items
        },
        success: function (response) {
            list_of_items = response;

            drawTables(response);

            $('#newItem').val('');

            
        }
    })
};

function updateTask(i) {
    $.ajax({
        type: 'post',
        url: '?handler=ToggleListItem&itemIndex=' + i,
        data: {
            existing_list: list_of_items
        },
        success: function (response) {

            list_of_items = response;
            drawTables(response);
        }
    })
}

function drawTables(response) {
    console.log(response);
    var pending = "";
    var complete = "";

    pending += "<table class='table table-bordered'>";
    complete += "<table class='table table-bordered'>";

    pending += "<thead>";
    pending += "<tr>";
    pending += "<th>Description</th>";
    pending += "<th>Created</th>";
    pending += "<th>Updated</th>";
    pending += "<th>Mark Complete</th>";
    pending += "</tr>";
    pending += "</thead>";

    complete += "<thead>";
    complete += "<tr>";
    complete += "<th>Description</th>";
    complete += "<th>Created</th>";
    complete += "<th>Updated</th>";
    complete += "<th>Mark Complete</th>";
    complete += "</tr>";
    complete += "</thead>";

    for (var i = 0; i < response.length; i++) {
        if (response[i].complete == true) {
            complete += "<tr>";
            complete += "<td>" + response[i].description + "</td>";
            complete += "<td>" + formatDate(response[i].created) + "</td>";
            complete += "<td>" + formatDate(response[i].updated) + "</td>";
            complete += "<td style='text-align:center; vertical-align:middle;'><input type='checkbox' onchange='updateTask(" + i + ")' checked value='" + response[i].complete + "'/></td>";
            complete += "</tr>";
        } else {
            pending += "<tr>";
            pending += "<td>" + response[i].description + "</td>";
            pending += "<td>" + formatDate(response[i].created) + "</td>";
            pending += "<td>" + formatDate(response[i].updated) + "</td>";
            pending += "<td style='text-align:center; vertical-align:middle;'><input type='checkbox' onchange='updateTask(" + i + ")' value='" + response[i].complete + "'/></td>";
            pending += "</tr>";
        }

    }


    pending += "</table>";
    complete += "</table>";


    $('#complete').empty();
    $('#pending').empty();


    $('#pending').append(pending);
    $('#complete').append(complete);
}

function formatDate(i) {
    var date = new Date(i);

    var day = date.getDate();
    var month = (date.getMonth() + 1);
    var year = date.getFullYear();

    var hour = date.getHours();
    var minute = date.getMinutes();

    var time = day + "/" + month + "/" + year + " " + hour + ":" + minute;

    return time;
}
