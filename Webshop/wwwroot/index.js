const productCard = document.querySelector('.product-card');
const productName = document.querySelector('.title');
const price = document.querySelector('.price');
const description = document.querySelector('.description');

fetch('https://localhost:5001/api/product')
    .then(response => response.json())
    .then(json => {
        const data = json;
        console.log(data);
        data.forEach(item => {
            // productName.innerHTML += `<p> ${item['name']} </p>`;
            // price.innerHTML += `<p> ${item['price']} </p>`;
            // description.innerHTML += `<p> ${item['description']} </p>`;
            // console.log(productName);
            // console.log(price);
            // console.log(description);

            productCard.innerHTML +=  `
            <div class="title"> ${item['name']} </div>
            <div class="price"> ${item['price']} </div>
            <i class="fas fa-cart-plus"></i>
            <div class="description"> ${item['description']} </div>
            <hr></hr>
            `

        });
    });
