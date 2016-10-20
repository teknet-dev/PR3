//Search box events.

function doSearch()
{
    document.getElementById("TxtSearch").onchange();
    document.getElementById("TxtSearch").focus();
}

function SetCursorToTextEnd(textControlID) {
    var text = document.getElementById(textControlID);
    if (text != null && text.value.length > 0) {
        if (text.createTextRange) {
            var range = text.createTextRange();
            range.moveStart('character', text.value.length);
            range.collapse();
            range.select();
        }
        else if (text.setSelectionRange) {
            var textLength = text.value.length;
            text.setSelectionRange(textLength, textLength);
        }
    }
}