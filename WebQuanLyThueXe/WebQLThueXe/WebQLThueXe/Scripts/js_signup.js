function validateForm() {
    var x = document.forms["SignUpForm"]["fsdt"].value;
    if (x == "") {
        alert("Sdt must be filled out");
        return false;
    }
}