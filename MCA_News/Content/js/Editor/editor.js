$(document).ready(function () {
    $.post('Dist', function (data) {
        d = JSON.parse(data);
        d.Table.map((dist) => {
            $('#District').append(` <option value="${dist.DistrictId}">${dist.District}</option>`);
        })
    });

});

const add = () => {

    let distictid = $('#District').val();
    let taluka = $('#Taluka').val();

    $.ajax({
        type: 'GET',
        url: "AddNewTaluka", cache: false,
        data: { Dist_ID: distictid, taluka: taluka },
        success: (a) => {
            Count_batch();
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
    if (c == 'AddTaluka') { Count_batch(); }


}
const Count_batch = () => {
    debugger;
    let finaldata;
    //let TalukaId = document.getElementById('TalukaId');
    let batch = document.getElementById('batch');
    $.post('NEWID', function (data) {
        finaldata = JSON.parse(data);
        finaldata = finaldata.Table[0];
        batch.setAttribute("data-count", finaldata.count)
        /*TalukaId.value = finaldata.id*/

    });
}