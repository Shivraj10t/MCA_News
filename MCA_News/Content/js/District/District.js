
let DistrictList = [];
function add() {
    let Id = document.getElementById('DistrictId').value;
    let District = document.getElementById('District').value;
    //$.getJSON('/District/AddNewDistrict/', function (data) {
    //    alert(data);
    //});

    $.ajax({
        url: 'AddNewDistrict',
        type: 'GET',
        cache: false,
        data: { District },
        success: function (data) { 
            pageload()

    },
    error: function (data) {   
    }
});
return true;
}

const LinkButton = () => {
    const href = document.getElementById('link').getAttribute('data-href');
    window.location.href = href;
}
document.addEventListener('DOMContentLoaded', pageload, false)

 function  pageload()  {
   
    debugger;
    const c = (window.location.pathname).split('/')[2];
    if (c == 'AddDistrict') { Distict.addNew(); } else { Distict.list();  }
       

 }
 const Distict = {
     addNew: function () {
         debugger;
         let finaldata;
         let d_ID = document.getElementById('DistrictId');
         let batch = document.getElementById('batch');        
             $.post('NEWID', function (data) {
                 finaldata = JSON.parse(data);
                 finaldata = finaldata.Table[0];                  
                 batch.setAttribute("data-count", finaldata.count)
                 d_ID.value = finaldata.id

             });
     },
     list: function () {
         debugger
         let d;
             let tbody = document.querySelector('#tbody');
         $.post('Listing', function (data) {
             d = JSON.parse(data);
             DistrictList = d.Table;
         
             
            var aaaa = '';
             if (DistrictList != null && DistrictList.length > 0) {
                 DistrictList.map((e) => {
              aaaa+= `<tr> <td>${e.DistrictId}</td> <td>${e.District}</td> <td class="d-I-Flex"><div class="edit" onclick="edit(this)" id="edit_${e.DistrictId}"><span class="fa fa fa-edit"></span>EDIT</div> <div class="delete"  onclick="delete_data(this)" id="delete_${e.DistrictId}">DELETE</div></td></tr>` 
                 })
                 $('#tbody').append(aaaa)
             }
          });
     },
     EDIT: function () {

     }

 }

 
 function delete_data(obj) {
    debugger
     let id = obj.getAttribute('id');
     id = id.split('_');
     $.post('Delete', { Id: id[1] }, function (data) {
         
     });
     $('#tbody').empty();
     setTimeout(() => { Distict.list(); }, 600)
    // Distict.list();
 }
    //$.ajax({
    //    url: '@Url.Action("District","AddNewDistrict")',
    //    data: { District: District },
    //    success: function (data) {
    //        //call is successfully completed and we got result in data
    //        alert(data);
    //    },
    //    error: function (xhr, ajaxOptions, thrownError) {
    //        //some errror, some show err msg to user and log the error  
    //        alert(xhr.responseText);

    //    }
    //});

//$.post('@Url.Action("Add","Cart")',{id:id } function(data) {
//    //do whatever with the result.
//});