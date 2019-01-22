var loading = false;

function beginLoading() {

    loading = true;

    $("#modal-loading").modal({
        backdrop: "static",
        keyboard: false,
        show: true //Display loader!
    });
}

function endLoading() {

    if (loading) {

        setTimeout(function () {
            $("#modal-loading").modal("hide");
        }, 1000);

        loading = false;
    }

}

function noReload(e) {

    e.preventDefault();
    e.stopPropagation();
}