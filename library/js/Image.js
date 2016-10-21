var currFFZoom = 1;

var currIEZoom = 100;

$(function () {
    $("#cropimg").draggable();
    $("#imgUpload").Jcrop({
        onSelect: croparea
    });
});

function croparea(c) {
    $("#X").val(c.x);
    $("#Y").val(c.y);
    $("#W").val(c.w);
    $("#H").val(c.h);
}

function plus() {
    //alert('sad');
    var step = 0.2;
    currFFZoom += step;
    $("#cropimg").css('MozTransform', 'scale(' + currFFZoom + ')');
    var stepie = 2;
    currIEZoom += stepie;
    $("#cropimg").css('zoom', ' ' + currIEZoom + '%');

};

function minus() {
    //alert('sad');
    var step = 0.2;
    currFFZoom -= step;
    $("#cropimg").css('MozTransform', 'scale(' + currFFZoom + ')');
    var stepie = 2;
    currIEZoom -= stepie;
    $("#cropimg").css('zoom', ' ' + currIEZoom + '%');
};