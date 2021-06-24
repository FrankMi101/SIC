let timer;
let deleteFirstPhotoDelay;
async function GetApiData() {
    var apiUrl = "https://dog.ceo/api/breeds/list/all";
    const response = await fetch(apiUrl);
    const data = await response.json();
    generateList(data.message);
}

GetApiData();

function generateList(listData) {

    var objList = document.getElementById("breed");
    // var listArray = Object.keys(listData);
    objList.innerHTML = `
        <select onchange="loadByBreed(this.value)">
            <option>Choose a dog breed</option>
            ${ Object.keys(listData).map(function (breed) {
        return `<option>${breed}</option>`
    }).join('')}
        </select>`;
}

async function loadByBreed(breed) {
    var apiUrl = "https://dog.ceo/api/breed/" + breed + "/images";

    if (breed != "Chose a dog breed") {
        const response = await fetch(apiUrl);
        const data = await response.json();
        slideShow(data.message);
    }

}

function slideShow(images) {
    let cPosition = 0;
    clearInterval(timer);
    clearTimeout(deleteFirstPhotoDelay);
    var objSlide = document.getElementById("slideshow");

    if (images.length > 1) {
        objSlide.innerHTML = `
        <div class="slide" style="background-image: url('${images[0]}')" > </div>
        <div class="slide" style="background-image: url('${images[1]}')" > </div>` 
        cPosition += 2;
        if (images.length == 2) cPosition = 0;
        timer = setInterval(nextSlide, 3000);
    } else {
        objSlide.innerHTML = `
        <div class="slide" style="background-image: url('${images[0]}')" > </div>
        <div class="slide" > </div>`
    }

    function nextSlide() {
        document.getElementById("slideshow").insertAdjacentHTML("beforeend", `<div class="slide" style="background-image: url('${images[cPosition]}')" > </div>`)
        setTimeout(function () { document.querySelector(".slide").remove() }, 1000);
        if (cPosition + 1 >= images.length) {
            cPosition = 0;
        }
        else {
            cPosition++;
        }
    }
}