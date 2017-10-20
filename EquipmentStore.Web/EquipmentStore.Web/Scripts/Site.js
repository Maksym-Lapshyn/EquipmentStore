$(document).ready(function () {
    var url = window.location;

    // Marks equipment dropdown as active
    if (url.toString().includes('products/category'))
    {
        $('.equipment-dropdown').addClass('active');
        return;
    }

    // Will only work if string in href matches with location
    $('ul.nav a[href="' + url + '"]').parent().addClass('active');

    // Will also work for relative and absolute hrefs
    $('ul.nav a').filter(function () {
        return this.href == url;
    }).parent().addClass('active').parent().parent().addClass('active');
});