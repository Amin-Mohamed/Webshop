const productCard = document.querySelector('.product-card');

fetch('https://localhost:5001/api/product')
    .then(response => response.json())
    .then(json => {
        const data = json;
        console.log(data);

        data.forEach(item => {
            productCard.innerHTML +=  `
            <div class="title"> ${item['name']} </div>
            <div class="price"> ${item['price']} </div>
            <i class="fas fa-cart-plus"></i>
            <div class="description"> ${item['description']} </div>
            <hr></hr>
            `
        });
    });
