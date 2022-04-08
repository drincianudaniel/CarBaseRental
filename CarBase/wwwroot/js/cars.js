const userCardTemplate = document.querySelector("[data-user-template]");
const userCardContainer = document.querySelector("[data-user-cards-container]");
let cars = []

function getVal() {
    const val = document.querySelector("input").value;
    return val;
}

function search() {
    const value = getVal().toLowerCase();
    cars.forEach(car => {
        const isVisible =
            car.make.toLowerCase().includes(value) ||
            car.model.toLowerCase().includes(value)
        car.element.classList.toggle("hide", !isVisible)
    })
}

fetch("../resources/cars/cars.json")
    .then(res => res.json())
    .then(data => {
        cars = data.map(car => {
            const card = userCardTemplate.content.cloneNode(true).children[0]

            const make = card.querySelector("[data-make]")
            const model = card.querySelector("[data-model]")
            const image = card.querySelector("[data-image]")

            make.textContent = car.make
            model.textContent = car.model
            image.src = car.img_url

            userCardContainer.append(card)

            return { make: car.make, model: car.model, img_url: car.img_url, element: card }
        })
    })

