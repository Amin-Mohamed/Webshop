const productCard = document.querySelector('.product-card');
const addToCartButton = document.getElementsByClassName('add-to-cart');
console.log(addToCartButton)

fetch('https://localhost:5001/api/product')
    .then(response => response.json())
    .then(json => {
        const data = json;
        console.log(data);
        data.forEach(item => {
            productCard.innerHTML +=  `
            <div class="title"> ${item['title']} </div>
            <div class="price"> ${item['price']} </div>
            <button class="add-to-cart" type="button" name="button"><i class="fas fa-cart-plus"></i></button>
            <div class="description"> ${item['description']} </div>
            <hr></hr>
            `
        });
        addToCartButton.addEventListener('click', function() {
            console.log(data.id)
        });
    });
