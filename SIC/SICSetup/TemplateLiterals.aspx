<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TemplateLiterals.aspx.cs" Inherits="SIC.SICSetup.Template_Javascript" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            font-family: sans-serif;
            background-color: #dedede;
            color: #333;
            padding: 20px 0 28px 0;
            margin: 0;
        }

        img {
            max-width: 100%;
            height: auto;
        }

        .app-title {
            text-align: center;
            font-weight: normal;
            font-size: 2.6rem;
        }

        .animal {
            max-width: 650px;
            padding: 20px;
            margin: 30px auto;
            background-color: #fff;
            box-shadow: 3px 3px 3px rgba(0, 0, 0, 0.1);
            overflow: hidden;
        }

            .animal h4 {
                margin: 0 0 6px 0;
            }

        .pet-photo {
            float: left;
            width: 40%;
            margin-right: 15px;
        }

        .pet-name {
            font-size: 2rem;
            font-weight: normal;
            margin: 0 0 1rem 0;
        }

        .species {
            font-size: 0.9rem;
            color: #888;
            vertical-align: middle;
        }

        .foods-list {
            margin: 0;
            padding: 0;
            position: relative;
            left: 17px;
            font-size: 0.85rem;
            line-height: 1.5;
        }

        .footer {
            font-size: 0.7rem;
            color: #888;
            text-align: center;
            margin: 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="app">

            </div>
        </div>
    </form>
</body>
</html>

<script>
    // this page come from LearnWebCode YouTube 
    const petsData = [
        {
            name: "Purrsloud",
            species: "Cat",
            favFoods: ["wet food", "dry food", "<strong>any</strong> food"],
            birthYear: 2016,
            photo: "https://learnwebcode.github.io/json-example/images/cat-2.jpg"
        },
        {
            name: "Barksalot",
            species: "Dog",
            birthYear: 2008,
            photo: "https://learnwebcode.github.io/json-example/images/dog-1.jpg"
        },
        {
            name: "Meowsalot",
            species: "Cat",
            favFoods: ["tuna", "catnip", "celery"],
            birthYear: 2012,
            photo: "https://learnwebcode.github.io/json-example/images/cat-1.jpg"
        }
    ];

    function age(birthYear) {
        let calculatedAge = new Date().getFullYear() - birthYear;
        if (calculatedAge == 1) {
            return "1 year old";
        } else if (calculatedAge == 0) {
            return "Baby";
        } else {
            return `${calculatedAge} years old`;
        }
    }

    function foods(foods) {
        return `
            <h4>Favorite Foods</h4>
            <ul class="foods-list"> ${foods.map(food => `<li>${food}</li>`).join("")}</ul>
            `;
    }
    function foods_old(foods) {
        return `
            <h4>Favorite Foods</h4>
            <ul class="foods-list">
            ${foods.map(function (food) {
                 return `<li>${food}</li>`
            }).join("")}
            </ul>
            `;
    }
    function petTemplate(pet) {
        return `
                <div class="animal">
                <img class="pet-photo" src="${pet.photo}">
                <h2 class="pet-name">${pet.name} <span class="species">(${pet.species})</span></h2>
                <p><strong>Age:</strong> ${age(pet.birthYear)}</p>
                ${pet.favFoods ? foods(pet.favFoods) : ""}
                </div>
             `;
    }

    document.getElementById("app").innerHTML = `
          <h1 class="app-title">Pets (${petsData.length} results)</h1>
          ${petsData.map(petTemplate).join("")}
          <p class="footer">These ${petsData.length} pets were added recently. Check back soon for updates.</p>
        `;

</script>
