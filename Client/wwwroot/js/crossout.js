function crossOutXX() {
    divs = document.getElementsByName("True");
    for (i = 0; i < divs.length; i++) {
        divs[i].style.background = "red";
    }
}

//function crossOut() {
//    divs = document.getElementsByName("True");
//    for (i = 0; i < divs.length; i++) {
//        divs[i].style.setProperty("text-decoration", "line-through");
//    }

function crossOut() {
    element = document.getElementsByName("True");
    element.style.setProperty("text-decoration", "line-through");
}

//var ele = document.getElementById("myelement");
//ele.style.setProperty("text-decoration", "line-through");
