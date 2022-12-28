
const add = () => {
    let ReportType = $('#ReportType').val();


    $.ajax({
        type: 'GET',
        url: "AddNewReportType", cache: false,
        data: { ReportingType: ReportType },
        success: (a) => {
            Count_batch(); LinkButton();
        }
        , error: (e) => {
            console.log(e);
        }
    })


}

async function delete_data(obj) {
    debugger
    let id = obj.getAttribute('id');
    id = id.split('_');
    await $.post('Delete', { Id: id[1] }, function (data) {

    });

    location.reload();
}
const LinkButton = () => {
    const href = document.getElementById('link').getAttribute('data-href');
    window.location.href = href;
}

document.addEventListener('DOMContentLoaded', pageload, false)

function pageload() {

    debugger;
    const c = (window.location.pathname).split('/')[2];
    if (c == 'AddReportType') { Count_batch(); }


}
const Count_batch = () => {
    debugger;
    let finaldata;
    let batch = document.getElementById('batch');
    $.post('NEWID', function (data) {
        finaldata = JSON.parse(data);
        finaldata = finaldata.Table[0];
        batch.setAttribute("data-count", finaldata.count)

    });
}

//const edit_data = (obj) => {

//    let id = obj.getAttribute('id');
//    id = id.split('_')[1];

//    $.ajax({
//        type: 'GET',
//        url: "Edit", cache: false,
//        data: { id: id },
//        success: (a) => {
//            Count_batch(); LinkButton();
//        }
//        , error: (e) => {
//            console.log(e);
//        }
//    })

//}