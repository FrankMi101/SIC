//Object
var myCart = {
    "name": "Meowsalate",
    "species": "cat",
    "favFood": "true"
}
var FavCartName = myCart.name;
// Array
var myFavColours = ["blue", "green", "purple"];
var myColour = myFavColours[1];

var thePets = [
    {
        "name": "Meowsy",
        "species": "cat",
        "foods": {
            "likes": ["tuna", "catnip"],
            "dislikes": ["ham", "zucchini"]
        }
    },
    {
        "name": "Barky",
        "species": "dog",
        "foods": {
            "likes": ["bones", "carrots"],
            "dislikes": ["tuna"]
        }
    },
    {
        "name": "Purrpaws",
        "species": "cat",
        "foods": {
            "likes": ["mice"],
            "dislikes": ["cookies"]
        }
    }
]

var secondaryFav = thePets[1].favFood

const url = "https://learnwebcode.github.io/json-example/animals-"; // "-1.json"
var pageCounter = 1;
var divContainer = document.getElementById("animal-info");
var btn = document.getElementById("btn");

btn.addEventListener("click", function () {

    const xmlRequest = new XMLHttpRequest();
    var goUrl = url + pageCounter + ".json";
    xmlRequest.open('Get', goUrl);
    xmlRequest.onload = function () {
        if (xmlRequest.status >= 200 && xmlRequest.status < 400) {
            var jsonData = JSON.parse(xmlRequest.responseText);
            var firstData = jsonData[0];
            var firstFav = jsonData[0].FavCartName;
            renderHTML(jsonData);
        }
        else {
            //do error handling
            console.log("handle error");
        }
    };
    xmlRequest.onerror = functino() {
        // do some thing
        console.log("Some thing going error");
    }
    xmlRequest.send();
    pageCounter++;
    if (pageCounter > 3) {
        btn.classList.add("hide-me");
    }

});

function renderHTML(data) {
    var htmlStr = "";
    for (i = 0; i < data.length; i++) {
        htmlStr += "<p>" + data[i].name + " is a " + data[i].species + " that likes ";
        for (j = 0; j < data[i].foods.likes.length; j++) {
            if (j == 0) {
                htmlStr += data[i].foods.likes[j]; }
            else {
                htmlStr += " and " +  data[i].foods.likes[j];
            }
        }

        htmlStr += ' and dislikes ';
        for (j = 0; j < data[i].foods.dislikes.length; j++) {
            if (j == 0) {
                htmlStr += data[i].foods.dislikes[j];
            }
            else {
                htmlStr += " and " + data[i].foods.dislikes[j];
            }
        }

        htmlStr +=   + ".</p>";
    }

    divContainer.insertAdjacentHTML('beforeend', htmlStr)
}



