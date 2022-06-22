function WarningAlert(message, Title) {
    $("#alertContainer").append('<div class="alert bg-light-warning alert-dismissible mb-2" role="alert"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true"><i class="ft-x font-medium-2 text-bold-700"></i></span></button><h4 class="alert-heading mb-2">' + Title + '</h4><p class="mb-0">' + message + '</p></div>')
};
function infoAlert(message, Title) {
    $("#alertContainer").append('<div class="alert bg-light-info alert-dismissible mb-2" role="alert"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true"><i class="ft-x font-medium-2 text-bold-700"></i></span></button><h4 class="alert-heading mb-2">' + Title + '</h4><p class="mb-0">' + message + '</p></div>')
};
function dangerAlert(message, Title) {
    $("#alertContainer").append('<div class="alert bg-light-danger alert-dismissible mb-2" role="alert"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true"><i class="ft-x font-medium-2 text-bold-700"></i></span></button><h4 class="alert-heading mb-2">' + Title + '</h4><p class="mb-0">' + message + '</p></div>')
};
function successAlert(message, Title) {
    $("#alertContainer").append('<div class="alert bg-light-success alert-dismissible mb-2" role="alert"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true"><i class="ft-x font-medium-2 text-bold-700"></i></span></button><h4 class="alert-heading mb-2">' + Title + '</h4><p class="mb-0">' + message + '</p></div>')
};
function PrimaryAlert(message, Title) {
    $("#alertContainer").append('<div class="alert bg-light-warning alert-dismissible mb-2" role="alert"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true"><i class="ft-x font-medium-2 text-bold-700"></i></span></button><h4 class="alert-heading mb-2">' + Title + '</h4><p class="mb-0">' + message + '</p></div>')
};