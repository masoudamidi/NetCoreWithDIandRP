// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function GetLocations() {
  var url = "/Search/GetLocations";
  var latitude = $("#Lat").val();
  var longitude = $("#Long").val();
  var maxDistance = $("#maxdistance").val();
  var maxResults = $("#maxresults").val();
  $.ajax({
    type: "POST",
    url: url,
    data: {
        latitude: latitude,
        longitude: longitude,
        maxDistance: maxDistance,
        maxResults: maxResults,
    },
    success: function(res) {
        $("#resultdiv").empty().append(res);
        $(document).ready(function() {
            $('#resulttable').DataTable({
              "order": [[ 1, "asc" ]]
          } );
        });
    },
    //dataType: dataType,
  });
}
