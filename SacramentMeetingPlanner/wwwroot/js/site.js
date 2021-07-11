// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const PrintElem = (elem) => {
    var mywindow = window.open('', 'PRINT', 'height=400,width=600');

    mywindow.document.write('<html>');
    mywindow.document.write('<body >');
    mywindow.document.write('<h1>' + document.title + '</h1>');
    mywindow.document.write(document.querySelector(elem).innerHTML);
    mywindow.document.write('</body></html>');

    mywindow.document.close(); // necessary for IE >= 10
    mywindow.focus(); // necessary for IE >= 10*/

    mywindow.print();
    mywindow.close();

    return true;
}