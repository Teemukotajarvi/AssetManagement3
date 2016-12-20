/// <reference path="../typings/jquery/jquery.d.ts" />

 class AssignLocatioModel {
    public AssetCode: string;

    public LocationCode: string;

    }





function initAssetAssignment() {
    $("#AssignAssetButton").click(function () {
        var locationCode: string = $("#LocationCode").val();
        var assetCode: string = $("#AssetCode").val();
        alert("L: " + locationCode + ", A: " + assetCode);
        var data: AssignLocatioModel = new AssignLocatioModel();
        data.LocationCode = locationCode;
        data.AssetCode = assetCode;

        // lähetetään JSON-muotoista dataa palvelimelle.
        $.ajax({
            type: "POST",
            url: "/Asset/AssignLocation",
            data: JSON.stringify(data),
            contentType: "application/json",
            success: function (data) {

                if (data.success == true) {
                    alert("Asset successfully assigned.");
                    $(".result").html(data);
                }
                else {
                    alert("There was an error: " + data.error);
                }
            },
            dataType: "json"
        });
    });
}